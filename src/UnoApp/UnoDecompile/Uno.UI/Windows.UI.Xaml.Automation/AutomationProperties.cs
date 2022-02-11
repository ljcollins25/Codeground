using System.Collections.Generic;
using Uno;
using Uno.UI;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml.Automation;

public sealed class AutomationProperties
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AcceleratorKeyProperty { get; } = DependencyProperty.RegisterAttached("AcceleratorKey", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AccessKeyProperty { get; } = DependencyProperty.RegisterAttached("AccessKey", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HelpTextProperty { get; } = DependencyProperty.RegisterAttached("HelpText", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsRequiredForFormProperty { get; } = DependencyProperty.RegisterAttached("IsRequiredForForm", typeof(bool), typeof(AutomationProperties), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemStatusProperty { get; } = DependencyProperty.RegisterAttached("ItemStatus", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ItemTypeProperty { get; } = DependencyProperty.RegisterAttached("ItemType", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LiveSettingProperty { get; } = DependencyProperty.RegisterAttached("LiveSetting", typeof(AutomationLiveSetting), typeof(AutomationProperties), new FrameworkPropertyMetadata(AutomationLiveSetting.Off));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ControlledPeersProperty { get; } = DependencyProperty.RegisterAttached("ControlledPeers", typeof(IList<UIElement>), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AnnotationsProperty { get; } = DependencyProperty.RegisterAttached("Annotations", typeof(IList<AutomationAnnotation>), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LevelProperty { get; } = DependencyProperty.RegisterAttached("Level", typeof(int), typeof(AutomationProperties), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LocalizedLandmarkTypeProperty { get; } = DependencyProperty.RegisterAttached("LocalizedLandmarkType", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FlowsFromProperty { get; } = DependencyProperty.RegisterAttached("FlowsFrom", typeof(IList<DependencyObject>), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FlowsToProperty { get; } = DependencyProperty.RegisterAttached("FlowsTo", typeof(IList<DependencyObject>), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FullDescriptionProperty { get; } = DependencyProperty.RegisterAttached("FullDescription", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDataValidForFormProperty { get; } = DependencyProperty.RegisterAttached("IsDataValidForForm", typeof(bool), typeof(AutomationProperties), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsPeripheralProperty { get; } = DependencyProperty.RegisterAttached("IsPeripheral", typeof(bool), typeof(AutomationProperties), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CultureProperty { get; } = DependencyProperty.RegisterAttached("Culture", typeof(int), typeof(AutomationProperties), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeadingLevelProperty { get; } = DependencyProperty.RegisterAttached("HeadingLevel", typeof(AutomationHeadingLevel), typeof(AutomationProperties), new FrameworkPropertyMetadata(AutomationHeadingLevel.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDialogProperty { get; } = DependencyProperty.RegisterAttached("IsDialog", typeof(bool), typeof(AutomationProperties), new FrameworkPropertyMetadata(false));


	public static DependencyProperty NameProperty { get; } = DependencyProperty.RegisterAttached("Name", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata(string.Empty, OnNamePropertyChanged));


	public static DependencyProperty AccessibilityViewProperty { get; } = DependencyProperty.RegisterAttached("AccessibilityView", typeof(AccessibilityView), typeof(AutomationProperties), new FrameworkPropertyMetadata(AccessibilityView.Content));


	public static DependencyProperty LabeledByProperty { get; } = DependencyProperty.RegisterAttached("LabeledBy", typeof(UIElement), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty LocalizedControlTypeProperty { get; } = DependencyProperty.RegisterAttached("LocalizedControlType", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty DescribedByProperty { get; } = DependencyProperty.RegisterAttached("DescribedBy", typeof(IList<DependencyObject>), typeof(AutomationProperties), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty AutomationIdProperty { get; } = DependencyProperty.RegisterAttached("AutomationId", typeof(string), typeof(AutomationProperties), new FrameworkPropertyMetadata("", OnAutomationIdChanged));


	public static DependencyProperty PositionInSetProperty { get; } = DependencyProperty.RegisterAttached("PositionInSet", typeof(int), typeof(AutomationProperties), new FrameworkPropertyMetadata(0));


	public static DependencyProperty SizeOfSetProperty { get; } = DependencyProperty.RegisterAttached("SizeOfSet", typeof(int), typeof(AutomationProperties), new FrameworkPropertyMetadata(0));


	public static DependencyProperty LandmarkTypeProperty { get; } = DependencyProperty.RegisterAttached("LandmarkType", typeof(AutomationLandmarkType), typeof(AutomationProperties), new FrameworkPropertyMetadata(AutomationLandmarkType.None));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsDialog(DependencyObject element)
	{
		return (bool)element.GetValue(IsDialogProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsDialog(DependencyObject element, bool value)
	{
		element.SetValue(IsDialogProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static AutomationHeadingLevel GetHeadingLevel(DependencyObject element)
	{
		return (AutomationHeadingLevel)element.GetValue(HeadingLevelProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetHeadingLevel(DependencyObject element, AutomationHeadingLevel value)
	{
		element.SetValue(HeadingLevelProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static int GetCulture(DependencyObject element)
	{
		return (int)element.GetValue(CultureProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetCulture(DependencyObject element, int value)
	{
		element.SetValue(CultureProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsPeripheral(DependencyObject element)
	{
		return (bool)element.GetValue(IsPeripheralProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsPeripheral(DependencyObject element, bool value)
	{
		element.SetValue(IsPeripheralProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsDataValidForForm(DependencyObject element)
	{
		return (bool)element.GetValue(IsDataValidForFormProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsDataValidForForm(DependencyObject element, bool value)
	{
		element.SetValue(IsDataValidForFormProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetFullDescription(DependencyObject element)
	{
		return (string)element.GetValue(FullDescriptionProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetFullDescription(DependencyObject element, string value)
	{
		element.SetValue(FullDescriptionProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IList<DependencyObject> GetFlowsTo(DependencyObject element)
	{
		return (IList<DependencyObject>)element.GetValue(FlowsToProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IList<DependencyObject> GetFlowsFrom(DependencyObject element)
	{
		return (IList<DependencyObject>)element.GetValue(FlowsFromProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetLocalizedLandmarkType(DependencyObject element)
	{
		return (string)element.GetValue(LocalizedLandmarkTypeProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetLocalizedLandmarkType(DependencyObject element, string value)
	{
		element.SetValue(LocalizedLandmarkTypeProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static int GetLevel(DependencyObject element)
	{
		return (int)element.GetValue(LevelProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetLevel(DependencyObject element, int value)
	{
		element.SetValue(LevelProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IList<AutomationAnnotation> GetAnnotations(DependencyObject element)
	{
		return (IList<AutomationAnnotation>)element.GetValue(AnnotationsProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetAccessibilityView(DependencyObject element, AccessibilityView value)
	{
		element.SetValue(AccessibilityViewProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static IList<UIElement> GetControlledPeers(DependencyObject element)
	{
		return (IList<UIElement>)element.GetValue(ControlledPeersProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetAcceleratorKey(DependencyObject element)
	{
		return (string)element.GetValue(AcceleratorKeyProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetAcceleratorKey(DependencyObject element, string value)
	{
		element.SetValue(AcceleratorKeyProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetAccessKey(DependencyObject element)
	{
		return (string)element.GetValue(AccessKeyProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetAccessKey(DependencyObject element, string value)
	{
		element.SetValue(AccessKeyProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetHelpText(DependencyObject element)
	{
		return (string)element.GetValue(HelpTextProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetHelpText(DependencyObject element, string value)
	{
		element.SetValue(HelpTextProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool GetIsRequiredForForm(DependencyObject element)
	{
		return (bool)element.GetValue(IsRequiredForFormProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetIsRequiredForForm(DependencyObject element, bool value)
	{
		element.SetValue(IsRequiredForFormProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetItemStatus(DependencyObject element)
	{
		return (string)element.GetValue(ItemStatusProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetItemStatus(DependencyObject element, string value)
	{
		element.SetValue(ItemStatusProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static string GetItemType(DependencyObject element)
	{
		return (string)element.GetValue(ItemTypeProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetItemType(DependencyObject element, string value)
	{
		element.SetValue(ItemTypeProperty, value);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static AutomationLiveSetting GetLiveSetting(DependencyObject element)
	{
		return (AutomationLiveSetting)element.GetValue(LiveSettingProperty);
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static void SetLiveSetting(DependencyObject element, AutomationLiveSetting value)
	{
		element.SetValue(LiveSettingProperty, value);
	}

	public static void SetName(DependencyObject element, string value)
	{
		element.SetValue(NameProperty, value);
	}

	public static string GetName(DependencyObject element)
	{
		return (string)element.GetValue(NameProperty);
	}

	private static void OnNamePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
	}

	public static AccessibilityView GetAccessibilityView(DependencyObject element)
	{
		return (AccessibilityView)element.GetValue(AccessibilityViewProperty);
	}

	public static void SetAccessibilityeView(DependencyObject element, AccessibilityView value)
	{
		element.SetValue(AccessibilityViewProperty, value);
	}

	public static UIElement GetLabeledBy(DependencyObject element)
	{
		return (UIElement)element.GetValue(LabeledByProperty);
	}

	public static void SetLabeledBy(DependencyObject element, UIElement value)
	{
		element.SetValue(LabeledByProperty, value);
	}

	public static string GetLocalizedControlType(DependencyObject element)
	{
		return (string)element.GetValue(LocalizedControlTypeProperty);
	}

	public static void SetLocalizedControlType(DependencyObject element, string value)
	{
		element.SetValue(LocalizedControlTypeProperty, value);
	}

	public static IList<DependencyObject> GetDescribedBy(DependencyObject element)
	{
		return (IList<DependencyObject>)element.GetValue(DescribedByProperty);
	}

	private static void OnAutomationIdChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is UIElement uIElement)
		{
			if (FrameworkElementHelper.IsUiAutomationMappingEnabled)
			{
				uIElement.SetAttribute("xamlautomationid", (string)args.NewValue);
			}
			string text = FindHtmlRole(uIElement);
			if (text != null)
			{
				uIElement.SetAttribute(("aria-label", (string)args.NewValue), ("role", text));
			}
		}
	}

	public static string GetAutomationId(DependencyObject element)
	{
		return (string)element.GetValue(AutomationIdProperty);
	}

	public static void SetAutomationId(DependencyObject element, string value)
	{
		element.SetValue(AutomationIdProperty, value);
	}

	public static int GetPositionInSet(DependencyObject element)
	{
		return (int)element.GetValue(PositionInSetProperty);
	}

	public static void SetPositionInSet(DependencyObject element, int value)
	{
		element.SetValue(PositionInSetProperty, value);
	}

	public static int GetSizeOfSet(DependencyObject element)
	{
		return (int)element.GetValue(SizeOfSetProperty);
	}

	public static void SetSizeOfSet(DependencyObject element, int value)
	{
		element.SetValue(SizeOfSetProperty, value);
	}

	public static AutomationLandmarkType GetLandmarkType(DependencyObject element)
	{
		return (AutomationLandmarkType)element.GetValue(LandmarkTypeProperty);
	}

	public static void SetLandmarkType(DependencyObject element, AutomationLandmarkType value)
	{
		element.SetValue(LandmarkTypeProperty, value);
	}

	private static string FindHtmlRole(UIElement uIElement)
	{
		if (!(uIElement is Button))
		{
			if (!(uIElement is RadioButton))
			{
				if (!(uIElement is CheckBox))
				{
					if (!(uIElement is TextBlock))
					{
						if (!(uIElement is TextBox))
						{
							if (uIElement is Slider)
							{
								return "slider";
							}
							return null;
						}
						return "textbox";
					}
					return "label";
				}
				return "checkbox";
			}
			return "radio";
		}
		return "button";
	}
}
