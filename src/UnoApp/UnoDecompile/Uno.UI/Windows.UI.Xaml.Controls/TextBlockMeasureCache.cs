using System;
using System.Collections.Generic;
using System.Diagnostics;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

[DebuggerDisplay("\"{_text}\"")]
internal class TextBlockMeasureCache
{
	private class MeasureEntry
	{
		private readonly Dictionary<CachedTuple<double, double>, MeasureSizeEntry> _sizes = new Dictionary<CachedTuple<double, double>, MeasureSizeEntry>();

		private readonly LinkedList<CachedTuple<double, double>> _queue = new LinkedList<CachedTuple<double, double>>();

		public LinkedListNode<MeasureKey> ListNode { get; }

		public MeasureEntry(LinkedListNode<MeasureKey> node)
		{
			ListNode = node;
		}

		public Size? FindMeasuredSize(MeasureKey key, Size availableSize)
		{
			double width = availableSize.Width;
			double height = availableSize.Height;
			if (_sizes.TryGetValue(CachedTuple.Create(width, height), out var value))
			{
				return value.MeasuredSize;
			}
			bool isWrapping = key.IsWrapping;
			bool isClipping = key.IsClipping;
			foreach (KeyValuePair<CachedTuple<double, double>, MeasureSizeEntry> size in _sizes)
			{
				CachedTuple<double, double> key2 = size.Key;
				MeasureSizeEntry value2 = size.Value;
				double width2 = value2.MeasuredSize.Width;
				double height2 = value2.MeasuredSize.Height;
				double item = key2.Item1;
				double item2 = key2.Item2;
				if (isWrapping || isClipping)
				{
					if (!(width2 <= width) || !(width <= item))
					{
						continue;
					}
				}
				else if (!double.IsInfinity(item) && Math.Abs(width2 - item) <= 0.5 && !(Math.Abs(width2 - width) <= 0.5))
				{
					continue;
				}
				if (double.IsInfinity(item2) || !(Math.Abs(height2 - item2) <= 0.5) || height2 >= height)
				{
					MoveToLast(key2, value2);
					return value2.MeasuredSize;
				}
			}
			return null;
		}

		private void MoveToLast(CachedTuple<double, double> key, MeasureSizeEntry value)
		{
			if (_queue.Count != 0 && !object.Equals(_queue.Last!.Value, key))
			{
				_queue.Remove(value.ListNode);
				_queue.AddLast(value.ListNode);
			}
		}

		internal void CacheMeasure(Size desiredSize, Size measuredSize)
		{
			Scavenge();
			CachedTuple<double, double> cachedTuple = CachedTuple.Create(desiredSize.Width, desiredSize.Height);
			LinkedListNode<CachedTuple<double, double>> node = _queue.AddLast(cachedTuple);
			_sizes[cachedTuple] = new MeasureSizeEntry(measuredSize, node);
		}

		private void Scavenge()
		{
			if (_queue.Count >= MaxMeasureSizeKeyEntries)
			{
				_sizes.Remove(_queue.First!.Value);
				_queue.RemoveFirst();
			}
		}
	}

	private class MeasureKey
	{
		public class Comparer : IEqualityComparer<MeasureKey>
		{
			public static Comparer Instance { get; } = new Comparer();


			public bool Equals(MeasureKey x, MeasureKey y)
			{
				return x._text == y._text && Math.Abs(x._fontSize - y._fontSize) < 1E-09 && x._fontFamily == y._fontFamily && x._fontStyle == y._fontStyle && x._textWrapping == y._textWrapping && x._fontWeight == y._fontWeight && x._maxLines == y._maxLines && x._textTrimming == y._textTrimming && x._textAlignment == y._textAlignment && Math.Abs(x._lineHeight - y._lineHeight) < 1E-09 && x._padding == y._padding && x._lineStackingStrategy == y._lineStackingStrategy && x._textDecorations == y._textDecorations && x._characterSpacing == y._characterSpacing;
			}

			public int GetHashCode(MeasureKey obj)
			{
				return obj._hashCode;
			}
		}

		private readonly int _hashCode;

		private readonly FontStyle _fontStyle;

		private readonly TextWrapping _textWrapping;

		private readonly FontWeight _fontWeight;

		private readonly string _text;

		private readonly FontFamily _fontFamily;

		private readonly double _fontSize;

		private readonly int _maxLines;

		private readonly TextTrimming _textTrimming;

		private readonly TextAlignment _textAlignment;

		private readonly double _lineHeight;

		private readonly Thickness _padding;

		private readonly LineStackingStrategy _lineStackingStrategy;

		private readonly int _characterSpacing;

		private readonly TextDecorations _textDecorations;

		internal bool IsWrapping => _textWrapping != TextWrapping.NoWrap;

		internal bool IsClipping => _textTrimming != TextTrimming.None;

		public MeasureKey(TextBlock source)
		{
			_fontStyle = source.FontStyle;
			_textWrapping = source.TextWrapping;
			_fontWeight = source.FontWeight;
			_text = source.Text;
			_fontFamily = source.FontFamily;
			_fontSize = source.FontSize;
			_maxLines = source.MaxLines;
			_textTrimming = source.TextTrimming;
			_textAlignment = source.TextAlignment;
			_lineHeight = source.LineHeight;
			_padding = source.Padding;
			_lineStackingStrategy = source.LineStackingStrategy;
			_characterSpacing = source.CharacterSpacing;
			_textDecorations = source.TextDecorations;
			_hashCode = _text?.GetHashCode() ?? (0 ^ _fontFamily.GetHashCode() ^ _fontSize.GetHashCode());
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override bool Equals(object obj)
		{
			if (obj is MeasureKey y)
			{
				return Comparer.Instance.Equals(this, y);
			}
			return false;
		}
	}

	private class MeasureSizeEntry
	{
		public Size MeasuredSize { get; }

		public LinkedListNode<CachedTuple<double, double>> ListNode { get; }

		public MeasureSizeEntry(Size measuredSize, LinkedListNode<CachedTuple<double, double>> node)
		{
			MeasuredSize = measuredSize;
			ListNode = node;
		}
	}

	private static Stopwatch _timer = Stopwatch.StartNew();

	private readonly Dictionary<MeasureKey, MeasureEntry> _entries = new Dictionary<MeasureKey, MeasureEntry>(new MeasureKey.Comparer());

	private readonly LinkedList<MeasureKey> _queue = new LinkedList<MeasureKey>();

	internal static int MaxMeasureKeyEntries { get; set; } = 500;


	internal static int MaxMeasureSizeKeyEntries { get; set; } = 50;


	public Size? FindMeasuredSize(TextBlock source, Size availableSize)
	{
		if (!FeatureConfiguration.TextBlock.IsMeasureCacheEnabled)
		{
			return null;
		}
		MeasureKey key = new MeasureKey(source);
		if (!_entries.TryGetValue(key, out var value))
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().LogDebug("{0}", $"TextMeasure-cached [{source.Text} / {source.TextWrapping} / {source.MaxLines}]: {availableSize} -> NOT FOUND.");
			}
			return null;
		}
		Size? size = value.FindMeasuredSize(key, availableSize);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug("{0}", $"TextMeasure-cached [{source.Text} / {source.TextWrapping} / {source.MaxLines}]: {availableSize} -> {size}");
		}
		return size;
	}

	public void CacheMeasure(TextBlock source, Size availableSize, Size measuredSize)
	{
		MeasureKey measureKey = new MeasureKey(source);
		if (_entries.TryGetValue(measureKey, out var value))
		{
			if (_queue.Count > 1 && !_queue.Last!.Value.Equals(measureKey))
			{
				_queue.Remove(value.ListNode);
				_queue.AddLast(value.ListNode);
			}
		}
		else
		{
			Scavenge();
			LinkedListNode<MeasureKey> node = _queue.AddLast(measureKey);
			value = (_entries[measureKey] = new MeasureEntry(node));
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug("{0}", $"TextMeasure-new [{source.Text} / {source.TextWrapping} / {source.MaxLines}]: {availableSize} -> {measuredSize}");
		}
		value.CacheMeasure(availableSize, measuredSize);
	}

	private void Scavenge()
	{
		while (_queue.Count >= MaxMeasureKeyEntries)
		{
			_entries.Remove(_queue.First!.Value);
			_queue.RemoveFirst();
		}
	}
}
