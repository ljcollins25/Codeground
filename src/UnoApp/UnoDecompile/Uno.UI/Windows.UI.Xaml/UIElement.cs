using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DirectUI;
using Uno;
using Uno.Collections;
using Uno.Core.Comparison;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Foundation.Logging;
using Uno.Foundation.Runtime.WebAssembly.Interop;
using Uno.UI;
using Uno.UI.Core;
using Uno.UI.DataBinding;
using Uno.UI.Extensions;
using Uno.UI.Media;
using Uno.UI.Xaml;
using Uno.UI.Xaml.Controls;
using Uno.UI.Xaml.Core;
using Uno.UI.Xaml.Input;
using Uno.UI.Xaml.Rendering;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Devices.Haptics;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Media3D;

namespace Windows.UI.Xaml;

[Windows.UI.Xaml.Data.Bindable]
public class UIElement : IAnimationObject, IVisualElement, DependencyObject, IXUidProvider, IUIElement, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	[Flags]
	internal enum PointerCaptureKind : byte
	{
		None = 0,
		Explicit = 1,
		Implicit = 2,
		Any = 3
	}

	private protected class PointerCapture
	{
		private static readonly IDictionary<PointerIdentifier, PointerCapture> _actives = new Dictionary<PointerIdentifier, PointerCapture>(EqualityComparer<PointerIdentifier>.Default);

		private UIElement _nativeCaptureElement;

		private readonly Dictionary<UIElement, PointerCaptureTarget> _targets = new Dictionary<UIElement, PointerCaptureTarget>(2);

		public Windows.UI.Xaml.Input.Pointer Pointer { get; }

		public long MostRecentDispatchedEventFrameId { get; private set; }

		public bool IsImplicitOnly { get; private set; } = true;


		public IEnumerable<PointerCaptureTarget> Targets => _targets.Values;

		public static PointerCapture GetOrCreate(Windows.UI.Xaml.Input.Pointer pointer)
		{
			if (!_actives.TryGetValue(pointer.UniqueId, out var value))
			{
				return new PointerCapture(pointer);
			}
			return value;
		}

		public static bool TryGet(PointerIdentifier pointer, out PointerCapture capture)
		{
			return _actives.TryGetValue(pointer, out capture);
		}

		public static bool TryGet(Windows.UI.Xaml.Input.Pointer pointer, out PointerCapture capture)
		{
			return _actives.TryGetValue(pointer.UniqueId, out capture);
		}

		public static bool Any(out List<PointerCapture> cloneOfAllCaptures)
		{
			if (_actives.Any())
			{
				cloneOfAllCaptures = _actives.Values.ToList();
				return true;
			}
			cloneOfAllCaptures = null;
			return false;
		}

		private PointerCapture(Windows.UI.Xaml.Input.Pointer pointer)
		{
			Pointer = pointer;
		}

		public bool IsTarget(UIElement element, PointerCaptureKind kinds)
		{
			if (_targets.TryGetValue(element, out var value))
			{
				return (value.Kind & kinds) != 0;
			}
			return false;
		}

		public IEnumerable<PointerCaptureTarget> GetTargets(PointerCaptureKind kinds)
		{
			return _targets.Values.Where((PointerCaptureTarget target) => (target.Kind & kinds) != 0);
		}

		public bool TryAddTarget(UIElement element, PointerCaptureKind kind, PointerRoutedEventArgs relatedArgs = null)
		{
			if (this.Log().IsEnabled(LogLevel.Information))
			{
				this.Log().Info($"{element}: Capturing ({kind}) pointer {Pointer}");
			}
			if (_targets.TryGetValue(element, out var value))
			{
				if (value.Kind.HasFlag(kind))
				{
					return false;
				}
				value.Kind |= kind;
			}
			else
			{
				value = new PointerCaptureTarget(element, kind);
				_targets.Add(element, value);
				if (relatedArgs?.Pointer == Pointer)
				{
					Update(value, relatedArgs);
					if (kind == PointerCaptureKind.Implicit)
					{
						value.NativeCaptureElement = (relatedArgs?.OriginalSource as UIElement) ?? element;
					}
				}
			}
			if (kind == PointerCaptureKind.Explicit)
			{
				IsImplicitOnly = false;
				element._localExplicitCaptures.Add(Pointer);
			}
			EnsureEffectiveCaptureState();
			return true;
		}

		public PointerCaptureKind RemoveTarget(UIElement element, PointerCaptureKind kinds, out PointerRoutedEventArgs lastDispatched)
		{
			if (!_targets.TryGetValue(element, out var value) || (value.Kind & kinds) == 0)
			{
				lastDispatched = null;
				return PointerCaptureKind.None;
			}
			PointerCaptureKind result = value.Kind & kinds;
			lastDispatched = value.LastDispatched;
			RemoveCore(value, kinds);
			return result;
		}

		private void Clear()
		{
			foreach (PointerCaptureTarget item in _targets.Values.ToList())
			{
				RemoveCore(item, PointerCaptureKind.Any);
			}
		}

		private void RemoveCore(PointerCaptureTarget target, PointerCaptureKind kinds)
		{
			if (this.Log().IsEnabled(LogLevel.Information))
			{
				this.Log().Info($"{target.Element.GetDebugName()}: Releasing ({kinds}) capture of pointer {Pointer}");
			}
			if (kinds.HasFlag(PointerCaptureKind.Explicit) && target.Kind.HasFlag(PointerCaptureKind.Explicit))
			{
				target.Element._localExplicitCaptures.Remove(Pointer);
			}
			target.Kind &= (PointerCaptureKind)(byte)(~(int)kinds);
			if (target.Kind == PointerCaptureKind.None)
			{
				_targets.Remove(target.Element);
			}
			IsImplicitOnly = _targets.None((KeyValuePair<UIElement, PointerCaptureTarget> t) => t.Value.Kind.HasFlag(PointerCaptureKind.Explicit));
			EnsureEffectiveCaptureState();
		}

		public bool ValidateAndUpdate(UIElement element, PointerRoutedEventArgs args, bool autoRelease)
		{
			if ((autoRelease && MostRecentDispatchedEventFrameId < args.FrameId) || _nativeCaptureElement.GetHitTestVisibility() == HitTestability.Collapsed)
			{
				Clear();
				return true;
			}
			if (_targets.TryGetValue(element, out var value))
			{
				Update(value, args);
				return true;
			}
			if (IsImplicitOnly)
			{
				return true;
			}
			return MostRecentDispatchedEventFrameId >= args.FrameId;
		}

		private void Update(PointerCaptureTarget target, PointerRoutedEventArgs args)
		{
			target.LastDispatched = args;
			if (MostRecentDispatchedEventFrameId < args.FrameId)
			{
				MostRecentDispatchedEventFrameId = args.FrameId;
			}
		}

		private void EnsureEffectiveCaptureState()
		{
			if (_targets.Any())
			{
				if (_actives.TryGetValue(Pointer.UniqueId, out var value))
				{
					if (value != this)
					{
						throw new InvalidOperationException("There is already another active capture.");
					}
				}
				else
				{
					_actives.Add(Pointer.UniqueId, this);
				}
				if (_nativeCaptureElement == null)
				{
					_nativeCaptureElement = _targets.Single().Value.NativeCaptureElement;
					CapturePointerNative();
				}
			}
			else
			{
				if (_nativeCaptureElement != null)
				{
					ReleasePointerNative();
					_nativeCaptureElement = null;
				}
				if (_actives.TryGetValue(Pointer.UniqueId, out var value2) && value2 == this)
				{
					_actives.Remove(Pointer.UniqueId);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ReleasePointerNative()
		{
			try
			{
				_nativeCaptureElement.ReleasePointerNative(Pointer);
			}
			catch (Exception ex)
			{
				this.Log().Error($"Failed to release native capture of {Pointer}", ex);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CapturePointerNative()
		{
			try
			{
				_nativeCaptureElement.CapturePointerNative(Pointer);
			}
			catch (Exception ex)
			{
				this.Log().Error($"Failed to capture natively pointer {Pointer}.", ex);
			}
		}
	}

	private protected class PointerCaptureTarget
	{
		public UIElement Element { get; }

		public UIElement NativeCaptureElement { get; set; }

		public PointerCaptureKind Kind { get; set; }

		public bool? IsInNativeBubblingTree { get; set; }

		public PointerRoutedEventArgs LastDispatched { get; set; }

		public PointerCaptureTarget(UIElement element, PointerCaptureKind kind)
		{
			NativeCaptureElement = (Element = element);
			Kind = kind;
		}
	}

	private struct RoutedEventHandlerInfo
	{
		internal object Handler { get; }

		internal bool HandledEventsToo { get; }

		internal RoutedEventHandlerInfo(object handler, bool handledEventsToo)
		{
			Handler = handler;
			HandledEventsToo = handledEventsToo;
		}
	}

	internal struct BubblingContext
	{
		public static readonly BubblingContext Bubble = default(BubblingContext);

		public static readonly BubblingContext NoBubbling = new BubblingContext
		{
			Mode = BubblingMode.NoBubbling
		};

		public static readonly BubblingContext OnManagedBubbling = new BubblingContext
		{
			Mode = BubblingMode.NoBubbling,
			IsInternal = true
		};

		public BubblingMode Mode { get; set; }

		public UIElement Root { get; set; }

		public bool IsInternal { get; set; }

		public static BubblingContext BubbleUpTo(UIElement root)
		{
			BubblingContext result = default(BubblingContext);
			result.Root = root;
			return result;
		}

		public BubblingContext WithMode(BubblingMode mode)
		{
			BubblingContext result = default(BubblingContext);
			result.Mode = mode;
			result.Root = Root;
			result.IsInternal = IsInternal;
			return result;
		}

		public override string ToString()
		{
			object arg = Mode;
			string arg2 = (IsInternal ? " *internal*" : "");
			UIElement root = Root;
			return string.Format("{0}{1}{2}", arg, arg2, (root != null) ? (" up to " + Root.GetDebugName()) : "");
		}
	}

	[Flags]
	internal enum BubblingMode
	{
		Bubble = 0,
		IgnoreElement = 1,
		IgnoreParents = 2,
		NoBubbling = 3
	}

	private delegate HtmlEventDispatchResult RawEventHandler(UIElement sender, string paylaod);

	internal delegate object GenericEventHandler(Delegate d, object sender, object args);

	private class EventRegistration
	{
		private class InvocationItem
		{
			public Delegate Handler { get; }

			public GenericEventHandler Invoker { get; }

			public InvocationItem(Delegate handler, GenericEventHandler invoker)
			{
				Handler = handler;
				Invoker = invoker;
			}
		}

		private static readonly string[] noRegistrationEventNames = new string[8] { "loading", "loaded", "unloaded", "pointerenter", "pointerleave", "pointerdown", "pointerup", "pointercancel" };

		private readonly UIElement _owner;

		private readonly string _eventName;

		private readonly EventArgsParser _payloadConverter;

		private readonly Action _subscribeCommand;

		private List<InvocationItem> _invocationList = new List<InvocationItem>();

		private List<InvocationItem> _pendingInvocationList;

		private bool _isSubscribed;

		private bool _isDispatching;

		public EventRegistration(UIElement owner, string eventName, bool onCapturePhase = false, HtmlEventExtractor? eventExtractor = null, EventArgsParser payloadConverter = null)
		{
			EventRegistration eventRegistration = this;
			_owner = owner;
			_eventName = eventName;
			_payloadConverter = payloadConverter;
			if (!noRegistrationEventNames.Contains(eventName))
			{
				_subscribeCommand = delegate
				{
					WindowManagerInterop.RegisterEventOnView(eventRegistration._owner.HtmlId, eventName, onCapturePhase, (int)eventExtractor.GetValueOrDefault());
				};
			}
		}

		public void Add(Delegate handler, GenericEventHandler invoker)
		{
			InvocationItem item = new InvocationItem(handler, invoker);
			List<InvocationItem> list = (_isDispatching ? (_pendingInvocationList ?? (_pendingInvocationList = new List<InvocationItem>(_invocationList))) : _invocationList);
			if (!list.Contains(item))
			{
				list.Add(item);
				if (_subscribeCommand != null && list.Count == 1 && !_isSubscribed)
				{
					_subscribeCommand();
					_isSubscribed = true;
				}
			}
		}

		public void Remove(Delegate handler, GenericEventHandler invoker)
		{
			InvocationItem item = new InvocationItem(handler, invoker);
			List<InvocationItem> list = (_isDispatching ? (_pendingInvocationList ?? (_pendingInvocationList = new List<InvocationItem>(_invocationList))) : _invocationList);
			list.Remove(item);
		}

		public HtmlEventDispatchResult Dispatch(EventArgs eventArgs, string nativeEventPayload)
		{
			if (_invocationList.Count == 0)
			{
				return HtmlEventDispatchResult.NotDispatched;
			}
			try
			{
				return InnerDispatch(eventArgs, nativeEventPayload);
			}
			catch (Exception ex)
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error($"Failed to dispatch event {_eventName} on {_owner.HtmlId} to {_invocationList.Count} handlers.", ex);
				}
				throw;
			}
			finally
			{
				_isDispatching = false;
				if (_pendingInvocationList != null)
				{
					_invocationList = _pendingInvocationList;
					_pendingInvocationList = null;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private HtmlEventDispatchResult InnerDispatch(EventArgs eventArgs, string nativeEventPayload)
		{
			_isDispatching = true;
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"{_owner}: Dispatching event {_eventName}");
			}
			EventArgs eventArgs2 = eventArgs;
			if (_payloadConverter != null && nativeEventPayload != null)
			{
				eventArgs2 = _payloadConverter(_owner, nativeEventPayload);
			}
			HtmlEventDispatchResult htmlEventDispatchResult = HtmlEventDispatchResult.Ok;
			foreach (InvocationItem invocation in _invocationList)
			{
				if (invocation.Handler is RawEventHandler rawEventHandler)
				{
					HtmlEventDispatchResult htmlEventDispatchResult2 = rawEventHandler(_owner, nativeEventPayload);
					if (htmlEventDispatchResult2.HasFlag(HtmlEventDispatchResult.StopPropagation))
					{
						return htmlEventDispatchResult | HtmlEventDispatchResult.StopPropagation;
					}
					htmlEventDispatchResult |= htmlEventDispatchResult2;
					continue;
				}
				object obj = invocation.Invoker(invocation.Handler, _owner, eventArgs2);
				object obj2 = obj;
				if (!(obj2 is bool))
				{
					if (obj2 is HtmlEventDispatchResult htmlEventDispatchResult3)
					{
						HtmlEventDispatchResult htmlEventDispatchResult4 = htmlEventDispatchResult3;
						if (htmlEventDispatchResult4.HasFlag(HtmlEventDispatchResult.StopPropagation))
						{
							return htmlEventDispatchResult | HtmlEventDispatchResult.StopPropagation;
						}
						HtmlEventDispatchResult htmlEventDispatchResult5 = htmlEventDispatchResult3;
						htmlEventDispatchResult |= htmlEventDispatchResult5;
					}
				}
				else if ((bool)obj2)
				{
					if (eventArgs2 is IPreventDefaultHandling preventDefaultHandling && preventDefaultHandling.DoNotPreventDefault)
					{
						return HtmlEventDispatchResult.StopPropagation;
					}
					return HtmlEventDispatchResult.StopPropagation | HtmlEventDispatchResult.PreventDefault;
				}
			}
			return HtmlEventDispatchResult.Ok;
		}
	}

	internal delegate EventArgs EventArgsParser(object sender, string payload);

	internal enum HtmlEventExtractor
	{
		None,
		PointerEventExtractor,
		TappedEventExtractor,
		KeyboardEventExtractor,
		FocusEventExtractor,
		CustomEventDetailStringExtractor,
		CustomEventDetailJsonExtractor
	}

	[Flags]
	internal enum HtmlEventDispatchResult
	{
		Ok = 0,
		StopPropagation = 1,
		PreventDefault = 2,
		NotDispatched = 0x80
	}

	internal static class GenericEventHandlers
	{
		internal static object RaiseEventHandler(Delegate d, object sender, object args)
		{
			if (d is EventHandler eventHandler)
			{
				eventHandler(sender, args as EventArgs);
				return null;
			}
			throw new InvalidOperationException($"The parameters for invoking GenericEventHandlers.RaiseEventHandler with {d} are incorrect");
		}

		internal static object RaiseRawEventHandler(Delegate d, object sender, object args)
		{
			if (d is RawEventHandler rawEventHandler)
			{
				return rawEventHandler(sender as UIElement, args as string);
			}
			throw new InvalidOperationException($"The parameters for invoking GenericEventHandlers.RaiseEventHandler with {d} are incorrect");
		}

		internal static object RaiseRoutedEventHandler(Delegate d, object sender, object args)
		{
			if (d is RoutedEventHandler routedEventHandler)
			{
				routedEventHandler(sender, args as RoutedEventArgs);
				return null;
			}
			throw new InvalidOperationException($"The parameters for invoking GenericEventHandlers.RaiseEventHandler with {d} are incorrect");
		}

		internal static object RaiseExceptionRoutedEventHandler(Delegate d, object sender, object args)
		{
			if (d is ExceptionRoutedEventHandler exceptionRoutedEventHandler)
			{
				exceptionRoutedEventHandler(sender, args as ExceptionRoutedEventArgs);
				return null;
			}
			return null;
		}

		internal static object RaiseRoutedEventHandlerWithHandled(Delegate d, object sender, object args)
		{
			if (d is RoutedEventHandlerWithHandled routedEventHandlerWithHandled)
			{
				return routedEventHandlerWithHandled(sender, args as RoutedEventArgs);
			}
			return null;
		}
	}

	private struct NativePointerEventArgs
	{
		public double pointerId;

		public double x;

		public double y;

		public bool ctrl;

		public bool shift;

		public int buttons;

		public int buttonUpdate;

		public string typeStr;

		public int srcHandle;

		public double timestamp;

		public double pressure;

		public double wheelDeltaX;

		public double wheelDeltaY;
	}

	private static class UIElementNativeRegistrar
	{
		private static readonly Dictionary<Type, int> _classNames = new Dictionary<Type, int>();

		internal static int GetForType(Type type)
		{
			if (!_classNames.TryGetValue(type, out var value))
			{
				value = (_classNames[type] = WindowManagerInterop.RegisterUIElement(type.FullName, GetClassesForType(type).ToArray(), type.Is<FrameworkElement>()));
			}
			return value;
		}

		private static IEnumerable<string> GetClassesForType(Type type)
		{
			while (type != null && type != typeof(object))
			{
				yield return type.Name.ToLowerInvariant();
				type = type.BaseType;
			}
		}
	}

	private readonly SerialDisposable _clipSubscription = new SerialDisposable();

	private XamlRoot _xamlRoot;

	private string _uid;

	private VirtualizationInformation _virtualizationInformation;

	internal NativeRenderTransformAdapter _renderTransform;

	[ThreadStatic]
	private static bool _isInUpdateLayout;

	[ThreadStatic]
	private static bool _isLayoutingVisualTreeRoot;

	private const int MaxLayoutIterations = 250;

	private const KeyboardNavigationMode UnsetKeyboardNavigationMode = (KeyboardNavigationMode)3;

	private KeyboardNavigationMode _keyboardNavigationMode = (KeyboardNavigationMode)3;

	private bool _animateIfBringIntoView;

	private Lazy<GestureRecognizer> _gestures;

	private static readonly PropertyChangedCallback ClearPointersStateIfNeeded;

	private static readonly RoutedEventHandler ClearPointersStateOnUnload;

	private static readonly TypedEventHandler<GestureRecognizer, ManipulationStartingEventArgs> OnRecognizerManipulationStarting;

	private static readonly TypedEventHandler<GestureRecognizer, ManipulationStartedEventArgs> OnRecognizerManipulationStarted;

	private static readonly TypedEventHandler<GestureRecognizer, ManipulationUpdatedEventArgs> OnRecognizerManipulationUpdated;

	private static readonly TypedEventHandler<GestureRecognizer, ManipulationInertiaStartingEventArgs> OnRecognizerManipulationInertiaStarting;

	private static readonly TypedEventHandler<GestureRecognizer, ManipulationCompletedEventArgs> OnRecognizerManipulationCompleted;

	private static readonly TypedEventHandler<GestureRecognizer, TappedEventArgs> OnRecognizerTapped;

	private static readonly TypedEventHandler<GestureRecognizer, RightTappedEventArgs> OnRecognizerRightTapped;

	private static readonly TypedEventHandler<GestureRecognizer, HoldingEventArgs> OnRecognizerHolding;

	private static readonly TypedEventHandler<GestureRecognizer, DraggingEventArgs> OnRecognizerDragging;

	private bool _isGestureCompleted;

	[ThreadStatic]
	private static uint _lastDragStartFrameId;

	private static (UIElement sender, RoutedEvent @event, PointerRoutedEventArgs args) _pendingRaisedEvent;

	private readonly HashSet<uint> _pressedPointers = new HashSet<uint>();

	private List<Windows.UI.Xaml.Input.Pointer> _localExplicitCaptures;

	private HashSet<long> _draggingOver;

	private readonly Dictionary<RoutedEvent, List<RoutedEventHandlerInfo>> _eventHandlerStore = new Dictionary<RoutedEvent, List<RoutedEventHandlerInfo>>();

	private Size _size;

	private bool _isMeasureValid;

	private bool _isArrangeValid;

	private protected readonly Logger _log;

	private protected readonly Logger _logDebug;

	private readonly bool _isFrameworkElement;

	internal readonly MaterializableList<UIElement> _children = new MaterializableList<UIElement>();

	private readonly Dictionary<string, EventRegistration> _eventHandlers = new Dictionary<string, EventRegistration>(StringComparer.OrdinalIgnoreCase);

	private SerialDisposable _brushSubscription;

	internal const string DefaultHtmlTag = "div";

	private readonly GCHandle _gcHandle;

	private static Dictionary<Type, string> _htmlTagCache;

	private static Type _htmlElementAttribute;

	private static PropertyInfo _htmlTagAttributeTagGetter;

	private static readonly Assembly _unoUIAssembly;

	private Rect _arranged;

	private string _name;

	private RoutedEventFlag _registeredRoutedEvents;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace;

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	private bool _XYFocusKeyboardNavigationPropertyBackingFieldSet;

	private XYFocusKeyboardNavigationMode _XYFocusKeyboardNavigationPropertyBackingField;

	private bool _XYFocusDownNavigationStrategyPropertyBackingFieldSet;

	private XYFocusNavigationStrategy _XYFocusDownNavigationStrategyPropertyBackingField;

	private bool _XYFocusLeftNavigationStrategyPropertyBackingFieldSet;

	private XYFocusNavigationStrategy _XYFocusLeftNavigationStrategyPropertyBackingField;

	private bool _XYFocusRightNavigationStrategyPropertyBackingFieldSet;

	private XYFocusNavigationStrategy _XYFocusRightNavigationStrategyPropertyBackingField;

	private bool _XYFocusUpNavigationStrategyPropertyBackingFieldSet;

	private XYFocusNavigationStrategy _XYFocusUpNavigationStrategyPropertyBackingField;

	private bool _TabFocusNavigationPropertyBackingFieldSet;

	private KeyboardNavigationMode _TabFocusNavigationPropertyBackingField;

	private bool _FocusStatePropertyBackingFieldSet;

	private FocusState _FocusStatePropertyBackingField;

	private bool _TabIndexPropertyBackingFieldSet;

	private int _TabIndexPropertyBackingField;

	private bool _XYFocusUpPropertyBackingFieldSet;

	private DependencyObject _XYFocusUpPropertyBackingField;

	private bool _XYFocusDownPropertyBackingFieldSet;

	private DependencyObject _XYFocusDownPropertyBackingField;

	private bool _XYFocusLeftPropertyBackingFieldSet;

	private DependencyObject _XYFocusLeftPropertyBackingField;

	private bool _XYFocusRightPropertyBackingFieldSet;

	private DependencyObject _XYFocusRightPropertyBackingField;

	private bool _UseSystemFocusVisualsPropertyBackingFieldSet;

	private bool _UseSystemFocusVisualsPropertyBackingField;

	private bool _IsHitTestVisiblePropertyBackingFieldSet;

	private bool _IsHitTestVisiblePropertyBackingField;

	private bool _OpacityPropertyBackingFieldSet;

	private double _OpacityPropertyBackingField;

	private bool _VisibilityPropertyBackingFieldSet;

	private Visibility _VisibilityPropertyBackingField;

	private bool _ContextFlyoutPropertyBackingFieldSet;

	private FlyoutBase _ContextFlyoutPropertyBackingField;

	private bool _KeyboardAcceleratorsPropertyBackingFieldSet;

	private IList<KeyboardAccelerator> _KeyboardAcceleratorsPropertyBackingField;

	private bool _HitTestVisibilityPropertyBackingFieldSet;

	private HitTestability _HitTestVisibilityPropertyBackingField;

	internal bool __Grid_RowPropertyBackingFieldSet;

	internal int __Grid_RowPropertyBackingField;

	internal bool __Grid_ColumnPropertyBackingFieldSet;

	internal int __Grid_ColumnPropertyBackingField;

	internal bool __Grid_RowSpanPropertyBackingFieldSet;

	internal int __Grid_RowSpanPropertyBackingField;

	internal bool __Grid_ColumnSpanPropertyBackingFieldSet;

	internal int __Grid_ColumnSpanPropertyBackingField;

	internal bool __Canvas_LeftPropertyBackingFieldSet;

	internal double __Canvas_LeftPropertyBackingField;

	internal bool __Canvas_TopPropertyBackingFieldSet;

	internal double __Canvas_TopPropertyBackingField;

	internal bool __Canvas_ZIndexPropertyBackingFieldSet;

	internal double __Canvas_ZIndexPropertyBackingField;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Projection Projection
	{
		get
		{
			return (Projection)GetValue(ProjectionProperty);
		}
		set
		{
			SetValue(ProjectionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsTapEnabled
	{
		get
		{
			return (bool)GetValue(IsTapEnabledProperty);
		}
		set
		{
			SetValue(IsTapEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsRightTapEnabled
	{
		get
		{
			return (bool)GetValue(IsRightTapEnabledProperty);
		}
		set
		{
			SetValue(IsRightTapEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsHoldingEnabled
	{
		get
		{
			return (bool)GetValue(IsHoldingEnabledProperty);
		}
		set
		{
			SetValue(IsHoldingEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsDoubleTapEnabled
	{
		get
		{
			return (bool)GetValue(IsDoubleTapEnabledProperty);
		}
		set
		{
			SetValue(IsDoubleTapEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public CacheMode CacheMode
	{
		get
		{
			return (CacheMode)GetValue(CacheModeProperty);
		}
		set
		{
			SetValue(CacheModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool UseLayoutRounding
	{
		get
		{
			return (bool)GetValue(UseLayoutRoundingProperty);
		}
		set
		{
			SetValue(UseLayoutRoundingProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Shadow Shadow
	{
		get
		{
			return (Shadow)GetValue(ShadowProperty);
		}
		set
		{
			SetValue(ShadowProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 ActualOffset
	{
		get
		{
			throw new NotImplementedException("The member Vector3 UIElement.ActualOffset is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public UIContext UIContext
	{
		get
		{
			throw new NotImplementedException("The member UIContext UIElement.UIContext is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ElementCompositeMode CompositeMode
	{
		get
		{
			return (ElementCompositeMode)GetValue(CompositeModeProperty);
		}
		set
		{
			SetValue(CompositeModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Transform3D Transform3D
	{
		get
		{
			return (Transform3D)GetValue(Transform3DProperty);
		}
		set
		{
			SetValue(Transform3DProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsAccessKeyScope
	{
		get
		{
			return (bool)GetValue(IsAccessKeyScopeProperty);
		}
		set
		{
			SetValue(IsAccessKeyScopeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ExitDisplayModeOnAccessKeyInvoked
	{
		get
		{
			return (bool)GetValue(ExitDisplayModeOnAccessKeyInvokedProperty);
		}
		set
		{
			SetValue(ExitDisplayModeOnAccessKeyInvokedProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject AccessKeyScopeOwner
	{
		get
		{
			return (DependencyObject)GetValue(AccessKeyScopeOwnerProperty);
		}
		set
		{
			SetValue(AccessKeyScopeOwnerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string AccessKey
	{
		get
		{
			return (string)GetValue(AccessKeyProperty);
		}
		set
		{
			SetValue(AccessKeyProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double KeyTipHorizontalOffset
	{
		get
		{
			return (double)GetValue(KeyTipHorizontalOffsetProperty);
		}
		set
		{
			SetValue(KeyTipHorizontalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ElementHighContrastAdjustment HighContrastAdjustment
	{
		get
		{
			return (ElementHighContrastAdjustment)GetValue(HighContrastAdjustmentProperty);
		}
		set
		{
			SetValue(HighContrastAdjustmentProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public double KeyTipVerticalOffset
	{
		get
		{
			return (double)GetValue(KeyTipVerticalOffsetProperty);
		}
		set
		{
			SetValue(KeyTipVerticalOffsetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public KeyTipPlacementMode KeyTipPlacementMode
	{
		get
		{
			return (KeyTipPlacementMode)GetValue(KeyTipPlacementModeProperty);
		}
		set
		{
			SetValue(KeyTipPlacementModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<XamlLight> Lights => (IList<XamlLight>)GetValue(LightsProperty);

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject KeyboardAcceleratorPlacementTarget
	{
		get
		{
			return (DependencyObject)GetValue(KeyboardAcceleratorPlacementTargetProperty);
		}
		set
		{
			SetValue(KeyboardAcceleratorPlacementTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public KeyboardAcceleratorPlacementMode KeyboardAcceleratorPlacementMode
	{
		get
		{
			return (KeyboardAcceleratorPlacementMode)GetValue(KeyboardAcceleratorPlacementModeProperty);
		}
		set
		{
			SetValue(KeyboardAcceleratorPlacementModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DependencyObject KeyTipTarget
	{
		get
		{
			return (DependencyObject)GetValue(KeyTipTargetProperty);
		}
		set
		{
			SetValue(KeyTipTargetProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3Transition TranslationTransition
	{
		get
		{
			throw new NotImplementedException("The member Vector3Transition UIElement.TranslationTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3Transition UIElement.TranslationTransition");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ScalarTransition OpacityTransition
	{
		get
		{
			throw new NotImplementedException("The member ScalarTransition UIElement.OpacityTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "ScalarTransition UIElement.OpacityTransition");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Matrix4x4 TransformMatrix
	{
		get
		{
			throw new NotImplementedException("The member Matrix4x4 UIElement.TransformMatrix is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Matrix4x4 UIElement.TransformMatrix");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3Transition ScaleTransition
	{
		get
		{
			throw new NotImplementedException("The member Vector3Transition UIElement.ScaleTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3Transition UIElement.ScaleTransition");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 Scale
	{
		get
		{
			throw new NotImplementedException("The member Vector3 UIElement.Scale is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3 UIElement.Scale");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public ScalarTransition RotationTransition
	{
		get
		{
			throw new NotImplementedException("The member ScalarTransition UIElement.RotationTransition is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "ScalarTransition UIElement.RotationTransition");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 RotationAxis
	{
		get
		{
			throw new NotImplementedException("The member Vector3 UIElement.RotationAxis is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3 UIElement.RotationAxis");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public float Rotation
	{
		get
		{
			throw new NotImplementedException("The member float UIElement.Rotation is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "float UIElement.Rotation");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 Translation
	{
		get
		{
			throw new NotImplementedException("The member Vector3 UIElement.Translation is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3 UIElement.Translation");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Vector3 CenterPoint
	{
		get
		{
			throw new NotImplementedException("The member Vector3 UIElement.CenterPoint is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "Vector3 UIElement.CenterPoint");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CanBeScrollAnchor
	{
		get
		{
			return (bool)GetValue(CanBeScrollAnchorProperty);
		}
		set
		{
			SetValue(CanBeScrollAnchorProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsDoubleTapEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsHoldingEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsRightTapEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsTapEnabledProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ProjectionProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty UseLayoutRoundingProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CacheModeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ShadowProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CompositeModeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty Transform3DProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AccessKeyProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty AccessKeyScopeOwnerProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsAccessKeyScopeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ExitDisplayModeOnAccessKeyInvokedProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HighContrastAdjustmentProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyTipHorizontalOffsetProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyTipPlacementModeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyTipVerticalOffsetProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LightsProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RoutedEvent CharacterReceivedEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent UIElement.CharacterReceivedEvent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RoutedEvent PreviewKeyDownEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent UIElement.PreviewKeyDownEvent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RoutedEvent PreviewKeyUpEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent UIElement.PreviewKeyUpEvent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RoutedEvent BringIntoViewRequestedEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent UIElement.BringIntoViewRequestedEvent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RoutedEvent ContextRequestedEvent
	{
		get
		{
			throw new NotImplementedException("The member RoutedEvent UIElement.ContextRequestedEvent is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyTipTargetProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyboardAcceleratorPlacementModeProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty KeyboardAcceleratorPlacementTargetProperty { get; }

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty CanBeScrollAnchorProperty { get; }

	internal bool IsScrollPort { get; private set; }

	internal Point ScrollOffsets { get; private protected set; }

	internal bool IsWindowRoot { get; set; }

	internal bool IsVisualTreeRoot { get; set; }

	private protected virtual bool IsTabStopDefaultValue => false;

	public Vector2 ActualSize => new Vector2((float)GetActualWidth(), (float)GetActualHeight());

	internal Size AssignedActualSize { get; set; }

	string IXUidProvider.Uid
	{
		get
		{
			return _uid;
		}
		set
		{
			_uid = value;
			OnUidChangedPartial();
		}
	}

	public XamlRoot XamlRoot
	{
		get
		{
			return _xamlRoot ?? XamlRoot.Current;
		}
		set
		{
			_xamlRoot = value;
		}
	}

	internal bool IsGeneratedContainer
	{
		get
		{
			return _virtualizationInformation?.IsGeneratedContainer ?? false;
		}
		set
		{
			GetVirtualizationInformation().IsGeneratedContainer = value;
		}
	}

	internal bool IsContainerFromTemplateRoot
	{
		get
		{
			return _virtualizationInformation?.IsContainerFromTemplateRoot ?? false;
		}
		set
		{
			GetVirtualizationInformation().IsContainerFromTemplateRoot = value;
		}
	}

	public RectangleGeometry Clip
	{
		get
		{
			return (RectangleGeometry)GetValue(ClipProperty);
		}
		set
		{
			SetValue(ClipProperty, value);
		}
	}

	public static DependencyProperty ClipProperty { get; }

	public Transform RenderTransform
	{
		get
		{
			return (Transform)GetValue(RenderTransformProperty);
		}
		set
		{
			SetValue(RenderTransformProperty, value);
		}
	}

	public static DependencyProperty RenderTransformProperty { get; }

	public Point RenderTransformOrigin
	{
		get
		{
			return (Point)GetValue(RenderTransformOriginProperty);
		}
		set
		{
			SetValue(RenderTransformOriginProperty, value);
		}
	}

	public static DependencyProperty RenderTransformOriginProperty { get; }

	internal bool IsRenderingSuspended { get; set; }

	Size IUIElement.LastAvailableSize { get; set; }

	internal Size LastAvailableSize => ((IUIElement)this).LastAvailableSize;

	Rect IUIElement.LayoutSlot { get; set; }

	internal Rect LayoutSlot => ((IUIElement)this).LayoutSlot;

	internal Rect LayoutSlotWithMarginsAndAlignments { get; set; }

	internal bool NeedsClipToSlot { get; set; }

	Size IUIElement.DesiredSize { get; set; }

	public XYFocusKeyboardNavigationMode XYFocusKeyboardNavigation
	{
		get
		{
			return GetXYFocusKeyboardNavigationValue();
		}
		set
		{
			SetXYFocusKeyboardNavigationValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = XYFocusKeyboardNavigationMode.Auto, Options = FrameworkPropertyMetadataOptions.Inherits)]
	public static DependencyProperty XYFocusKeyboardNavigationProperty { get; }

	public XYFocusNavigationStrategy XYFocusDownNavigationStrategy
	{
		get
		{
			return GetXYFocusDownNavigationStrategyValue();
		}
		set
		{
			SetXYFocusDownNavigationStrategyValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = XYFocusNavigationStrategy.Auto)]
	public static DependencyProperty XYFocusDownNavigationStrategyProperty { get; }

	public XYFocusNavigationStrategy XYFocusLeftNavigationStrategy
	{
		get
		{
			return GetXYFocusLeftNavigationStrategyValue();
		}
		set
		{
			SetXYFocusLeftNavigationStrategyValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = XYFocusNavigationStrategy.Auto)]
	public static DependencyProperty XYFocusLeftNavigationStrategyProperty { get; }

	public XYFocusNavigationStrategy XYFocusRightNavigationStrategy
	{
		get
		{
			return GetXYFocusRightNavigationStrategyValue();
		}
		set
		{
			SetXYFocusRightNavigationStrategyValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = XYFocusNavigationStrategy.Auto)]
	public static DependencyProperty XYFocusRightNavigationStrategyProperty { get; }

	public XYFocusNavigationStrategy XYFocusUpNavigationStrategy
	{
		get
		{
			return GetXYFocusUpNavigationStrategyValue();
		}
		set
		{
			SetXYFocusUpNavigationStrategyValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = XYFocusNavigationStrategy.Auto)]
	public static DependencyProperty XYFocusUpNavigationStrategyProperty { get; }

	public KeyboardNavigationMode TabFocusNavigation
	{
		get
		{
			return GetTabFocusNavigationValue();
		}
		set
		{
			SetTabFocusNavigationValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = KeyboardNavigationMode.Local)]
	public static DependencyProperty TabFocusNavigationProperty { get; }

	public FocusState FocusState
	{
		get
		{
			return GetFocusStateValue();
		}
		set
		{
			SetFocusStateValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = FocusState.Unfocused)]
	public static DependencyProperty FocusStateProperty { get; }

	public bool IsTabStop
	{
		get
		{
			return (bool)GetValue(IsTabStopProperty);
		}
		set
		{
			SetValue(IsTabStopProperty, value);
		}
	}

	public static DependencyProperty IsTabStopProperty { get; }

	public int TabIndex
	{
		get
		{
			return GetTabIndexValue();
		}
		set
		{
			SetTabIndexValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = int.MaxValue)]
	public static DependencyProperty TabIndexProperty { get; }

	public DependencyObject XYFocusUp
	{
		get
		{
			return GetXYFocusUpValue();
		}
		set
		{
			SetXYFocusUpValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty XYFocusUpProperty { get; }

	public DependencyObject XYFocusDown
	{
		get
		{
			return GetXYFocusDownValue();
		}
		set
		{
			SetXYFocusDownValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty XYFocusDownProperty { get; }

	public DependencyObject XYFocusLeft
	{
		get
		{
			return GetXYFocusLeftValue();
		}
		set
		{
			SetXYFocusLeftValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty XYFocusLeftProperty { get; }

	public DependencyObject XYFocusRight
	{
		get
		{
			return GetXYFocusRightValue();
		}
		set
		{
			SetXYFocusRightValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	public static DependencyProperty XYFocusRightProperty { get; }

	public bool UseSystemFocusVisuals
	{
		get
		{
			return GetUseSystemFocusVisualsValue();
		}
		set
		{
			SetUseSystemFocusVisualsValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = false)]
	public static DependencyProperty UseSystemFocusVisualsProperty { get; }

	internal virtual bool IsFocusable
	{
		get
		{
			if (IsVisible())
			{
				if (!IsEnabled())
				{
					FrameworkElement obj = this as FrameworkElement;
					if (obj == null || !obj.AllowFocusWhenDisabled)
					{
						goto IL_003b;
					}
				}
				if (IsTabStop || IsFocusableForFocusEngagement())
				{
					return AreAllAncestorsVisible();
				}
			}
			goto IL_003b;
			IL_003b:
			return false;
		}
	}

	internal bool IsFocused => FocusState != FocusState.Unfocused;

	internal bool IsKeyboardFocused => FocusState == FocusState.Keyboard;

	internal bool SkipFocusSubtree { get; set; }

	internal bool IsGamepadFocusCandidate { get; set; } = true;


	internal bool IsTabNavigationSet
	{
		get
		{
			DependencyPropertyValuePrecedences dependencyPropertyValuePrecedences = DependencyPropertyValuePrecedences.DefaultValue;
			if (this is Control dependencyObject)
			{
				dependencyPropertyValuePrecedences = dependencyObject.GetCurrentHighestValuePrecedence(Control.TabNavigationProperty);
			}
			DependencyPropertyValuePrecedences currentHighestValuePrecedence = this.GetCurrentHighestValuePrecedence(TabFocusNavigationProperty);
			if (currentHighestValuePrecedence < dependencyPropertyValuePrecedences)
			{
				dependencyPropertyValuePrecedences = currentHighestValuePrecedence;
			}
			return dependencyPropertyValuePrecedences < DependencyPropertyValuePrecedences.DefaultValue;
		}
	}

	internal bool IsInLiveTree
	{
		get
		{
			if (!IsLoading)
			{
				return IsLoaded;
			}
			return true;
		}
	}

	private protected DispatcherQueue DispatcherQueue => DispatcherQueue.GetForCurrentThread();

	public static DependencyProperty ManipulationModeProperty { get; }

	public ManipulationModes ManipulationMode
	{
		get
		{
			return (ManipulationModes)GetValue(ManipulationModeProperty);
		}
		set
		{
			SetValue(ManipulationModeProperty, value);
		}
	}

	public static DependencyProperty CanDragProperty { get; }

	public bool CanDrag
	{
		get
		{
			return (bool)GetValue(CanDragProperty);
		}
		set
		{
			SetValue(CanDragProperty, value);
		}
	}

	public static DependencyProperty AllowDropProperty { get; }

	public bool AllowDrop
	{
		get
		{
			return (bool)GetValue(AllowDropProperty);
		}
		set
		{
			SetValue(AllowDropProperty, value);
		}
	}

	private bool IsPointersSuspended => _gestures == null;

	private bool HasManipulationHandler
	{
		get
		{
			if (CountHandler(ManipulationStartingEvent) == 0 && CountHandler(ManipulationStartedEvent) == 0 && CountHandler(ManipulationDeltaEvent) == 0 && CountHandler(ManipulationInertiaStartingEvent) == 0)
			{
				return CountHandler(ManipulationCompletedEvent) != 0;
			}
			return true;
		}
	}

	internal bool IsPointerOver { get; set; }

	internal bool IsPointerPressed => _pressedPointers.Count != 0;

	public static DependencyProperty PointerCapturesProperty { get; }

	public IReadOnlyList<Windows.UI.Xaml.Input.Pointer> PointerCaptures => (IReadOnlyList<Windows.UI.Xaml.Input.Pointer>)GetValue(PointerCapturesProperty);

	internal bool HasPointerCapture => (_localExplicitCaptures?.Count ?? 0) != 0;

	[GeneratedDependencyProperty(DefaultValue = true, ChangedCallback = true)]
	public static DependencyProperty IsHitTestVisibleProperty { get; }

	public bool IsHitTestVisible
	{
		get
		{
			return GetIsHitTestVisibleValue();
		}
		set
		{
			SetIsHitTestVisibleValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = 1.0, ChangedCallback = true)]
	public static DependencyProperty OpacityProperty { get; }

	public double Opacity
	{
		get
		{
			return GetOpacityValue();
		}
		set
		{
			SetOpacityValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = Visibility.Visible, ChangedCallback = true, Options = FrameworkPropertyMetadataOptions.AffectsMeasure)]
	public static DependencyProperty VisibilityProperty { get; }

	public Visibility Visibility
	{
		get
		{
			return GetVisibilityValue();
		}
		set
		{
			SetVisibilityValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null, ChangedCallback = true)]
	public static DependencyProperty ContextFlyoutProperty { get; }

	public FlyoutBase ContextFlyout
	{
		get
		{
			return GetContextFlyoutValue();
		}
		set
		{
			SetContextFlyoutValue(value);
		}
	}

	[GeneratedDependencyProperty(DefaultValue = null)]
	internal static DependencyProperty KeyboardAcceleratorsProperty { get; }

	public IList<KeyboardAccelerator> KeyboardAccelerators
	{
		get
		{
			return GetKeyboardAcceleratorsValue() ?? (KeyboardAccelerators = new List<KeyboardAccelerator>());
		}
		set
		{
			SetKeyboardAcceleratorsValue(value);
		}
	}

	public static RoutedEvent PointerPressedEvent { get; }

	public static RoutedEvent PointerReleasedEvent { get; }

	public static RoutedEvent PointerEnteredEvent { get; }

	public static RoutedEvent PointerExitedEvent { get; }

	public static RoutedEvent PointerMovedEvent { get; }

	public static RoutedEvent PointerCanceledEvent { get; }

	public static RoutedEvent PointerCaptureLostEvent { get; }

	public static RoutedEvent PointerWheelChangedEvent { get; }

	public static RoutedEvent ManipulationStartingEvent { get; }

	public static RoutedEvent ManipulationStartedEvent { get; }

	public static RoutedEvent ManipulationDeltaEvent { get; }

	public static RoutedEvent ManipulationInertiaStartingEvent { get; }

	public static RoutedEvent ManipulationCompletedEvent { get; }

	public static RoutedEvent TappedEvent { get; }

	public static RoutedEvent DoubleTappedEvent { get; }

	public static RoutedEvent RightTappedEvent { get; }

	public static RoutedEvent HoldingEvent { get; }

	internal static RoutedEvent DragStartingEvent { get; }

	public static RoutedEvent DragEnterEvent { get; }

	public static RoutedEvent DragOverEvent { get; }

	public static RoutedEvent DragLeaveEvent { get; }

	public static RoutedEvent DropEvent { get; }

	internal static RoutedEvent DropCompletedEvent { get; }

	public static RoutedEvent KeyDownEvent { get; }

	public static RoutedEvent KeyUpEvent { get; }

	internal static RoutedEvent GotFocusEvent { get; }

	internal static RoutedEvent LostFocusEvent { get; }

	public static RoutedEvent GettingFocusEvent { get; }

	public static RoutedEvent LosingFocusEvent { get; }

	public static RoutedEvent NoFocusCandidateFoundEvent { get; }

	public static DependencyProperty EventsBubblingInManagedCodeProperty { get; }

	public RoutedEventFlag EventsBubblingInManagedCode
	{
		get
		{
			return (RoutedEventFlag)GetValue(EventsBubblingInManagedCodeProperty);
		}
		set
		{
			SetValue(EventsBubblingInManagedCodeProperty, value);
		}
	}

	private static DependencyProperty SubscribedToHandledEventsTooProperty { get; }

	private RoutedEventFlag SubscribedToHandledEventsToo
	{
		get
		{
			return (RoutedEventFlag)GetValue(SubscribedToHandledEventsTooProperty);
		}
		set
		{
			SetValue(SubscribedToHandledEventsTooProperty, value);
		}
	}

	public Size DesiredSize
	{
		get
		{
			if (Visibility != Visibility.Collapsed)
			{
				return ((IUIElement)this).DesiredSize;
			}
			return new Size(0.0, 0.0);
		}
	}

	internal bool IsMeasureDirty => !_isMeasureValid;

	internal bool IsArrangeDirty => !_isArrangeValid;

	internal bool ShouldInterceptInvalidate { get; set; }

	public Size RenderSize
	{
		get
		{
			if (Visibility != Visibility.Collapsed)
			{
				return _size;
			}
			return default(Size);
		}
		internal set
		{
			Size size = _size;
			_size = value;
			if (_size != size && this is FrameworkElement frameworkElement)
			{
				frameworkElement.SetActualSize(_size);
				frameworkElement.RaiseSizeChanged(new SizeChangedEventArgs(this, size, _size));
			}
		}
	}

	internal bool IsLoaded { get; private protected set; }

	internal bool IsLoading { get; private protected set; }

	internal int Depth { get; private set; } = int.MinValue;


	[GeneratedDependencyProperty(DefaultValue = HitTestability.Collapsed, ChangedCallback = true, CoerceCallback = true, Options = FrameworkPropertyMetadataOptions.Inherits)]
	internal static DependencyProperty HitTestVisibilityProperty { get; }

	internal HitTestability HitTestVisibility
	{
		get
		{
			return GetHitTestVisibilityValue();
		}
		set
		{
			SetHitTestVisibilityValue(value);
		}
	}

	public IntPtr Handle { get; }

	public IntPtr HtmlId { get; }

	public string HtmlTag { get; }

	public bool HtmlTagIsSvg { get; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			if (FeatureConfiguration.UIElement.AssignDOMXamlName)
			{
				WindowManagerInterop.SetName(HtmlId, _name);
			}
		}
	}

	public int MeasureCallCount { get; protected set; }

	public int ArrangeCallCount { get; protected set; }

	public Size? RequestedDesiredSize { get; set; }

	public Size AvailableMeasureSize { get; protected set; }

	public Rect Arranged
	{
		get
		{
			return _arranged;
		}
		set
		{
			ArrangeCallCount++;
			_arranged = value;
		}
	}

	public Func<Size, Size> DesiredSizeSelector { get; set; }

	public CoreDispatcher Dispatcher => CoreApplication.MainView.Dispatcher;

	private DependencyObjectStore __Store
	{
		get
		{
			if (__storeBackingField == null)
			{
				__storeBackingField = new DependencyObjectStore(this, DataContextProperty, TemplatedParentProperty);
				__InitializeBinder();
			}
			return __storeBackingField;
		}
	}

	public bool IsStoreInitialized => __storeBackingField != null;

	DependencyObjectStore IDependencyObjectStoreProvider.Store => __Store;

	ManagedWeakReference IWeakReferenceProvider.WeakReference
	{
		get
		{
			if (_selfWeakReference == null)
			{
				_selfWeakReference = WeakReferencePool.RentSelfWeakReference(this);
			}
			return _selfWeakReference;
		}
	}

	public object DataContext
	{
		get
		{
			return GetValue(DataContextProperty);
		}
		set
		{
			SetValue(DataContextProperty, value);
		}
	}

	public static DependencyProperty DataContextProperty { get; }

	public DependencyObject TemplatedParent
	{
		get
		{
			return (DependencyObject)GetValue(TemplatedParentProperty);
		}
		set
		{
			SetValue(TemplatedParentProperty, value);
		}
	}

	public static DependencyProperty TemplatedParentProperty { get; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	internal bool IsAutoPropertyInheritanceEnabled
	{
		get
		{
			return __Store.IsAutoPropertyInheritanceEnabled;
		}
		set
		{
			__Store.IsAutoPropertyInheritanceEnabled = value;
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, AccessKeyDisplayDismissedEventArgs> AccessKeyDisplayDismissed
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyDisplayDismissedEventArgs> UIElement.AccessKeyDisplayDismissed");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyDisplayDismissedEventArgs> UIElement.AccessKeyDisplayDismissed");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, AccessKeyDisplayRequestedEventArgs> AccessKeyDisplayRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyDisplayRequestedEventArgs> UIElement.AccessKeyDisplayRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyDisplayRequestedEventArgs> UIElement.AccessKeyDisplayRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, AccessKeyInvokedEventArgs> AccessKeyInvoked
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyInvokedEventArgs> UIElement.AccessKeyInvoked");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, AccessKeyInvokedEventArgs> UIElement.AccessKeyInvoked");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, RoutedEventArgs> ContextCanceled
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, RoutedEventArgs> UIElement.ContextCanceled");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, RoutedEventArgs> UIElement.ContextCanceled");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, ContextRequestedEventArgs> ContextRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, ContextRequestedEventArgs> UIElement.ContextRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, ContextRequestedEventArgs> UIElement.ContextRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, CharacterReceivedRoutedEventArgs> CharacterReceived
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, CharacterReceivedRoutedEventArgs> UIElement.CharacterReceived");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, CharacterReceivedRoutedEventArgs> UIElement.CharacterReceived");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event KeyEventHandler PreviewKeyDown
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event KeyEventHandler UIElement.PreviewKeyDown");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event KeyEventHandler UIElement.PreviewKeyDown");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event KeyEventHandler PreviewKeyUp
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event KeyEventHandler UIElement.PreviewKeyUp");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event KeyEventHandler UIElement.PreviewKeyUp");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, ProcessKeyboardAcceleratorEventArgs> ProcessKeyboardAccelerators
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, ProcessKeyboardAcceleratorEventArgs> UIElement.ProcessKeyboardAccelerators");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, ProcessKeyboardAcceleratorEventArgs> UIElement.ProcessKeyboardAccelerators");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<UIElement, BringIntoViewRequestedEventArgs> BringIntoViewRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, BringIntoViewRequestedEventArgs> UIElement.BringIntoViewRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "event TypedEventHandler<UIElement, BringIntoViewRequestedEventArgs> UIElement.BringIntoViewRequested");
		}
	}

	public event RoutedEventHandler LostFocus
	{
		add
		{
			AddHandler(LostFocusEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(LostFocusEvent, value);
		}
	}

	public event RoutedEventHandler GotFocus
	{
		add
		{
			AddHandler(GotFocusEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(GotFocusEvent, value);
		}
	}

	public event TypedEventHandler<UIElement, LosingFocusEventArgs> LosingFocus
	{
		add
		{
			AddHandler(LosingFocusEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(LosingFocusEvent, value);
		}
	}

	public event TypedEventHandler<UIElement, GettingFocusEventArgs> GettingFocus
	{
		add
		{
			AddHandler(GettingFocusEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(GettingFocusEvent, value);
		}
	}

	public event TypedEventHandler<UIElement, NoFocusCandidateFoundEventArgs> NoFocusCandidateFound
	{
		add
		{
			AddHandler(NoFocusCandidateFoundEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(NoFocusCandidateFoundEvent, value);
		}
	}

	public event PointerEventHandler PointerCanceled
	{
		add
		{
			AddHandler(PointerCanceledEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerCanceledEvent, value);
		}
	}

	public event PointerEventHandler PointerCaptureLost
	{
		add
		{
			AddHandler(PointerCaptureLostEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerCaptureLostEvent, value);
		}
	}

	public event PointerEventHandler PointerEntered
	{
		add
		{
			AddHandler(PointerEnteredEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerEnteredEvent, value);
		}
	}

	public event PointerEventHandler PointerExited
	{
		add
		{
			AddHandler(PointerExitedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerExitedEvent, value);
		}
	}

	public event PointerEventHandler PointerMoved
	{
		add
		{
			AddHandler(PointerMovedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerMovedEvent, value);
		}
	}

	public event PointerEventHandler PointerPressed
	{
		add
		{
			AddHandler(PointerPressedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerPressedEvent, value);
		}
	}

	public event PointerEventHandler PointerReleased
	{
		add
		{
			AddHandler(PointerReleasedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerReleasedEvent, value);
		}
	}

	public event PointerEventHandler PointerWheelChanged
	{
		add
		{
			AddHandler(PointerWheelChangedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(PointerWheelChangedEvent, value);
		}
	}

	public event ManipulationStartingEventHandler ManipulationStarting
	{
		add
		{
			AddHandler(ManipulationStartingEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(ManipulationStartingEvent, value);
		}
	}

	public event ManipulationStartedEventHandler ManipulationStarted
	{
		add
		{
			AddHandler(ManipulationStartedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(ManipulationStartedEvent, value);
		}
	}

	public event ManipulationDeltaEventHandler ManipulationDelta
	{
		add
		{
			AddHandler(ManipulationDeltaEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(ManipulationDeltaEvent, value);
		}
	}

	public event ManipulationInertiaStartingEventHandler ManipulationInertiaStarting
	{
		add
		{
			AddHandler(ManipulationInertiaStartingEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(ManipulationInertiaStartingEvent, value);
		}
	}

	public event ManipulationCompletedEventHandler ManipulationCompleted
	{
		add
		{
			AddHandler(ManipulationCompletedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(ManipulationCompletedEvent, value);
		}
	}

	public event TappedEventHandler Tapped
	{
		add
		{
			AddHandler(TappedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(TappedEvent, value);
		}
	}

	public event DoubleTappedEventHandler DoubleTapped
	{
		add
		{
			AddHandler(DoubleTappedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DoubleTappedEvent, value);
		}
	}

	public event RightTappedEventHandler RightTapped
	{
		add
		{
			AddHandler(RightTappedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(RightTappedEvent, value);
		}
	}

	public event HoldingEventHandler Holding
	{
		add
		{
			AddHandler(HoldingEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(HoldingEvent, value);
		}
	}

	public event TypedEventHandler<UIElement, DragStartingEventArgs> DragStarting
	{
		add
		{
			AddHandler(DragStartingEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DragStartingEvent, value);
		}
	}

	public event DragEventHandler DragEnter
	{
		add
		{
			AddHandler(DragEnterEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DragEnterEvent, value);
		}
	}

	public event DragEventHandler DragLeave
	{
		add
		{
			AddHandler(DragLeaveEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DragLeaveEvent, value);
		}
	}

	public event DragEventHandler DragOver
	{
		add
		{
			AddHandler(DragOverEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DragOverEvent, value);
		}
	}

	public event DragEventHandler Drop
	{
		add
		{
			AddHandler(DropEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DropEvent, value);
		}
	}

	public event TypedEventHandler<UIElement, DropCompletedEventArgs> DropCompleted
	{
		add
		{
			AddHandler(DropCompletedEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(DropCompletedEvent, value);
		}
	}

	public event KeyEventHandler KeyDown
	{
		add
		{
			AddHandler(KeyDownEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(KeyDownEvent, value);
		}
	}

	public event KeyEventHandler KeyUp
	{
		add
		{
			AddHandler(KeyUpEvent, value, handledEventsToo: false);
		}
		remove
		{
			RemoveHandler(KeyUpEvent, value);
		}
	}

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool CancelDirectManipulations()
	{
		throw new NotImplementedException("The member bool UIElement.CancelDirectManipulations() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void TryInvokeKeyboardAccelerator(ProcessKeyboardAcceleratorEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.TryInvokeKeyboardAccelerator(ProcessKeyboardAcceleratorEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartAnimation(ICompositionAnimationBase animation)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.StartAnimation(ICompositionAnimationBase animation)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StopAnimation(ICompositionAnimationBase animation)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.StopAnimation(ICompositionAnimationBase animation)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnDisconnectVisualChildren()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.OnDisconnectVisualChildren()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual IEnumerable<IEnumerable<Point>> FindSubElementsForTouchTargeting(Point point, Rect boundingRect)
	{
		throw new NotImplementedException("The member IEnumerable<IEnumerable<Point>> UIElement.FindSubElementsForTouchTargeting(Point point, Rect boundingRect) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnProcessKeyboardAccelerators(ProcessKeyboardAcceleratorEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.OnProcessKeyboardAccelerators(ProcessKeyboardAcceleratorEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnKeyboardAcceleratorInvoked(KeyboardAcceleratorInvokedEventArgs args)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.OnKeyboardAcceleratorInvoked(KeyboardAcceleratorInvokedEventArgs args)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void OnBringIntoViewRequested(BringIntoViewRequestedEventArgs e)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.OnBringIntoViewRequested(BringIntoViewRequestedEventArgs e)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual void PopulatePropertyInfoOverride(string propertyName, AnimationPropertyInfo animationPropertyInfo)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.PopulatePropertyInfoOverride(string propertyName, AnimationPropertyInfo animationPropertyInfo)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void PopulatePropertyInfo(string propertyName, AnimationPropertyInfo propertyInfo)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.UIElement", "void UIElement.PopulatePropertyInfo(string propertyName, AnimationPropertyInfo propertyInfo)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static bool TryStartDirectManipulation(Windows.UI.Xaml.Input.Pointer value)
	{
		throw new NotImplementedException("The member bool UIElement.TryStartDirectManipulation(Pointer value) is not implemented in Uno.");
	}

	public static void RegisterAsScrollPort(UIElement element)
	{
		element.IsScrollPort = true;
	}

	private void Initialize()
	{
		this.RegisterDefaultValueProvider(OnGetDefaultValue);
	}

	private bool OnGetDefaultValue(DependencyProperty property, out object defaultValue)
	{
		if (property == KeyboardAcceleratorsProperty)
		{
			defaultValue = new List<KeyboardAccelerator>(0);
			return true;
		}
		if (property == IsTabStopProperty)
		{
			defaultValue = IsTabStopDefaultValue;
			return true;
		}
		defaultValue = null;
		return false;
	}

	private protected virtual double GetActualWidth()
	{
		return AssignedActualSize.Width;
	}

	private protected virtual double GetActualHeight()
	{
		return AssignedActualSize.Height;
	}

	private void OnUidChangedPartial()
	{
		if (FeatureConfiguration.UIElement.AssignDOMXamlName)
		{
			WindowManagerInterop.SetXUid(HtmlId, _uid);
		}
	}

	internal VirtualizationInformation GetVirtualizationInformation()
	{
		return _virtualizationInformation ?? (_virtualizationInformation = new VirtualizationInformation());
	}

	private void OnClipChanged(DependencyPropertyChangedEventArgs e)
	{
		RectangleGeometry instance = e.NewValue as RectangleGeometry;
		ApplyClip();
		_clipSubscription.Disposable = instance.RegisterDisposableNestedPropertyChangedCallback(delegate
		{
			ApplyClip();
		}, new DependencyProperty[1] { RectangleGeometry.RectProperty }, new DependencyProperty[1] { Geometry.TransformProperty }, new DependencyProperty[2]
		{
			Geometry.TransformProperty,
			TranslateTransform.XProperty
		}, new DependencyProperty[2]
		{
			Geometry.TransformProperty,
			TranslateTransform.YProperty
		});
	}

	private static void OnRenderTransformChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		UIElement uIElement = (UIElement)dependencyObject;
		uIElement._renderTransform?.Dispose();
		if (args.NewValue is Transform transform)
		{
			uIElement._renderTransform = new NativeRenderTransformAdapter(uIElement, transform, uIElement.RenderTransformOrigin);
		}
		else
		{
			uIElement._renderTransform = null;
		}
	}

	private static void OnRenderTransformOriginChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		UIElement uIElement = (UIElement)dependencyObject;
		Point origin = (Point)args.NewValue;
		uIElement._renderTransform?.UpdateOrigin(origin);
	}

	public bool Focus(FocusState value)
	{
		return FocusImpl(value);
	}

	internal void Unfocus()
	{
		if (FocusProperties.HasFocusedElement(this))
		{
			VisualTree.GetFocusManagerForElement(this)?.ClearFocus();
		}
	}

	public GeneralTransform TransformToVisual(UIElement visual)
	{
		return new MatrixTransform
		{
			Matrix = new Matrix(GetTransform(this, visual))
		};
	}

	protected virtual void OnVisibilityChanged(Visibility oldValue, Visibility newVisibility)
	{
		OnVisibilityChangedPartial(oldValue, newVisibility);
		if (newVisibility != 0 && FocusProperties.HasFocusedElement(this))
		{
			FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
			focusManagerForElement?.SetFocusOnNextFocusableElement(focusManagerForElement.GetRealFocusStateForFocusedElement(), shouldFireFocusedRemoved: true);
		}
	}

	private void OnVisibilityChangedPartial(Visibility oldValue, Visibility newValue)
	{
		InvalidateMeasure();
		UpdateHitTest();
		WindowManagerInterop.SetVisibility(HtmlId, newValue == Visibility.Visible);
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMProperties();
		}
	}

	[NotImplemented]
	protected virtual AutomationPeer OnCreateAutomationPeer()
	{
		return new AutomationPeer();
	}

	internal AutomationPeer OnCreateAutomationPeerInternal()
	{
		return OnCreateAutomationPeer();
	}

	internal static Matrix3x2 GetTransform(UIElement from, UIElement to)
	{
		StringBuilder stringBuilder = (from.Log().IsEnabled(LogLevel.Debug) ? new StringBuilder() : null);
		stringBuilder?.Append(string.Format("{0}(from: {1}, to: {2}) Offsets: [", "GetTransform", from, to?.ToString() ?? "<null>"));
		if (from == to)
		{
			return Matrix3x2.Identity;
		}
		if (to != null && from.Depth < to.Depth)
		{
			return GetTransform(to, from).Inverse();
		}
		Matrix3x2 identity = Matrix3x2.Identity;
		double offsetX = 0.0;
		double offsetY = 0.0;
		UIElement parentElement = from;
		do
		{
			Rect layoutSlotWithMarginsAndAlignments = parentElement.LayoutSlotWithMarginsAndAlignments;
			Transform renderTransform = parentElement.RenderTransform;
			if (renderTransform == null)
			{
				offsetX += layoutSlotWithMarginsAndAlignments.X;
				offsetY += layoutSlotWithMarginsAndAlignments.Y;
			}
			else
			{
				Point renderTransformOrigin = parentElement.RenderTransformOrigin;
				Matrix3x2 matrix3x = ((renderTransformOrigin == default(Point)) ? renderTransform.MatrixCore : renderTransform.ToMatrix(renderTransformOrigin, layoutSlotWithMarginsAndAlignments.Size));
				identity *= Matrix3x2.CreateTranslation((float)offsetX, (float)offsetY);
				identity *= matrix3x;
				offsetX = layoutSlotWithMarginsAndAlignments.X;
				offsetY = layoutSlotWithMarginsAndAlignments.Y;
			}
			if (parentElement is Windows.UI.Xaml.Controls.ScrollViewer scrollViewer && parentElement != from)
			{
				float zoomFactor = scrollViewer.ZoomFactor;
				if (zoomFactor != 1f)
				{
					identity *= Matrix3x2.CreateTranslation((float)offsetX, (float)offsetY);
					identity *= Matrix3x2.CreateScale(zoomFactor);
				}
			}
			if (parentElement.IsScrollPort)
			{
				offsetX -= parentElement.ScrollOffsets.X;
				offsetY -= parentElement.ScrollOffsets.Y;
			}
			stringBuilder?.Append($"{parentElement}: ({offsetX}, {offsetY}), ");
		}
		while (parentElement.TryGetParentUIElementForTransformToVisual(out parentElement, ref offsetX, ref offsetY) && parentElement != to);
		identity *= Matrix3x2.CreateTranslation((float)offsetX, (float)offsetY);
		if (to != null && parentElement != to)
		{
			Matrix3x2 transform = GetTransform(to, null);
			Matrix3x2 matrix3x2 = transform.Inverse();
			identity *= matrix3x2;
		}
		if (stringBuilder != null)
		{
			stringBuilder.Append($"], matrix: {identity}");
			from.Log().LogDebug(stringBuilder.ToString());
		}
		return identity;
	}

	private bool TryGetParentUIElementForTransformToVisual(out UIElement parentElement, ref double offsetX, ref double offsetY)
	{
		object parent = this.GetParent();
		if (!(parent is UIElement uIElement))
		{
			if (parent == null)
			{
				parentElement = null;
				return false;
			}
			Application.Current.RaiseRecoverableUnhandledException(new InvalidOperationException("Found a parent which is NOT a UIElement."));
			parentElement = null;
			return false;
		}
		parentElement = uIElement;
		return true;
	}

	protected virtual void OnIsHitTestVisibleChanged(bool oldValue, bool newValue)
	{
		OnIsHitTestVisibleChangedPartial(oldValue, newValue);
	}

	private void OnIsHitTestVisibleChangedPartial(bool oldValue, bool newValue)
	{
		UpdateHitTest();
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMProperties();
		}
	}

	private void OnOpacityChanged(DependencyPropertyChangedEventArgs args)
	{
		double opacity = Opacity;
		if (opacity >= 1.0)
		{
			ResetStyle("opacity");
		}
		else
		{
			SetStyle("opacity", opacity);
		}
	}

	private protected virtual void OnContextFlyoutChanged(FlyoutBase oldValue, FlyoutBase newValue)
	{
		if (newValue != null)
		{
			RightTapped += OpenContextFlyout;
		}
		else
		{
			RightTapped -= OpenContextFlyout;
		}
	}

	private void OpenContextFlyout(object sender, RightTappedRoutedEventArgs args)
	{
		if (this is FrameworkElement placementTarget)
		{
			ContextFlyout?.ShowAt(placementTarget, new FlyoutShowOptions
			{
				Position = args.GetPosition(this)
			});
		}
	}

	public void UpdateLayout()
	{
		if (_isInUpdateLayout || _isLayoutingVisualTreeRoot)
		{
			return;
		}
		UIElement rootElement = Window.Current.RootElement;
		if (rootElement == null)
		{
			return;
		}
		try
		{
			InnerUpdateLayout(rootElement);
		}
		finally
		{
			_isInUpdateLayout = false;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void InnerUpdateLayout(UIElement root)
	{
		_isInUpdateLayout = true;
		Rect bounds = Window.Current.Bounds;
		for (int i = 0; i < 250; i++)
		{
			if (root.IsMeasureDirty)
			{
				root.Measure(bounds.Size);
				continue;
			}
			if (root.IsArrangeDirty)
			{
				root.Arrange(bounds);
				continue;
			}
			return;
		}
		throw new InvalidOperationException("Layout cycle detected.");
	}

	internal void ApplyClip()
	{
		Rect rect;
		if (Clip == null)
		{
			rect = Rect.Empty;
			if (NeedsClipToSlot)
			{
				rect = new Rect(0.0, 0.0, RenderSize.Width, RenderSize.Height);
			}
		}
		else
		{
			rect = Clip.Rect;
			if (Clip.Transform != null)
			{
				rect = Clip.Transform.TransformBounds(rect);
			}
		}
		ApplyNativeClip(rect);
		OnViewportUpdated(rect);
	}

	private void ApplyNativeClip(Rect rect)
	{
		if (rect.IsEmpty)
		{
			ResetStyle("clip");
			return;
		}
		double num = (double.IsInfinity(rect.Width) ? 100000.0 : rect.Width);
		double num2 = (double.IsInfinity(rect.Height) ? 100000.0 : rect.Height);
		SetStyle("clip", "rect(" + Math.Floor(rect.Y).ToStringInvariant() + "px," + Math.Ceiling(rect.X + num).ToStringInvariant() + "px," + Math.Ceiling(rect.Y + num2).ToStringInvariant() + "px," + Math.Floor(rect.X).ToStringInvariant() + "px)");
	}

	private protected virtual void OnViewportUpdated(Rect viewport)
	{
	}

	internal static object GetDependencyPropertyValueInternal(DependencyObject owner, string dependencyPropertyName)
	{
		DependencyProperty property = DependencyProperty.GetProperty(owner.GetType(), dependencyPropertyName);
		if (property != null)
		{
			return owner.GetValue(property);
		}
		return null;
	}

	internal static string SetDependencyPropertyValueInternal(DependencyObject owner, string dependencyPropertyNameAndValue)
	{
		int num = dependencyPropertyNameAndValue.IndexOf("|");
		if (num != -1)
		{
			string text = dependencyPropertyNameAndValue.Substring(0, num);
			string text2 = dependencyPropertyNameAndValue.Substring(num + 1);
			DependencyProperty property = DependencyProperty.GetProperty(owner.GetType(), text);
			if (property != null)
			{
				if (owner.Log().IsEnabled(LogLevel.Debug))
				{
					owner.Log().LogDebug("SetDependencyPropertyValue(" + text + ") = " + text2);
				}
				owner.SetValue(property, XamlBindingHelper.ConvertValue(property.Type, text2));
				return owner.GetValue(property)?.ToString();
			}
			if (owner.Log().IsEnabled(LogLevel.Debug))
			{
				owner.Log().LogDebug($"Failed to find property [{text}] on [{owner}]");
			}
			return "**** Failed to find property";
		}
		return "**** Invalid property and value format.";
	}

	internal virtual void OnPropertyChanged2(DependencyPropertyChangedEventArgs args)
	{
	}

	public void StartBringIntoView()
	{
		StartBringIntoView(new BringIntoViewOptions());
	}

	public void StartBringIntoView(BringIntoViewOptions options)
	{
	}

	internal virtual bool IsViewHit()
	{
		return true;
	}

	internal virtual bool IsEnabledOverride()
	{
		return true;
	}

	internal bool GetUseLayoutRounding()
	{
		return false;
	}

	internal double LayoutRound(double value)
	{
		return value;
	}

	internal Rect LayoutRound(Rect value)
	{
		return value;
	}

	internal Thickness LayoutRound(Thickness value)
	{
		return value;
	}

	internal Vector2 LayoutRound(Vector2 value)
	{
		return value;
	}

	internal Size LayoutRound(Size value)
	{
		return value;
	}

	private double LayoutRound(double value, double scaleFactor)
	{
		double num = value;
		if (scaleFactor != 1.0)
		{
			return XcpRound(num * scaleFactor) / scaleFactor;
		}
		return XcpRound(num);
	}

	internal double GetScaleFactorForLayoutRounding()
	{
		return DisplayInformation.GetForCurrentView().LogicalDpi / 96f;
	}

	private double XcpRound(double x)
	{
		return Math.Round(x);
	}

	private protected virtual void OnIsTabStopChanged(bool oldValue, bool newValue)
	{
	}

	internal virtual void UpdateFocusState(FocusState focusState)
	{
		if (focusState == FocusState)
		{
			return;
		}
		SetValue(FocusStateProperty, focusState);
		if ((focusState != FocusState.Keyboard && focusState != 0) || !UseSystemFocusVisuals)
		{
			return;
		}
		UIElement uIElement = null;
		if (this is Control control)
		{
			uIElement = control.FocusTargetDescendant;
		}
		if (uIElement != null)
		{
			FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this);
			NWSetContentDirty(uIElement, DirtyFlags.Render);
			if (focusState == FocusState.Unfocused)
			{
				focusManagerForElement?.SetFocusRectangleUIElement(null);
			}
			else
			{
				focusManagerForElement?.SetFocusRectangleUIElement(uIElement);
			}
		}
		else
		{
			NWSetContentDirty(this, DirtyFlags.Render);
		}
	}

	internal virtual bool IsFocusableForFocusEngagement()
	{
		return false;
	}

	private protected bool IsVisible()
	{
		return Visibility == Visibility.Visible;
	}

	private bool IsEnabled()
	{
		if (this is Control control)
		{
			return control.IsEnabled;
		}
		return true;
	}

	internal static void NWSetContentDirty(UIElement focusedElement, object render)
	{
	}

	internal KeyboardNavigationMode GetTabNavigation()
	{
		return TabFocusNavigation;
	}

	internal void SetTabNavigation(KeyboardNavigationMode mode)
	{
		if (!Enum.IsDefined(typeof(KeyboardNavigationMode), mode))
		{
			throw new ArgumentOutOfRangeException("mode");
		}
		_keyboardNavigationMode = mode;
	}

	internal float GetOffsetX()
	{
		object value = GetValue(Canvas.LeftProperty);
		return (value as float?).GetValueOrDefault();
	}

	internal float GetOffsetY()
	{
		object value = GetValue(Canvas.TopProperty);
		return (value as float?).GetValueOrDefault();
	}

	internal bool AreAllAncestorsVisible()
	{
		UIElement uIElement = this;
		while (uIElement != null)
		{
			UIElement uIElementAdjustedParentInternal = uIElement.GetUIElementAdjustedParentInternal();
			if (uIElementAdjustedParentInternal != null && uIElementAdjustedParentInternal.Visibility == Visibility.Collapsed)
			{
				return false;
			}
			uIElement = uIElementAdjustedParentInternal;
		}
		return true;
	}

	private protected AutomationPeer? GetOrCreateAutomationPeer()
	{
		bool flag = true;
		if (this is Popup popup)
		{
			flag = popup.IsOpen;
		}
		if (Visibility != Visibility.Collapsed && flag)
		{
			return OnCreateAutomationPeerInternal();
		}
		return null;
	}

	internal TabStopProcessingResult ProcessTabStop(DependencyObject? pFocusedElement, DependencyObject? pCandidateTabStopElement, bool isBackward, bool didCycleFocusAtRootVisualScope)
	{
		DependencyObject dependencyObject = null;
		DependencyObject dependencyObject2 = null;
		DependencyObject dependencyObject3 = null;
		DependencyObject dependencyObject4 = null;
		UIElement uIElement = null;
		UIElement uIElement2 = null;
		UIElement uIElement3 = null;
		TabStopProcessingResult tabStopProcessingResult = default(TabStopProcessingResult);
		TabStopProcessingResult tabStopProcessingResult2 = default(TabStopProcessingResult);
		if (pFocusedElement != null)
		{
			dependencyObject = pFocusedElement;
			uIElement = dependencyObject as UIElement;
			if (uIElement == null)
			{
				dependencyObject3 = VisualTreeHelper.GetParent(dependencyObject);
				uIElement = dependencyObject3 as UIElement;
			}
		}
		if (pCandidateTabStopElement != null)
		{
			dependencyObject2 = pCandidateTabStopElement;
			uIElement2 = dependencyObject2 as UIElement;
			if (uIElement2 == null)
			{
				dependencyObject4 = VisualTreeHelper.GetParent(dependencyObject2);
				uIElement2 = dependencyObject4 as UIElement;
			}
		}
		if (uIElement != null)
		{
			tabStopProcessingResult = uIElement.ProcessTabStopInternal(dependencyObject2, isBackward, didCycleFocusAtRootVisualScope);
		}
		if (!tabStopProcessingResult.IsOverriden && uIElement2 != null)
		{
			TabStopProcessingResult tabStopProcessingResult3 = uIElement2.ProcessCandidateTabStopInternal(dependencyObject, null, isBackward);
			tabStopProcessingResult.NewTabStop = tabStopProcessingResult3.NewTabStop;
			tabStopProcessingResult.IsOverriden = tabStopProcessingResult3.IsOverriden;
		}
		else if (tabStopProcessingResult.IsOverriden && tabStopProcessingResult.NewTabStop != null && tabStopProcessingResult.NewTabStop is UIElement uIElement4)
		{
			tabStopProcessingResult2 = uIElement4.ProcessCandidateTabStopInternal(dependencyObject, tabStopProcessingResult.NewTabStop, isBackward);
		}
		if (!tabStopProcessingResult.IsOverriden && !tabStopProcessingResult2.IsOverriden)
		{
			ApplicationBarService applicationBarService = DXamlCore.Current.TryGetApplicationBarService();
			if (applicationBarService != null)
			{
				TabStopProcessingResult tabStopProcessingResult4 = applicationBarService.ProcessTabStopOverride(dependencyObject, dependencyObject2, isBackward);
				tabStopProcessingResult.NewTabStop = tabStopProcessingResult4.NewTabStop;
				tabStopProcessingResult.IsOverriden = tabStopProcessingResult4.IsOverriden;
				if (tabStopProcessingResult.IsOverriden && tabStopProcessingResult.NewTabStop != null && tabStopProcessingResult.NewTabStop is UIElement uIElement5)
				{
					tabStopProcessingResult2 = uIElement5.ProcessCandidateTabStopInternal(dependencyObject, tabStopProcessingResult.NewTabStop, isBackward);
				}
			}
		}
		TabStopProcessingResult result = default(TabStopProcessingResult);
		if (tabStopProcessingResult2.IsOverriden)
		{
			if (tabStopProcessingResult2.NewTabStop != null)
			{
				result.NewTabStop = tabStopProcessingResult2.NewTabStop;
			}
			result.IsOverriden = true;
		}
		else if (tabStopProcessingResult.IsOverriden)
		{
			if (tabStopProcessingResult.NewTabStop != null)
			{
				result.NewTabStop = tabStopProcessingResult.NewTabStop;
			}
			result.IsOverriden = true;
		}
		return result;
	}

	private TabStopProcessingResult ProcessTabStopInternal(DependencyObject? pCandidateTabStop, bool isBackward, bool didCycleFocusAtRootVisualScope)
	{
		UIElement uIElement = this;
		TabStopProcessingResult result = default(TabStopProcessingResult);
		while (uIElement != null && !result.IsOverriden)
		{
			result = uIElement.ProcessTabStopOverride(this, pCandidateTabStop, isBackward, didCycleFocusAtRootVisualScope);
			DependencyObject parent = VisualTreeHelper.GetParent(uIElement);
			uIElement = parent as UIElement;
		}
		return result;
	}

	private TabStopProcessingResult ProcessCandidateTabStopInternal(DependencyObject? pCurrentTabStop, DependencyObject? pOverriddenCandidateTabStop, bool isBackward)
	{
		UIElement uIElement = this;
		TabStopProcessingResult result = default(TabStopProcessingResult);
		while (uIElement != null && !result.IsOverriden)
		{
			result = uIElement.ProcessCandidateTabStopOverride(pCurrentTabStop, this, pOverriddenCandidateTabStop, isBackward);
			DependencyObject parent = VisualTreeHelper.GetParent(uIElement);
			uIElement = parent as UIElement;
		}
		return result;
	}

	internal virtual TabStopProcessingResult ProcessTabStopOverride(DependencyObject? focusedElement, DependencyObject? candidateTabStopElement, bool isBackward, bool didCycleFocusAtRootVisualScope)
	{
		return default(TabStopProcessingResult);
	}

	internal virtual TabStopProcessingResult ProcessCandidateTabStopOverride(DependencyObject? focusedElement, DependencyObject candidateTabStopElement, DependencyObject? overriddenCandidateTabStopElement, bool isBackward)
	{
		return default(TabStopProcessingResult);
	}

	internal virtual DependencyObject? GetNextTabStopOverride()
	{
		return null;
	}

	internal virtual DependencyObject? GetPreviousTabStopOverride()
	{
		return null;
	}

	internal virtual DependencyObject? GetFirstFocusableElementOverride()
	{
		return null;
	}

	internal virtual DependencyObject? GetLastFocusableElementOverride()
	{
		return null;
	}

	internal UIElement? GetUIElementAdjustedParentInternal(bool publicParentsOnly = true, bool useRealParentForClosedParentedPopups = false)
	{
		for (DependencyObject parent = VisualTreeHelper.GetParent(this); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			if (parent is UIElement result)
			{
				return result;
			}
		}
		return null;
	}

	internal virtual bool CanHaveChildren()
	{
		return false;
	}

	internal DependencyObject? GetRootOfPopupSubTree()
	{
		DependencyObject parentInternal = this.GetParentInternal(publicParentOnly: false);
		DependencyObject result = this;
		while (parentInternal != null)
		{
			if (parentInternal is PopupRoot)
			{
				return result;
			}
			result = parentInternal;
			parentInternal = parentInternal.GetParentInternal(publicParentOnly: false);
		}
		return null;
	}

	internal bool Focus(FocusState focusState, bool animateIfBringIntoView, FocusNavigationDirection focusNavigationDirection = FocusNavigationDirection.None)
	{
		FocusManager focusManagerForElement = VisualTree.GetFocusManagerForElement(this, VisualTree.LookupOptions.NoFallback);
		if (focusManagerForElement == null)
		{
			return false;
		}
		FocusMovement focusMovement = new FocusMovement(this, focusNavigationDirection, focusState);
		focusMovement.AnimateIfBringIntoView = animateIfBringIntoView;
		FocusMovementResult focusMovementResult = focusManagerForElement.SetFocusedElement(focusMovement);
		return focusMovementResult.WasMoved;
	}

	internal Rect GetGlobalBounds(bool ignoreClipping)
	{
		return GetGlobalBoundsLogical(ignoreClipping);
	}

	internal Rect GetGlobalBoundsLogical(bool ignoreClipping = false, bool useTargetInformation = false)
	{
		RootVisual rootForElement = VisualTree.GetRootForElement(this);
		if (rootForElement == null)
		{
			return Rect.Empty;
		}
		GeneralTransform generalTransform = TransformToVisual(rootForElement);
		Point point = generalTransform.TransformPoint(Point.Zero);
		return new Rect(point.X, point.Y, GetActualWidth(), GetActualHeight());
	}

	internal void SetAnimateIfBringIntoView()
	{
		_animateIfBringIntoView = true;
	}

	internal bool FocusImpl(FocusState focusState)
	{
		return FocusWithDirection(focusState, FocusNavigationDirection.None);
	}

	internal bool FocusWithDirection(FocusState focusState, FocusNavigationDirection focusNavigationDirection)
	{
		if (focusState == FocusState.Unfocused)
		{
			throw new ArgumentOutOfRangeException("focusState", "Focus state Unfocused cannot be used when calling Focus.");
		}
		bool animateIfBringIntoView = _animateIfBringIntoView;
		_animateIfBringIntoView = false;
		return Focus(focusState, animateIfBringIntoView, focusNavigationDirection);
	}

	protected virtual IEnumerable<DependencyObject>? GetChildrenInTabFocusOrder()
	{
		DependencyObject[] focusChildren = FocusProperties.GetFocusChildren(this);
		if (focusChildren != null && focusChildren.Length != 0)
		{
			return focusChildren;
		}
		return Array.Empty<DependencyObject>();
	}

	internal IEnumerable<DependencyObject>? GetChildrenInTabFocusOrderInternal()
	{
		return GetChildrenInTabFocusOrder();
	}

	internal bool IsOccluded(UIElement? childElement, Rect elementBounds)
	{
		return false;
	}

	internal bool IsScroller()
	{
		return this is Windows.UI.Xaml.Controls.ScrollViewer;
	}

	static UIElement()
	{
		IsDoubleTapEnabledProperty = DependencyProperty.Register("IsDoubleTapEnabled", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		IsHoldingEnabledProperty = DependencyProperty.Register("IsHoldingEnabled", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		IsRightTapEnabledProperty = DependencyProperty.Register("IsRightTapEnabled", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		IsTapEnabledProperty = DependencyProperty.Register("IsTapEnabled", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		ProjectionProperty = DependencyProperty.Register("Projection", typeof(Projection), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		UseLayoutRoundingProperty = DependencyProperty.Register("UseLayoutRounding", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		CacheModeProperty = DependencyProperty.Register("CacheMode", typeof(CacheMode), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		ShadowProperty = DependencyProperty.Register("Shadow", typeof(Shadow), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		CompositeModeProperty = DependencyProperty.Register("CompositeMode", typeof(ElementCompositeMode), typeof(UIElement), new FrameworkPropertyMetadata(ElementCompositeMode.Inherit));
		Transform3DProperty = DependencyProperty.Register("Transform3D", typeof(Transform3D), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		AccessKeyProperty = DependencyProperty.Register("AccessKey", typeof(string), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		AccessKeyScopeOwnerProperty = DependencyProperty.Register("AccessKeyScopeOwner", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		IsAccessKeyScopeProperty = DependencyProperty.Register("IsAccessKeyScope", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		ExitDisplayModeOnAccessKeyInvokedProperty = DependencyProperty.Register("ExitDisplayModeOnAccessKeyInvoked", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		HighContrastAdjustmentProperty = DependencyProperty.Register("HighContrastAdjustment", typeof(ElementHighContrastAdjustment), typeof(UIElement), new FrameworkPropertyMetadata(ElementHighContrastAdjustment.None));
		KeyTipHorizontalOffsetProperty = DependencyProperty.Register("KeyTipHorizontalOffset", typeof(double), typeof(UIElement), new FrameworkPropertyMetadata(0.0));
		KeyTipPlacementModeProperty = DependencyProperty.Register("KeyTipPlacementMode", typeof(KeyTipPlacementMode), typeof(UIElement), new FrameworkPropertyMetadata(KeyTipPlacementMode.Auto));
		KeyTipVerticalOffsetProperty = DependencyProperty.Register("KeyTipVerticalOffset", typeof(double), typeof(UIElement), new FrameworkPropertyMetadata(0.0));
		LightsProperty = DependencyProperty.Register("Lights", typeof(IList<XamlLight>), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		KeyTipTargetProperty = DependencyProperty.Register("KeyTipTarget", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		KeyboardAcceleratorPlacementModeProperty = DependencyProperty.Register("KeyboardAcceleratorPlacementMode", typeof(KeyboardAcceleratorPlacementMode), typeof(UIElement), new FrameworkPropertyMetadata(KeyboardAcceleratorPlacementMode.Auto));
		KeyboardAcceleratorPlacementTargetProperty = DependencyProperty.Register("KeyboardAcceleratorPlacementTarget", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		CanBeScrollAnchorProperty = DependencyProperty.Register("CanBeScrollAnchor", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		ClipProperty = DependencyProperty.Register("Clip", typeof(RectangleGeometry), typeof(UIElement), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((UIElement)s)?.OnClipChanged(e);
		}));
		RenderTransformProperty = DependencyProperty.Register("RenderTransform", typeof(Transform), typeof(UIElement), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			OnRenderTransformChanged(s, e);
		}));
		RenderTransformOriginProperty = DependencyProperty.Register("RenderTransformOrigin", typeof(Point), typeof(UIElement), new FrameworkPropertyMetadata(default(Point), delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			OnRenderTransformOriginChanged(s, e);
		}));
		XYFocusKeyboardNavigationProperty = CreateXYFocusKeyboardNavigationProperty();
		XYFocusDownNavigationStrategyProperty = CreateXYFocusDownNavigationStrategyProperty();
		XYFocusLeftNavigationStrategyProperty = CreateXYFocusLeftNavigationStrategyProperty();
		XYFocusRightNavigationStrategyProperty = CreateXYFocusRightNavigationStrategyProperty();
		XYFocusUpNavigationStrategyProperty = CreateXYFocusUpNavigationStrategyProperty();
		TabFocusNavigationProperty = CreateTabFocusNavigationProperty();
		FocusStateProperty = CreateFocusStateProperty();
		IsTabStopProperty = DependencyProperty.Register("IsTabStop", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((UIElement)s)?.OnIsTabStopChanged((bool)e.OldValue, (bool)e.NewValue);
		}));
		TabIndexProperty = CreateTabIndexProperty();
		XYFocusUpProperty = CreateXYFocusUpProperty();
		XYFocusDownProperty = CreateXYFocusDownProperty();
		XYFocusLeftProperty = CreateXYFocusLeftProperty();
		XYFocusRightProperty = CreateXYFocusRightProperty();
		UseSystemFocusVisualsProperty = CreateUseSystemFocusVisualsProperty();
		ManipulationModeProperty = DependencyProperty.Register("ManipulationMode", typeof(ManipulationModes), typeof(UIElement), new FrameworkPropertyMetadata(ManipulationModes.System, FrameworkPropertyMetadataOptions.None, OnManipulationModeChanged));
		CanDragProperty = DependencyProperty.Register("CanDrag", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false, OnCanDragChanged));
		AllowDropProperty = DependencyProperty.Register("AllowDrop", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata(false));
		ClearPointersStateIfNeeded = delegate(DependencyObject sender, DependencyPropertyChangedEventArgs dp)
		{
			object newValue = dp.NewValue;
			if (newValue is Visibility && (Visibility)newValue != 0 && PointerCapture.Any(out var cloneOfAllCaptures))
			{
				for (int j = 0; j < cloneOfAllCaptures.Count; j++)
				{
					PointerCapture pointerCapture = cloneOfAllCaptures[j];
					List<PointerCaptureTarget> list = pointerCapture.Targets.ToList();
					for (int k = 0; k < list.Count; k++)
					{
						PointerCaptureTarget pointerCaptureTarget = list[k];
						if (pointerCaptureTarget.Element.HasParent(sender))
						{
							pointerCaptureTarget.Element.Release(pointerCapture, PointerCaptureKind.Any);
						}
					}
				}
			}
			if (sender is UIElement uIElement11 && uIElement11.GetHitTestVisibility() == HitTestability.Collapsed)
			{
				uIElement11.Release(PointerCaptureKind.Any);
				uIElement11.ClearPressed();
				uIElement11.SetOver(null, isOver: false, muteEvent: true);
				uIElement11.ClearDragOver();
			}
		};
		ClearPointersStateOnUnload = delegate(object sender, RoutedEventArgs args)
		{
			if (sender is UIElement uIElement10)
			{
				uIElement10.Release(PointerCaptureKind.Any);
				uIElement10.ClearPressed();
				uIElement10.SetOver(null, isOver: false, muteEvent: true);
				uIElement10.ClearDragOver();
			}
		};
		OnRecognizerManipulationStarting = delegate(GestureRecognizer sender, ManipulationStartingEventArgs args)
		{
			UIElement uIElement9 = (UIElement)sender.Owner;
			uIElement9.SafeRaiseEvent(ManipulationStartingEvent, new ManipulationStartingRoutedEventArgs(uIElement9, args));
		};
		OnRecognizerManipulationStarted = delegate(GestureRecognizer sender, ManipulationStartedEventArgs args)
		{
			UIElement uIElement8 = (UIElement)sender.Owner;
			uIElement8.SafeRaiseEvent(ManipulationStartedEvent, new ManipulationStartedRoutedEventArgs(uIElement8, sender, args));
		};
		OnRecognizerManipulationUpdated = delegate(GestureRecognizer sender, ManipulationUpdatedEventArgs args)
		{
			UIElement uIElement7 = (UIElement)sender.Owner;
			uIElement7.SafeRaiseEvent(ManipulationDeltaEvent, new ManipulationDeltaRoutedEventArgs(uIElement7, sender, args));
		};
		OnRecognizerManipulationInertiaStarting = delegate(GestureRecognizer sender, ManipulationInertiaStartingEventArgs args)
		{
			UIElement uIElement6 = (UIElement)sender.Owner;
			uIElement6.SafeRaiseEvent(ManipulationInertiaStartingEvent, new ManipulationInertiaStartingRoutedEventArgs(uIElement6, args));
		};
		OnRecognizerManipulationCompleted = delegate(GestureRecognizer sender, ManipulationCompletedEventArgs args)
		{
			UIElement uIElement5 = (UIElement)sender.Owner;
			PointerIdentifier[] pointers = args.Pointers;
			foreach (PointerIdentifier pointer in pointers)
			{
				uIElement5.ReleasePointerCapture(pointer, muteEvent: true, PointerCaptureKind.Implicit);
			}
			uIElement5.SafeRaiseEvent(ManipulationCompletedEvent, new ManipulationCompletedRoutedEventArgs(uIElement5, args));
		};
		OnRecognizerTapped = delegate(GestureRecognizer sender, TappedEventArgs args)
		{
			UIElement uIElement4 = (UIElement)sender.Owner;
			if (args.TapCount == 1)
			{
				uIElement4.SafeRaiseEvent(TappedEvent, new TappedRoutedEventArgs(uIElement4, args));
			}
			else
			{
				uIElement4.SafeRaiseEvent(DoubleTappedEvent, new DoubleTappedRoutedEventArgs(uIElement4, args));
			}
		};
		OnRecognizerRightTapped = delegate(GestureRecognizer sender, RightTappedEventArgs args)
		{
			UIElement uIElement3 = (UIElement)sender.Owner;
			uIElement3.SafeRaiseEvent(RightTappedEvent, new RightTappedRoutedEventArgs(uIElement3, args));
		};
		OnRecognizerHolding = delegate(GestureRecognizer sender, HoldingEventArgs args)
		{
			UIElement uIElement2 = (UIElement)sender.Owner;
			uIElement2.SafeRaiseEvent(HoldingEvent, new HoldingRoutedEventArgs(uIElement2, args));
		};
		OnRecognizerDragging = delegate(GestureRecognizer sender, DraggingEventArgs args)
		{
			UIElement uIElement = (UIElement)sender.Owner;
			uIElement.OnDragStarting(args);
		};
		PointerCapturesProperty = DependencyProperty.Register("PointerCaptures", typeof(IReadOnlyList<Windows.UI.Xaml.Input.Pointer>), typeof(UIElement), new FrameworkPropertyMetadata((object)null));
		IsHitTestVisibleProperty = CreateIsHitTestVisibleProperty();
		OpacityProperty = CreateOpacityProperty();
		VisibilityProperty = CreateVisibilityProperty();
		ContextFlyoutProperty = CreateContextFlyoutProperty();
		KeyboardAcceleratorsProperty = CreateKeyboardAcceleratorsProperty();
		PointerPressedEvent = new RoutedEvent(RoutedEventFlag.PointerPressed, "PointerPressedEvent");
		PointerReleasedEvent = new RoutedEvent(RoutedEventFlag.PointerReleased, "PointerReleasedEvent");
		PointerEnteredEvent = new RoutedEvent(RoutedEventFlag.PointerEntered, "PointerEnteredEvent");
		PointerExitedEvent = new RoutedEvent(RoutedEventFlag.PointerExited, "PointerExitedEvent");
		PointerMovedEvent = new RoutedEvent(RoutedEventFlag.PointerMoved, "PointerMovedEvent");
		PointerCanceledEvent = new RoutedEvent(RoutedEventFlag.PointerCanceled, "PointerCanceledEvent");
		PointerCaptureLostEvent = new RoutedEvent(RoutedEventFlag.PointerCaptureLost, "PointerCaptureLostEvent");
		PointerWheelChangedEvent = new RoutedEvent(RoutedEventFlag.PointerWheelChanged, "PointerWheelChangedEvent");
		ManipulationStartingEvent = new RoutedEvent(RoutedEventFlag.ManipulationStarting, "ManipulationStartingEvent");
		ManipulationStartedEvent = new RoutedEvent(RoutedEventFlag.ManipulationStarted, "ManipulationStartedEvent");
		ManipulationDeltaEvent = new RoutedEvent(RoutedEventFlag.ManipulationDelta, "ManipulationDeltaEvent");
		ManipulationInertiaStartingEvent = new RoutedEvent(RoutedEventFlag.ManipulationInertiaStarting, "ManipulationInertiaStartingEvent");
		ManipulationCompletedEvent = new RoutedEvent(RoutedEventFlag.ManipulationCompleted, "ManipulationCompletedEvent");
		TappedEvent = new RoutedEvent(RoutedEventFlag.Tapped, "TappedEvent");
		DoubleTappedEvent = new RoutedEvent(RoutedEventFlag.DoubleTapped, "DoubleTappedEvent");
		RightTappedEvent = new RoutedEvent(RoutedEventFlag.RightTapped, "RightTappedEvent");
		HoldingEvent = new RoutedEvent(RoutedEventFlag.Holding, "HoldingEvent");
		DragStartingEvent = new RoutedEvent(RoutedEventFlag.DragStarting, "DragStartingEvent");
		DragEnterEvent = new RoutedEvent(RoutedEventFlag.DragEnter, "DragEnterEvent");
		DragOverEvent = new RoutedEvent(RoutedEventFlag.DragOver, "DragOverEvent");
		DragLeaveEvent = new RoutedEvent(RoutedEventFlag.DragLeave, "DragLeaveEvent");
		DropEvent = new RoutedEvent(RoutedEventFlag.Drop, "DropEvent");
		DropCompletedEvent = new RoutedEvent(RoutedEventFlag.DropCompleted, "DropCompletedEvent");
		KeyDownEvent = new RoutedEvent(RoutedEventFlag.KeyDown, "KeyDownEvent");
		KeyUpEvent = new RoutedEvent(RoutedEventFlag.KeyUp, "KeyUpEvent");
		GotFocusEvent = new RoutedEvent(RoutedEventFlag.GotFocus, "GotFocusEvent");
		LostFocusEvent = new RoutedEvent(RoutedEventFlag.LostFocus, "LostFocusEvent");
		GettingFocusEvent = new RoutedEvent(RoutedEventFlag.GettingFocus, "GettingFocusEvent");
		LosingFocusEvent = new RoutedEvent(RoutedEventFlag.LosingFocus, "LosingFocusEvent");
		NoFocusCandidateFoundEvent = new RoutedEvent(RoutedEventFlag.NoFocusCandidateFound, "NoFocusCandidateFoundEvent");
		EventsBubblingInManagedCodeProperty = DependencyProperty.Register("EventsBubblingInManagedCode", typeof(RoutedEventFlag), typeof(UIElement), new FrameworkPropertyMetadata(RoutedEventFlag.None, FrameworkPropertyMetadataOptions.Inherits)
		{
			CoerceValueCallback = CoerceRoutedEventFlag
		});
		SubscribedToHandledEventsTooProperty = DependencyProperty.Register("SubscribedToHandledEventsToo", typeof(RoutedEventFlag), typeof(UIElement), new FrameworkPropertyMetadata(RoutedEventFlag.None, FrameworkPropertyMetadataOptions.Inherits)
		{
			CoerceValueCallback = CoerceRoutedEventFlag
		});
		HitTestVisibilityProperty = CreateHitTestVisibilityProperty();
		_htmlTagCache = new Dictionary<Type, string>(FastTypeComparer.Default);
		_unoUIAssembly = typeof(UIElement).Assembly;
		_binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);
		DataContextProperty = DependencyProperty.Register("DataContext", typeof(object), typeof(UIElement), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((UIElement)s).OnDataContextChanged(e);
		}));
		TemplatedParentProperty = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((UIElement)s).OnTemplatedParentChanged(e);
		}));
		Type typeFromHandle = typeof(UIElement);
		VisibilityProperty.GetMetadata(typeFromHandle).MergePropertyChangedCallback(ClearPointersStateIfNeeded);
		Control.IsEnabledProperty.GetMetadata(typeof(Control)).MergePropertyChangedCallback(ClearPointersStateIfNeeded);
		HitTestVisibilityProperty.GetMetadata(typeFromHandle).MergePropertyChangedCallback(ClearPointersStateIfNeeded);
	}

	private static void OnManipulationModeChanged(DependencyObject snd, DependencyPropertyChangedEventArgs args)
	{
		if (snd is UIElement uIElement)
		{
			ManipulationModes oldMode = (ManipulationModes)args.OldValue;
			ManipulationModes manipulationModes = (ManipulationModes)args.NewValue;
			manipulationModes.LogIfNotSupported(uIElement.Log());
			uIElement.UpdateManipulations(manipulationModes, uIElement.HasManipulationHandler);
			uIElement.OnManipulationModeChanged(oldMode, manipulationModes);
		}
	}

	private void OnManipulationModeChanged(ManipulationModes oldMode, ManipulationModes newMode)
	{
		SetStyle("touch-action", (newMode == ManipulationModes.None) ? "none" : "auto");
	}

	private static void OnCanDragChanged(DependencyObject snd, DependencyPropertyChangedEventArgs args)
	{
		if (snd is UIElement uIElement)
		{
			object newValue = args.NewValue;
			if (newValue is bool)
			{
				bool isEnabled = (bool)newValue;
				uIElement.UpdateDragAndDrop(isEnabled);
			}
		}
	}

	private void InitializePointers()
	{
		_gestures = new Lazy<GestureRecognizer>(new Func<GestureRecognizer>(CreateGestureRecognizer));
		if (this is FrameworkElement frameworkElement)
		{
			frameworkElement.Unloaded += ClearPointersStateOnUnload;
		}
	}

	internal HitTestability GetHitTestVisibility()
	{
		return HitTestVisibility;
	}

	private GestureRecognizer CreateGestureRecognizer()
	{
		GestureRecognizer gestureRecognizer = new GestureRecognizer(this);
		OnGestureRecognizerInitialized(gestureRecognizer);
		gestureRecognizer.ManipulationStarting += OnRecognizerManipulationStarting;
		gestureRecognizer.ManipulationStarted += OnRecognizerManipulationStarted;
		gestureRecognizer.ManipulationUpdated += OnRecognizerManipulationUpdated;
		gestureRecognizer.ManipulationInertiaStarting += OnRecognizerManipulationInertiaStarting;
		gestureRecognizer.ManipulationCompleted += OnRecognizerManipulationCompleted;
		gestureRecognizer.Tapped += OnRecognizerTapped;
		gestureRecognizer.RightTapped += OnRecognizerRightTapped;
		gestureRecognizer.Holding += OnRecognizerHolding;
		gestureRecognizer.Dragging += OnRecognizerDragging;
		if (WinRTFeatureConfiguration.GestureRecognizer.ShouldProvideHapticFeedback)
		{
			gestureRecognizer.DragReady += HapticFeedbackWhenReadyToDrag;
		}
		return gestureRecognizer;
	}

	private void OnGestureRecognizerInitialized(GestureRecognizer recognizer)
	{
		AddPointerHandler(PointerMovedEvent, 1, null, handledEventsToo: false);
	}

	private async void HapticFeedbackWhenReadyToDrag(GestureRecognizer sender, GestureRecognizer.Manipulation args)
	{
		_ = 1;
		try
		{
			if (await VibrationDevice.RequestAccessAsync() != 0)
			{
				return;
			}
			VibrationDevice vibrationDevice = await VibrationDevice.GetDefaultAsync();
			if (vibrationDevice != null)
			{
				SimpleHapticsController simpleHapticsController = vibrationDevice.SimpleHapticsController;
				SimpleHapticsControllerFeedback simpleHapticsControllerFeedback = simpleHapticsController.SupportedFeedback.FirstOrDefault((SimpleHapticsControllerFeedback f) => f.Waveform == KnownSimpleHapticsControllerWaveforms.Press);
				if (simpleHapticsControllerFeedback != null)
				{
					simpleHapticsController.SendHapticFeedback(simpleHapticsControllerFeedback);
				}
			}
		}
		catch (Exception ex)
		{
			this.Log().Error("Haptic feedback for drag failed", ex);
		}
	}

	private void UpdateManipulations(ManipulationModes mode, bool hasManipulationHandler)
	{
		if (!hasManipulationHandler || mode == ManipulationModes.None || mode == ManipulationModes.System)
		{
			if (_gestures.IsValueCreated)
			{
				_gestures.Value.GestureSettings &= ~(GestureSettings.ManipulationTranslateX | GestureSettings.ManipulationTranslateY | GestureSettings.ManipulationTranslateRailsX | GestureSettings.ManipulationTranslateRailsY | GestureSettings.ManipulationRotate | GestureSettings.ManipulationScale | GestureSettings.ManipulationTranslateInertia | GestureSettings.ManipulationRotateInertia | GestureSettings.ManipulationScaleInertia | GestureSettings.ManipulationMultipleFingerPanning);
			}
		}
		else
		{
			GestureSettings gestureSettings = _gestures.Value.GestureSettings;
			gestureSettings &= ~(GestureSettings.ManipulationTranslateX | GestureSettings.ManipulationTranslateY | GestureSettings.ManipulationTranslateRailsX | GestureSettings.ManipulationTranslateRailsY | GestureSettings.ManipulationRotate | GestureSettings.ManipulationScale | GestureSettings.ManipulationTranslateInertia | GestureSettings.ManipulationRotateInertia | GestureSettings.ManipulationScaleInertia | GestureSettings.ManipulationMultipleFingerPanning);
			gestureSettings |= mode.ToGestureSettings();
			_gestures.Value.GestureSettings = gestureSettings;
		}
	}

	private void ToggleGesture(RoutedEvent routedEvent)
	{
		if (routedEvent == TappedEvent)
		{
			_gestures.Value.GestureSettings |= GestureSettings.Tap;
		}
		else if (routedEvent == DoubleTappedEvent)
		{
			_gestures.Value.GestureSettings |= GestureSettings.DoubleTap;
		}
		else if (routedEvent == RightTappedEvent)
		{
			_gestures.Value.GestureSettings |= GestureSettings.RightTap;
		}
		else if (routedEvent == HoldingEvent)
		{
			_gestures.Value.GestureSettings |= GestureSettings.Hold;
		}
	}

	private protected void CompleteGesture()
	{
		_isGestureCompleted = true;
		if (_gestures.IsValueCreated)
		{
			_gestures.Value.CompleteGesture();
		}
	}

	private void UpdateDragAndDrop(bool isEnabled)
	{
		GestureSettings gestureSettings = _gestures.Value.GestureSettings;
		gestureSettings &= ~GestureSettings.Drag;
		if (isEnabled)
		{
			gestureSettings |= GestureSettings.Drag;
		}
		_gestures.Value.GestureSettings = gestureSettings;
	}

	private void OnDragStarting(DraggingEventArgs args)
	{
		if (args.DraggingState == DraggingState.Started && CanDrag && args.Pointer.Properties.IsLeftButtonPressed && args.Pointer.FrameId > _lastDragStartFrameId)
		{
			_lastDragStartFrameId = args.Pointer.FrameId;
			StartDragAsyncCore(args.Pointer, null, CancellationToken.None);
		}
	}

	public IAsyncOperation<DataPackageOperation> StartDragAsync(PointerPoint pointerPoint)
	{
		return Windows.Foundation.AsyncOperation.FromTask((CancellationToken ct) => StartDragAsyncCore(pointerPoint, _pendingRaisedEvent.args, ct));
	}

	private async Task<DataPackageOperation> StartDragAsyncCore(PointerPoint pointer, PointerRoutedEventArgs ptArgs, CancellationToken ct)
	{
		if (ptArgs == null)
		{
			ptArgs = CoreWindow.GetForCurrentThread()!.LastPointerEvent as PointerRoutedEventArgs;
		}
		if (ptArgs == null || ptArgs.Pointer.PointerDeviceType != pointer.PointerDeviceType)
		{
			return DataPackageOperation.None;
		}
		DragStartingEventArgs routedArgs = new DragStartingEventArgs(this, ptArgs);
		PrepareShare(routedArgs.Data);
		SafeRaiseEvent(DragStartingEvent, routedArgs);
		_ = ptArgs.GetCurrentPoint(this).Position;
		DragOperationDeferral deferral = routedArgs.Deferral;
		if (deferral != null)
		{
			await deferral.Completed(ct);
		}
		if (routedArgs.Cancel)
		{
			throw new TaskCanceledException();
		}
		CoreDragInfo dragInfo = new CoreDragInfo(ptArgs, routedArgs.Data.GetView(), routedArgs.AllowedOperations, routedArgs.DragUI);
		if (!pointer.Properties.HasPressedButton)
		{
			OnDropCompleted(dragInfo, DataPackageOperation.None);
			return DataPackageOperation.None;
		}
		TaskCompletionSource<DataPackageOperation> asyncResult = new TaskCompletionSource<DataPackageOperation>();
		dragInfo.RegisterCompletedCallback(delegate(DataPackageOperation result)
		{
			OnDropCompleted(dragInfo, result);
			asyncResult.SetResult(result);
		});
		CoreDragDropManager.GetForCurrentView()!.DragStarted(dragInfo);
		return await asyncResult.Task;
	}

	private void OnDropCompleted(CoreDragInfo info, DataPackageOperation result)
	{
		SafeRaiseEvent(DropCompletedEvent, new DropCompletedEventArgs(this, info, result));
	}

	private protected virtual void PrepareShare(DataPackage data)
	{
	}

	internal void RaiseDragEnterOrOver(DragEventArgs args)
	{
		RoutedEvent routedEvent = (IsDragOver(args.SourceId) ? DragOverEvent : DragEnterEvent);
		(_draggingOver ?? (_draggingOver = new HashSet<long>())).Add(args.SourceId);
		SafeRaiseEvent(routedEvent, args);
	}

	internal void RaiseDragLeave(DragEventArgs args, UIElement upTo = null)
	{
		HashSet<long> draggingOver = _draggingOver;
		if (draggingOver != null && draggingOver.Remove(args.SourceId))
		{
			SafeRaiseEvent(DragLeaveEvent, args, BubblingContext.BubbleUpTo(upTo));
		}
	}

	internal void RaiseDrop(DragEventArgs args)
	{
		HashSet<long> draggingOver = _draggingOver;
		if (draggingOver != null && draggingOver.Remove(args.SourceId))
		{
			SafeRaiseEvent(DropEvent, args);
		}
	}

	private bool OnNativePointerEnter(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		return OnPointerEnter(args);
	}

	private bool OnPointerEnter(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		bool flag = ValidateAndUpdateCapture(args, isOver: true);
		return SetOver(args, isOver: true, ctx.IsInternal || !flag);
	}

	private bool OnNativePointerDown(PointerRoutedEventArgs args)
	{
		return OnPointerDown(args);
	}

	private bool OnPointerDown(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		_isGestureCompleted = false;
		bool flag = ValidateAndUpdateCapture(args, isOver: true, forceRelease: true);
		bool result = SetPressed(args, isPressed: true, ctx.IsInternal || !flag);
		if (!ctx.IsInternal && !flag)
		{
			return result;
		}
		if (!_isGestureCompleted && _gestures.IsValueCreated)
		{
			GestureRecognizer value = _gestures.Value;
			PointerPoint currentPoint = args.GetCurrentPoint(this);
			value.ProcessDownEvent(currentPoint);
			GestureRecognizer.Manipulation pendingManipulation = value.PendingManipulation;
			if (pendingManipulation != null && pendingManipulation.IsActive(currentPoint.Pointer))
			{
				Capture(args.Pointer, PointerCaptureKind.Implicit, args);
			}
		}
		return result;
	}

	private bool OnNativePointerMoveWithOverCheck(PointerRoutedEventArgs args, bool isOver)
	{
		bool flag = false;
		bool flag2 = ValidateAndUpdateCapture(args, isOver);
		flag |= SetOver(args, isOver);
		if (flag2)
		{
			args.Handled = false;
			flag |= RaisePointerEvent(PointerMovedEvent, args);
		}
		if (_gestures.IsValueCreated)
		{
			GestureRecognizer value = _gestures.Value;
			value.ProcessMoveEvents(args.GetIntermediatePoints(this), flag2);
			if (value.IsDragging)
			{
				Window.Current.DragDrop.ProcessMoved(args);
			}
		}
		return flag;
	}

	private bool OnNativePointerMove(PointerRoutedEventArgs args)
	{
		return OnPointerMove(args);
	}

	private bool OnPointerMove(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		bool flag = false;
		bool flag2 = ValidateAndUpdateCapture(args);
		if (!ctx.IsInternal && flag2)
		{
			args.Handled = false;
			flag |= RaisePointerEvent(PointerMovedEvent, args);
		}
		if (_gestures.IsValueCreated)
		{
			_gestures.Value.ProcessMoveEvents(args.GetIntermediatePoints(this), !ctx.IsInternal || flag2);
			if (_gestures.Value.IsDragging)
			{
				Window.Current.DragDrop.ProcessMoved(args);
			}
		}
		return flag;
	}

	private bool OnNativePointerUp(PointerRoutedEventArgs args)
	{
		return OnPointerUp(args);
	}

	private bool OnPointerUp(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		bool flag = false;
		bool isOver;
		bool flag2 = ValidateAndUpdateCapture(args, out isOver);
		flag |= SetPressed(args, isPressed: false, ctx.IsInternal || !flag2);
		if (_gestures.IsValueCreated)
		{
			bool isDragging = _gestures.Value.IsDragging;
			_gestures.Value.ProcessUpEvent(args.GetCurrentPoint(this), !ctx.IsInternal || flag2);
			if (isDragging)
			{
				Window.Current.DragDrop.ProcessDropped(args);
			}
		}
		if (!isOver || args.Pointer.PointerDeviceType != 0)
		{
			flag |= SetNotCaptured(args);
		}
		return flag;
	}

	private bool OnNativePointerExited(PointerRoutedEventArgs args)
	{
		return OnPointerExited(args);
	}

	private bool OnPointerExited(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		bool flag = false;
		bool flag2 = ValidateAndUpdateCapture(args);
		flag |= SetOver(args, isOver: false, ctx.IsInternal || !flag2);
		if (_gestures.IsValueCreated && _gestures.Value.IsDragging)
		{
			Window.Current.DragDrop.ProcessMoved(args);
		}
		if (!IsPressed(args.Pointer))
		{
			flag |= SetNotCaptured(args);
		}
		return flag;
	}

	private bool OnNativePointerCancel(PointerRoutedEventArgs args, bool isSwallowedBySystem)
	{
		args.CanceledByDirectManipulation = isSwallowedBySystem;
		return OnPointerCancel(args);
	}

	private bool OnPointerCancel(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		bool flag = ValidateAndUpdateCapture(args);
		SetPressed(args, isPressed: false, muteEvent: true);
		SetOver(args, isOver: false, muteEvent: true);
		if (_gestures.IsValueCreated)
		{
			_gestures.Value.CompleteGesture();
			if (_gestures.Value.IsDragging)
			{
				Window.Current.DragDrop.ProcessAborted(args);
			}
		}
		if (!flag)
		{
			return false;
		}
		bool flag2 = false;
		if (args.CanceledByDirectManipulation)
		{
			return flag2 | SetNotCaptured(args, forceCaptureLostEvent: true);
		}
		args.Handled = false;
		flag2 |= !ctx.IsInternal && RaisePointerEvent(PointerCanceledEvent, args);
		return flag2 | SetNotCaptured(args);
	}

	private bool OnNativePointerWheel(PointerRoutedEventArgs args)
	{
		return RaisePointerEvent(PointerWheelChangedEvent, args);
	}

	private bool OnPointerWheel(PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		return RaisePointerEvent(PointerWheelChangedEvent, args);
	}

	private bool RaisePointerEvent(RoutedEvent evt, PointerRoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		try
		{
			_pendingRaisedEvent = (this, evt, args);
			return RaiseEvent(evt, args, ctx);
		}
		catch (Exception arg)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().Error($"Failed to raise '{evt.Name}': {arg}");
			}
			return false;
		}
		finally
		{
			_pendingRaisedEvent = (null, null, null);
		}
	}

	internal bool IsOver(Windows.UI.Xaml.Input.Pointer pointer)
	{
		return IsPointerOver;
	}

	private bool SetOver(PointerRoutedEventArgs args, bool isOver, bool muteEvent = false)
	{
		bool isPointerOver = IsPointerOver;
		IsPointerOver = isOver;
		if (muteEvent || isPointerOver == isOver)
		{
			return false;
		}
		if (isOver)
		{
			args.Handled = false;
			return RaisePointerEvent(PointerEnteredEvent, args);
		}
		args.Handled = false;
		return RaisePointerEvent(PointerExitedEvent, args);
	}

	internal bool IsPressed(Windows.UI.Xaml.Input.Pointer pointer)
	{
		return _pressedPointers.Contains(pointer.PointerId);
	}

	private bool IsPressed(uint pointerId)
	{
		return _pressedPointers.Contains(pointerId);
	}

	private bool SetPressed(PointerRoutedEventArgs args, bool isPressed, bool muteEvent = false)
	{
		bool flag = IsPressed(args.Pointer);
		if (flag == isPressed)
		{
			return false;
		}
		if (isPressed)
		{
			_pressedPointers.Add(args.Pointer.PointerId);
			if (muteEvent)
			{
				return false;
			}
			args.Handled = false;
			return RaisePointerEvent(PointerPressedEvent, args);
		}
		_pressedPointers.Remove(args.Pointer.PointerId);
		if (muteEvent)
		{
			return false;
		}
		args.Handled = false;
		return RaisePointerEvent(PointerReleasedEvent, args);
	}

	private void ClearPressed()
	{
		_pressedPointers.Clear();
	}

	internal bool IsCaptured(Windows.UI.Xaml.Input.Pointer pointer)
	{
		if (HasPointerCapture && PointerCapture.TryGet(pointer, out var capture))
		{
			return capture.IsTarget(this, PointerCaptureKind.Explicit);
		}
		return false;
	}

	public bool CapturePointer(Windows.UI.Xaml.Input.Pointer value)
	{
		Windows.UI.Xaml.Input.Pointer pointer = value ?? throw new ArgumentNullException("value");
		return Capture(pointer, PointerCaptureKind.Explicit, _pendingRaisedEvent.args);
	}

	public void ReleasePointerCapture(Windows.UI.Xaml.Input.Pointer value)
	{
		ReleasePointerCapture((value ?? throw new ArgumentNullException("value")).UniqueId);
	}

	internal void ReleasePointerCapture(PointerIdentifier pointer, bool muteEvent = false, PointerCaptureKind kinds = PointerCaptureKind.Explicit)
	{
		if (!Release(pointer, kinds, null, muteEvent) && this.Log().IsEnabled(LogLevel.Information))
		{
			this.Log().Info($"{this}: Cannot release pointer {pointer}: not captured by this control.");
		}
	}

	public void ReleasePointerCaptures()
	{
		if (!HasPointerCapture)
		{
			if (this.Log().IsEnabled(LogLevel.Information))
			{
				this.Log().Info($"{this}: no pointers to release.");
			}
		}
		else
		{
			Release(PointerCaptureKind.Explicit);
		}
	}

	private void CapturePointerNative(Windows.UI.Xaml.Input.Pointer pointer)
	{
		string str = "Uno.UI.WindowManager.current.setPointerCapture(" + HtmlId + ", " + pointer.PointerId + ");";
		WebAssemblyRuntime.InvokeJS(str);
		if (pointer.PointerDeviceType != PointerDeviceType.Mouse)
		{
			SetStyle("touch-action", "none");
		}
	}

	private void ReleasePointerNative(Windows.UI.Xaml.Input.Pointer pointer)
	{
		string str = "Uno.UI.WindowManager.current.releasePointerCapture(" + HtmlId + ", " + pointer.PointerId + ");";
		WebAssemblyRuntime.InvokeJS(str);
		if (pointer.PointerDeviceType != PointerDeviceType.Mouse && ManipulationMode != 0)
		{
			SetStyle("touch-action", "auto");
		}
	}

	private bool ValidateAndUpdateCapture(PointerRoutedEventArgs args)
	{
		return ValidateAndUpdateCapture(args, IsOver(args.Pointer));
	}

	private bool ValidateAndUpdateCapture(PointerRoutedEventArgs args, out bool isOver)
	{
		return ValidateAndUpdateCapture(args, isOver = IsOver(args.Pointer));
	}

	private bool ValidateAndUpdateCapture(PointerRoutedEventArgs args, bool isOver, bool forceRelease = false)
	{
		if (PointerCapture.TryGet(args.Pointer, out var capture))
		{
			return capture.ValidateAndUpdate(this, args, forceRelease);
		}
		return isOver;
	}

	private bool SetNotCaptured(PointerRoutedEventArgs args, bool forceCaptureLostEvent = false)
	{
		if (Release(args.Pointer.UniqueId, PointerCaptureKind.Any, args))
		{
			return true;
		}
		if (forceCaptureLostEvent)
		{
			args.Handled = false;
			return RaisePointerEvent(PointerCaptureLostEvent, args);
		}
		return false;
	}

	private bool Capture(Windows.UI.Xaml.Input.Pointer pointer, PointerCaptureKind kind, PointerRoutedEventArgs relatedArgs)
	{
		if (_localExplicitCaptures == null)
		{
			_localExplicitCaptures = new List<Windows.UI.Xaml.Input.Pointer>();
			SetValue(PointerCapturesProperty, _localExplicitCaptures);
		}
		return PointerCapture.GetOrCreate(pointer).TryAddTarget(this, kind, relatedArgs);
	}

	private void Release(PointerCaptureKind kinds, PointerRoutedEventArgs relatedArgs = null, bool muteEvent = false)
	{
		if (!PointerCapture.Any(out var cloneOfAllCaptures))
		{
			return;
		}
		foreach (PointerCapture item in cloneOfAllCaptures)
		{
			Release(item, kinds, relatedArgs, muteEvent);
		}
	}

	private bool Release(PointerIdentifier pointer, PointerCaptureKind kinds, PointerRoutedEventArgs relatedArgs = null, bool muteEvent = false)
	{
		if (PointerCapture.TryGet(pointer, out var capture))
		{
			return Release(capture, kinds, relatedArgs, muteEvent);
		}
		return false;
	}

	private bool Release(PointerCapture capture, PointerCaptureKind kinds, PointerRoutedEventArgs relatedArgs = null, bool muteEvent = false)
	{
		if (!capture.RemoveTarget(this, kinds, out var lastDispatched).HasFlag(PointerCaptureKind.Explicit))
		{
			return false;
		}
		if (muteEvent)
		{
			return false;
		}
		if (relatedArgs == null)
		{
			relatedArgs = lastDispatched;
		}
		if (relatedArgs == null)
		{
			return false;
		}
		relatedArgs.Handled = false;
		return RaisePointerEvent(PointerCaptureLostEvent, relatedArgs);
	}

	internal bool IsDragOver(Windows.UI.Xaml.Input.Pointer pointer)
	{
		return _draggingOver?.Contains(pointer.UniqueId) ?? false;
	}

	internal bool IsDragOver(long sourceId)
	{
		return _draggingOver?.Contains(sourceId) ?? false;
	}

	private void SetIsDragOver(long sourceId, bool isOver)
	{
		if (isOver)
		{
			(_draggingOver ?? (_draggingOver = new HashSet<long>())).Add(sourceId);
		}
		else
		{
			_draggingOver?.Remove(sourceId);
		}
	}

	private void ClearDragOver()
	{
		_draggingOver?.Clear();
	}

	private static object CoerceRoutedEventFlag(DependencyObject dependencyObject, object baseValue)
	{
		UIElement instance = (UIElement)dependencyObject;
		if (!(instance.GetPrecedenceSpecificValue(SubscribedToHandledEventsTooProperty, DependencyPropertyValuePrecedences.Local) is RoutedEventFlag routedEventFlag))
		{
			return baseValue;
		}
		if (instance.GetPrecedenceSpecificValue(SubscribedToHandledEventsTooProperty, DependencyPropertyValuePrecedences.Inheritance) is RoutedEventFlag routedEventFlag2)
		{
			return routedEventFlag | routedEventFlag2;
		}
		return baseValue;
	}

	private protected void InsertHandler(RoutedEvent routedEvent, object handler, bool handledEventsToo = false)
	{
		List<RoutedEventHandlerInfo> list = _eventHandlerStore.FindOrCreate(routedEvent, () => new List<RoutedEventHandlerInfo>());
		if (list.Count > 0)
		{
			list.Insert(0, new RoutedEventHandlerInfo(handler, handledEventsToo));
		}
		else
		{
			list.Add(new RoutedEventHandlerInfo(handler, handledEventsToo));
		}
		AddHandler(routedEvent, list.Count, handler, handledEventsToo);
		if (handledEventsToo && !routedEvent.IsAlwaysBubbled)
		{
			UpdateSubscribedToHandledEventsToo();
		}
	}

	public void AddHandler(RoutedEvent routedEvent, object handler, bool handledEventsToo)
	{
		List<RoutedEventHandlerInfo> list = _eventHandlerStore.FindOrCreate(routedEvent, () => new List<RoutedEventHandlerInfo>());
		list.Add(new RoutedEventHandlerInfo(handler, handledEventsToo));
		AddHandler(routedEvent, list.Count, handler, handledEventsToo);
		if (handledEventsToo && !routedEvent.IsAlwaysBubbled)
		{
			UpdateSubscribedToHandledEventsToo();
		}
	}

	private void AddHandler(RoutedEvent routedEvent, int handlersCount, object handler, bool handledEventsToo)
	{
		if (routedEvent.IsPointerEvent)
		{
			AddPointerHandler(routedEvent, handlersCount, handler, handledEventsToo);
		}
		else if (routedEvent.IsKeyEvent)
		{
			AddKeyHandler(routedEvent, handlersCount, handler, handledEventsToo);
		}
		else if (!routedEvent.IsFocusEvent)
		{
			if (routedEvent.IsManipulationEvent)
			{
				AddManipulationHandler(routedEvent, handlersCount, handler, handledEventsToo);
			}
			else if (routedEvent.IsGestureEvent)
			{
				AddGestureHandler(routedEvent, handlersCount, handler, handledEventsToo);
			}
			else
			{
				_ = routedEvent.IsDragAndDropEvent;
			}
		}
	}

	private void AddPointerHandler(RoutedEvent routedEvent, int handlersCount, object handler, bool handledEventsToo)
	{
		if (handlersCount == 1 && !_registeredRoutedEvents.HasFlag(routedEvent.Flag))
		{
			if (!_registeredRoutedEvents.HasFlag(RoutedEventFlag.PointerEntered))
			{
				WindowManagerInterop.RegisterPointerEventsOnView(HtmlId);
				_registeredRoutedEvents |= RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased | RoutedEventFlag.PointerEntered | RoutedEventFlag.PointerExited | RoutedEventFlag.PointerCanceled;
				RegisterEventHandler("pointerenter", new RawEventHandler(DispatchNativePointerEnter), GenericEventHandlers.RaiseRawEventHandler);
				RegisterEventHandler("pointerleave", new RawEventHandler(DispatchNativePointerLeave), GenericEventHandlers.RaiseRawEventHandler);
				RegisterEventHandler("pointerdown", new RawEventHandler(DispatchNativePointerDown), GenericEventHandlers.RaiseRawEventHandler);
				RegisterEventHandler("pointerup", new RawEventHandler(DispatchNativePointerUp), GenericEventHandlers.RaiseRawEventHandler);
				RegisterEventHandler("pointercancel", new RawEventHandler(DispatchNativePointerCancel), GenericEventHandlers.RaiseRawEventHandler);
			}
			switch (routedEvent.Flag)
			{
			case RoutedEventFlag.PointerMoved:
				_registeredRoutedEvents |= RoutedEventFlag.PointerMoved;
				RegisterEventHandler("pointermove", new RawEventHandler(DispatchNativePointerMove), GenericEventHandlers.RaiseRawEventHandler, onCapturePhase: false, HtmlEventExtractor.PointerEventExtractor);
				break;
			case RoutedEventFlag.PointerCaptureLost:
				_registeredRoutedEvents |= routedEvent.Flag;
				break;
			case RoutedEventFlag.PointerWheelChanged:
				_registeredRoutedEvents |= RoutedEventFlag.PointerMoved;
				RegisterEventHandler("wheel", new RawEventHandler(DispatchNativePointerWheel), GenericEventHandlers.RaiseRawEventHandler, onCapturePhase: false, HtmlEventExtractor.PointerEventExtractor);
				break;
			default:
				Application.Current.RaiseRecoverableUnhandledException(new NotImplementedException("Pointer event " + routedEvent.Name + " is not supported on this platform"));
				break;
			case RoutedEventFlag.PointerPressed:
			case RoutedEventFlag.PointerReleased:
			case RoutedEventFlag.PointerEntered:
			case RoutedEventFlag.PointerExited:
			case RoutedEventFlag.PointerCanceled:
				break;
			}
		}
	}

	private void AddKeyHandler(RoutedEvent routedEvent, int handlersCount, object handler, bool handledEventsToo)
	{
		if (handlersCount != 1 || _registeredRoutedEvents.HasFlag(routedEvent.Flag))
		{
			return;
		}
		_registeredRoutedEvents |= routedEvent.Flag;
		string eventName;
		if (routedEvent.Flag == RoutedEventFlag.KeyDown)
		{
			eventName = "keydown";
		}
		else
		{
			if (routedEvent.Flag != RoutedEventFlag.KeyUp)
			{
				throw new ArgumentOutOfRangeException("routedEvent", "Not a keyboard event");
			}
			eventName = "keyup";
		}
		RegisterEventHandler(eventName, (RoutedEventHandlerWithHandled)((object snd, RoutedEventArgs args) => RaiseEvent(routedEvent, args)), GenericEventHandlers.RaiseRoutedEventHandlerWithHandled, onCapturePhase: false, HtmlEventExtractor.KeyboardEventExtractor, PayloadToKeyArgs);
	}

	private void AddManipulationHandler(RoutedEvent routedEvent, int handlersCount, object handler, bool handledEventsToo)
	{
		if (handlersCount == 1)
		{
			UpdateManipulations(ManipulationMode, hasManipulationHandler: true);
		}
	}

	private void AddGestureHandler(RoutedEvent routedEvent, int handlersCount, object handler, bool handledEventsToo)
	{
		if (handlersCount == 1)
		{
			ToggleGesture(routedEvent);
		}
	}

	public void RemoveHandler(RoutedEvent routedEvent, object handler)
	{
		if (_eventHandlerStore.TryGetValue(routedEvent, out var value))
		{
			RoutedEventHandlerInfo item = value.FirstOrDefault((RoutedEventHandlerInfo handlerInfo) => (handlerInfo.Handler as Delegate).Equals(handler as Delegate));
			if (!item.Equals(default(RoutedEventHandlerInfo)))
			{
				value.Remove(item);
				if (item.HandledEventsToo && !routedEvent.IsAlwaysBubbled)
				{
					UpdateSubscribedToHandledEventsToo();
				}
			}
			RemoveHandler(routedEvent, value.Count, handler);
		}
		else
		{
			RemoveHandler(routedEvent, -1, handler);
		}
	}

	private void RemoveHandler(RoutedEvent routedEvent, int remainingHandlersCount, object handler)
	{
		if (!routedEvent.IsPointerEvent && !routedEvent.IsKeyEvent && !routedEvent.IsFocusEvent)
		{
			if (routedEvent.IsManipulationEvent)
			{
				RemoveManipulationHandler(routedEvent, remainingHandlersCount, handler);
			}
			else if (routedEvent.IsGestureEvent)
			{
				RemoveGestureHandler(routedEvent, remainingHandlersCount, handler);
			}
			else
			{
				_ = routedEvent.IsDragAndDropEvent;
			}
		}
	}

	private void RemoveManipulationHandler(RoutedEvent routedEvent, int remainingHandlersCount, object handler)
	{
		if (remainingHandlersCount == 0 && !HasManipulationHandler)
		{
			UpdateManipulations(ManipulationModes.None, hasManipulationHandler: false);
		}
	}

	private void RemoveGestureHandler(RoutedEvent routedEvent, int remainingHandlersCount, object handler)
	{
		if (remainingHandlersCount == 0)
		{
			ToggleGesture(routedEvent);
		}
	}

	private int CountHandler(RoutedEvent routedEvent)
	{
		if (!_eventHandlerStore.TryGetValue(routedEvent, out var value))
		{
			return 0;
		}
		return value.Count;
	}

	private void UpdateSubscribedToHandledEventsToo()
	{
		RoutedEventFlag routedEventFlag = RoutedEventFlag.None;
		foreach (KeyValuePair<RoutedEvent, List<RoutedEventHandlerInfo>> item in _eventHandlerStore)
		{
			if (item.Key.IsAlwaysBubbled)
			{
				continue;
			}
			foreach (RoutedEventHandlerInfo item2 in item.Value)
			{
				if (item2.HandledEventsToo)
				{
					routedEventFlag |= item.Key.Flag;
					break;
				}
			}
		}
		SubscribedToHandledEventsToo = routedEventFlag;
	}

	internal bool SafeRaiseEvent(RoutedEvent routedEvent, RoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		try
		{
			return RaiseEvent(routedEvent, args, ctx);
		}
		catch (Exception arg)
		{
			if (this.Log().IsEnabled(LogLevel.Error))
			{
				this.Log().Error($"Failed to raise '{routedEvent.Name}': {arg}");
			}
			return false;
		}
	}

	internal bool RaiseEvent(RoutedEvent routedEvent, RoutedEventArgs args, BubblingContext ctx = default(BubblingContext))
	{
		if (routedEvent.Flag == RoutedEventFlag.None)
		{
			throw new InvalidOperationException("Flag not defined for routed event " + routedEvent.Name + ".");
		}
		if (routedEvent.IsKeyEvent)
		{
			TrackKeyState(routedEvent, args);
		}
		bool flag = IsHandled(args);
		if (!ctx.Mode.HasFlag(BubblingMode.IgnoreElement) && !ctx.IsInternal && _eventHandlerStore.TryGetValue(routedEvent, out var value) && value.Any())
		{
			RoutedEventHandlerInfo[] array = value.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				RoutedEventHandlerInfo routedEventHandlerInfo = array[i];
				if (!flag || routedEventHandlerInfo.HandledEventsToo)
				{
					InvokeHandler(routedEventHandlerInfo.Handler, args);
					flag = IsHandled(args);
				}
			}
			if (flag)
			{
				if (!AnyParentInterested(routedEvent))
				{
					return true;
				}
				if (args != null)
				{
					args.CanBubbleNatively = false;
				}
			}
		}
		if (ctx.Mode.HasFlag(BubblingMode.IgnoreParents))
		{
			return flag;
		}
		if (!IsBubblingInManagedCode(routedEvent, args))
		{
			return false;
		}
		if (args != null)
		{
			args.CanBubbleNatively = false;
		}
		if (!(this.GetParent() is UIElement parent))
		{
			return true;
		}
		return RaiseOnParent(routedEvent, args, parent, ctx);
	}

	private static void TrackKeyState(RoutedEvent routedEvent, RoutedEventArgs args)
	{
		if (args is KeyRoutedEventArgs keyRoutedEventArgs)
		{
			if (routedEvent == KeyDownEvent)
			{
				KeyboardStateTracker.OnKeyDown(keyRoutedEventArgs.OriginalKey);
			}
			else if (routedEvent == KeyUpEvent)
			{
				KeyboardStateTracker.OnKeyUp(keyRoutedEventArgs.OriginalKey);
			}
		}
	}

	private static bool RaiseOnParent(RoutedEvent routedEvent, RoutedEventArgs args, UIElement parent, BubblingContext ctx)
	{
		BubblingMode bubblingMode = parent.PrepareManagedEventBubbling(routedEvent, args, out args);
		if (parent == ctx.Root)
		{
			bubblingMode |= BubblingMode.IgnoreParents;
		}
		return parent.RaiseEvent(routedEvent, args, ctx.WithMode(bubblingMode));
	}

	private BubblingMode PrepareManagedEventBubbling(RoutedEvent routedEvent, RoutedEventArgs args, out RoutedEventArgs alteredArgs)
	{
		BubblingMode bubblingMode = BubblingMode.Bubble;
		alteredArgs = args;
		if (routedEvent.IsPointerEvent)
		{
			PrepareManagedPointerEventBubbling(routedEvent, ref alteredArgs, ref bubblingMode);
		}
		else if (!routedEvent.IsKeyEvent && !routedEvent.IsFocusEvent)
		{
			if (routedEvent.IsManipulationEvent)
			{
				PrepareManagedManipulationEventBubbling(routedEvent, ref alteredArgs, ref bubblingMode);
			}
			else if (routedEvent.IsGestureEvent)
			{
				PrepareManagedGestureEventBubbling(routedEvent, ref alteredArgs, ref bubblingMode);
			}
			else if (routedEvent.IsDragAndDropEvent)
			{
				PrepareManagedDragAndDropEventBubbling(routedEvent, ref alteredArgs, ref bubblingMode);
			}
		}
		return bubblingMode;
	}

	private void PrepareManagedPointerEventBubbling(RoutedEvent routedEvent, ref RoutedEventArgs args, ref BubblingMode bubblingMode)
	{
		PointerRoutedEventArgs args2 = (PointerRoutedEventArgs)args;
		RoutedEventFlag flag = routedEvent.Flag;
		switch (flag)
		{
		case RoutedEventFlag.None:
		case RoutedEventFlag.PointerPressed:
		case RoutedEventFlag.PointerReleased:
		case RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased:
		case RoutedEventFlag.PointerEntered:
		case RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerEntered:
		case RoutedEventFlag.PointerReleased | RoutedEventFlag.PointerEntered:
		case RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased | RoutedEventFlag.PointerEntered:
		case RoutedEventFlag.PointerExited:
		{
			RoutedEventFlag num = flag - 1;
			if (num <= (RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased))
			{
				switch (num)
				{
				case RoutedEventFlag.PointerPressed | RoutedEventFlag.PointerReleased:
					OnPointerEnter(args2, BubblingContext.OnManagedBubbling);
					return;
				case RoutedEventFlag.None:
					OnPointerDown(args2, BubblingContext.OnManagedBubbling);
					return;
				case RoutedEventFlag.PointerPressed:
					OnPointerUp(args2, BubblingContext.OnManagedBubbling);
					return;
				case RoutedEventFlag.PointerReleased:
					return;
				}
			}
			if (flag == RoutedEventFlag.PointerExited)
			{
				OnPointerExited(args2, BubblingContext.OnManagedBubbling);
			}
			break;
		}
		case RoutedEventFlag.PointerMoved:
			OnPointerMove(args2, BubblingContext.OnManagedBubbling);
			break;
		case RoutedEventFlag.PointerCanceled:
			OnPointerCancel(args2, BubblingContext.OnManagedBubbling);
			break;
		}
	}

	private void PrepareManagedManipulationEventBubbling(RoutedEvent routedEvent, ref RoutedEventArgs args, ref BubblingMode bubblingMode)
	{
		if (routedEvent != ManipulationStartingEvent && _gestures.IsValueCreated)
		{
			_gestures.Value.CompleteGesture();
		}
	}

	private void PrepareManagedGestureEventBubbling(RoutedEvent routedEvent, ref RoutedEventArgs args, ref BubblingMode bubblingMode)
	{
		if (routedEvent == HoldingEvent)
		{
			if (_gestures.IsValueCreated)
			{
				_gestures.Value.PreventHolding(((HoldingRoutedEventArgs)args).PointerId);
			}
		}
		else
		{
			CompleteGesture();
		}
	}

	private void PrepareManagedDragAndDropEventBubbling(RoutedEvent routedEvent, ref RoutedEventArgs args, ref BubblingMode bubblingMode)
	{
		switch (routedEvent.Flag)
		{
		case RoutedEventFlag.DragStarting:
		case RoutedEventFlag.DropCompleted:
			bubblingMode = BubblingMode.NoBubbling;
			break;
		case RoutedEventFlag.DragEnter:
		{
			long sourceId2 = ((DragEventArgs)args).SourceId;
			bool flag2 = IsDragOver(sourceId2);
			SetIsDragOver(sourceId2, isOver: true);
			if (!AllowDrop || flag2)
			{
				bubblingMode = BubblingMode.IgnoreElement;
			}
			break;
		}
		case RoutedEventFlag.DragOver:
			SetIsDragOver(((DragEventArgs)args).SourceId, isOver: true);
			if (!AllowDrop)
			{
				bubblingMode = BubblingMode.IgnoreElement;
			}
			break;
		case RoutedEventFlag.DragLeave:
		case RoutedEventFlag.Drop:
		{
			long sourceId = ((DragEventArgs)args).SourceId;
			bool flag = IsDragOver(sourceId);
			SetIsDragOver(sourceId, isOver: false);
			if (!AllowDrop || !flag)
			{
				bubblingMode = BubblingMode.IgnoreElement;
			}
			break;
		}
		}
	}

	private static bool IsHandled(RoutedEventArgs args)
	{
		if (args is IHandleableRoutedEventArgs handleableRoutedEventArgs)
		{
			return handleableRoutedEventArgs.Handled;
		}
		return false;
	}

	private bool IsBubblingInManagedCode(RoutedEvent routedEvent, RoutedEventArgs args)
	{
		if (args == null || !args.CanBubbleNatively)
		{
			return true;
		}
		RoutedEventFlag eventsBubblingInManagedCode = EventsBubblingInManagedCode;
		RoutedEventFlag flag = routedEvent.Flag;
		return eventsBubblingInManagedCode.HasFlag(flag);
	}

	private bool AnyParentInterested(RoutedEvent routedEvent)
	{
		if (routedEvent.IsAlwaysBubbled)
		{
			return true;
		}
		RoutedEventFlag subscribedToHandledEventsToo = SubscribedToHandledEventsToo;
		RoutedEventFlag flag = routedEvent.Flag;
		return subscribedToHandledEventsToo.HasFlag(flag);
	}

	private void InvokeHandler(object handler, RoutedEventArgs args)
	{
		if (!(handler is RoutedEventHandler routedEventHandler))
		{
			if (!(handler is PointerEventHandler pointerEventHandler))
			{
				if (!(handler is TappedEventHandler tappedEventHandler))
				{
					if (!(handler is DoubleTappedEventHandler doubleTappedEventHandler))
					{
						if (!(handler is RightTappedEventHandler rightTappedEventHandler))
						{
							if (!(handler is HoldingEventHandler holdingEventHandler))
							{
								if (!(handler is DragEventHandler dragEventHandler))
								{
									if (!(handler is TypedEventHandler<UIElement, DragStartingEventArgs> typedEventHandler))
									{
										if (!(handler is TypedEventHandler<UIElement, DropCompletedEventArgs> typedEventHandler2))
										{
											if (!(handler is KeyEventHandler keyEventHandler))
											{
												if (!(handler is ManipulationStartingEventHandler manipulationStartingEventHandler))
												{
													if (!(handler is ManipulationStartedEventHandler manipulationStartedEventHandler))
													{
														if (!(handler is ManipulationDeltaEventHandler manipulationDeltaEventHandler))
														{
															if (!(handler is ManipulationInertiaStartingEventHandler manipulationInertiaStartingEventHandler))
															{
																if (!(handler is ManipulationCompletedEventHandler manipulationCompletedEventHandler))
																{
																	if (!(handler is TypedEventHandler<UIElement, GettingFocusEventArgs> typedEventHandler3))
																	{
																		if (handler is TypedEventHandler<UIElement, LosingFocusEventArgs> typedEventHandler4)
																		{
																			typedEventHandler4(this, (LosingFocusEventArgs)args);
																		}
																		else
																		{
																			this.Log().Error($"The handler type {handler.GetType()} has not been registered for RoutedEvent");
																		}
																	}
																	else
																	{
																		typedEventHandler3(this, (GettingFocusEventArgs)args);
																	}
																}
																else
																{
																	manipulationCompletedEventHandler(this, (ManipulationCompletedRoutedEventArgs)args);
																}
															}
															else
															{
																manipulationInertiaStartingEventHandler(this, (ManipulationInertiaStartingRoutedEventArgs)args);
															}
														}
														else
														{
															manipulationDeltaEventHandler(this, (ManipulationDeltaRoutedEventArgs)args);
														}
													}
													else
													{
														manipulationStartedEventHandler(this, (ManipulationStartedRoutedEventArgs)args);
													}
												}
												else
												{
													manipulationStartingEventHandler(this, (ManipulationStartingRoutedEventArgs)args);
												}
											}
											else
											{
												keyEventHandler(this, (KeyRoutedEventArgs)args);
											}
										}
										else
										{
											typedEventHandler2(this, (DropCompletedEventArgs)args);
										}
									}
									else
									{
										typedEventHandler(this, (DragStartingEventArgs)args);
									}
								}
								else
								{
									dragEventHandler(this, (DragEventArgs)args);
								}
							}
							else
							{
								holdingEventHandler(this, (HoldingRoutedEventArgs)args);
							}
						}
						else
						{
							rightTappedEventHandler(this, (RightTappedRoutedEventArgs)args);
						}
					}
					else
					{
						doubleTappedEventHandler(this, (DoubleTappedRoutedEventArgs)args);
					}
				}
				else
				{
					tappedEventHandler(this, (TappedRoutedEventArgs)args);
				}
			}
			else
			{
				pointerEventHandler(this, (PointerRoutedEventArgs)args);
			}
		}
		else
		{
			routedEventHandler(this, args);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool ShouldRaiseEvent(Delegate eventHandler)
	{
		return (object)eventHandler != null;
	}

	public void InvalidateMeasure()
	{
		if (!ShouldInterceptInvalidate)
		{
			_isMeasureValid = false;
			_isArrangeValid = false;
			if (this.GetParent() is UIElement uIElement)
			{
				uIElement.InvalidateMeasure();
			}
			else
			{
				Window.InvalidateMeasure();
			}
		}
	}

	public void InvalidateArrange()
	{
		if (!ShouldInterceptInvalidate && _isArrangeValid)
		{
			_isArrangeValid = false;
			if (this.GetParent() is UIElement uIElement)
			{
				uIElement.InvalidateArrange();
			}
			else
			{
				Window.InvalidateMeasure();
			}
		}
	}

	public void Measure(Size availableSize)
	{
		if (!(this is FrameworkElement))
		{
			return;
		}
		if (double.IsNaN(availableSize.Width) || double.IsNaN(availableSize.Height))
		{
			throw new InvalidOperationException($"Cannot measure [{GetType()}] with NaN");
		}
		bool flag = availableSize == LastAvailableSize;
		if (Visibility == Visibility.Collapsed)
		{
			if (!flag)
			{
				_isMeasureValid = false;
				LayoutInformation.SetAvailableSize(this, availableSize);
			}
		}
		else if (!(_isMeasureValid && flag))
		{
			if (IsVisualTreeRoot)
			{
				MeasureVisualTreeRoot(availableSize);
			}
			else
			{
				DoMeasure(availableSize);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void MeasureVisualTreeRoot(Size availableSize)
	{
		try
		{
			_isLayoutingVisualTreeRoot = true;
			DoMeasure(availableSize);
		}
		finally
		{
			_isLayoutingVisualTreeRoot = false;
		}
	}

	private void DoMeasure(Size availableSize)
	{
		InvalidateArrange();
		_isMeasureValid = true;
		MeasureCore(availableSize);
		LayoutInformation.SetAvailableSize(this, availableSize);
	}

	internal virtual void MeasureCore(Size availableSize)
	{
		throw new NotSupportedException("UIElement doesn't implement MeasureCore. Inherit from FrameworkElement, which properly implements MeasureCore.");
	}

	public void Arrange(Rect finalRect)
	{
		if (!(this is FrameworkElement))
		{
			return;
		}
		if (Visibility == Visibility.Collapsed || (finalRect == default(Rect) && (!(this is ICustomClippingElement customClippingElement) || customClippingElement.AllowClippingToLayoutSlot)))
		{
			LayoutInformation.SetLayoutSlot(this, finalRect);
			_isArrangeValid = true;
		}
		else if (!_isArrangeValid || !(finalRect == LayoutSlot))
		{
			if (IsVisualTreeRoot)
			{
				ArrangeVisualTreeRoot(finalRect);
			}
			else
			{
				DoArrange(finalRect);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ArrangeVisualTreeRoot(Rect finalRect)
	{
		try
		{
			_isLayoutingVisualTreeRoot = true;
			DoArrange(finalRect);
		}
		finally
		{
			_isLayoutingVisualTreeRoot = false;
		}
	}

	private void DoArrange(Rect finalRect)
	{
		LayoutInformation.SetLayoutSlot(this, finalRect);
		_isArrangeValid = true;
		ArrangeCore(finalRect);
	}

	internal virtual void ArrangeCore(Rect finalRect)
	{
		throw new NotSupportedException("UIElement doesn't implement ArrangeCore. Inherit from FrameworkElement, which properly implements ArrangeCore.");
	}

	internal static void LoadingRootElement(UIElement visualTreeRoot)
	{
		visualTreeRoot.OnElementLoading(1);
	}

	internal static void RootElementLoaded(UIElement visualTreeRoot)
	{
		visualTreeRoot.SetHitTestVisibilityForRoot();
		visualTreeRoot.OnElementLoaded();
	}

	internal static void RootElementUnloaded(UIElement visualTreeRoot)
	{
		visualTreeRoot.ClearHitTestVisibilityForRoot();
		visualTreeRoot.OnElementUnloaded();
	}

	private protected virtual void OnFwEltLoading()
	{
	}

	private protected virtual void OnFwEltLoaded()
	{
	}

	private protected virtual void OnFwEltUnloaded()
	{
	}

	private void OnElementLoading(int depth)
	{
		if (!IsLoading && !IsLoaded)
		{
			IsLoading = true;
			Depth = depth;
			OnFwEltLoading();
			List<UIElement> materialized = _children.Materialized;
			for (int i = 0; i < materialized.Count; i++)
			{
				materialized[i].OnElementLoading(depth + 1);
			}
		}
	}

	private void OnElementLoaded()
	{
		if (!IsLoaded)
		{
			if (!IsLoading && _log.IsEnabled(LogLevel.Error))
			{
				_log.Error($"Element {this} is being loaded while not in loading state");
			}
			IsLoading = false;
			IsLoaded = true;
			OnFwEltLoaded();
			UpdateHitTest();
			List<UIElement> materialized = _children.Materialized;
			for (int i = 0; i < materialized.Count; i++)
			{
				materialized[i].OnElementLoaded();
			}
		}
	}

	private void OnElementUnloaded()
	{
		if (IsLoaded)
		{
			IsLoaded = false;
			Depth = int.MinValue;
			List<UIElement> materialized = _children.Materialized;
			for (int i = 0; i < materialized.Count; i++)
			{
				materialized[i].OnElementUnloaded();
			}
			OnFwEltUnloaded();
			UpdateHitTest();
		}
	}

	private void OnAddingChild(UIElement child)
	{
		if (IsLoading || IsLoaded)
		{
			child.OnElementLoading(Depth + 1);
		}
	}

	private void OnChildAdded(UIElement child)
	{
		if (!FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded || !IsLoaded || !child._isFrameworkElement)
		{
			return;
		}
		if (child.IsLoaded)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"{this.GetDebugName()}: Inconsistent state: child {child} is already loaded (OnChildAdded). Common cause for this is an exception during Unloaded handling.");
			}
		}
		else
		{
			child.OnElementLoaded();
		}
	}

	private void OnChildRemoved(UIElement child)
	{
		if (FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded && IsLoaded && child._isFrameworkElement)
		{
			if (child.IsLoaded)
			{
				child.OnElementUnloaded();
			}
			else if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"{this.GetDebugName()}: Inconsistent state: child {child} is not loaded (OnChildRemoved). Common cause for this is an exception during Loaded handling.");
			}
		}
	}

	internal Point GetPosition(Point position, UIElement relativeTo)
	{
		return TransformToVisual(relativeTo).TransformPoint(position);
	}

	internal void RegisterEventHandler(string eventName, Delegate handler, GenericEventHandler invoker, bool onCapturePhase = false, HtmlEventExtractor? eventExtractor = null, EventArgsParser payloadConverter = null)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Registering {eventName} on {this}.");
		}
		if (!_eventHandlers.TryGetValue(eventName, out var value))
		{
			value = (_eventHandlers[eventName] = new EventRegistration(this, eventName, onCapturePhase, eventExtractor, payloadConverter));
		}
		value.Add(handler, invoker);
	}

	internal void UnregisterEventHandler(string eventName, Delegate handler, GenericEventHandler invoker)
	{
		if (_eventHandlers.TryGetValue(eventName, out var value))
		{
			value.Remove(handler, invoker);
		}
		else if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug("No handler registered for event " + eventName + ".");
		}
	}

	internal HtmlEventDispatchResult InternalDispatchEvent(string eventName, EventArgs eventArgs = null, string nativeEventPayload = null)
	{
		try
		{
			return InternalInnerDispatchEvent(eventArgs, nativeEventPayload, eventName);
		}
		catch (Exception ex)
		{
			this.Log().Error($"{this}-{HtmlId}/{eventName}/\"{nativeEventPayload}\": Error: {ex}");
			Application.Current.RaiseRecoverableUnhandledExceptionOrLog(ex, this);
		}
		return HtmlEventDispatchResult.Ok;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private HtmlEventDispatchResult InternalInnerDispatchEvent(EventArgs eventArgs, string nativeEventPayload, string n)
	{
		if (_eventHandlers.TryGetValue(n, out var value))
		{
			return value.Dispatch(eventArgs, nativeEventPayload);
		}
		string text = string.Join(", ", _eventHandlers.Keys);
		this.Log().Warn($"{this}-{HtmlId}: No Handler for {n}. Registered: {text}");
		return HtmlEventDispatchResult.Ok;
	}

	[Preserve]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static int DispatchEvent(int handle, string eventName, string eventArgs)
	{
		UIElement elementFromHandle = GetElementFromHandle(handle);
		if (elementFromHandle != null)
		{
			return (int)elementFromHandle.InternalDispatchEvent(eventName, null, eventArgs);
		}
		Console.Error.WriteLine($"No UIElement found for htmlId \"{handle}\"");
		return 128;
	}

	private static HtmlEventDispatchResult DispatchNativePointerEnter(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerEnter(ToPointerArgs(target, args)))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerLeave(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerExited(ToPointerArgs(target, args)))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerDown(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerDown(ToPointerArgs(target, args, true)))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerUp(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerUp(ToPointerArgs(target, args, false)))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerMove(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerMove(ToPointerArgs(target, args)))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerCancel(UIElement target, string eventPayload)
	{
		if (!TryParse(eventPayload, out var args) || !target.OnNativePointerCancel(ToPointerArgs(target, args, false), isSwallowedBySystem: true))
		{
			return HtmlEventDispatchResult.Ok;
		}
		return HtmlEventDispatchResult.StopPropagation;
	}

	private static HtmlEventDispatchResult DispatchNativePointerWheel(UIElement target, string eventPayload)
	{
		if (TryParse(eventPayload, out var args))
		{
			bool flag = false;
			if (args.wheelDeltaX != 0.0)
			{
				bool num = flag;
				NativePointerEventArgs args2 = args;
				(bool, double) wheel = (true, args.wheelDeltaX);
				flag = num | target.OnNativePointerWheel(ToPointerArgs(target, args2, null, wheel));
			}
			if (args.wheelDeltaY != 0.0)
			{
				bool num2 = flag;
				NativePointerEventArgs args3 = args;
				(bool, double) wheel = (false, 0.0 - args.wheelDeltaY);
				flag = num2 | target.OnNativePointerWheel(ToPointerArgs(target, args3, null, wheel));
			}
			if (!flag)
			{
				return HtmlEventDispatchResult.Ok;
			}
			return HtmlEventDispatchResult.StopPropagation;
		}
		return HtmlEventDispatchResult.Ok;
	}

	private static bool TryParse(string eventPayload, out NativePointerEventArgs args)
	{
		string[] array = eventPayload?.Split(new char[1] { ';' });
		if (array == null || array.Length != 13)
		{
			args = default(NativePointerEventArgs);
			return false;
		}
		args = new NativePointerEventArgs
		{
			pointerId = double.Parse(array[0], CultureInfo.InvariantCulture),
			x = double.Parse(array[1], CultureInfo.InvariantCulture),
			y = double.Parse(array[2], CultureInfo.InvariantCulture),
			ctrl = (array[3] == "1"),
			shift = (array[4] == "1"),
			buttons = int.Parse(array[5], CultureInfo.InvariantCulture),
			buttonUpdate = int.Parse(array[6], CultureInfo.InvariantCulture),
			typeStr = array[7],
			srcHandle = int.Parse(array[8], CultureInfo.InvariantCulture),
			timestamp = double.Parse(array[9], CultureInfo.InvariantCulture),
			pressure = double.Parse(array[10], CultureInfo.InvariantCulture),
			wheelDeltaX = double.Parse(array[11], CultureInfo.InvariantCulture),
			wheelDeltaY = double.Parse(array[12], CultureInfo.InvariantCulture)
		};
		return true;
	}

	private static PointerRoutedEventArgs ToPointerArgs(UIElement snd, NativePointerEventArgs args, bool? isInContact = null, (bool isHorizontalWheel, double delta) wheel = default((bool isHorizontalWheel, double delta)))
	{
		uint pointerId = (uint)args.pointerId;
		UIElement source = GetElementFromHandle(args.srcHandle) ?? snd;
		Point absolutePosition = new Point(args.x, args.y);
		PointerDeviceType pointerType = ConvertPointerTypeString(args.typeStr);
		VirtualKeyModifiers virtualKeyModifiers = VirtualKeyModifiers.None;
		if (args.ctrl)
		{
			virtualKeyModifiers |= VirtualKeyModifiers.Control;
		}
		if (args.shift)
		{
			virtualKeyModifiers |= VirtualKeyModifiers.Shift;
		}
		return new PointerRoutedEventArgs(args.timestamp, pointerId, pointerType, absolutePosition, isInContact ?? snd.IsPressed(pointerId), (WindowManagerInterop.HtmlPointerButtonsState)args.buttons, (WindowManagerInterop.HtmlPointerButtonUpdate)args.buttonUpdate, virtualKeyModifiers, args.pressure, wheel, source);
	}

	private static PointerDeviceType ConvertPointerTypeString(string typeStr)
	{
		return typeStr.ToUpper() switch
		{
			"PEN" => PointerDeviceType.Pen, 
			"TOUCH" => PointerDeviceType.Touch, 
			_ => PointerDeviceType.Mouse, 
		};
	}

	internal void UpdateHitTest()
	{
		this.CoerceValue(HitTestVisibilityProperty);
	}

	private object CoerceHitTestVisibility(object baseValue)
	{
		if ((HitTestability)baseValue == HitTestability.Collapsed)
		{
			return HitTestability.Collapsed;
		}
		if ((!IsLoaded && !HtmlTagIsSvg) || !IsHitTestVisible || Visibility != 0 || !IsEnabledOverride())
		{
			return HitTestability.Collapsed;
		}
		if (!IsViewHit())
		{
			return HitTestability.Invisible;
		}
		return HitTestability.Visible;
	}

	private protected virtual void OnHitTestVisibilityChanged(HitTestability oldValue, HitTestability newValue)
	{
		ApplyHitTestVisibility(newValue);
	}

	private void ApplyHitTestVisibility(HitTestability value)
	{
		if (value == HitTestability.Visible)
		{
			WindowManagerInterop.SetPointerEvents(HtmlId, enabled: true);
		}
		else
		{
			WindowManagerInterop.SetPointerEvents(HtmlId, enabled: false);
		}
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMProperties();
		}
	}

	internal void SetHitTestVisibilityForRoot()
	{
		HitTestVisibility = HitTestability.Visible;
	}

	internal void ClearHitTestVisibilityForRoot()
	{
		ClearValue(HitTestVisibilityProperty);
	}

	internal void SetText(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ((!string.IsNullOrEmpty(text)) ? ("\u200b" + text) : "\u200b");
		}
		SetProperty("textContent", text);
	}

	internal void SetFontStyle(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("font-style");
			return;
		}
		switch ((FontStyle)localValue)
		{
		case FontStyle.Normal:
			SetStyle("font-style", "normal");
			break;
		case FontStyle.Italic:
			SetStyle("font-style", "italic");
			break;
		case FontStyle.Oblique:
			SetStyle("font-style", "oblique");
			break;
		}
	}

	internal void SetFontWeight(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("font-weight");
		}
		else
		{
			SetStyle("font-weight", ((FontWeight)localValue).ToCssString());
		}
	}

	internal void SetFontFamily(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("font-family");
			return;
		}
		FontFamily fontFamily = (FontFamily)localValue;
		if (fontFamily != null)
		{
			string source = fontFamily.Source;
			if (source == "XamlAutoFontFamily")
			{
				fontFamily = FontFamily.Default;
			}
			SetStyle("font-family", fontFamily.ParsedSource);
		}
	}

	internal void SetFontSize(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("font-size");
		}
		else
		{
			double number = (double)localValue;
			SetStyle("font-size", number.ToStringInvariant() + "px");
		}
	}

	internal void SetMaxLines(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("display", "-webkit-line-clamp", "webkit-box-orient");
		}
		else
		{
			int number = (int)localValue;
			SetStyle(("display", "-webkit-box"), ("-webkit-line-clamp", number.ToStringInvariant()), ("-webkit-box-orient", "vertical"));
		}
	}

	private void SetTextTrimming(object localValue)
	{
		if (localValue is TextTrimming textTrimming)
		{
			switch (textTrimming)
			{
			case TextTrimming.CharacterEllipsis:
			case TextTrimming.WordEllipsis:
				SetStyle("text-overflow", "ellipsis");
				return;
			case TextTrimming.Clip:
				SetStyle("text-overflow", "clip");
				return;
			}
		}
		else if (localValue is UnsetValue)
		{
			ResetStyle("text-overflow");
			return;
		}
		SetStyle("text-overflow", "");
	}

	internal void SetForeground(object localValue)
	{
		if (_brushSubscription != null)
		{
			_brushSubscription.Disposable = null;
		}
		if (!(localValue is SolidColorBrush solidColorBrush))
		{
			if (!(localValue is GradientBrush gradientBrush))
			{
				ImageBrush imageBrush = localValue as ImageBrush;
				if (imageBrush == null)
				{
					if (!(localValue is AcrylicBrush acrylicBrush))
					{
						UnsetValue unsetValue = localValue as UnsetValue;
						if ((object)unsetValue == null)
						{
						}
						ResetStyle("color", "background", "background-clip");
						AcrylicBrush.ResetStyle(this);
					}
					else
					{
						acrylicBrush.Apply(this);
						SetStyle("background-clip", "text");
					}
					return;
				}
				if (_brushSubscription == null)
				{
					_brushSubscription = new SerialDisposable();
				}
				_brushSubscription.Disposable = imageBrush.Subscribe(delegate(ImageData img)
				{
					switch (img.Kind)
					{
					case ImageDataKind.Empty:
					case ImageDataKind.Error:
						ResetStyle("background-color", "background-image", "background-size");
						SetStyle(("color", "transparent"), ("background-clip", "text"));
						break;
					default:
						SetStyle(("color", "transparent"), ("background-clip", "text"), ("background-color", ""), ("background-origin", "content-box"), ("background-position", imageBrush.ToCssPosition()), ("background-size", imageBrush.ToCssBackgroundSize()), ("background-image", "url(" + img.Value + ")"));
						break;
					}
				});
			}
			else
			{
				SetStyle(("background", gradientBrush.ToCssString(RenderSize)), ("color", "transparent"), ("background-clip", "text"));
			}
		}
		else
		{
			WindowManagerInterop.SetElementColor(HtmlId, solidColorBrush.ColorWithOpacity);
		}
	}

	internal void SetCharacterSpacing(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("letter-spacing");
		}
		else
		{
			int num = (int)localValue;
			SetStyle("letter-spacing", ((double)num / 1000.0).ToStringInvariant() + "em");
		}
	}

	internal void SetLineHeight(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("line-height");
			return;
		}
		double num = (double)localValue;
		if (Math.Abs(num) < 0.0001)
		{
			ResetStyle("line-height");
		}
		else
		{
			SetStyle("line-height", num.ToStringInvariant() + "px");
		}
	}

	internal void SetTextAlignment(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("text-align");
			return;
		}
		switch ((TextAlignment)localValue)
		{
		case TextAlignment.Left:
			SetStyle("text-align", "left");
			break;
		case TextAlignment.Center:
			SetStyle("text-align", "center");
			break;
		case TextAlignment.Right:
			SetStyle("text-align", "right");
			break;
		case TextAlignment.Justify:
			SetStyle("text-align", "justify");
			break;
		default:
			ResetStyle("text-align");
			break;
		}
	}

	internal void SetTextWrappingAndTrimming(object textWrapping, object textTrimming)
	{
		if (textWrapping is UnsetValue)
		{
			ResetStyle("white-space", "word-break", "text-overflow");
			return;
		}
		switch ((TextWrapping)textWrapping)
		{
		case TextWrapping.NoWrap:
			SetStyle(("white-space", "pre"), ("word-break", ""));
			SetTextTrimming(textTrimming);
			break;
		case TextWrapping.Wrap:
			SetStyle(("white-space", "pre-wrap"), ("word-break", "break-word"), ("text-overflow", ""));
			break;
		case TextWrapping.WrapWholeWords:
			SetStyle(("white-space", "pre-wrap"), ("word-break", "keep-all"), ("text-overflow", ""));
			break;
		}
	}

	internal void SetTextDecorations(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("text-decoration");
			return;
		}
		switch ((TextDecorations)localValue)
		{
		case TextDecorations.None:
			SetStyle("text-decoration", "none");
			break;
		case TextDecorations.Underline:
			SetStyle("text-decoration", "underline");
			break;
		case TextDecorations.Strikethrough:
			SetStyle("text-decoration", "line-through");
			break;
		case TextDecorations.Underline | TextDecorations.Strikethrough:
			SetStyle("text-decoration", "underline line-through");
			break;
		}
	}

	internal void SetTextPadding(object localValue)
	{
		if (localValue is UnsetValue)
		{
			ResetStyle("padding");
			return;
		}
		Thickness thickness = (Thickness)localValue;
		string[] array = new string[8]
		{
			thickness.Top.ToStringInvariant(),
			"px ",
			thickness.Right.ToStringInvariant(),
			"px ",
			thickness.Bottom.ToStringInvariant(),
			"px ",
			thickness.Left.ToStringInvariant(),
			"px"
		};
		SetStyle("padding", string.Concat(array));
	}

	public Size MeasureView(Size availableSize, bool measureContent = true)
	{
		return WindowManagerInterop.MeasureView(HtmlId, availableSize, measureContent);
	}

	internal Rect GetBBox()
	{
		if (!HtmlTagIsSvg)
		{
			throw new InvalidOperationException("GetBBox is available only for SVG elements.");
		}
		return WindowManagerInterop.GetBBox(HtmlId);
	}

	private Rect GetBoundingClientRect()
	{
		string text = WebAssemblyRuntime.InvokeJS("Uno.UI.WindowManager.current.getBoundingClientRect(" + HtmlId + ");");
		string[] array = text.Split(new char[1] { ';' });
		return new Rect(double.Parse(array[0]), double.Parse(array[1]), double.Parse(array[2]), double.Parse(array[3]));
	}

	public UIElement()
		: this(null, isSvg: false)
	{
	}

	public UIElement(string htmlTag = "div")
		: this(htmlTag, isSvg: false)
	{
	}

	public UIElement(string htmlTag, bool isSvg)
	{
		_log = this.Log();
		_logDebug = (_log.IsEnabled(LogLevel.Debug) ? _log : null);
		Initialize();
		_gcHandle = GCHandle.Alloc(this, GCHandleType.Weak);
		_isFrameworkElement = this is FrameworkElement;
		HtmlTag = GetHtmlTag(htmlTag);
		HtmlTagIsSvg = isSvg;
		Type type = GetType();
		Handle = GCHandle.ToIntPtr(_gcHandle);
		HtmlId = Handle;
		WindowManagerInterop.CreateContent(HtmlId, HtmlTag, Handle, UIElementNativeRegistrar.GetForType(type), HtmlTagIsSvg, isFocusable: false);
		InitializePointers();
		UpdateHitTest();
	}

	private string GetHtmlTag(string htmlTag)
	{
		Type type = GetType();
		if (type.Assembly != _unoUIAssembly)
		{
			if (_htmlElementAttribute == null)
			{
				_htmlElementAttribute = GetUnoUIRuntimeWebAssembly().GetType("Uno.UI.Runtime.WebAssembly.HtmlElementAttribute", throwOnError: true);
				_htmlTagAttributeTagGetter = _htmlElementAttribute.GetProperty("Tag");
			}
			if (!_htmlTagCache.TryGetValue(type, out var value))
			{
				value = htmlTag;
				Attribute customAttribute = type.GetCustomAttribute(_htmlElementAttribute, inherit: true);
				if (customAttribute != null)
				{
					value = (_htmlTagCache[type] = _htmlTagAttributeTagGetter.GetValue(customAttribute, Array.Empty<object>()) as string);
				}
				_htmlTagCache[type] = value;
			}
			return value;
		}
		return htmlTag;
	}

	~UIElement()
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Collecting UIElement for [{HtmlId}]");
		}
		Cleanup();
		WindowManagerInterop.DestroyView(HtmlId);
		_gcHandle.Free();
	}

	protected internal void SetStyle(string name, string value)
	{
		WindowManagerInterop.SetStyles(HtmlId, new(string, string)[1] { (name, value) });
	}

	protected internal void SetStyle(string name, double value)
	{
		WindowManagerInterop.SetStyleDouble(HtmlId, name, value);
	}

	protected internal void SetStyle(params (string name, string value)[] styles)
	{
		if (styles != null && styles.Length != 0)
		{
			WindowManagerInterop.SetStyles(HtmlId, styles);
		}
	}

	protected internal void SetCssClasses(params string[] classesToSet)
	{
		WindowManagerInterop.SetUnsetCssClasses(HtmlId, classesToSet, null);
	}

	protected internal void UnsetCssClasses(params string[] classesToUnset)
	{
		WindowManagerInterop.SetUnsetCssClasses(HtmlId, null, classesToUnset);
	}

	protected internal void SetUnsetCssClasses(string[] classesToSet, string[] classesToUnset)
	{
		WindowManagerInterop.SetUnsetCssClasses(HtmlId, classesToSet, classesToUnset);
	}

	protected internal void SetClasses(string[] cssClasses, int index = -1)
	{
		WindowManagerInterop.SetClasses(HtmlId, cssClasses, index);
	}

	protected internal void ArrangeVisual(Rect rect, Rect? clipRect)
	{
		LayoutSlotWithMarginsAndAlignments = ((VisualTreeHelper.GetParent(this) is UIElement uiElement) ? rect.DeflateBy(uiElement.GetBorderThickness()) : rect);
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMXamlProperty("LayoutSlotWithMarginsAndAlignments", LayoutSlotWithMarginsAndAlignments);
		}
		if (Visibility == Visibility.Collapsed)
		{
			double num3 = (rect.X = (rect.Y = -100000.0));
		}
		WindowManagerInterop.ArrangeElement(HtmlId, rect, clipRect);
		OnViewportUpdated(clipRect ?? Rect.Empty);
	}

	protected internal void SetNativeTransform(Matrix3x2 matrix)
	{
		WindowManagerInterop.SetElementTransform(HtmlId, matrix);
	}

	protected internal void ResetStyle(params string[] names)
	{
		WindowManagerInterop.ResetStyle(HtmlId, names);
	}

	protected internal void SetAttribute(string name, string value)
	{
		WindowManagerInterop.SetAttribute(HtmlId, name, value);
	}

	protected internal void RemoveAttribute(string name)
	{
		WindowManagerInterop.RemoveAttribute(HtmlId, name);
	}

	protected internal void SetAttribute(params (string name, string value)[] attributes)
	{
		if (attributes != null && attributes.Length != 0)
		{
			WindowManagerInterop.SetAttributes(HtmlId, attributes);
		}
	}

	protected internal string GetAttribute(string name)
	{
		string str = "Uno.UI.WindowManager.current.getAttribute(" + HtmlId + ", \"" + name + "\");";
		return WebAssemblyRuntime.InvokeJS(str);
	}

	protected internal void SetProperty(string name, string value)
	{
		SetProperty((name, value));
	}

	protected internal void SetProperty(params (string name, string value)[] properties)
	{
		if (properties != null && properties.Length != 0)
		{
			WindowManagerInterop.SetProperty(HtmlId, properties);
		}
	}

	protected internal string GetProperty(string name)
	{
		string str = "Uno.UI.WindowManager.current.getProperty(" + HtmlId + ", \"" + name + "\");";
		return WebAssemblyRuntime.InvokeJS(str);
	}

	protected internal void SetHtmlContent(string html)
	{
		WindowManagerInterop.SetContentHtml(HtmlId, html);
	}

	internal static UIElement GetElementFromHandle(int handle)
	{
		GCHandle gCHandle = GCHandle.FromIntPtr((IntPtr)handle);
		if (gCHandle.IsAllocated && gCHandle.Target is UIElement result)
		{
			return result;
		}
		return null;
	}

	public override string ToString()
	{
		if (FeatureConfiguration.UIElement.RenderToStringWithId)
		{
			return GetType().Name + "-" + HtmlId;
		}
		return base.ToString();
	}

	public UIElement FindFirstChild()
	{
		return _children.FirstOrDefault();
	}

	public virtual IEnumerable<UIElement> GetChildren()
	{
		return _children;
	}

	public void AddChild(UIElement child, int? index = null)
	{
		if (child != null)
		{
			UIElement uIElement = child.GetParent() as UIElement;
			if (uIElement != this && uIElement != null)
			{
				this.Log().Info($"{this}.AddChild({child}): Removing child {child} from its current parent {uIElement}.");
				uIElement.RemoveChild(child);
			}
			child.SetParent(this);
			OnAddingChild(child);
			if (index.HasValue)
			{
				int valueOrDefault = index.GetValueOrDefault();
				_children.Insert(valueOrDefault, child);
			}
			else
			{
				_children.Add(child);
			}
			WindowManagerInterop.AddView(HtmlId, child.HtmlId, index);
			OnChildAdded(child);
			child.InvalidateMeasure();
			child.InvalidateArrange();
		}
	}

	public void ClearChildren()
	{
		for (int i = 0; i < _children.Count; i++)
		{
			UIElement child = _children[i];
			RemoveNativeView(child);
			OnChildRemoved(child);
		}
		_children.Clear();
		InvalidateMeasure();
	}

	private void RemoveNativeView(UIElement child)
	{
		object parent = child.GetParent();
		child.SetParent(null);
		if (parent != null)
		{
			WindowManagerInterop.RemoveView(HtmlId, child.HtmlId);
		}
	}

	private void Cleanup()
	{
		if (this.GetParent() is UIElement uIElement)
		{
			uIElement.RemoveChild(this);
		}
		if (this is Panel panel)
		{
			panel.Children.Clear();
			return;
		}
		for (int i = 0; i < _children.Count; i++)
		{
			RemoveNativeView(_children[i]);
		}
		_children.Clear();
	}

	public bool RemoveChild(UIElement child)
	{
		if (child != null && _children.Remove(child))
		{
			child.SetParent(null);
			WindowManagerInterop.RemoveView(HtmlId, child.HtmlId);
			OnChildRemoved(child);
			InvalidateMeasure();
			return true;
		}
		return false;
	}

	internal void MoveChildTo(int oldIndex, int newIndex)
	{
		UIElement uIElement = _children[oldIndex];
		_children.RemoveAt(oldIndex);
		if (newIndex == _children.Count)
		{
			_children.Add(uIElement);
		}
		else
		{
			_children.Insert(newIndex, uIElement);
		}
		WindowManagerInterop.AddView(HtmlId, uIElement.HtmlId, newIndex);
		InvalidateMeasure();
	}

	private protected virtual void UpdateDOMProperties()
	{
		if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			UpdateDOMXamlProperty("Visibility", Visibility);
			UpdateDOMXamlProperty("IsHitTestVisible", IsHitTestVisible);
		}
	}

	internal void UpdateDOMXamlProperty(string propertyName, object value)
	{
		WindowManagerInterop.SetAttribute(HtmlId, "xaml" + propertyName.ToLowerInvariant().Replace('.', '_'), value?.ToString() ?? "[null]");
	}

	private static KeyRoutedEventArgs PayloadToKeyArgs(object src, string payload)
	{
		return new KeyRoutedEventArgs(src, VirtualKeyHelper.FromKey(payload))
		{
			CanBubbleNatively = true
		};
	}

	private static RoutedEventArgs PayloadToFocusArgs(object src, string payload)
	{
		if (int.TryParse(payload, out var result))
		{
			UIElement elementFromHandle = GetElementFromHandle(result);
			if (elementFromHandle != null)
			{
				return new RoutedEventArgs(elementFromHandle);
			}
		}
		return new RoutedEventArgs(src);
	}

	private static Assembly GetUnoUIRuntimeWebAssembly()
	{
		if (PlatformHelper.IsNetCore)
		{
			return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == "Uno.UI.Runtime.WebAssembly") ?? throw new InvalidOperationException("Unable to find Uno.UI.Runtime.WebAssembly in the loaded assemblies");
		}
		return Assembly.Load("Uno.UI.Runtime.WebAssembly");
	}

	public object GetValue(DependencyProperty dp)
	{
		return __Store.GetValue(dp);
	}

	public void SetValue(DependencyProperty dp, object value)
	{
		__Store.SetValue(dp, value);
	}

	public void ClearValue(DependencyProperty dp)
	{
		__Store.ClearValue(dp);
	}

	public object ReadLocalValue(DependencyProperty dp)
	{
		return __Store.ReadLocalValue(dp);
	}

	public object GetAnimationBaseValue(DependencyProperty dp)
	{
		return __Store.GetAnimationBaseValue(dp);
	}

	public long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback)
	{
		return __Store.RegisterPropertyChangedCallback(dp, callback);
	}

	public void UnregisterPropertyChangedCallback(DependencyProperty dp, long token)
	{
		__Store.UnregisterPropertyChangedCallback(dp, token);
	}

	private void __InitializeBinder()
	{
		if (BinderReferenceHolder.IsEnabled)
		{
			_refHolder = new BinderReferenceHolder(GetType(), this);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearBindings()
	{
		__Store.ClearBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RestoreBindings()
	{
		__Store.RestoreBindings();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ApplyCompiledBindings()
	{
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(this as FrameworkElement, new DataContextChangedEventArgs(DataContext));
	}

	protected internal virtual void OnTemplatedParentChanged(DependencyPropertyChangedEventArgs e)
	{
		__Store.SetTemplatedParent(e.NewValue as FrameworkElement);
	}

	public void SetBinding(object target, string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(target, dependencyProperty, binding);
	}

	public void SetBinding(string dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBinding(DependencyProperty dependencyProperty, BindingBase binding)
	{
		__Store.SetBinding(dependencyProperty, binding);
	}

	public void SetBindingValue(object value, [CallerMemberName] string propertyName = null)
	{
		__Store.SetBindingValue(value, propertyName);
	}

	public BindingExpression GetBindingExpression(DependencyProperty dependencyProperty)
	{
		return __Store.GetBindingExpression(dependencyProperty);
	}

	public void ResumeBindings()
	{
		__Store.ResumeBindings();
	}

	public void SuspendBindings()
	{
		__Store.SuspendBindings();
	}

	private XYFocusKeyboardNavigationMode GetXYFocusKeyboardNavigationValue()
	{
		if (!_XYFocusKeyboardNavigationPropertyBackingFieldSet)
		{
			_XYFocusKeyboardNavigationPropertyBackingField = (XYFocusKeyboardNavigationMode)GetValue(XYFocusKeyboardNavigationProperty);
			_XYFocusKeyboardNavigationPropertyBackingFieldSet = true;
		}
		return _XYFocusKeyboardNavigationPropertyBackingField;
	}

	private void SetXYFocusKeyboardNavigationValue(XYFocusKeyboardNavigationMode value)
	{
		SetValue(XYFocusKeyboardNavigationProperty, value);
	}

	private static DependencyProperty CreateXYFocusKeyboardNavigationProperty()
	{
		return DependencyProperty.Register("XYFocusKeyboardNavigation", typeof(XYFocusKeyboardNavigationMode), typeof(UIElement), new FrameworkPropertyMetadata((object)XYFocusKeyboardNavigationMode.Auto, FrameworkPropertyMetadataOptions.Inherits, (BackingFieldUpdateCallback)OnXYFocusKeyboardNavigationBackingFieldUpdate));
	}

	private static void OnXYFocusKeyboardNavigationBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusKeyboardNavigationPropertyBackingField = (XYFocusKeyboardNavigationMode)newValue;
		uIElement._XYFocusKeyboardNavigationPropertyBackingFieldSet = true;
	}

	private XYFocusNavigationStrategy GetXYFocusDownNavigationStrategyValue()
	{
		if (!_XYFocusDownNavigationStrategyPropertyBackingFieldSet)
		{
			_XYFocusDownNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)GetValue(XYFocusDownNavigationStrategyProperty);
			_XYFocusDownNavigationStrategyPropertyBackingFieldSet = true;
		}
		return _XYFocusDownNavigationStrategyPropertyBackingField;
	}

	private void SetXYFocusDownNavigationStrategyValue(XYFocusNavigationStrategy value)
	{
		SetValue(XYFocusDownNavigationStrategyProperty, value);
	}

	private static DependencyProperty CreateXYFocusDownNavigationStrategyProperty()
	{
		return DependencyProperty.Register("XYFocusDownNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(UIElement), new FrameworkPropertyMetadata((object)XYFocusNavigationStrategy.Auto, (BackingFieldUpdateCallback)OnXYFocusDownNavigationStrategyBackingFieldUpdate));
	}

	private static void OnXYFocusDownNavigationStrategyBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusDownNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)newValue;
		uIElement._XYFocusDownNavigationStrategyPropertyBackingFieldSet = true;
	}

	private XYFocusNavigationStrategy GetXYFocusLeftNavigationStrategyValue()
	{
		if (!_XYFocusLeftNavigationStrategyPropertyBackingFieldSet)
		{
			_XYFocusLeftNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)GetValue(XYFocusLeftNavigationStrategyProperty);
			_XYFocusLeftNavigationStrategyPropertyBackingFieldSet = true;
		}
		return _XYFocusLeftNavigationStrategyPropertyBackingField;
	}

	private void SetXYFocusLeftNavigationStrategyValue(XYFocusNavigationStrategy value)
	{
		SetValue(XYFocusLeftNavigationStrategyProperty, value);
	}

	private static DependencyProperty CreateXYFocusLeftNavigationStrategyProperty()
	{
		return DependencyProperty.Register("XYFocusLeftNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(UIElement), new FrameworkPropertyMetadata((object)XYFocusNavigationStrategy.Auto, (BackingFieldUpdateCallback)OnXYFocusLeftNavigationStrategyBackingFieldUpdate));
	}

	private static void OnXYFocusLeftNavigationStrategyBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusLeftNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)newValue;
		uIElement._XYFocusLeftNavigationStrategyPropertyBackingFieldSet = true;
	}

	private XYFocusNavigationStrategy GetXYFocusRightNavigationStrategyValue()
	{
		if (!_XYFocusRightNavigationStrategyPropertyBackingFieldSet)
		{
			_XYFocusRightNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)GetValue(XYFocusRightNavigationStrategyProperty);
			_XYFocusRightNavigationStrategyPropertyBackingFieldSet = true;
		}
		return _XYFocusRightNavigationStrategyPropertyBackingField;
	}

	private void SetXYFocusRightNavigationStrategyValue(XYFocusNavigationStrategy value)
	{
		SetValue(XYFocusRightNavigationStrategyProperty, value);
	}

	private static DependencyProperty CreateXYFocusRightNavigationStrategyProperty()
	{
		return DependencyProperty.Register("XYFocusRightNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(UIElement), new FrameworkPropertyMetadata((object)XYFocusNavigationStrategy.Auto, (BackingFieldUpdateCallback)OnXYFocusRightNavigationStrategyBackingFieldUpdate));
	}

	private static void OnXYFocusRightNavigationStrategyBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusRightNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)newValue;
		uIElement._XYFocusRightNavigationStrategyPropertyBackingFieldSet = true;
	}

	private XYFocusNavigationStrategy GetXYFocusUpNavigationStrategyValue()
	{
		if (!_XYFocusUpNavigationStrategyPropertyBackingFieldSet)
		{
			_XYFocusUpNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)GetValue(XYFocusUpNavigationStrategyProperty);
			_XYFocusUpNavigationStrategyPropertyBackingFieldSet = true;
		}
		return _XYFocusUpNavigationStrategyPropertyBackingField;
	}

	private void SetXYFocusUpNavigationStrategyValue(XYFocusNavigationStrategy value)
	{
		SetValue(XYFocusUpNavigationStrategyProperty, value);
	}

	private static DependencyProperty CreateXYFocusUpNavigationStrategyProperty()
	{
		return DependencyProperty.Register("XYFocusUpNavigationStrategy", typeof(XYFocusNavigationStrategy), typeof(UIElement), new FrameworkPropertyMetadata((object)XYFocusNavigationStrategy.Auto, (BackingFieldUpdateCallback)OnXYFocusUpNavigationStrategyBackingFieldUpdate));
	}

	private static void OnXYFocusUpNavigationStrategyBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusUpNavigationStrategyPropertyBackingField = (XYFocusNavigationStrategy)newValue;
		uIElement._XYFocusUpNavigationStrategyPropertyBackingFieldSet = true;
	}

	private KeyboardNavigationMode GetTabFocusNavigationValue()
	{
		if (!_TabFocusNavigationPropertyBackingFieldSet)
		{
			_TabFocusNavigationPropertyBackingField = (KeyboardNavigationMode)GetValue(TabFocusNavigationProperty);
			_TabFocusNavigationPropertyBackingFieldSet = true;
		}
		return _TabFocusNavigationPropertyBackingField;
	}

	private void SetTabFocusNavigationValue(KeyboardNavigationMode value)
	{
		SetValue(TabFocusNavigationProperty, value);
	}

	private static DependencyProperty CreateTabFocusNavigationProperty()
	{
		return DependencyProperty.Register("TabFocusNavigation", typeof(KeyboardNavigationMode), typeof(UIElement), new FrameworkPropertyMetadata((object)KeyboardNavigationMode.Local, (BackingFieldUpdateCallback)OnTabFocusNavigationBackingFieldUpdate));
	}

	private static void OnTabFocusNavigationBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._TabFocusNavigationPropertyBackingField = (KeyboardNavigationMode)newValue;
		uIElement._TabFocusNavigationPropertyBackingFieldSet = true;
	}

	private FocusState GetFocusStateValue()
	{
		if (!_FocusStatePropertyBackingFieldSet)
		{
			_FocusStatePropertyBackingField = (FocusState)GetValue(FocusStateProperty);
			_FocusStatePropertyBackingFieldSet = true;
		}
		return _FocusStatePropertyBackingField;
	}

	private void SetFocusStateValue(FocusState value)
	{
		SetValue(FocusStateProperty, value);
	}

	private static DependencyProperty CreateFocusStateProperty()
	{
		return DependencyProperty.Register("FocusState", typeof(FocusState), typeof(UIElement), new FrameworkPropertyMetadata((object)FocusState.Unfocused, (BackingFieldUpdateCallback)OnFocusStateBackingFieldUpdate));
	}

	private static void OnFocusStateBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._FocusStatePropertyBackingField = (FocusState)newValue;
		uIElement._FocusStatePropertyBackingFieldSet = true;
	}

	private int GetTabIndexValue()
	{
		if (!_TabIndexPropertyBackingFieldSet)
		{
			_TabIndexPropertyBackingField = (int)GetValue(TabIndexProperty);
			_TabIndexPropertyBackingFieldSet = true;
		}
		return _TabIndexPropertyBackingField;
	}

	private void SetTabIndexValue(int value)
	{
		SetValue(TabIndexProperty, value);
	}

	private static DependencyProperty CreateTabIndexProperty()
	{
		return DependencyProperty.Register("TabIndex", typeof(int), typeof(UIElement), new FrameworkPropertyMetadata((object)int.MaxValue, (BackingFieldUpdateCallback)OnTabIndexBackingFieldUpdate));
	}

	private static void OnTabIndexBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._TabIndexPropertyBackingField = (int)newValue;
		uIElement._TabIndexPropertyBackingFieldSet = true;
	}

	private DependencyObject GetXYFocusUpValue()
	{
		if (!_XYFocusUpPropertyBackingFieldSet)
		{
			_XYFocusUpPropertyBackingField = (DependencyObject)GetValue(XYFocusUpProperty);
			_XYFocusUpPropertyBackingFieldSet = true;
		}
		return _XYFocusUpPropertyBackingField;
	}

	private void SetXYFocusUpValue(DependencyObject value)
	{
		SetValue(XYFocusUpProperty, value);
	}

	private static DependencyProperty CreateXYFocusUpProperty()
	{
		return DependencyProperty.Register("XYFocusUp", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnXYFocusUpBackingFieldUpdate));
	}

	private static void OnXYFocusUpBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusUpPropertyBackingField = (DependencyObject)newValue;
		uIElement._XYFocusUpPropertyBackingFieldSet = true;
	}

	private DependencyObject GetXYFocusDownValue()
	{
		if (!_XYFocusDownPropertyBackingFieldSet)
		{
			_XYFocusDownPropertyBackingField = (DependencyObject)GetValue(XYFocusDownProperty);
			_XYFocusDownPropertyBackingFieldSet = true;
		}
		return _XYFocusDownPropertyBackingField;
	}

	private void SetXYFocusDownValue(DependencyObject value)
	{
		SetValue(XYFocusDownProperty, value);
	}

	private static DependencyProperty CreateXYFocusDownProperty()
	{
		return DependencyProperty.Register("XYFocusDown", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnXYFocusDownBackingFieldUpdate));
	}

	private static void OnXYFocusDownBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusDownPropertyBackingField = (DependencyObject)newValue;
		uIElement._XYFocusDownPropertyBackingFieldSet = true;
	}

	private DependencyObject GetXYFocusLeftValue()
	{
		if (!_XYFocusLeftPropertyBackingFieldSet)
		{
			_XYFocusLeftPropertyBackingField = (DependencyObject)GetValue(XYFocusLeftProperty);
			_XYFocusLeftPropertyBackingFieldSet = true;
		}
		return _XYFocusLeftPropertyBackingField;
	}

	private void SetXYFocusLeftValue(DependencyObject value)
	{
		SetValue(XYFocusLeftProperty, value);
	}

	private static DependencyProperty CreateXYFocusLeftProperty()
	{
		return DependencyProperty.Register("XYFocusLeft", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnXYFocusLeftBackingFieldUpdate));
	}

	private static void OnXYFocusLeftBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusLeftPropertyBackingField = (DependencyObject)newValue;
		uIElement._XYFocusLeftPropertyBackingFieldSet = true;
	}

	private DependencyObject GetXYFocusRightValue()
	{
		if (!_XYFocusRightPropertyBackingFieldSet)
		{
			_XYFocusRightPropertyBackingField = (DependencyObject)GetValue(XYFocusRightProperty);
			_XYFocusRightPropertyBackingFieldSet = true;
		}
		return _XYFocusRightPropertyBackingField;
	}

	private void SetXYFocusRightValue(DependencyObject value)
	{
		SetValue(XYFocusRightProperty, value);
	}

	private static DependencyProperty CreateXYFocusRightProperty()
	{
		return DependencyProperty.Register("XYFocusRight", typeof(DependencyObject), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnXYFocusRightBackingFieldUpdate));
	}

	private static void OnXYFocusRightBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._XYFocusRightPropertyBackingField = (DependencyObject)newValue;
		uIElement._XYFocusRightPropertyBackingFieldSet = true;
	}

	private bool GetUseSystemFocusVisualsValue()
	{
		if (!_UseSystemFocusVisualsPropertyBackingFieldSet)
		{
			_UseSystemFocusVisualsPropertyBackingField = (bool)GetValue(UseSystemFocusVisualsProperty);
			_UseSystemFocusVisualsPropertyBackingFieldSet = true;
		}
		return _UseSystemFocusVisualsPropertyBackingField;
	}

	private void SetUseSystemFocusVisualsValue(bool value)
	{
		SetValue(UseSystemFocusVisualsProperty, value);
	}

	private static DependencyProperty CreateUseSystemFocusVisualsProperty()
	{
		return DependencyProperty.Register("UseSystemFocusVisuals", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata((object)false, (BackingFieldUpdateCallback)OnUseSystemFocusVisualsBackingFieldUpdate));
	}

	private static void OnUseSystemFocusVisualsBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._UseSystemFocusVisualsPropertyBackingField = (bool)newValue;
		uIElement._UseSystemFocusVisualsPropertyBackingFieldSet = true;
	}

	private bool GetIsHitTestVisibleValue()
	{
		if (!_IsHitTestVisiblePropertyBackingFieldSet)
		{
			_IsHitTestVisiblePropertyBackingField = (bool)GetValue(IsHitTestVisibleProperty);
			_IsHitTestVisiblePropertyBackingFieldSet = true;
		}
		return _IsHitTestVisiblePropertyBackingField;
	}

	private void SetIsHitTestVisibleValue(bool value)
	{
		SetValue(IsHitTestVisibleProperty, value);
	}

	private static DependencyProperty CreateIsHitTestVisibleProperty()
	{
		return DependencyProperty.Register("IsHitTestVisible", typeof(bool), typeof(UIElement), new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((UIElement)instance).OnIsHitTestVisibleChanged((bool)args.OldValue, (bool)args.NewValue);
		}, (BackingFieldUpdateCallback)OnIsHitTestVisibleBackingFieldUpdate));
	}

	private static void OnIsHitTestVisibleBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._IsHitTestVisiblePropertyBackingField = (bool)newValue;
		uIElement._IsHitTestVisiblePropertyBackingFieldSet = true;
	}

	private double GetOpacityValue()
	{
		if (!_OpacityPropertyBackingFieldSet)
		{
			_OpacityPropertyBackingField = (double)GetValue(OpacityProperty);
			_OpacityPropertyBackingFieldSet = true;
		}
		return _OpacityPropertyBackingField;
	}

	private void SetOpacityValue(double value)
	{
		SetValue(OpacityProperty, value);
	}

	private static DependencyProperty CreateOpacityProperty()
	{
		return DependencyProperty.Register("Opacity", typeof(double), typeof(UIElement), new FrameworkPropertyMetadata((object)1.0, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((UIElement)instance).OnOpacityChanged(args);
		}, (BackingFieldUpdateCallback)OnOpacityBackingFieldUpdate));
	}

	private static void OnOpacityBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._OpacityPropertyBackingField = (double)newValue;
		uIElement._OpacityPropertyBackingFieldSet = true;
	}

	private Visibility GetVisibilityValue()
	{
		if (!_VisibilityPropertyBackingFieldSet)
		{
			_VisibilityPropertyBackingField = (Visibility)GetValue(VisibilityProperty);
			_VisibilityPropertyBackingFieldSet = true;
		}
		return _VisibilityPropertyBackingField;
	}

	private void SetVisibilityValue(Visibility value)
	{
		SetValue(VisibilityProperty, value);
	}

	private static DependencyProperty CreateVisibilityProperty()
	{
		return DependencyProperty.Register("Visibility", typeof(Visibility), typeof(UIElement), new FrameworkPropertyMetadata((object)Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((UIElement)instance).OnVisibilityChanged((Visibility)args.OldValue, (Visibility)args.NewValue);
		}, (BackingFieldUpdateCallback)OnVisibilityBackingFieldUpdate));
	}

	private static void OnVisibilityBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._VisibilityPropertyBackingField = (Visibility)newValue;
		uIElement._VisibilityPropertyBackingFieldSet = true;
	}

	private FlyoutBase GetContextFlyoutValue()
	{
		if (!_ContextFlyoutPropertyBackingFieldSet)
		{
			_ContextFlyoutPropertyBackingField = (FlyoutBase)GetValue(ContextFlyoutProperty);
			_ContextFlyoutPropertyBackingFieldSet = true;
		}
		return _ContextFlyoutPropertyBackingField;
	}

	private void SetContextFlyoutValue(FlyoutBase value)
	{
		SetValue(ContextFlyoutProperty, value);
	}

	private static DependencyProperty CreateContextFlyoutProperty()
	{
		return DependencyProperty.Register("ContextFlyout", typeof(FlyoutBase), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((UIElement)instance).OnContextFlyoutChanged((FlyoutBase)args.OldValue, (FlyoutBase)args.NewValue);
		}, (BackingFieldUpdateCallback)OnContextFlyoutBackingFieldUpdate));
	}

	private static void OnContextFlyoutBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._ContextFlyoutPropertyBackingField = (FlyoutBase)newValue;
		uIElement._ContextFlyoutPropertyBackingFieldSet = true;
	}

	private IList<KeyboardAccelerator> GetKeyboardAcceleratorsValue()
	{
		if (!_KeyboardAcceleratorsPropertyBackingFieldSet)
		{
			_KeyboardAcceleratorsPropertyBackingField = (IList<KeyboardAccelerator>)GetValue(KeyboardAcceleratorsProperty);
			_KeyboardAcceleratorsPropertyBackingFieldSet = true;
		}
		return _KeyboardAcceleratorsPropertyBackingField;
	}

	private void SetKeyboardAcceleratorsValue(IList<KeyboardAccelerator> value)
	{
		SetValue(KeyboardAcceleratorsProperty, value);
	}

	private static DependencyProperty CreateKeyboardAcceleratorsProperty()
	{
		return DependencyProperty.Register("KeyboardAccelerators", typeof(IList<KeyboardAccelerator>), typeof(UIElement), new FrameworkPropertyMetadata((object)null, (BackingFieldUpdateCallback)OnKeyboardAcceleratorsBackingFieldUpdate));
	}

	private static void OnKeyboardAcceleratorsBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._KeyboardAcceleratorsPropertyBackingField = (IList<KeyboardAccelerator>)newValue;
		uIElement._KeyboardAcceleratorsPropertyBackingFieldSet = true;
	}

	private HitTestability GetHitTestVisibilityValue()
	{
		if (!_HitTestVisibilityPropertyBackingFieldSet)
		{
			_HitTestVisibilityPropertyBackingField = (HitTestability)GetValue(HitTestVisibilityProperty);
			_HitTestVisibilityPropertyBackingFieldSet = true;
		}
		return _HitTestVisibilityPropertyBackingField;
	}

	private void SetHitTestVisibilityValue(HitTestability value)
	{
		SetValue(HitTestVisibilityProperty, value);
	}

	private static DependencyProperty CreateHitTestVisibilityProperty()
	{
		return DependencyProperty.Register("HitTestVisibility", typeof(HitTestability), typeof(UIElement), new FrameworkPropertyMetadata(HitTestability.Collapsed, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((UIElement)instance).OnHitTestVisibilityChanged((HitTestability)args.OldValue, (HitTestability)args.NewValue);
		}, (DependencyObject instance, object baseValue) => ((UIElement)instance).CoerceHitTestVisibility(baseValue), OnHitTestVisibilityBackingFieldUpdate));
	}

	private static void OnHitTestVisibilityBackingFieldUpdate(object instance, object newValue)
	{
		UIElement uIElement = instance as UIElement;
		uIElement._HitTestVisibilityPropertyBackingField = (HitTestability)newValue;
		uIElement._HitTestVisibilityPropertyBackingFieldSet = true;
	}
}
