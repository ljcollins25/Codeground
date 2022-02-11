using System;
using Uno;
using Uno.Disposables;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.Media.Casting;
using Windows.Media.PlayTo;
using Windows.UI.Composition;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows.UI.Xaml.Controls;

public class Image : FrameworkElement, ICustomClippingElement
{
	private Color? _monochromeColor;

	private readonly SerialDisposable _sourceDisposable = new SerialDisposable();

	private readonly HtmlImage _htmlImage;

	private Size _lastMeasuredSize;

	private static readonly Size _zeroSize = new Size(0.0, 0.0);

	private ImageData _currentImg;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Thickness NineGrid
	{
		get
		{
			return (Thickness)GetValue(NineGridProperty);
		}
		set
		{
			SetValue(NineGridProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public PlayToSource PlayToSource => (PlayToSource)GetValue(PlayToSourceProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty NineGridProperty { get; } = DependencyProperty.Register("NineGrid", typeof(Thickness), typeof(Image), new FrameworkPropertyMetadata(default(Thickness)));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlayToSourceProperty { get; } = DependencyProperty.Register("PlayToSource", typeof(PlayToSource), typeof(Image), new FrameworkPropertyMetadata((object)null));


	internal Color? MonochromeColor
	{
		get
		{
			return _monochromeColor;
		}
		set
		{
			_monochromeColor = value;
			OnSourceChanged(Source);
		}
	}

	public ImageSource Source
	{
		get
		{
			return (ImageSource)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Image), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Image)s)?.OnSourceChanged(e.NewValue as ImageSource);
	}));


	public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(Image), new FrameworkPropertyMetadata(Stretch.Uniform, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Image)s).OnStretchChanged((Stretch)e.NewValue, (Stretch)e.OldValue);
	}));


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

	bool ICustomClippingElement.AllowClippingToLayoutSlot => true;

	bool ICustomClippingElement.ForceClippingToLayoutSlot => true;

	public event RoutedEventHandler ImageOpened
	{
		add
		{
			_htmlImage.RegisterEventHandler("load", value, GenericEventHandlers.RaiseRoutedEventHandler);
		}
		remove
		{
			_htmlImage.UnregisterEventHandler("load", value, GenericEventHandlers.RaiseRoutedEventHandler);
		}
	}

	public event ExceptionRoutedEventHandler ImageFailed
	{
		add
		{
			HtmlImage htmlImage = _htmlImage;
			GenericEventHandler invoker = GenericEventHandlers.RaiseExceptionRoutedEventHandler;
			EventArgsParser payloadConverter = ImageFailedConverter;
			htmlImage.RegisterEventHandler("error", value, invoker, onCapturePhase: false, null, payloadConverter);
		}
		remove
		{
			_htmlImage.UnregisterEventHandler("error", value, GenericEventHandlers.RaiseExceptionRoutedEventHandler);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CastingSource GetAsCastingSource()
	{
		throw new NotImplementedException("The member CastingSource Image.GetAsCastingSource() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CompositionBrush GetAlphaMask()
	{
		throw new NotImplementedException("The member CompositionBrush Image.GetAlphaMask() is not implemented in Uno.");
	}

	private void OnSourceChanged(ImageSource newValue)
	{
		UpdateHitTest();
		_lastMeasuredSize = _zeroSize;
		if (newValue != null)
		{
			_sourceDisposable.Disposable = null;
			_sourceDisposable.Disposable = newValue.Subscribe(OnSourceOpened);
		}
		else
		{
			_htmlImage.SetAttribute("src", "");
		}
		void OnSourceOpened(ImageData img)
		{
			_currentImg = img;
			switch (img.Kind)
			{
			case ImageDataKind.Empty:
				_htmlImage.SetAttribute("src", "");
				break;
			default:
				if (MonochromeColor.HasValue)
				{
					WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.setImageAsMonochrome(" + _htmlImage.HtmlId + ", \"" + img.Value + "\", \"" + MonochromeColor.Value.ToHexString() + "\");");
				}
				else
				{
					_htmlImage.SetAttribute("src", img.Value);
				}
				break;
			case ImageDataKind.Error:
			{
				_htmlImage.SetAttribute("src", "");
				ExceptionRoutedEventArgs eventArgs = new ExceptionRoutedEventArgs(this, img.Error?.ToString());
				_htmlImage.InternalDispatchEvent("error", eventArgs);
				break;
			}
			}
		}
	}

	private void OnStretchChanged(Stretch newValue, Stretch oldValue)
	{
		InvalidateArrange();
	}

	internal override bool IsViewHit()
	{
		if (Source == null)
		{
			return base.IsViewHit();
		}
		return true;
	}

	public Image()
	{
		_htmlImage = new HtmlImage();
		_htmlImage.SetAttribute("draggable", "false");
		ImageOpened += OnImageOpened;
		ImageFailed += OnImageFailed;
		AddChild(_htmlImage);
	}

	private void OnImageFailed(object sender, ExceptionRoutedEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Image failed [{_currentImg.Source}]: {e.ErrorMessage}");
		}
		_currentImg.Source?.ReportImageFailed(e.ErrorMessage);
	}

	private void OnImageOpened(object sender, RoutedEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Image opened [{(Source as BitmapSource)?.WebUri}]");
		}
		if (_lastMeasuredSize == _zeroSize)
		{
			InvalidateMeasure();
		}
		_currentImg.Source?.ReportImageLoaded();
	}

	private ExceptionRoutedEventArgs ImageFailedConverter(object sender, string e)
	{
		return new ExceptionRoutedEventArgs(sender, e);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		_lastMeasuredSize = _htmlImage.MeasureView(new Size(double.PositiveInfinity, double.PositiveInfinity));
		if (Source is BitmapSource bitmapSource)
		{
			bitmapSource.PixelWidth = (int)_lastMeasuredSize.Width;
			bitmapSource.PixelHeight = (int)_lastMeasuredSize.Height;
		}
		Size size = ((!double.IsInfinity(availableSize.Width) || !double.IsInfinity(availableSize.Height)) ? this.AdjustSize(availableSize, _lastMeasuredSize) : _lastMeasuredSize);
		size = new Size((!double.IsNaN(base.Width) && size.Width > availableSize.Width) ? availableSize.Width : size.Width, (!double.IsNaN(base.Height) && size.Height > availableSize.Height) ? availableSize.Height : size.Height);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"Measure {this} availableSize:{availableSize} measuredSize:{_lastMeasuredSize} ret:{size} Stretch: {Stretch} Width:{base.Width} Height:{base.Height}");
		}
		return size;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		Size containerSize = this.MeasureSource(finalSize, _lastMeasuredSize);
		Rect rect = this.ArrangeSource(finalSize, containerSize);
		_htmlImage.ArrangeVisual(rect, null);
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().LogDebug($"Arrange {this} _lastMeasuredSize:{_lastMeasuredSize} position:{rect} finalSize:{finalSize}");
		}
		return finalSize;
	}
}
