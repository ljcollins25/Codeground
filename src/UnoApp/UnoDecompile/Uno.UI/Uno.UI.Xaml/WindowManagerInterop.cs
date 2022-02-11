using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Foundation.Interop;
using Windows.Foundation;
using Windows.UI;

namespace Uno.UI.Xaml;

internal class WindowManagerInterop
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerInitParams
	{
		public bool IsHostedMode;

		public bool IsLoadEventsEnabled;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerCreateContentParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string TagName;

		public IntPtr Handle;

		public int UIElementRegistrationId;

		public bool IsSvg;

		public bool IsFocusable;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRegisterUIElementParams
	{
		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string TypeName;

		public bool IsFrameworkElement;

		public int Classes_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
		public string[] Classes;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRegisterUIElementReturn
	{
		public int RegistrationId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerSetElementTransformParams
	{
		public IntPtr HtmlId;

		public double M11;

		public double M12;

		public double M21;

		public double M22;

		public double M31;

		public double M32;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetPointerEventsParams
	{
		public IntPtr HtmlId;

		public bool Enabled;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerMeasureViewParams
	{
		public IntPtr HtmlId;

		public double AvailableWidth;

		public double AvailableHeight;

		public bool MeasureContent;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerMeasureViewReturn
	{
		public double DesiredWidth;

		public double DesiredHeight;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetStyleDoubleParams
	{
		public IntPtr HtmlId;

		public string Name;

		public double Value;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerSetSvgElementRectParams
	{
		public double X;

		public double Y;

		public double Width;

		public double Height;

		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetStylesParams
	{
		public IntPtr HtmlId;

		public int Pairs_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] Pairs;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetUnsetClassesParams
	{
		public IntPtr HtmlId;

		public int CssClassesToSet_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] CssClassesToSet;

		public int CssClassesToUnset_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] CssClassesToUnset;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetClassesParams
	{
		public IntPtr HtmlId;

		public int CssClasses_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
		public string[] CssClasses;

		public int Index;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerAddViewParams
	{
		public IntPtr HtmlId;

		public IntPtr ChildView;

		public int Index;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetAttributesParams
	{
		public IntPtr HtmlId;

		public int Pairs_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
		public string[] Pairs;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetAttributeParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Name;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Value;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRemoveAttributeParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Name;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetNameParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Name;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetXUidParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Uid;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetVisibilityParams
	{
		public IntPtr HtmlId;

		public bool Visible;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetPropertyParams
	{
		public IntPtr HtmlId;

		public int Pairs_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
		public string[] Pairs;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetElementColorParams
	{
		public IntPtr HtmlId;

		public uint Color;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRemoveViewParams
	{
		public IntPtr HtmlId;

		public IntPtr ChildView;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerDestroyViewParams
	{
		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerResetStyleParams
	{
		public IntPtr HtmlId;

		public int Styles_Length;

		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
		public string[] Styles;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRegisterEventOnViewParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string EventName;

		public bool OnCapturePhase;

		public int EventExtractorId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerRegisterPointerEventsOnViewParams
	{
		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerGetBBoxParams
	{
		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerGetBBoxReturn
	{
		public double X;

		public double Y;

		public double Width;

		public double Height;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetContentHtmlParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string Html;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerArrangeElementParams
	{
		public double Top;

		public double Left;

		public double Width;

		public double Height;

		public double ClipTop;

		public double ClipLeft;

		public double ClipBottom;

		public double ClipRight;

		public IntPtr HtmlId;

		public bool Clip;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerGetClientViewSizeParams
	{
		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[TSInteropMessage]
	private struct WindowManagerGetClientViewSizeReturn
	{
		public double OffsetWidth;

		public double OffsetHeight;

		public double ClientWidth;

		public double ClientHeight;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerScrollToOptionsParams
	{
		public double Left;

		public double Top;

		public bool HasLeft;

		public bool HasTop;

		public bool DisableAnimation;

		public IntPtr HtmlId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetElementBackgroundColorParams
	{
		public IntPtr HtmlId;

		public uint Color;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerSetElementBackgroundGradientParams
	{
		public IntPtr HtmlId;

		[MarshalAs(UnmanagedType.LPUTF8Str)]
		public string CssGradient;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[TSInteropMessage]
	private struct WindowManagerResetElementBackgroundParams
	{
		public IntPtr HtmlId;
	}

	[Flags]
	internal enum HtmlPointerButtonsState
	{
		None = 0,
		Left = 1,
		Middle = 4,
		Right = 2,
		X1 = 8,
		X2 = 0x10,
		Eraser = 0x20
	}

	internal enum HtmlPointerButtonUpdate
	{
		None = -1,
		Left,
		Middle,
		Right,
		X1,
		X2,
		Eraser
	}

	private const double MAX_SCROLLING_OFFSET = 1E+18;

	private static bool UseJavascriptEval
	{
		get
		{
			if (WebAssemblyRuntime.IsWebAssembly)
			{
				return FeatureConfiguration.Interop.ForceJavascriptInterop;
			}
			return true;
		}
	}

	internal static void Init(bool isHostedMode, bool isLoadEventsEnabled)
	{
		if (UseJavascriptEval)
		{
			WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.init(" + isHostedMode.ToString().ToLowerInvariant() + ", " + isLoadEventsEnabled.ToString().ToLowerInvariant() + ");");
		}
		else
		{
			WindowManagerInitParams windowManagerInitParams = default(WindowManagerInitParams);
			windowManagerInitParams.IsHostedMode = isHostedMode;
			windowManagerInitParams.IsLoadEventsEnabled = isLoadEventsEnabled;
			WindowManagerInitParams windowManagerInitParams2 = windowManagerInitParams;
			TSInteropMarshaller.InvokeJS("UnoStatic:initNative", windowManagerInitParams2, "Init");
		}
	}

	internal static void CreateContent(IntPtr htmlId, string htmlTag, IntPtr handle, int uiElementRegistrationId, bool htmlTagIsSvg, bool isFocusable)
	{
		if (UseJavascriptEval)
		{
			string text = (htmlTagIsSvg ? "true" : "false");
			string text2 = (isFocusable ? "true" : "false");
			WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.createContent({id:\"" + htmlId + "\",tagName:\"" + htmlTag + "\", handle:" + handle + ", uiElementRegistrationId: " + uiElementRegistrationId + ", isSvg:" + text + ", isFocusable:" + text2 + "});");
		}
		else
		{
			WindowManagerCreateContentParams windowManagerCreateContentParams = default(WindowManagerCreateContentParams);
			windowManagerCreateContentParams.HtmlId = htmlId;
			windowManagerCreateContentParams.TagName = htmlTag;
			windowManagerCreateContentParams.Handle = handle;
			windowManagerCreateContentParams.UIElementRegistrationId = uiElementRegistrationId;
			windowManagerCreateContentParams.IsSvg = htmlTagIsSvg;
			windowManagerCreateContentParams.IsFocusable = isFocusable;
			WindowManagerCreateContentParams windowManagerCreateContentParams2 = windowManagerCreateContentParams;
			TSInteropMarshaller.InvokeJS("Uno:createContentNative", windowManagerCreateContentParams2, "CreateContent");
		}
	}

	internal static int RegisterUIElement(string typeName, string[] classNames, bool isFrameworkElement)
	{
		if (UseJavascriptEval)
		{
			string text = (isFrameworkElement ? "true" : "false");
			string text2 = classNames.Select((string c) => "\"" + c + "\"").JoinBy(",");
			string s = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.registerUIElement({typeName:\"" + typeName + "\",isFrameworkElement:" + text + ", classes:[" + text2 + "]});");
			return int.Parse(s);
		}
		WindowManagerRegisterUIElementParams windowManagerRegisterUIElementParams = default(WindowManagerRegisterUIElementParams);
		windowManagerRegisterUIElementParams.TypeName = typeName;
		windowManagerRegisterUIElementParams.IsFrameworkElement = isFrameworkElement;
		windowManagerRegisterUIElementParams.Classes_Length = classNames.Length;
		windowManagerRegisterUIElementParams.Classes = classNames;
		WindowManagerRegisterUIElementParams windowManagerRegisterUIElementParams2 = windowManagerRegisterUIElementParams;
		return ((WindowManagerRegisterUIElementReturn)TSInteropMarshaller.InvokeJS("Uno:registerUIElementNative", windowManagerRegisterUIElementParams2, typeof(WindowManagerRegisterUIElementReturn), "RegisterUIElement")).RegistrationId;
	}

	internal static void SetElementTransform(IntPtr htmlId, Matrix3x2 matrix)
	{
		if (UseJavascriptEval)
		{
			FormattableString number = $"matrix({matrix.M11},{matrix.M12},{matrix.M21},{matrix.M22},{matrix.M31},{matrix.M32})";
			SetStyles(htmlId, new(string, string)[1] { ("transform", number.ToStringInvariant()) });
			SetArrangeProperties(htmlId);
		}
		else
		{
			WindowManagerSetElementTransformParams windowManagerSetElementTransformParams = default(WindowManagerSetElementTransformParams);
			windowManagerSetElementTransformParams.HtmlId = htmlId;
			windowManagerSetElementTransformParams.M11 = matrix.M11;
			windowManagerSetElementTransformParams.M12 = matrix.M12;
			windowManagerSetElementTransformParams.M21 = matrix.M21;
			windowManagerSetElementTransformParams.M22 = matrix.M22;
			windowManagerSetElementTransformParams.M31 = matrix.M31;
			windowManagerSetElementTransformParams.M32 = matrix.M32;
			WindowManagerSetElementTransformParams windowManagerSetElementTransformParams2 = windowManagerSetElementTransformParams;
			TSInteropMarshaller.InvokeJS("Uno:setElementTransformNative", windowManagerSetElementTransformParams2, "SetElementTransform");
		}
	}

	internal static void SetPointerEvents(IntPtr htmlId, bool enabled)
	{
		if (UseJavascriptEval)
		{
			string text = (enabled ? "true" : "false");
			string str = "Uno.UI.WindowManager.current.setPointerEvents(" + htmlId + ", " + text + ");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerSetPointerEventsParams windowManagerSetPointerEventsParams = default(WindowManagerSetPointerEventsParams);
			windowManagerSetPointerEventsParams.HtmlId = htmlId;
			windowManagerSetPointerEventsParams.Enabled = enabled;
			WindowManagerSetPointerEventsParams windowManagerSetPointerEventsParams2 = windowManagerSetPointerEventsParams;
			TSInteropMarshaller.InvokeJS("Uno:setPointerEventsNative", windowManagerSetPointerEventsParams2, "SetPointerEvents");
		}
	}

	internal static Size MeasureView(IntPtr htmlId, Size availableSize, bool measureContent)
	{
		if (UseJavascriptEval)
		{
			string text = (double.IsInfinity(availableSize.Width) ? "null" : availableSize.Width.ToStringInvariant());
			string text2 = (double.IsInfinity(availableSize.Height) ? "null" : availableSize.Height.ToStringInvariant());
			string text3 = (measureContent ? "true" : "false");
			string str = "Uno.UI.WindowManager.current.measureView(" + htmlId + ", \"" + text + "\", \"" + text2 + "\", " + text3 + ");";
			string text4 = WebAssemblyRuntime.InvokeJS(str);
			string[] array = text4.Split(new char[1] { ';' });
			return new Size(double.Parse(array[0], CultureInfo.InvariantCulture), double.Parse(array[1], CultureInfo.InvariantCulture));
		}
		WindowManagerMeasureViewParams windowManagerMeasureViewParams = default(WindowManagerMeasureViewParams);
		windowManagerMeasureViewParams.HtmlId = htmlId;
		windowManagerMeasureViewParams.AvailableWidth = availableSize.Width;
		windowManagerMeasureViewParams.AvailableHeight = availableSize.Height;
		windowManagerMeasureViewParams.MeasureContent = measureContent;
		WindowManagerMeasureViewParams windowManagerMeasureViewParams2 = windowManagerMeasureViewParams;
		WindowManagerMeasureViewReturn windowManagerMeasureViewReturn = (WindowManagerMeasureViewReturn)TSInteropMarshaller.InvokeJS("Uno:measureViewNative", windowManagerMeasureViewParams2, typeof(WindowManagerMeasureViewReturn), "MeasureView");
		return new Size(windowManagerMeasureViewReturn.DesiredWidth, windowManagerMeasureViewReturn.DesiredHeight);
	}

	internal static void SetStyleDouble(IntPtr htmlId, string name, double value)
	{
		if (UseJavascriptEval)
		{
			SetStyles(htmlId, new(string, string)[1] { (name, value.ToString(CultureInfo.InvariantCulture)) });
			return;
		}
		WindowManagerSetStyleDoubleParams windowManagerSetStyleDoubleParams = default(WindowManagerSetStyleDoubleParams);
		windowManagerSetStyleDoubleParams.HtmlId = htmlId;
		windowManagerSetStyleDoubleParams.Name = name;
		windowManagerSetStyleDoubleParams.Value = value;
		WindowManagerSetStyleDoubleParams windowManagerSetStyleDoubleParams2 = windowManagerSetStyleDoubleParams;
		TSInteropMarshaller.InvokeJS("Uno:setStyleDoubleNative", windowManagerSetStyleDoubleParams2, "SetStyleDouble");
	}

	internal static void SetSvgElementRect(IntPtr htmlId, Rect rect)
	{
		if (UseJavascriptEval)
		{
			SetAttributes(htmlId, new(string, string)[4]
			{
				("x", rect.X.ToStringInvariant()),
				("y", rect.Y.ToStringInvariant()),
				("width", rect.Width.ToStringInvariant()),
				("height", rect.Height.ToStringInvariant())
			});
		}
		else
		{
			WindowManagerSetSvgElementRectParams windowManagerSetSvgElementRectParams = default(WindowManagerSetSvgElementRectParams);
			windowManagerSetSvgElementRectParams.HtmlId = htmlId;
			windowManagerSetSvgElementRectParams.X = rect.X;
			windowManagerSetSvgElementRectParams.Y = rect.Y;
			windowManagerSetSvgElementRectParams.Width = rect.Width;
			windowManagerSetSvgElementRectParams.Height = rect.Height;
			WindowManagerSetSvgElementRectParams windowManagerSetSvgElementRectParams2 = windowManagerSetSvgElementRectParams;
			TSInteropMarshaller.InvokeJS("Uno:setSvgElementRect", windowManagerSetSvgElementRectParams2, "SetSvgElementRect");
		}
	}

	internal static void SetStyles(IntPtr htmlId, (string name, string value)[] styles)
	{
		if (UseJavascriptEval)
		{
			string text = string.Join(", ", styles.Select(((string name, string value) s) => "\"" + s.name + "\": \"" + WebAssemblyRuntime.EscapeJs(s.value) + "\""));
			string str = "Uno.UI.WindowManager.current.setStyle(\"" + htmlId + "\", {" + text + "}); ";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			string[] array = new string[styles.Length * 2];
			for (int i = 0; i < styles.Length; i++)
			{
				array[i * 2] = styles[i].name;
				array[i * 2 + 1] = styles[i].value;
			}
			WindowManagerSetStylesParams windowManagerSetStylesParams = default(WindowManagerSetStylesParams);
			windowManagerSetStylesParams.HtmlId = htmlId;
			windowManagerSetStylesParams.Pairs_Length = array.Length;
			windowManagerSetStylesParams.Pairs = array;
			WindowManagerSetStylesParams windowManagerSetStylesParams2 = windowManagerSetStylesParams;
			TSInteropMarshaller.InvokeJS("Uno:setStyleNative", windowManagerSetStylesParams2, "SetStyles");
		}
	}

	internal static bool IsCssFeatureSupported(string propertyName, string value)
	{
		string str = "Uno.UI.WindowManager.current.isCssPropertySupported(\"" + propertyName + "\", \"" + WebAssemblyRuntime.EscapeJs(value) + "\")";
		string value2 = WebAssemblyRuntime.InvokeJS(str);
		return bool.Parse(value2);
	}

	internal static bool IsCssFeatureSupported(string supportCondition)
	{
		string str = "Uno.UI.WindowManager.current.isCssConditionSupported(\"" + WebAssemblyRuntime.EscapeJs(supportCondition) + "\")";
		string value = WebAssemblyRuntime.InvokeJS(str);
		return bool.Parse(value);
	}

	private static void SetArrangeProperties(IntPtr htmlId)
	{
		if (!UseJavascriptEval)
		{
			throw new InvalidOperationException("This should only be called when UseJavascriptEval flag is set");
		}
		string str = "Uno.UI.WindowManager.current.setArrangeProperties(\"" + htmlId + "\"); ";
		WebAssemblyRuntime.InvokeJS(str);
	}

	internal static void SetUnsetCssClasses(IntPtr htmlId, string[] cssClassesToSet, string[] cssClassesToUnset)
	{
		if (UseJavascriptEval)
		{
			string text = ((cssClassesToSet == null) ? "null" : ("[" + string.Join(", ", from s in cssClassesToSet.Select(new Func<string, string>(WebAssemblyRuntime.EscapeJs))
				select "\"" + s + "\"") + "]"));
			string text2 = ((cssClassesToUnset == null) ? "null" : ("[" + string.Join(", ", from s in cssClassesToUnset.Select(new Func<string, string>(WebAssemblyRuntime.EscapeJs))
				select "\"" + s + "\"") + "]"));
			string str = "Uno.UI.WindowManager.current.setUnsetClasses(" + htmlId + ", " + text + ", " + text2 + ");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerSetUnsetClassesParams windowManagerSetUnsetClassesParams = default(WindowManagerSetUnsetClassesParams);
			windowManagerSetUnsetClassesParams.HtmlId = htmlId;
			windowManagerSetUnsetClassesParams.CssClassesToSet = cssClassesToSet;
			windowManagerSetUnsetClassesParams.CssClassesToSet_Length = ((cssClassesToSet != null) ? cssClassesToSet.Length : 0);
			windowManagerSetUnsetClassesParams.CssClassesToUnset = cssClassesToUnset;
			windowManagerSetUnsetClassesParams.CssClassesToUnset_Length = ((cssClassesToUnset != null) ? cssClassesToUnset.Length : 0);
			WindowManagerSetUnsetClassesParams windowManagerSetUnsetClassesParams2 = windowManagerSetUnsetClassesParams;
			TSInteropMarshaller.InvokeJS("Uno:setUnsetClassesNative", windowManagerSetUnsetClassesParams2, "SetUnsetCssClasses");
		}
	}

	internal static void SetClasses(IntPtr htmlId, string[] cssClasses, int index)
	{
		if (UseJavascriptEval)
		{
			string text = string.Join(", ", cssClasses.Select((string s) => "\"" + s + "\""));
			string str = "Uno.UI.WindowManager.current.setClasses(" + htmlId + ", [" + text + "], " + index + ");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerSetClassesParams windowManagerSetClassesParams = default(WindowManagerSetClassesParams);
			windowManagerSetClassesParams.HtmlId = htmlId;
			windowManagerSetClassesParams.CssClasses = cssClasses;
			windowManagerSetClassesParams.CssClasses_Length = cssClasses.Length;
			windowManagerSetClassesParams.Index = index;
			WindowManagerSetClassesParams windowManagerSetClassesParams2 = windowManagerSetClassesParams;
			TSInteropMarshaller.InvokeJS("Uno:setClassesNative", windowManagerSetClassesParams2, "SetClasses");
		}
	}

	internal static void AddView(IntPtr htmlId, IntPtr child, int? index = null)
	{
		if (UseJavascriptEval)
		{
			if (index.HasValue)
			{
				string str = "Uno.UI.WindowManager.current.addView(" + htmlId + ", " + child + ", " + index.Value + ");";
				WebAssemblyRuntime.InvokeJS(str);
			}
			else
			{
				string str2 = "Uno.UI.WindowManager.current.addView(" + htmlId + ", " + child + ");";
				WebAssemblyRuntime.InvokeJS(str2);
			}
		}
		else
		{
			WindowManagerAddViewParams windowManagerAddViewParams = default(WindowManagerAddViewParams);
			windowManagerAddViewParams.HtmlId = htmlId;
			windowManagerAddViewParams.ChildView = child;
			windowManagerAddViewParams.Index = index ?? (-1);
			WindowManagerAddViewParams windowManagerAddViewParams2 = windowManagerAddViewParams;
			TSInteropMarshaller.InvokeJS("Uno:addViewNative", windowManagerAddViewParams2, "AddView");
		}
	}

	internal static void SetAttributes(IntPtr htmlId, (string name, string value)[] attributes)
	{
		if (UseJavascriptEval)
		{
			string text = string.Join(", ", attributes.Select(((string name, string value) s) => "\"" + s.name + "\": \"" + WebAssemblyRuntime.EscapeJs(s.value) + "\""));
			string str = "Uno.UI.WindowManager.current.setAttributes(\"" + htmlId + "\", {" + text + "});";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			string[] array = new string[attributes.Length * 2];
			for (int i = 0; i < attributes.Length; i++)
			{
				array[i * 2] = attributes[i].name;
				array[i * 2 + 1] = attributes[i].value;
			}
			WindowManagerSetAttributesParams windowManagerSetAttributesParams = default(WindowManagerSetAttributesParams);
			windowManagerSetAttributesParams.HtmlId = htmlId;
			windowManagerSetAttributesParams.Pairs_Length = array.Length;
			windowManagerSetAttributesParams.Pairs = array;
			WindowManagerSetAttributesParams windowManagerSetAttributesParams2 = windowManagerSetAttributesParams;
			TSInteropMarshaller.InvokeJS("Uno:setAttributesNative", windowManagerSetAttributesParams2, "SetAttributes");
		}
	}

	internal static void SetAttribute(IntPtr htmlId, string name, string value)
	{
		if (UseJavascriptEval)
		{
			string text = "\"" + name + "\": \"" + WebAssemblyRuntime.EscapeJs(value) + "\"";
			string str = "Uno.UI.WindowManager.current.setAttributes(\"" + htmlId + "\", {" + text + "});";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerSetAttributeParams windowManagerSetAttributeParams = default(WindowManagerSetAttributeParams);
			windowManagerSetAttributeParams.HtmlId = htmlId;
			windowManagerSetAttributeParams.Name = name;
			windowManagerSetAttributeParams.Value = value;
			WindowManagerSetAttributeParams windowManagerSetAttributeParams2 = windowManagerSetAttributeParams;
			TSInteropMarshaller.InvokeJS("Uno:setAttributeNative", windowManagerSetAttributeParams2, "SetAttribute");
		}
	}

	internal static string GetAttribute(IntPtr htmlId, string name)
	{
		string str = "Uno.UI.WindowManager.current.getAttribute(\"" + htmlId + "\", \"" + name + "\");";
		return WebAssemblyRuntime.InvokeJS(str);
	}

	internal static void RemoveAttribute(IntPtr htmlId, string name)
	{
		if (UseJavascriptEval)
		{
			string str = "Uno.UI.WindowManager.current.removeAttribute(\"" + htmlId + "\", \"" + name + "\");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerRemoveAttributeParams windowManagerRemoveAttributeParams = default(WindowManagerRemoveAttributeParams);
			windowManagerRemoveAttributeParams.HtmlId = htmlId;
			windowManagerRemoveAttributeParams.Name = name;
			WindowManagerRemoveAttributeParams windowManagerRemoveAttributeParams2 = windowManagerRemoveAttributeParams;
			TSInteropMarshaller.InvokeJS("Uno:removeAttributeNative", windowManagerRemoveAttributeParams2, "RemoveAttribute");
		}
	}

	internal static void SetName(IntPtr htmlId, string name)
	{
		if (UseJavascriptEval)
		{
			string str = $"Uno.UI.WindowManager.current.setName(\"{htmlId}\", \"{name}\");";
			WebAssemblyRuntime.InvokeJS(str);
			return;
		}
		WindowManagerSetNameParams windowManagerSetNameParams = default(WindowManagerSetNameParams);
		windowManagerSetNameParams.HtmlId = htmlId;
		windowManagerSetNameParams.Name = name;
		WindowManagerSetNameParams windowManagerSetNameParams2 = windowManagerSetNameParams;
		TSInteropMarshaller.InvokeJS("Uno:setNameNative", windowManagerSetNameParams2, "SetName");
	}

	internal static void SetXUid(IntPtr htmlId, string name)
	{
		if (UseJavascriptEval)
		{
			string str = $"Uno.UI.WindowManager.current.setXUid(\"{htmlId}\", \"{name}\");";
			WebAssemblyRuntime.InvokeJS(str);
			return;
		}
		WindowManagerSetXUidParams windowManagerSetXUidParams = default(WindowManagerSetXUidParams);
		windowManagerSetXUidParams.HtmlId = htmlId;
		windowManagerSetXUidParams.Uid = name;
		WindowManagerSetXUidParams windowManagerSetXUidParams2 = windowManagerSetXUidParams;
		TSInteropMarshaller.InvokeJS("Uno:setXUidNative", windowManagerSetXUidParams2, "SetXUid");
	}

	internal static void SetVisibility(IntPtr htmlId, bool visible)
	{
		if (UseJavascriptEval)
		{
			string str = $"Uno.UI.WindowManager.current.setVisibility(\"{htmlId}\", {visible});";
			WebAssemblyRuntime.InvokeJS(str);
			return;
		}
		WindowManagerSetVisibilityParams windowManagerSetVisibilityParams = default(WindowManagerSetVisibilityParams);
		windowManagerSetVisibilityParams.HtmlId = htmlId;
		windowManagerSetVisibilityParams.Visible = visible;
		WindowManagerSetVisibilityParams windowManagerSetVisibilityParams2 = windowManagerSetVisibilityParams;
		TSInteropMarshaller.InvokeJS("Uno:setVisibilityNative", windowManagerSetVisibilityParams2, "SetVisibility");
	}

	internal static void SetProperty(IntPtr htmlId, (string name, string value)[] properties)
	{
		if (UseJavascriptEval)
		{
			string text = string.Join(", ", properties.Select(((string name, string value) s) => "\"" + s.name + "\": \"" + WebAssemblyRuntime.EscapeJs(s.value) + "\""));
			string str = "Uno.UI.WindowManager.current.setProperty(\"" + htmlId + "\", {" + text + "});";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			string[] array = new string[properties.Length * 2];
			for (int i = 0; i < properties.Length; i++)
			{
				array[i * 2] = properties[i].name;
				array[i * 2 + 1] = properties[i].value;
			}
			WindowManagerSetAttributesParams windowManagerSetAttributesParams = default(WindowManagerSetAttributesParams);
			windowManagerSetAttributesParams.HtmlId = htmlId;
			windowManagerSetAttributesParams.Pairs_Length = array.Length;
			windowManagerSetAttributesParams.Pairs = array;
			WindowManagerSetAttributesParams windowManagerSetAttributesParams2 = windowManagerSetAttributesParams;
			TSInteropMarshaller.InvokeJS("Uno:setPropertyNative", windowManagerSetAttributesParams2, "SetProperty");
		}
	}

	internal static void SetElementColor(IntPtr htmlId, Color color)
	{
		uint color2 = color.ToCssInteger();
		if (UseJavascriptEval)
		{
			string str = $"Uno.UI.WindowManager.current.setElementColor(\"{htmlId}\", {color});";
			WebAssemblyRuntime.InvokeJS(str);
			return;
		}
		WindowManagerSetElementColorParams windowManagerSetElementColorParams = default(WindowManagerSetElementColorParams);
		windowManagerSetElementColorParams.HtmlId = htmlId;
		windowManagerSetElementColorParams.Color = color2;
		WindowManagerSetElementColorParams windowManagerSetElementColorParams2 = windowManagerSetElementColorParams;
		TSInteropMarshaller.InvokeJS("Uno:setElementColorNative", windowManagerSetElementColorParams2, "SetElementColor");
	}

	internal static void RemoveView(IntPtr htmlId, IntPtr childId)
	{
		if (UseJavascriptEval)
		{
			string str = "Uno.UI.WindowManager.current.removeView(" + htmlId + ", " + childId + ");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerRemoveViewParams windowManagerRemoveViewParams = default(WindowManagerRemoveViewParams);
			windowManagerRemoveViewParams.HtmlId = htmlId;
			windowManagerRemoveViewParams.ChildView = childId;
			WindowManagerRemoveViewParams windowManagerRemoveViewParams2 = windowManagerRemoveViewParams;
			TSInteropMarshaller.InvokeJS("Uno:removeViewNative", windowManagerRemoveViewParams2, "RemoveView");
		}
	}

	internal static void DestroyView(IntPtr htmlId)
	{
		if (UseJavascriptEval)
		{
			string str = "Uno.UI.WindowManager.current.destroyView(" + htmlId + ");";
			WebAssemblyRuntime.InvokeJS(str);
			return;
		}
		WindowManagerDestroyViewParams windowManagerDestroyViewParams = default(WindowManagerDestroyViewParams);
		windowManagerDestroyViewParams.HtmlId = htmlId;
		WindowManagerDestroyViewParams windowManagerDestroyViewParams2 = windowManagerDestroyViewParams;
		TSInteropMarshaller.InvokeJS("Uno:destroyViewNative", windowManagerDestroyViewParams2, "DestroyView");
	}

	internal static void ResetStyle(IntPtr htmlId, string[] names)
	{
		if (names == null || names.Length == 0)
		{
			return;
		}
		if (UseJavascriptEval)
		{
			if (names.Length == 1)
			{
				string str = "Uno.UI.WindowManager.current.resetStyle(\"" + htmlId + "\", [\"" + names[0] + "\"]);";
				WebAssemblyRuntime.InvokeJS(str);
				return;
			}
			string text = string.Join(", ", names.Select((string n) => "\"" + n + "\""));
			string str2 = "Uno.UI.WindowManager.current.resetStyle(\"" + htmlId + "\", [\"" + text + "\"]);";
			WebAssemblyRuntime.InvokeJS(str2);
		}
		else
		{
			WindowManagerResetStyleParams windowManagerResetStyleParams = default(WindowManagerResetStyleParams);
			windowManagerResetStyleParams.HtmlId = htmlId;
			windowManagerResetStyleParams.Styles = names;
			windowManagerResetStyleParams.Styles_Length = names.Length;
			WindowManagerResetStyleParams windowManagerResetStyleParams2 = windowManagerResetStyleParams;
			TSInteropMarshaller.InvokeJS("Uno:resetStyleNative", windowManagerResetStyleParams2, "ResetStyle");
		}
	}

	internal static void RegisterEventOnView(IntPtr htmlId, string eventName, bool onCapturePhase, int eventExtractorId)
	{
		if (UseJavascriptEval)
		{
			string text = (onCapturePhase ? "true" : "false");
			string str = $"Uno.UI.WindowManager.current.registerEventOnView(\"{htmlId}\", \"{eventName}\", {text}, {eventExtractorId});";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerRegisterEventOnViewParams windowManagerRegisterEventOnViewParams = default(WindowManagerRegisterEventOnViewParams);
			windowManagerRegisterEventOnViewParams.HtmlId = htmlId;
			windowManagerRegisterEventOnViewParams.EventName = eventName;
			windowManagerRegisterEventOnViewParams.OnCapturePhase = onCapturePhase;
			windowManagerRegisterEventOnViewParams.EventExtractorId = eventExtractorId;
			WindowManagerRegisterEventOnViewParams windowManagerRegisterEventOnViewParams2 = windowManagerRegisterEventOnViewParams;
			TSInteropMarshaller.InvokeJS("Uno:registerEventOnViewNative", windowManagerRegisterEventOnViewParams2, "RegisterEventOnView");
		}
	}

	internal static void RegisterPointerEventsOnView(IntPtr htmlId)
	{
		WindowManagerRegisterPointerEventsOnViewParams windowManagerRegisterPointerEventsOnViewParams = default(WindowManagerRegisterPointerEventsOnViewParams);
		windowManagerRegisterPointerEventsOnViewParams.HtmlId = htmlId;
		WindowManagerRegisterPointerEventsOnViewParams windowManagerRegisterPointerEventsOnViewParams2 = windowManagerRegisterPointerEventsOnViewParams;
		TSInteropMarshaller.InvokeJS("Uno:registerPointerEventsOnView", windowManagerRegisterPointerEventsOnViewParams2, "RegisterPointerEventsOnView");
	}

	internal static Rect GetBBox(IntPtr htmlId)
	{
		if (UseJavascriptEval)
		{
			string text = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.getBBox(" + htmlId + ");");
			string[] array = text.Split(new char[1] { ';' });
			return new Rect(double.Parse(array[0]), double.Parse(array[1]), double.Parse(array[2]), double.Parse(array[3]));
		}
		WindowManagerGetBBoxParams windowManagerGetBBoxParams = default(WindowManagerGetBBoxParams);
		windowManagerGetBBoxParams.HtmlId = htmlId;
		WindowManagerGetBBoxParams windowManagerGetBBoxParams2 = windowManagerGetBBoxParams;
		WindowManagerGetBBoxReturn windowManagerGetBBoxReturn = (WindowManagerGetBBoxReturn)TSInteropMarshaller.InvokeJS("Uno:getBBoxNative", windowManagerGetBBoxParams2, typeof(WindowManagerGetBBoxReturn), "GetBBox");
		return new Rect(windowManagerGetBBoxReturn.X, windowManagerGetBBoxReturn.Y, windowManagerGetBBoxReturn.Width, windowManagerGetBBoxReturn.Height);
	}

	internal static void SetContentHtml(IntPtr htmlId, string html)
	{
		if (UseJavascriptEval)
		{
			string text = WebAssemblyRuntime.EscapeJs(html);
			string str = "Uno.UI.WindowManager.current.setHtmlContent(" + htmlId + ", \"" + text + "\");";
			WebAssemblyRuntime.InvokeJS(str);
		}
		else
		{
			WindowManagerSetContentHtmlParams windowManagerSetContentHtmlParams = default(WindowManagerSetContentHtmlParams);
			windowManagerSetContentHtmlParams.HtmlId = htmlId;
			windowManagerSetContentHtmlParams.Html = html;
			WindowManagerSetContentHtmlParams windowManagerSetContentHtmlParams2 = windowManagerSetContentHtmlParams;
			TSInteropMarshaller.InvokeJS("Uno:setHtmlContentNative", windowManagerSetContentHtmlParams2, "SetContentHtml");
		}
	}

	internal static void ArrangeElement(IntPtr htmlId, Rect rect, Rect? clipRect)
	{
		if (UseJavascriptEval)
		{
			string item = (clipRect.HasValue ? string.Format(CultureInfo.InvariantCulture, "rect({0}px,{1}px,{2}px,{3}px", clipRect.Value.Top, clipRect.Value.Right, clipRect.Value.Bottom, clipRect.Value.Left) : "");
			SetStyles(htmlId, new(string, string)[6]
			{
				("position", "absolute"),
				("top", rect.Top.ToString(CultureInfo.InvariantCulture) + "px"),
				("left", rect.Left.ToString(CultureInfo.InvariantCulture) + "px"),
				("width", rect.Width.ToString(CultureInfo.InvariantCulture) + "px"),
				("height", rect.Height.ToString(CultureInfo.InvariantCulture) + "px"),
				("clip", item)
			});
			SetArrangeProperties(htmlId);
			return;
		}
		WindowManagerArrangeElementParams windowManagerArrangeElementParams = default(WindowManagerArrangeElementParams);
		windowManagerArrangeElementParams.HtmlId = htmlId;
		windowManagerArrangeElementParams.Top = rect.Top;
		windowManagerArrangeElementParams.Left = rect.Left;
		windowManagerArrangeElementParams.Width = rect.Width;
		windowManagerArrangeElementParams.Height = rect.Height;
		WindowManagerArrangeElementParams windowManagerArrangeElementParams2 = windowManagerArrangeElementParams;
		if (clipRect.HasValue)
		{
			windowManagerArrangeElementParams2.Clip = true;
			windowManagerArrangeElementParams2.ClipTop = clipRect.Value.Top;
			windowManagerArrangeElementParams2.ClipLeft = clipRect.Value.Left;
			windowManagerArrangeElementParams2.ClipBottom = clipRect.Value.Bottom;
			windowManagerArrangeElementParams2.ClipRight = clipRect.Value.Right;
		}
		TSInteropMarshaller.InvokeJS("Uno:arrangeElementNative", windowManagerArrangeElementParams2, "ArrangeElement");
	}

	internal static (Size clientSize, Size offsetSize) GetClientViewSize(IntPtr htmlId)
	{
		if (UseJavascriptEval)
		{
			string text = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.getClientViewSize(" + htmlId + ");");
			string[] array = text.Split(new char[1] { ';' });
			return (new Size(double.Parse(array[0]), double.Parse(array[1])), new Size(double.Parse(array[2]), double.Parse(array[3])));
		}
		WindowManagerGetClientViewSizeParams windowManagerGetClientViewSizeParams = default(WindowManagerGetClientViewSizeParams);
		windowManagerGetClientViewSizeParams.HtmlId = htmlId;
		WindowManagerGetClientViewSizeParams windowManagerGetClientViewSizeParams2 = windowManagerGetClientViewSizeParams;
		WindowManagerGetClientViewSizeReturn windowManagerGetClientViewSizeReturn = (WindowManagerGetClientViewSizeReturn)TSInteropMarshaller.InvokeJS("Uno:getClientViewSizeNative", windowManagerGetClientViewSizeParams2, typeof(WindowManagerGetClientViewSizeReturn), "GetClientViewSize");
		return (new Size(windowManagerGetClientViewSizeReturn.ClientWidth, windowManagerGetClientViewSizeReturn.ClientHeight), new Size(windowManagerGetClientViewSizeReturn.OffsetWidth, windowManagerGetClientViewSizeReturn.OffsetHeight));
	}

	internal static void ScrollTo(IntPtr htmlId, double? left, double? top, bool disableAnimation)
	{
		double? num = ((top.HasValue && top == double.MaxValue) ? new double?(1E+18) : top);
		double? num2 = ((left.HasValue && left == double.MaxValue) ? new double?(1E+18) : left);
		WindowManagerScrollToOptionsParams windowManagerScrollToOptionsParams = default(WindowManagerScrollToOptionsParams);
		windowManagerScrollToOptionsParams.HtmlId = htmlId;
		windowManagerScrollToOptionsParams.HasLeft = num2.HasValue;
		windowManagerScrollToOptionsParams.Left = num2.GetValueOrDefault();
		windowManagerScrollToOptionsParams.HasTop = num.HasValue;
		windowManagerScrollToOptionsParams.Top = num.GetValueOrDefault();
		windowManagerScrollToOptionsParams.DisableAnimation = disableAnimation;
		WindowManagerScrollToOptionsParams windowManagerScrollToOptionsParams2 = windowManagerScrollToOptionsParams;
		TSInteropMarshaller.InvokeJS("Uno:scrollTo", windowManagerScrollToOptionsParams2, "ScrollTo");
	}

	internal static void SetElementBackgroundColor(IntPtr htmlId, Color color)
	{
		WindowManagerSetElementBackgroundColorParams windowManagerSetElementBackgroundColorParams = default(WindowManagerSetElementBackgroundColorParams);
		windowManagerSetElementBackgroundColorParams.HtmlId = htmlId;
		windowManagerSetElementBackgroundColorParams.Color = color.ToCssInteger();
		WindowManagerSetElementBackgroundColorParams windowManagerSetElementBackgroundColorParams2 = windowManagerSetElementBackgroundColorParams;
		TSInteropMarshaller.InvokeJS("Uno:setElementBackgroundColor", windowManagerSetElementBackgroundColorParams2, "SetElementBackgroundColor");
	}

	internal static void SetElementBackgroundGradient(IntPtr htmlId, string cssGradient)
	{
		WindowManagerSetElementBackgroundGradientParams windowManagerSetElementBackgroundGradientParams = default(WindowManagerSetElementBackgroundGradientParams);
		windowManagerSetElementBackgroundGradientParams.HtmlId = htmlId;
		windowManagerSetElementBackgroundGradientParams.CssGradient = cssGradient;
		WindowManagerSetElementBackgroundGradientParams windowManagerSetElementBackgroundGradientParams2 = windowManagerSetElementBackgroundGradientParams;
		TSInteropMarshaller.InvokeJS("Uno:setElementBackgroundGradient", windowManagerSetElementBackgroundGradientParams2, "SetElementBackgroundGradient");
	}

	internal static void ResetElementBackground(IntPtr htmlId)
	{
		WindowManagerResetElementBackgroundParams windowManagerResetElementBackgroundParams = default(WindowManagerResetElementBackgroundParams);
		windowManagerResetElementBackgroundParams.HtmlId = htmlId;
		WindowManagerResetElementBackgroundParams windowManagerResetElementBackgroundParams2 = windowManagerResetElementBackgroundParams;
		TSInteropMarshaller.InvokeJS("Uno:resetElementBackground", windowManagerResetElementBackgroundParams2, "ResetElementBackground");
	}
}
