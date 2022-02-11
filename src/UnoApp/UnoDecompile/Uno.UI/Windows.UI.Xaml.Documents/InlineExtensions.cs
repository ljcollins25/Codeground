using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Documents;

internal static class InlineExtensions
{
	internal static string GetText(this Inline inline)
	{
		if (!(inline is Run run))
		{
			if (!(inline is LineBreak))
			{
				if (inline is Span span)
				{
					return string.Concat(span.Inlines.Select(new Func<Inline, string>(GetText)));
				}
				return string.Empty;
			}
			return "\n";
		}
		return run.Text ?? string.Empty;
	}

	internal static IEnumerable<Inline> Enumerate(this Inline root)
	{
		yield return root;
		if (!(root is Span span))
		{
			yield break;
		}
		foreach (Inline item in span.Inlines.SelectMany(new Func<Inline, IEnumerable<Inline>>(Enumerate)))
		{
			yield return item;
		}
	}

	internal static bool HasTypographicalEffectWithin(this Inline inline, TextBlock textBlock)
	{
		if (inline is Run run && run.Text != string.Empty)
		{
			return !inline.IsTypographicallyEquivalentTo(textBlock);
		}
		return false;
	}

	internal static bool IsTypographicallyEquivalentTo(this Inline inline, TextBlock textBlock)
	{
		if (inline != null && inline.Foreground == textBlock.Foreground && inline.FontSize == textBlock.FontSize && inline.FontWeight == textBlock.FontWeight && inline.FontStyle == textBlock.FontStyle && inline.FontFamily == textBlock.FontFamily && inline.FontSize == textBlock.FontSize && inline.CharacterSpacing == textBlock.CharacterSpacing && inline.BaseLineAlignment == BaseLineAlignment.Baseline)
		{
			return inline.TextDecorations == textBlock.TextDecorations;
		}
		return false;
	}
}
