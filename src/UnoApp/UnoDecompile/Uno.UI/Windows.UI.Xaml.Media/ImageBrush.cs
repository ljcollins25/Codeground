using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Uno;
using Uno.Disposables;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.Xaml.Wasm;

namespace Windows.UI.Xaml.Media;

public class ImageBrush : Brush
{
	private readonly SerialDisposable _sourceSubscription = new SerialDisposable();

	private readonly List<Action<ImageData>> _listeners = new List<Action<ImageData>>();

	private ImageData? _cache;

	private static readonly IDictionary<string, Size> _naturalSizeCache = new Dictionary<string, Size>();

	private string _imageUri = string.Empty;

	public static DependencyProperty AlignmentXProperty { get; } = DependencyProperty.Register("AlignmentX", typeof(AlignmentX), typeof(ImageBrush), new FrameworkPropertyMetadata(AlignmentX.Center));


	[NotImplemented]
	public AlignmentX AlignmentX
	{
		get
		{
			return (AlignmentX)GetValue(AlignmentXProperty);
		}
		set
		{
			SetValue(AlignmentXProperty, value);
		}
	}

	public static DependencyProperty AlignmentYProperty { get; } = DependencyProperty.Register("AlignmentY", typeof(AlignmentY), typeof(ImageBrush), new FrameworkPropertyMetadata(AlignmentY.Center));


	[NotImplemented]
	public AlignmentY AlignmentY
	{
		get
		{
			return (AlignmentY)GetValue(AlignmentYProperty);
		}
		set
		{
			SetValue(AlignmentYProperty, value);
		}
	}

	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ImageBrush), new FrameworkPropertyMetadata((object)Stretch.Fill, (PropertyChangedCallback)null));


	[NotImplemented]
	public Stretch Stretch
	{
		get
		{
			return (Stretch)GetValue(StretchProperty);
		}
		set
		{
			SetValue(StretchProperty, value);
		}
	}

	public static DependencyProperty ImageSourceProperty { get; } = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageBrush), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ImageBrush)s).OnSourceChangedPartial((ImageSource)e.NewValue, (ImageSource)e.OldValue);
	}));


	public ImageSource ImageSource
	{
		get
		{
			return (ImageSource)GetValue(ImageSourceProperty);
		}
		set
		{
			SetValue(ImageSourceProperty, value);
		}
	}

	public event RoutedEventHandler ImageOpened;

	public event ExceptionRoutedEventHandler ImageFailed;

	private void OnSourceChangedPartial(ImageSource newValue, ImageSource oldValue)
	{
		_cache = null;
		_sourceSubscription.Disposable = Disposable.Empty;
		if (newValue != null && _listeners.Count > 0)
		{
			_sourceSubscription.Disposable = newValue.Subscribe(OnSourceOpened);
		}
	}

	internal Rect GetArrangedImageRect(Size sourceSize, Rect targetRect)
	{
		Size arrangedImageSize = GetArrangedImageSize(sourceSize, targetRect.Size);
		Point arrangedImageLocation = GetArrangedImageLocation(arrangedImageSize, targetRect.Size);
		arrangedImageLocation.X += targetRect.X;
		arrangedImageLocation.Y += targetRect.Y;
		return new Rect(arrangedImageLocation, arrangedImageSize);
	}

	private Size GetArrangedImageSize(Size sourceSize, Size targetSize)
	{
		double num = sourceSize.AspectRatio();
		double num2 = targetSize.AspectRatio();
		switch (Stretch)
		{
		default:
			return sourceSize;
		case Stretch.Fill:
			return targetSize;
		case Stretch.Uniform:
			if (!(num2 > num))
			{
				return new Size(targetSize.Width, sourceSize.Height * targetSize.Width / sourceSize.Width);
			}
			return new Size(sourceSize.Width * targetSize.Height / sourceSize.Height, targetSize.Height);
		case Stretch.UniformToFill:
			if (!(num2 < num))
			{
				return new Size(targetSize.Width, sourceSize.Height * targetSize.Width / sourceSize.Width);
			}
			return new Size(sourceSize.Width * targetSize.Height / sourceSize.Height, targetSize.Height);
		}
	}

	private Point GetArrangedImageLocation(Size finalSize, Size targetSize)
	{
		Point result = new Point(targetSize.Width - finalSize.Width, targetSize.Height - finalSize.Height);
		switch (AlignmentX)
		{
		default:
			result.X *= 0.0;
			break;
		case AlignmentX.Center:
			result.X *= 0.5;
			break;
		case AlignmentX.Right:
			result.X *= 1.0;
			break;
		}
		switch (AlignmentY)
		{
		default:
			result.Y *= 0.0;
			break;
		case AlignmentY.Center:
			result.Y *= 0.5;
			break;
		case AlignmentY.Bottom:
			result.Y *= 1.0;
			break;
		}
		return result;
	}

	private void OnImageOpened()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug(ToString() + " Image opened successfully");
		}
		this.ImageOpened?.Invoke(this, new RoutedEventArgs(this));
	}

	private void OnImageFailed()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug(ToString() + " Image failed to open");
		}
		this.ImageFailed?.Invoke(this, new ExceptionRoutedEventArgs(this, "Image failed to open"));
	}

	internal IDisposable Subscribe(Action<ImageData> onUpdated)
	{
		_listeners.Add(onUpdated);
		if (_cache.HasValue)
		{
			onUpdated(_cache.Value);
		}
		ImageSource imageSource = ImageSource;
		if (imageSource != null && _listeners.Count == 1)
		{
			_sourceSubscription.Disposable = imageSource.Subscribe(OnSourceOpened);
		}
		return Disposable.Create(delegate
		{
			_listeners.Remove(onUpdated);
			if (_listeners.Count == 0)
			{
				_sourceSubscription.Disposable = Disposable.Empty;
			}
		});
	}

	private void OnSourceOpened(ImageData image)
	{
		_cache = image;
		List<Action<ImageData>> list = _listeners.ToList();
		foreach (Action<ImageData> item in list)
		{
			item(image);
		}
		if (image.Kind == ImageDataKind.Error)
		{
			OnImageFailed();
		}
		else
		{
			OnImageOpened();
		}
	}

	internal string ToCssPosition()
	{
		return AlignmentX switch
		{
			AlignmentX.Left => "left", 
			AlignmentX.Center => "center", 
			AlignmentX.Right => "right", 
			_ => "", 
		} + " " + AlignmentY switch
		{
			AlignmentY.Top => "top", 
			AlignmentY.Center => "center", 
			AlignmentY.Bottom => "bottom", 
			_ => "", 
		};
	}

	internal string ToCssBackgroundSize()
	{
		return Stretch switch
		{
			Stretch.Fill => "100% 100%", 
			Stretch.None => "auto", 
			Stretch.Uniform => "auto", 
			Stretch.UniformToFill => "auto", 
			_ => "auto", 
		};
	}

	internal (UIElement defElement, IDisposable subscription) ToSvgElement(FrameworkElement target)
	{
		SvgElement pattern = new SvgElement("pattern");
		string preserveAspectRatio = SetPreserveAspectRatio();
		pattern.SetAttribute(("x", "0"), ("y", "0"), ("width", "100%"), ("height", "100%"));
		SerialDisposable subscriptionDisposable = new SerialDisposable();
		IDisposable disposable = this.RegisterDisposablePropertyChangedCallback(ImageSourceProperty, OnImageSourceChanged);
		IDisposable disposable2 = this.RegisterDisposablePropertyChangedCallback(StretchProperty, OnStretchChanged);
		IDisposable disposable3 = this.RegisterDisposablePropertyChangedCallback(AlignmentXProperty, OnAlignmentChanged);
		IDisposable disposable4 = this.RegisterDisposablePropertyChangedCallback(AlignmentYProperty, OnAlignmentChanged);
		target.LayoutUpdated += OnTargetLayoutUpdated;
		IDisposable disposable5 = Disposable.Create(delegate
		{
			target.LayoutUpdated -= OnTargetLayoutUpdated;
		});
		subscriptionDisposable.Disposable = ImageSource?.Subscribe(OnSourceOpened);
		CompositeDisposable item = new CompositeDisposable(disposable, subscriptionDisposable, disposable2, disposable3, disposable4, disposable5);
		return (pattern, item);
		void OnAlignmentChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
		{
			preserveAspectRatio = SetPreserveAspectRatio();
		}
		void OnImageSourceChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
		{
			ImageSource imageSource = args.NewValue as ImageSource;
			subscriptionDisposable.Disposable = imageSource?.Subscribe(OnSourceOpened);
		}
		void OnSourceOpened(ImageData data)
		{
			switch (data.Kind)
			{
			case ImageDataKind.Empty:
				pattern.ClearChildren();
				_imageUri = null;
				break;
			case ImageDataKind.Url:
			case ImageDataKind.DataUri:
			{
				_imageUri = data.Value;
				SvgElement svgElement = new SvgElement("image");
				svgElement.SetAttribute(("width", "100%"), ("height", "100%"), ("preserveAspectRatio", preserveAspectRatio), ("href", _imageUri));
				foreach (UIElement child in pattern.GetChildren())
				{
					pattern.RemoveChild(child);
				}
				pattern.AddChild(svgElement);
				if (Stretch == Stretch.None)
				{
					SetNaturalImageSize(pattern, target);
				}
				break;
			}
			}
		}
		void OnStretchChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
		{
			preserveAspectRatio = SetPreserveAspectRatio();
		}
		void OnTargetLayoutUpdated(object sender, object e)
		{
			preserveAspectRatio = SetPreserveAspectRatio();
		}
		string SetPreserveAspectRatio()
		{
			Stretch stretch = Stretch;
			string text = AlignmentX switch
			{
				AlignmentX.Left => "xMin", 
				AlignmentX.Center => "xMid", 
				AlignmentX.Right => "xMax", 
				_ => string.Empty, 
			};
			string text2 = AlignmentY switch
			{
				AlignmentY.Top => "YMin", 
				AlignmentY.Center => "YMid", 
				AlignmentY.Bottom => "YMax", 
				_ => string.Empty, 
			};
			string text3 = stretch switch
			{
				Stretch.None => text + text2, 
				Stretch.Fill => "none", 
				Stretch.Uniform => text + text2 + " meet", 
				Stretch.UniformToFill => text + text2 + " slice", 
				_ => string.Empty, 
			};
			if (stretch == Stretch.UniformToFill)
			{
				pattern.SetAttribute(("preserveAspectRatio", text3 ?? ""));
			}
			pattern.FindFirstChild()?.SetAttribute(("preserveAspectRatio", text3 ?? ""));
			if (Stretch == Stretch.None)
			{
				SetNaturalImageSize(pattern, target);
			}
			else
			{
				pattern.FindFirstChild()?.SetAttribute(("width", "100%"), ("height", "100%"));
				pattern.RemoveAttribute("viewBox");
			}
			return text3;
		}
	}

	private async void SetNaturalImageSize(UIElement pattern, FrameworkElement target)
	{
		if (string.IsNullOrWhiteSpace(_imageUri))
		{
			return;
		}
		if (!_naturalSizeCache.TryGetValue(_imageUri, out var value))
		{
			string promiseCode = "Uno.UI.WindowManager.current.getNaturalImageSize(\"" + _imageUri + "\");";
			string text = await WebAssemblyRuntime.InvokeAsync(promiseCode);
			if (!TryParseNaturalSize(text, out value))
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Warn("Error parsing response from Uno.UI.WindowManager.current.getNaturalImageSize. Attempted to parse value: " + text);
				}
				return;
			}
			if (!_naturalSizeCache.ContainsKey(_imageUri))
			{
				_naturalSizeCache.Add(_imageUri, value);
			}
		}
		pattern.FindFirstChild()?.SetAttribute(("width", value.Width.ToString()), ("height", value.Height.ToString()));
		int num = (int)target.ActualWidth;
		int num2 = (int)target.ActualHeight;
		int num3 = AlignmentX switch
		{
			AlignmentX.Left => 0, 
			AlignmentX.Center => (int)(value.Width - (double)num) / 2, 
			AlignmentX.Right => (int)(value.Width - (double)num), 
			_ => 0, 
		};
		int num4 = AlignmentY switch
		{
			AlignmentY.Top => 0, 
			AlignmentY.Center => (int)(value.Height - (double)num2) / 2, 
			AlignmentY.Bottom => (int)(value.Height - (double)num2), 
			_ => 0, 
		};
		pattern.SetAttribute(("viewBox", $"{num3} {num4} {num} {num2}"));
	}

	private bool TryParseNaturalSize(string sizeStr, out Size naturalSize)
	{
		naturalSize = default(Size);
		if (string.IsNullOrWhiteSpace(sizeStr))
		{
			return false;
		}
		string[] array = sizeStr.Split(new char[1] { ';' });
		if (array.Length < 1)
		{
			return false;
		}
		if (!int.TryParse(array[0], NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out var result) || !int.TryParse(array[1], NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out var result2))
		{
			return false;
		}
		naturalSize = new Size(result, result2);
		return true;
	}
}
