using Uno;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Documents;

[ContentProperty(Name = "Text")]
public class Run : Inline
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public FlowDirection FlowDirection
	{
		get
		{
			return (FlowDirection)GetValue(FlowDirectionProperty);
		}
		set
		{
			SetValue(FlowDirectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FlowDirectionProperty { get; } = DependencyProperty.Register("FlowDirection", typeof(FlowDirection), typeof(Run), new FrameworkPropertyMetadata(FlowDirection.LeftToRight));


	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(Run), new FrameworkPropertyMetadata((object)string.Empty, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Run)s).OnTextChanged();
	}, (CoerceValueCallback)TextBlock.CoerceText));


	public void OnTextChanged()
	{
		OnTextChangedPartial();
		InvalidateInlines();
	}

	private void OnTextChangedPartial()
	{
		SetText(Text);
	}

	protected override void OnForegroundChanged()
	{
		base.OnForegroundChanged();
		InvalidateInlines();
	}

	protected override void OnFontFamilyChanged()
	{
		base.OnFontFamilyChanged();
		InvalidateInlines();
	}

	protected override void OnFontSizeChanged()
	{
		base.OnFontSizeChanged();
		InvalidateInlines();
	}

	protected override void OnFontStyleChanged()
	{
		base.OnFontStyleChanged();
		InvalidateInlines();
	}

	protected override void OnFontWeightChanged()
	{
		base.OnFontWeightChanged();
		InvalidateInlines();
	}

	protected override void OnBaseLineAlignmentChanged()
	{
		base.OnBaseLineAlignmentChanged();
		InvalidateInlines();
	}

	protected override void OnCharacterSpacingChanged()
	{
		base.OnCharacterSpacingChanged();
		InvalidateInlines();
	}

	protected override void OnTextDecorationsChanged()
	{
		base.OnTextDecorationsChanged();
		InvalidateInlines();
	}
}
