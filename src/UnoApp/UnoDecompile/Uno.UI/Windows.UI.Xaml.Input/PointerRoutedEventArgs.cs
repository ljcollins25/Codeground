using System;
using System.Collections.Generic;
using System.Globalization;
using Uno;
using Uno.Foundation;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Input;
using Windows.ApplicationModel.DataTransfer.DragDrop;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;

namespace Windows.UI.Xaml.Input;

public sealed class PointerRoutedEventArgs : RoutedEventArgs, IHandleableRoutedEventArgs, CoreWindow.IPointerEventArgs, IDragEventSource
{
	internal const bool PlatformSupportsNativeBubbling = true;

	private readonly double _timestamp;

	private readonly Point _absolutePosition;

	private readonly WindowManagerInterop.HtmlPointerButtonsState _buttons;

	private readonly WindowManagerInterop.HtmlPointerButtonUpdate _buttonUpdate;

	private readonly double _pressure;

	private readonly (bool isHorizontalWheel, double delta) _wheel;

	private static ulong? _bootTime;

	internal uint FrameId { get; }

	internal bool CanceledByDirectManipulation { get; set; }

	public bool IsGenerated { get; }

	public bool Handled { get; set; }

	public VirtualKeyModifiers KeyModifiers { get; }

	public Pointer Pointer { get; }

	PointerIdentifier CoreWindow.IPointerEventArgs.Pointer => Pointer.UniqueId;

	long IDragEventSource.Id => Pointer.UniqueId;

	uint IDragEventSource.FrameId => FrameId;

	[NotImplemented]
	internal GestureModes GestureFollowing => GestureModes.None;

	public PointerRoutedEventArgs()
	{
		CoreWindow.GetForCurrentThread()!.LastPointerEvent = this;
		base.CanBubbleNatively = true;
	}

	PointerPoint CoreWindow.IPointerEventArgs.GetLocation(object relativeTo)
	{
		return GetCurrentPoint(relativeTo as UIElement);
	}

	public IList<PointerPoint> GetIntermediatePoints(UIElement relativeTo)
	{
		return new List<PointerPoint>(1) { GetCurrentPoint(relativeTo) };
	}

	public override string ToString()
	{
		return $"PointerRoutedEventArgs({Pointer}@{GetCurrentPoint(null).Position})";
	}

	Point IDragEventSource.GetPosition(object relativeTo)
	{
		if (relativeTo == null || relativeTo is UIElement)
		{
			return GetCurrentPoint(relativeTo as UIElement).Position;
		}
		throw new ArgumentOutOfRangeException("relativeTo", "The relative element must be a UIElement.");
	}

	(Point location, DragDropModifiers modifier) IDragEventSource.GetState()
	{
		PointerPoint currentPoint = GetCurrentPoint(null);
		DragDropModifiers dragDropModifiers = DragDropModifiers.None;
		PointerPointProperties properties = currentPoint.Properties;
		if (properties.IsLeftButtonPressed)
		{
			dragDropModifiers |= DragDropModifiers.LeftButton;
		}
		if (properties.IsMiddleButtonPressed)
		{
			dragDropModifiers |= DragDropModifiers.MiddleButton;
		}
		if (properties.IsRightButtonPressed)
		{
			dragDropModifiers |= DragDropModifiers.RightButton;
		}
		CoreWindow coreWindow = Window.Current.CoreWindow;
		if (coreWindow.GetAsyncKeyState(VirtualKey.Shift) == CoreVirtualKeyStates.Down)
		{
			dragDropModifiers |= DragDropModifiers.Shift;
		}
		if (coreWindow.GetAsyncKeyState(VirtualKey.Control) == CoreVirtualKeyStates.Down)
		{
			dragDropModifiers |= DragDropModifiers.Control;
		}
		if (coreWindow.GetAsyncKeyState(VirtualKey.Menu) == CoreVirtualKeyStates.Down)
		{
			dragDropModifiers |= DragDropModifiers.Alt;
		}
		return (currentPoint.Position, dragDropModifiers);
	}

	internal PointerRoutedEventArgs(double timestamp, uint pointerId, PointerDeviceType pointerType, Point absolutePosition, bool isInContact, WindowManagerInterop.HtmlPointerButtonsState buttons, WindowManagerInterop.HtmlPointerButtonUpdate buttonUpdate, VirtualKeyModifiers keys, double pressure, (bool isHorizontalWheel, double delta) wheel, UIElement source)
		: this()
	{
		_timestamp = timestamp;
		_absolutePosition = absolutePosition;
		_buttons = buttons;
		_buttonUpdate = buttonUpdate;
		_pressure = pressure;
		_wheel = wheel;
		FrameId = ToFrameId(timestamp);
		Pointer = new Pointer(pointerId, pointerType, isInContact, isInRange: true);
		KeyModifiers = keys;
		base.OriginalSource = source;
	}

	public PointerPoint GetCurrentPoint(UIElement relativeTo)
	{
		ulong timestamp = ToTimeStamp(_timestamp);
		PointerDevice device = PointerDevice.For(Pointer.PointerDeviceType);
		Point absolutePosition = _absolutePosition;
		Point position = relativeTo?.TransformToVisual(null).Inverse.TransformPoint(_absolutePosition) ?? absolutePosition;
		PointerPointProperties properties = GetProperties();
		return new PointerPoint(FrameId, timestamp, device, Pointer.PointerId, absolutePosition, position, Pointer.IsInContact, properties);
	}

	private PointerPointProperties GetProperties()
	{
		PointerPointProperties pointerPointProperties = new PointerPointProperties
		{
			IsPrimary = true,
			IsInRange = Pointer.IsInRange
		};
		pointerPointProperties.IsLeftButtonPressed = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Left);
		pointerPointProperties.IsMiddleButtonPressed = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Middle);
		pointerPointProperties.IsRightButtonPressed = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Right);
		pointerPointProperties.IsXButton1Pressed = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.X1);
		pointerPointProperties.IsXButton2Pressed = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.X2);
		pointerPointProperties.IsEraser = _buttons.HasFlag(WindowManagerInterop.HtmlPointerButtonsState.Eraser);
		pointerPointProperties.IsHorizontalMouseWheel = _wheel.isHorizontalWheel;
		pointerPointProperties.MouseWheelDelta = (int)_wheel.delta;
		PointerDeviceType pointerDeviceType = Pointer.PointerDeviceType;
		if (pointerDeviceType == PointerDeviceType.Pen)
		{
			pointerPointProperties.IsBarrelButtonPressed = pointerPointProperties.IsRightButtonPressed;
			pointerPointProperties.Pressure = (float)_pressure;
		}
		pointerPointProperties.PointerUpdateKind = ToUpdateKind(_buttonUpdate, pointerPointProperties);
		return pointerPointProperties;
	}

	private static ulong ToTimeStamp(double timestamp)
	{
		ulong valueOrDefault = _bootTime.GetValueOrDefault();
		if (!_bootTime.HasValue)
		{
			valueOrDefault = (ulong)(double.Parse(WebAssemblyRuntime.InvokeJS("Date.now() - performance.now()"), CultureInfo.InvariantCulture) * 10000.0);
			_bootTime = valueOrDefault;
		}
		return _bootTime.Value + (ulong)(timestamp * 10000.0);
	}

	internal static uint ToFrameId(double timestamp)
	{
		return (uint)(timestamp % 4294967295.0);
	}

	internal static Point ToRelativePosition(Point absolutePosition, UIElement relativeTo)
	{
		return relativeTo?.TransformToVisual(null).Inverse.TransformPoint(absolutePosition) ?? absolutePosition;
	}

	private static PointerUpdateKind ToUpdateKind(WindowManagerInterop.HtmlPointerButtonUpdate update, PointerPointProperties props)
	{
		switch (update)
		{
		case WindowManagerInterop.HtmlPointerButtonUpdate.Left:
			if (props.IsLeftButtonPressed)
			{
				return PointerUpdateKind.LeftButtonPressed;
			}
			return PointerUpdateKind.LeftButtonReleased;
		case WindowManagerInterop.HtmlPointerButtonUpdate.Middle:
			if (props.IsMiddleButtonPressed)
			{
				return PointerUpdateKind.MiddleButtonPressed;
			}
			return PointerUpdateKind.MiddleButtonReleased;
		case WindowManagerInterop.HtmlPointerButtonUpdate.Right:
			if (props.IsRightButtonPressed)
			{
				return PointerUpdateKind.RightButtonPressed;
			}
			return PointerUpdateKind.RightButtonReleased;
		case WindowManagerInterop.HtmlPointerButtonUpdate.X1:
			if (props.IsXButton1Pressed)
			{
				return PointerUpdateKind.XButton1Pressed;
			}
			return PointerUpdateKind.XButton1Released;
		case WindowManagerInterop.HtmlPointerButtonUpdate.X2:
			if (props.IsXButton2Pressed)
			{
				return PointerUpdateKind.XButton1Pressed;
			}
			return PointerUpdateKind.XButton1Released;
		default:
			return PointerUpdateKind.Other;
		}
	}
}
