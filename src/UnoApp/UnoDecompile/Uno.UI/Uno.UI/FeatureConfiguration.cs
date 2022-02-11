using System;
using System.Collections.Generic;
using System.ComponentModel;
using Uno.Foundation.Logging;
using Uno.UI.Xaml.Controls;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace Uno.UI;

public static class FeatureConfiguration
{
	public static class ApiInformation
	{
		public static bool IsFailWhenNotImplemented
		{
			get
			{
				return Windows.Foundation.Metadata.ApiInformation.IsFailWhenNotImplemented;
			}
			set
			{
				Windows.Foundation.Metadata.ApiInformation.IsFailWhenNotImplemented = value;
			}
		}

		public static bool AlwaysLogNotImplementedMessages
		{
			get
			{
				return Windows.Foundation.Metadata.ApiInformation.AlwaysLogNotImplementedMessages;
			}
			set
			{
				Windows.Foundation.Metadata.ApiInformation.AlwaysLogNotImplementedMessages = value;
			}
		}

		public static LogLevel NotImplementedLogLevel
		{
			get
			{
				return Windows.Foundation.Metadata.ApiInformation.NotImplementedLogLevel;
			}
			set
			{
				Windows.Foundation.Metadata.ApiInformation.NotImplementedLogLevel = value;
			}
		}
	}

	public static class AutomationPeer
	{
		public static bool UseSimpleAccessibility { get; set; }
	}

	public static class ComboBox
	{
		public static DropDownPlacement DefaultDropDownPreferredPlacement { get; set; }
	}

	public static class CompositionTarget
	{
		public static int RenderEventThrottle { get; set; } = 30;

	}

	public static class ContentPresenter
	{
		public static bool UseImplicitContentFromTemplatedParent { get; set; }
	}

	public static class Control
	{
		public static bool UseLegacyContentAlignment { get; set; } = false;


		public static bool UseLegacyLazyApplyTemplate { get; set; } = false;


		public static bool UseDeferredOnApplyTemplate { get; set; } = true;

	}

	public static class DataTemplateSelector
	{
		public static bool UseLegacyTemplateSelectorOverload { get; set; }
	}

	public static class DependencyObject
	{
		public static bool IsStoreHardReferenceEnabled { get; set; } = true;

	}

	public static class Font
	{
		public static string SymbolsFont { get; set; } = "Symbols";


		public static bool IgnoreTextScaleFactor { get; set; } = false;

	}

	public static class FrameworkElement
	{
		[Obsolete("This flag is no longer used.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool UseLegacyApplyStylePhase { get; set; }

		[Obsolete("This flag is no longer used.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool ClearPreviousOnStyleChange { get; set; }

		public static bool WasmUseManagedLoadedUnloaded { get; set; } = true;


		public static bool HandleLoadUnloadExceptions { get; set; } = true;

	}

	public static class Image
	{
		public static bool LegacyIosAlignment { get; set; }
	}

	public static class Interop
	{
		public static bool ForceJavascriptInterop { get; set; }
	}

	public static class Binding
	{
		public static bool IgnoreINPCSameReferences { get; set; }
	}

	public static class BindingExpression
	{
		public static bool HandleSetTargetValueExceptions { get; set; } = true;

	}

	public static class Popup
	{
	}

	public static class ProgressRing
	{
		public static Uri ProgressRingAsset { get; set; } = new Uri("embedded://Uno.UI/Uno.UI.Microsoft.UI.Xaml.Controls.ProgressRing.ProgressRingIntdeterminate.json");


		public static Uri DeterminateProgressRingAsset { get; set; } = new Uri("embedded://Uno.UI/Uno.UI.Microsoft.UI.Xaml.Controls.ProgressRing.ProgressRingDeterminate.json");

	}

	public static class ListViewBase
	{
		public static double? DefaultCacheLength = 1.0;
	}

	public static class Page
	{
		public static bool IsPoolingEnabled { get; set; }
	}

	public static class PointerRoutedEventArgs
	{
	}

	public static class SelectorItem
	{
		public static bool UseOverStates { get; set; } = true;

	}

	public static class Style
	{
		public static bool UseUWPDefaultStyles { get; set; } = true;


		public static IDictionary<Type, bool> UseUWPDefaultStylesOverride { get; } = new Dictionary<Type, bool>();


		public static void ConfigureNativeFrameNavigation()
		{
			SetUWPDefaultStylesOverride<Frame>(useUWPDefaultStyle: false);
			SetUWPDefaultStylesOverride<Windows.UI.Xaml.Controls.CommandBar>(useUWPDefaultStyle: false);
			SetUWPDefaultStylesOverride<Windows.UI.Xaml.Controls.AppBarButton>(useUWPDefaultStyle: false);
		}

		public static void SetUWPDefaultStylesOverride<TControl>(bool useUWPDefaultStyle) where TControl : Windows.UI.Xaml.Controls.Control
		{
			UseUWPDefaultStylesOverride[typeof(TControl)] = useUWPDefaultStyle;
		}
	}

	public static class TextBlock
	{
		public static bool IsMeasureCacheEnabled { get; set; } = true;

	}

	public static class TextBox
	{
		public static bool HideCaret { get; set; }
	}

	public static class ScrollViewer
	{
		public static ScrollViewerUpdatesMode DefaultUpdatesMode { get; set; } = ScrollViewerUpdatesMode.AsynchronousIdle;


		public static TimeSpan? DefaultAutoHideDelay { get; set; }
	}

	public static class ThemeAnimation
	{
		public static TimeSpan DefaultThemeAnimationDuration { get; set; } = TimeSpan.FromSeconds(0.75);

	}

	public static class ToolTip
	{
		public static bool UseToolTips { get; set; } = true;


		public static int ShowDelay { get; set; } = 1000;


		public static int ShowDuration { get; set; } = 7000;

	}

	public static class NativeFramePresenter
	{
	}

	public static class UIElement
	{
		[NotImplemented]
		public static bool UseLegacyClipping { get; set; } = true;


		public static bool ShowClippingBounds { get; set; } = false;


		public static bool AssignDOMXamlName { get; set; } = false;


		public static bool RenderToStringWithId { get; set; } = true;


		public static bool AssignDOMXamlProperties { get; set; } = false;

	}

	public static class VisualState
	{
		public static bool ApplySettersBeforeTransition { get; set; }
	}

	public static class WebView
	{
	}

	public static class Xaml
	{
		[Obsolete("This flag is no longer used.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int MaxRecursiveResolvingDepth { get; set; } = 12;

	}

	public static class DatePicker
	{
	}

	public static class TimePicker
	{
	}

	public static class CommandBar
	{
	}

	public static class AppBarButton
	{
	}

	public static class Cursors
	{
		public static bool UseHandForInteraction { get; set; } = true;

	}
}
