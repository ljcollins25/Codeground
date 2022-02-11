using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.System;
using Windows.System.Profile;
using Windows.System.Threading;
using Windows.UI.Text;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Helpers.WinUI;

internal class SharedHelpers
{
	private static bool s_isOnXboxInitialized;

	private static bool s_isOnXbox;

	private static bool s_isMouseModeEnabledInitialized;

	private static bool s_isMouseModeEnabled;

	private static bool? s_isInDesignModeV1;

	private static bool? s_isInDesignModeV2;

	private static bool? s_IsXamlCompositionBrushBaseAvailable_isAvailable;

	private static bool? s_movesLightFromRSVToRootVisual;

	private static bool? s_DoesListViewItemPresenterVSMWork_isAvailable;

	private static bool? s_IsCoreWindowActivationModeAvailable_isAvailable;

	private static bool? s_isFlyoutShowOptionsAvailable;

	private static bool? s_areInteractionTrackerPointerWheelRedirectionModesAvailable;

	private static bool? s_isScrollViewerReduceViewportForCoreInputViewOcclusionsAvailable;

	private static bool? s_isScrollContentPresenterSizesContentToTemplatedParentAvailable;

	private static bool? s_isFrameworkElementInvalidateViewportAvailable;

	private static bool? s_isDisplayRegionGetForCurrentViewAvailable;

	private static bool s_areFacadesAvailable;

	private static bool? s_IsIconSourceElementAvailable_isAvailable;

	private static bool? s_IsStandardUICommandAvailable_isAvailable;

	private static bool? s_IsDispatcherQueueAvailable_isAvailable;

	private static bool? s_IsXamlRootAvailable;

	private static bool? s_isThemeShadowAvailable;

	private static bool? s_IsIsLoadedAvailable;

	private static bool s_dynamicScrollbarsDirty;

	private static bool s_dynamicScrollbars;

	private static readonly Dictionary<ushort, bool> isApiContractVxAvailable;

	static SharedHelpers()
	{
		s_isOnXboxInitialized = false;
		s_isOnXbox = false;
		s_isMouseModeEnabledInitialized = false;
		s_isMouseModeEnabled = false;
		s_isFlyoutShowOptionsAvailable = false;
		s_areFacadesAvailable = false;
		s_dynamicScrollbarsDirty = true;
		isApiContractVxAvailable = new Dictionary<ushort, bool>();
	}

	public static bool IsSystemDll()
	{
		return false;
	}

	public static bool IsAnimationsEnabled()
	{
		UISettings uISettings = new UISettings();
		return uISettings.AnimationsEnabled;
	}

	public static bool IsInDesignMode()
	{
		return IsInDesignModeV1();
	}

	public static bool IsInDesignModeV1()
	{
		if (!s_isInDesignModeV1.HasValue)
		{
			s_isInDesignModeV1 = DesignMode.DesignModeEnabled && !IsInDesignModeV2();
		}
		return s_isInDesignModeV1.Value;
	}

	internal static void RaiseAutomationPropertyChangedEvent<T>(UIElement element, T oldValue, T newValue)
	{
		FrameworkElementAutomationPeer.FromElement(element)?.RaisePropertyChangedEvent(ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty, oldValue, newValue);
	}

	public static bool IsInDesignModeV2()
	{
		if (!s_isInDesignModeV2.HasValue)
		{
			s_isInDesignModeV2 = IsRS3OrHigher() && DesignMode.DesignMode2Enabled;
		}
		return s_isInDesignModeV2.Value;
	}

	public static bool ShouldUseDynamicScrollbars()
	{
		if (s_dynamicScrollbarsDirty)
		{
			UISettings uISettings = new UISettings();
			s_dynamicScrollbars = uISettings.AutoHideScrollBars;
			s_dynamicScrollbarsDirty = false;
		}
		return s_dynamicScrollbars;
	}

	public static bool Is21H1OrHigher()
	{
		return IsAPIContractV14Available();
	}

	public static bool IsVanadiumOrHigher()
	{
		return IsAPIContractV9Available();
	}

	public static bool Is19H1OrHigher()
	{
		return IsAPIContractV8Available();
	}

	public static bool IsRS5OrHigher()
	{
		return IsAPIContractV7Available();
	}

	public static bool IsRS4OrHigher()
	{
		return IsAPIContractV6Available();
	}

	public static bool IsRS3OrHigher()
	{
		return IsAPIContractV5Available();
	}

	public static bool IsRS2OrHigher()
	{
		return IsAPIContractV4Available();
	}

	public static bool IsRS1OrHigher()
	{
		return IsAPIContractV3Available();
	}

	public static bool IsRS1()
	{
		if (IsAPIContractV3Available())
		{
			return !IsAPIContractV4Available();
		}
		return false;
	}

	public static bool IsTH2OrLower()
	{
		return !IsAPIContractV3Available();
	}

	public static bool IsXamlCompositionBrushBaseAvailable()
	{
		if (!s_IsXamlCompositionBrushBaseAvailable_isAvailable.HasValue)
		{
			s_IsXamlCompositionBrushBaseAvailable_isAvailable = IsRS3OrHigher() || ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase");
		}
		return s_IsXamlCompositionBrushBaseAvailable_isAvailable.Value;
	}

	public static bool DoesXamlMoveRSVLightToRootVisual()
	{
		if (!s_movesLightFromRSVToRootVisual.HasValue)
		{
			s_movesLightFromRSVToRootVisual = IsSystemDll() || IsRS3OrHigher();
		}
		return s_movesLightFromRSVToRootVisual.Value;
	}

	public static bool DoesListViewItemPresenterVSMWork()
	{
		if (!s_DoesListViewItemPresenterVSMWork_isAvailable.HasValue)
		{
			s_DoesListViewItemPresenterVSMWork_isAvailable = IsSystemDll() || IsRS3OrHigher();
		}
		return s_DoesListViewItemPresenterVSMWork_isAvailable.Value;
	}

	public static bool IsCoreWindowActivationModeAvailable()
	{
		if (!s_IsCoreWindowActivationModeAvailable_isAvailable.HasValue)
		{
			s_IsCoreWindowActivationModeAvailable_isAvailable = IsSystemDll() || IsRS3OrHigher();
		}
		return s_IsCoreWindowActivationModeAvailable_isAvailable.Value;
	}

	public static bool IsFlyoutShowOptionsAvailable()
	{
		if (!s_isFlyoutShowOptionsAvailable.HasValue)
		{
			s_isFlyoutShowOptionsAvailable = IsSystemDll() || Is19H1OrHigher() || ApiInformation.IsTypePresent("Windows.UI.Xaml.Primitives.FlyoutShowOptions");
		}
		return s_isFlyoutShowOptionsAvailable.Value;
	}

	public static bool AreInteractionTrackerPointerWheelRedirectionModesAvailable()
	{
		if (!s_areInteractionTrackerPointerWheelRedirectionModesAvailable.HasValue)
		{
			s_areInteractionTrackerPointerWheelRedirectionModesAvailable = IsSystemDll() || IsRS5OrHigher() || (IsRS4OrHigher() && ApiInformation.IsEnumNamedValuePresent("Windows.UI.Composition.Interactions.VisualInteractionSourceRedirectionMode", "PointerWheelOnly"));
		}
		return s_areInteractionTrackerPointerWheelRedirectionModesAvailable.Value;
	}

	public static bool IsScrollViewerReduceViewportForCoreInputViewOcclusionsAvailable()
	{
		if (!s_isScrollViewerReduceViewportForCoreInputViewOcclusionsAvailable.HasValue)
		{
			s_isScrollViewerReduceViewportForCoreInputViewOcclusionsAvailable = IsSystemDll() || Is19H1OrHigher() || ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.ScrollViewer", "ReduceViewportForCoreInputViewOcclusions");
		}
		return s_isScrollViewerReduceViewportForCoreInputViewOcclusionsAvailable.Value;
	}

	public static bool IsScrollContentPresenterSizesContentToTemplatedParentAvailable()
	{
		if (!s_isScrollContentPresenterSizesContentToTemplatedParentAvailable.HasValue)
		{
			s_isScrollContentPresenterSizesContentToTemplatedParentAvailable = IsSystemDll() || Is19H1OrHigher() || ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.ScrollContentPresenter", "SizesContentToTemplatedParent");
		}
		return s_isScrollContentPresenterSizesContentToTemplatedParentAvailable.Value;
	}

	public static bool IsFrameworkElementInvalidateViewportAvailable()
	{
		if (!s_isFrameworkElementInvalidateViewportAvailable.HasValue)
		{
			s_isFrameworkElementInvalidateViewportAvailable = IsSystemDll() || IsRS5OrHigher();
		}
		return s_isFrameworkElementInvalidateViewportAvailable.Value;
	}

	public static bool IsDisplayRegionGetForCurrentViewAvailable()
	{
		if (!s_isDisplayRegionGetForCurrentViewAvailable.HasValue)
		{
			s_isDisplayRegionGetForCurrentViewAvailable = Is19H1OrHigher() || ApiInformation.IsMethodPresent("Windows.ApplicationModel.Core.DisplayRegion", "GetForCurrentView");
		}
		return s_isDisplayRegionGetForCurrentViewAvailable.Value;
	}

	public static bool IsTranslationFacadeAvailable(UIElement element)
	{
		s_areFacadesAvailable = true;
		return s_areFacadesAvailable;
	}

	public static bool IsIconSourceElementAvailable()
	{
		if (!s_IsIconSourceElementAvailable_isAvailable.HasValue)
		{
			s_IsIconSourceElementAvailable_isAvailable = IsSystemDll() || Is19H1OrHigher() || ApiInformation.IsTypePresent("Windows.UI.Xaml.Controls.IconSourceElement");
		}
		return s_IsIconSourceElementAvailable_isAvailable.Value;
	}

	public static bool IsStandardUICommandAvailable()
	{
		if (!s_IsStandardUICommandAvailable_isAvailable.HasValue)
		{
			s_IsStandardUICommandAvailable_isAvailable = IsSystemDll() || Is19H1OrHigher() || (ApiInformation.IsTypePresent("Windows.UI.Xaml.Input.XamlUICommand") && ApiInformation.IsTypePresent("Windows.UI.Xaml.Input.StandardUICommand"));
		}
		return s_IsStandardUICommandAvailable_isAvailable.Value;
	}

	public static bool IsDispatcherQueueAvailable()
	{
		if (!s_IsDispatcherQueueAvailable_isAvailable.HasValue)
		{
			s_IsDispatcherQueueAvailable_isAvailable = IsSystemDll() || IsRS4OrHigher() || ApiInformation.IsTypePresent("Windows.System.DispatcherQueue");
		}
		return s_IsDispatcherQueueAvailable_isAvailable.Value;
	}

	public static bool IsXamlRootAvailable()
	{
		if (!s_IsXamlRootAvailable.HasValue)
		{
			s_IsXamlRootAvailable = IsSystemDll() || IsVanadiumOrHigher() || ApiInformation.IsTypePresent("Windows.UI.Xaml.XamlRoot");
		}
		return s_IsXamlRootAvailable.Value;
	}

	public static bool IsThemeShadowAvailable()
	{
		if (!s_isThemeShadowAvailable.HasValue)
		{
			s_isThemeShadowAvailable = (IsSystemDll() || IsVanadiumOrHigher()) && ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.ThemeShadow");
		}
		return s_isThemeShadowAvailable.Value;
	}

	public static bool IsIsLoadedAvailable()
	{
		if (!s_IsIsLoadedAvailable.HasValue)
		{
			s_IsIsLoadedAvailable = IsSystemDll() || IsRS5OrHigher() || ApiInformation.IsPropertyPresent("Windows.UI.Xaml.FrameworkElement", "IsLoaded");
		}
		return s_IsIsLoadedAvailable.Value;
	}

	public static bool IsAPIContractVxAvailable(ushort apiVersion)
	{
		if (!isApiContractVxAvailable.TryGetValue(apiVersion, out var value))
		{
			value = IsSystemDll() || ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", apiVersion);
			isApiContractVxAvailable[apiVersion] = value;
		}
		return value;
	}

	public static bool IsAPIContractV14Available()
	{
		return IsAPIContractVxAvailable(14);
	}

	public static bool IsAPIContractV9Available()
	{
		return IsAPIContractVxAvailable(9);
	}

	public static bool IsAPIContractV8Available()
	{
		return IsAPIContractVxAvailable(8);
	}

	public static bool IsAPIContractV7Available()
	{
		return IsAPIContractVxAvailable(7);
	}

	public static bool IsAPIContractV6Available()
	{
		return IsAPIContractVxAvailable(6);
	}

	public static bool IsAPIContractV5Available()
	{
		return IsAPIContractVxAvailable(5);
	}

	public static bool IsAPIContractV4Available()
	{
		return IsAPIContractVxAvailable(4);
	}

	public static bool IsAPIContractV3Available()
	{
		return IsAPIContractVxAvailable(3);
	}

	public static bool IsInFrameworkPackage()
	{
		return false;
	}

	public static Rect ConvertDipsToPhysical(UIElement xamlRootReference, Rect dipsRect)
	{
		try
		{
			float num = (float)DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
			Rect result = default(Rect);
			result.X = dipsRect.X * (double)num;
			result.Y = dipsRect.Y * (double)num;
			result.Width = dipsRect.Width * (double)num;
			result.Height = dipsRect.Height * (double)num;
			return result;
		}
		catch (Exception)
		{
			return dipsRect;
		}
	}

	public static Rect ConvertPhysicalToDips(UIElement xamlRootReference, Rect physicalRect)
	{
		try
		{
			float num = (float)DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
			Rect result = default(Rect);
			result.X = physicalRect.X / (double)num;
			result.Y = physicalRect.Y / (double)num;
			result.Width = physicalRect.Width / (double)num;
			result.Height = physicalRect.Height / (double)num;
			return result;
		}
		catch (Exception)
		{
			return physicalRect;
		}
	}

	public static bool IsOnXbox()
	{
		if (!s_isOnXboxInitialized)
		{
			string deviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
			s_isOnXbox = deviceFamily == "Windows.Xbox" || deviceFamily == "Windows.XBoxSRA" || deviceFamily == "Windows.XBoxERA";
			s_isOnXboxInitialized = true;
		}
		return s_isOnXbox;
	}

	public static bool IsMouseModeEnabled()
	{
		if (!s_isMouseModeEnabledInitialized)
		{
			if (IsRS1OrHigher())
			{
				s_isMouseModeEnabled = Application.Current.RequiresPointerMode == ApplicationRequiresPointerMode.Auto;
			}
			else
			{
				s_isMouseModeEnabled = false;
			}
			s_isMouseModeEnabledInitialized = true;
		}
		return s_isMouseModeEnabled;
	}

	public static void ScheduleActionAfterWait(Action action, uint millisecondWait)
	{
		ThreadPoolTimer.CreateTimer(delegate
		{
			new DispatcherHelper().RunAsync(action);
		}, TimeSpan.FromMilliseconds(millisecondWait));
	}

	public static void QueueCallbackForCompositionRendering(Action callback)
	{
		try
		{
			CompositionTarget.Rendering += OnRender;
		}
		catch (Exception)
		{
			throw;
		}
		void OnRender(object sender, object e)
		{
			CompositionTarget.Rendering -= OnRender;
			callback();
		}
	}

	public static bool DoRectsIntersect(Rect rect1, Rect rect2)
	{
		return !(rect1.Width <= 0.0) && !(rect1.Height <= 0.0) && !(rect2.Width <= 0.0) && !(rect2.Height <= 0.0) && rect2.X <= rect1.X + rect1.Width && rect2.X + rect2.Width >= rect1.X && rect2.Y <= rect1.Y + rect1.Height && rect2.Y + rect2.Height >= rect1.Y;
	}

	private object FindResourceOrNull(string resource, ResourceDictionary resources)
	{
		if (!resources.HasKey(resource))
		{
			return null;
		}
		return resources.Lookup((object)resource);
	}

	public static bool IsAncestor(DependencyObject child, DependencyObject parent, bool checkVisibility)
	{
		if (child == null || parent == null || child == parent)
		{
			return false;
		}
		if (checkVisibility)
		{
			if (parent is UIElement uIElement && uIElement.Visibility == Visibility.Collapsed)
			{
				return false;
			}
			if (child is UIElement uIElement2 && uIElement2.Visibility == Visibility.Collapsed)
			{
				return false;
			}
		}
		for (DependencyObject parent2 = VisualTreeHelper.GetParent(child); parent2 != null; parent2 = VisualTreeHelper.GetParent(parent2))
		{
			if (checkVisibility && parent2 is UIElement uIElement3 && uIElement3.Visibility == Visibility.Collapsed)
			{
				return false;
			}
			if (parent2 == parent)
			{
				return true;
			}
		}
		return false;
	}

	public static IconElement MakeIconElementFrom(Microsoft.UI.Xaml.Controls.IconSource iconSource)
	{
		if (iconSource is Microsoft.UI.Xaml.Controls.FontIconSource fontIconSource)
		{
			FontIcon fontIcon = new FontIcon();
			fontIcon.Glyph = fontIconSource.Glyph;
			fontIcon.FontSize = fontIconSource.FontSize;
			if (fontIconSource.FontFamily != null)
			{
				fontIcon.FontFamily = fontIconSource.FontFamily;
			}
			if (fontIconSource.Foreground != null)
			{
				fontIcon.Foreground = fontIconSource.Foreground;
			}
			fontIcon.FontWeight = fontIconSource.FontWeight;
			fontIcon.FontStyle = fontIconSource.FontStyle;
			fontIcon.IsTextScaleFactorEnabled = fontIconSource.IsTextScaleFactorEnabled;
			fontIcon.MirroredWhenRightToLeft = fontIconSource.MirroredWhenRightToLeft;
			return fontIcon;
		}
		if (iconSource is Microsoft.UI.Xaml.Controls.SymbolIconSource symbolIconSource)
		{
			SymbolIcon symbolIcon = new SymbolIcon();
			symbolIcon.Symbol = symbolIconSource.Symbol;
			if (symbolIconSource.Foreground != null)
			{
				symbolIcon.Foreground = symbolIconSource.Foreground;
			}
			return symbolIcon;
		}
		if (iconSource is Microsoft.UI.Xaml.Controls.BitmapIconSource bitmapIconSource)
		{
			BitmapIcon bitmapIcon = new BitmapIcon();
			if (bitmapIconSource.UriSource != null)
			{
				bitmapIcon.UriSource = bitmapIconSource.UriSource;
			}
			if (bitmapIconSource.Foreground != null)
			{
				bitmapIcon.Foreground = bitmapIconSource.Foreground;
			}
			if (IsSystemDll() || ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Controls.BitmapIcon", "ShowAsMonochrome"))
			{
				bitmapIcon.ShowAsMonochrome = bitmapIconSource.ShowAsMonochrome;
			}
			return bitmapIcon;
		}
		if (iconSource is Microsoft.UI.Xaml.Controls.PathIconSource pathIconSource)
		{
			PathIcon pathIcon = new PathIcon();
			if (pathIconSource.Data != null)
			{
				pathIcon.Data = pathIconSource.Data;
			}
			if (pathIconSource.Foreground != null)
			{
				pathIcon.Foreground = pathIconSource.Foreground;
			}
			return pathIcon;
		}
		return null;
	}

	public static void SetBinding(string pathString, DependencyObject target, DependencyProperty targetProperty)
	{
		Binding binding = new Binding();
		RelativeSource relativeSource = new RelativeSource();
		relativeSource.Mode = RelativeSourceMode.TemplatedParent;
		binding.RelativeSource = relativeSource;
		binding.Path = new PropertyPath(pathString);
		BindingOperations.SetBinding(target, targetProperty, binding);
	}

	public static void SetBinding(object source, string pathString, DependencyObject target, DependencyProperty targetProperty, IValueConverter converter = null, BindingMode mode = BindingMode.OneWay)
	{
		Binding binding = new Binding();
		binding.Source = source;
		binding.Path = new PropertyPath(pathString);
		binding.Mode = mode;
		if (converter != null)
		{
			binding.Converter = converter;
		}
		BindingOperations.SetBinding(target, targetProperty, binding);
	}

	public static ITextSelection GetRichTextSelection(RichEditBox richEditBox)
	{
		return richEditBox.Document?.Selection;
	}

	public static VirtualKey GetVirtualKeyFromChar(char c)
	{
		switch (c)
		{
		case 'A':
		case 'a':
			return VirtualKey.A;
		case 'B':
		case 'b':
			return VirtualKey.B;
		case 'C':
		case 'c':
			return VirtualKey.C;
		case 'D':
		case 'd':
			return VirtualKey.D;
		case 'E':
		case 'e':
			return VirtualKey.E;
		case 'F':
		case 'f':
			return VirtualKey.F;
		case 'G':
		case 'g':
			return VirtualKey.G;
		case 'H':
		case 'h':
			return VirtualKey.H;
		case 'I':
		case 'i':
			return VirtualKey.I;
		case 'J':
		case 'j':
			return VirtualKey.J;
		case 'K':
		case 'k':
			return VirtualKey.K;
		case 'L':
		case 'l':
			return VirtualKey.L;
		case 'M':
		case 'm':
			return VirtualKey.M;
		case 'N':
		case 'n':
			return VirtualKey.N;
		case 'O':
		case 'o':
			return VirtualKey.O;
		case 'P':
		case 'p':
			return VirtualKey.P;
		case 'Q':
		case 'q':
			return VirtualKey.Q;
		case 'R':
		case 'r':
			return VirtualKey.R;
		case 'S':
		case 's':
			return VirtualKey.S;
		case 'T':
		case 't':
			return VirtualKey.T;
		case 'U':
		case 'u':
			return VirtualKey.U;
		case 'V':
		case 'v':
			return VirtualKey.V;
		case 'W':
		case 'w':
			return VirtualKey.W;
		case 'X':
		case 'x':
			return VirtualKey.X;
		case 'Y':
		case 'y':
			return VirtualKey.Y;
		case 'Z':
		case 'z':
			return VirtualKey.Z;
		default:
			return VirtualKey.None;
		}
	}

	public static object FindResource(string resource, ResourceDictionary resources, object defaultValue)
	{
		if (!resources.HasKey(resource))
		{
			return defaultValue;
		}
		return resources.Lookup(resource);
	}

	public static object FindInApplicationResources(string resource)
	{
		return FindInApplicationResources(resource, null);
	}

	public static object FindInApplicationResources(string resource, object defaultValue)
	{
		return FindResource(resource, Application.Current.Resources, defaultValue);
	}

	public static FrameworkElement FindInVisualTreeByName(FrameworkElement parent, string name)
	{
		return FindInVisualTree(parent, (FrameworkElement element) => element.Name == name);
	}

	public static T FindInVisualTreeByType<T>(FrameworkElement parent) where T : class
	{
		FrameworkElement frameworkElement = FindInVisualTree(parent, (FrameworkElement element) => element is T);
		return frameworkElement as T;
	}

	public static FrameworkElement FindInVisualTree(FrameworkElement parent, Func<FrameworkElement, bool> isMatch)
	{
		return FindInVisualTreeInner(parent, isMatch);
		static FrameworkElement FindInVisualTreeInner(DependencyObject parent, Func<FrameworkElement, bool> isMatch)
		{
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			if (parent is FrameworkElement frameworkElement && isMatch(frameworkElement))
			{
				return frameworkElement;
			}
			for (int i = 0; i < childrenCount; i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				if (child != null)
				{
					FrameworkElement frameworkElement2 = FindInVisualTreeInner(child, isMatch);
					if (frameworkElement2 != null)
					{
						return frameworkElement2;
					}
				}
			}
			return null;
		}
	}

	public static bool IsTrue(bool? nullableBool)
	{
		if (nullableBool.HasValue)
		{
			return nullableBool.Value;
		}
		return false;
	}

	public static string TryGetStringRepresentationFromObject(object obj)
	{
		string text = "";
		if (obj != null)
		{
			if (obj is IStringable stringable)
			{
				text = stringable.ToString();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = obj?.ToString() ?? text;
			}
		}
		return text;
	}

	public static AncestorType GetAncestorOfType<AncestorType>(DependencyObject firstGuess) where AncestorType : class
	{
		DependencyObject dependencyObject = firstGuess;
		AncestorType val = null;
		while (dependencyObject != null && val == null)
		{
			val = dependencyObject as AncestorType;
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
		}
		if (val != null)
		{
			return val;
		}
		return null;
	}
}
