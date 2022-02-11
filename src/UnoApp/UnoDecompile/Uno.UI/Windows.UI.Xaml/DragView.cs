using System;
using System.Linq;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml;

internal class DragView : Control
{
	public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register("Glyph", typeof(string), typeof(DragView), new FrameworkPropertyMetadata((object)null));

	public static readonly DependencyProperty GlyphVisibilityProperty = DependencyProperty.Register("GlyphVisibility", typeof(Visibility), typeof(DragView), new FrameworkPropertyMetadata(Visibility.Visible));

	public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(DragView), new FrameworkPropertyMetadata((object)null));

	public static readonly DependencyProperty CaptionVisibilityProperty = DependencyProperty.Register("CaptionVisibility", typeof(Visibility), typeof(DragView), new FrameworkPropertyMetadata(Visibility.Visible));

	public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(ImageSource), typeof(DragView), new FrameworkPropertyMetadata((object)null));

	public static readonly DependencyProperty ContentAnchorProperty = DependencyProperty.Register("ContentAnchor", typeof(Point), typeof(DragView), new FrameworkPropertyMetadata(default(Point)));

	public static readonly DependencyProperty ContentVisibilityProperty = DependencyProperty.Register("ContentVisibility", typeof(Visibility), typeof(DragView), new FrameworkPropertyMetadata(Visibility.Visible));

	public static readonly DependencyProperty TooltipVisibilityProperty = DependencyProperty.Register("TooltipVisibility", typeof(Visibility), typeof(DragView), new FrameworkPropertyMetadata(Visibility.Visible));

	private readonly DragUI? _ui;

	private readonly TranslateTransform _transform;

	private Point _location;

	public string Glyph
	{
		get
		{
			return (string)GetValue(GlyphProperty);
		}
		set
		{
			SetValue(GlyphProperty, value);
		}
	}

	public Visibility GlyphVisibility
	{
		get
		{
			return (Visibility)GetValue(GlyphVisibilityProperty);
		}
		private set
		{
			SetValue(GlyphVisibilityProperty, value);
		}
	}

	public string Caption
	{
		get
		{
			return (string)GetValue(CaptionProperty);
		}
		set
		{
			SetValue(CaptionProperty, value);
		}
	}

	public Visibility CaptionVisibility
	{
		get
		{
			return (Visibility)GetValue(CaptionVisibilityProperty);
		}
		private set
		{
			SetValue(CaptionVisibilityProperty, value);
		}
	}

	public ImageSource? Content
	{
		get
		{
			return (ImageSource)GetValue(ContentProperty);
		}
		private set
		{
			SetValue(ContentProperty, value);
		}
	}

	public Point ContentAnchor
	{
		get
		{
			return (Point)GetValue(ContentAnchorProperty);
		}
		private set
		{
			SetValue(ContentAnchorProperty, value);
		}
	}

	public Visibility ContentVisibility
	{
		get
		{
			return (Visibility)GetValue(ContentVisibilityProperty);
		}
		private set
		{
			SetValue(ContentVisibilityProperty, value);
		}
	}

	public Visibility TooltipVisibility
	{
		get
		{
			return (Visibility)GetValue(TooltipVisibilityProperty);
		}
		set
		{
			SetValue(TooltipVisibilityProperty, value);
		}
	}

	public DragView(DragUI? ui)
	{
		_ui = ui;
		base.DefaultStyleKey = typeof(DragView);
		base.RenderTransform = (_transform = new TranslateTransform());
		Content = ui?.Content;
	}

	public void SetLocation(Point location)
	{
		_location = location;
		_transform.X = location.X;
		_transform.Y = location.Y;
	}

	public void Update(DataPackageOperation acceptedOperation, CoreDragUIOverride viewOverride)
	{
		string text = viewOverride.Caption?.Split(new char[2] { '\r', '\n' }, StringSplitOptions.None).FirstOrDefault()?.Trim();
		if (string.IsNullOrEmpty(text))
		{
			text = ToCaption(acceptedOperation);
		}
		Glyph = ToGlyph(acceptedOperation);
		GlyphVisibility = ToVisibility(viewOverride.IsGlyphVisible);
		Caption = text;
		CaptionVisibility = ToVisibility(viewOverride.IsCaptionVisible && !string.IsNullOrWhiteSpace(text));
		if (viewOverride.Content is ImageSource content)
		{
			Content = content;
			ContentAnchor = viewOverride.ContentAnchor;
		}
		else
		{
			Content = _ui?.Content;
			ContentAnchor = (_ui?.Anchor).GetValueOrDefault();
		}
		ContentVisibility = ToVisibility(viewOverride.IsContentVisible);
		TooltipVisibility = ToVisibility(viewOverride.IsGlyphVisible || viewOverride.IsCaptionVisible);
		base.Visibility = Visibility.Visible;
	}

	public void Hide()
	{
		base.Visibility = Visibility.Collapsed;
	}

	private static Visibility ToVisibility(bool isVisible)
	{
		if (!isVisible)
		{
			return Visibility.Collapsed;
		}
		return Visibility.Visible;
	}

	private static string ToGlyph(DataPackageOperation result)
	{
		if (result.HasFlag(DataPackageOperation.Link))
		{
			return "\ud83d\udd17";
		}
		if (result.HasFlag(DataPackageOperation.Copy))
		{
			return "⎘";
		}
		if (result.HasFlag(DataPackageOperation.Move))
		{
			return "\ud83e\udc55";
		}
		return "\ud83d\udeab";
	}

	private static string ToCaption(DataPackageOperation result)
	{
		if (result.HasFlag(DataPackageOperation.Link))
		{
			return ResourceAccessor.GetLocalizedStringResource("DragViewLinkCaption");
		}
		if (result.HasFlag(DataPackageOperation.Copy))
		{
			return ResourceAccessor.GetLocalizedStringResource("DragViewCopyCaption");
		}
		if (result.HasFlag(DataPackageOperation.Move))
		{
			return ResourceAccessor.GetLocalizedStringResource("DragViewMoveCaption");
		}
		return string.Empty;
	}
}
