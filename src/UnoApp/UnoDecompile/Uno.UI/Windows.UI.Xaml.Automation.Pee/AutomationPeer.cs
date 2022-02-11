using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Automation.Peers;

[Windows.UI.Xaml.Data.Bindable]
public class AutomationPeer : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private AutomationPeer _parent;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public AutomationPeer EventsSource
	{
		get
		{
			throw new NotImplementedException("The member AutomationPeer AutomationPeer.EventsSource is not implemented in Uno.");
		}
		set
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "AutomationPeer AutomationPeer.EventsSource");
		}
	}

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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(AutomationPeer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AutomationPeer)s).OnDataContextChanged(e);
	}));


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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(AutomationPeer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AutomationPeer)s).OnTemplatedParentChanged(e);
	}));


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

	public event TypedEventHandler<FrameworkElement, DataContextChangedEventArgs> DataContextChanged;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RaiseAutomationEvent(AutomationEvents eventId)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "void AutomationPeer.RaiseAutomationEvent(AutomationEvents eventId)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RaisePropertyChangedEvent(AutomationProperty automationProperty, object oldValue, object newValue)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "void AutomationPeer.RaisePropertyChangedEvent(AutomationProperty automationProperty, object oldValue, object newValue)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RaiseTextEditTextChangedEvent(AutomationTextEditChangeType automationTextEditChangeType, IReadOnlyList<string> changedData)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "void AutomationPeer.RaiseTextEditTextChangedEvent(AutomationTextEditChangeType automationTextEditChangeType, IReadOnlyList<string> changedData)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RaiseStructureChangedEvent(AutomationStructureChangeType structureChangeType, AutomationPeer child)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "void AutomationPeer.RaiseStructureChangedEvent(AutomationStructureChangeType structureChangeType, AutomationPeer child)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int GetCulture()
	{
		throw new NotImplementedException("The member int AutomationPeer.GetCulture() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void RaiseNotificationEvent(AutomationNotificationKind notificationKind, AutomationNotificationProcessing notificationProcessing, string displayString, string activityId)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "void AutomationPeer.RaiseNotificationEvent(AutomationNotificationKind notificationKind, AutomationNotificationProcessing notificationProcessing, string displayString, string activityId)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected AutomationPeer PeerFromProvider(IRawElementProviderSimple provider)
	{
		throw new NotImplementedException("The member AutomationPeer AutomationPeer.PeerFromProvider(IRawElementProviderSimple provider) is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual IEnumerable<AutomationPeer> GetFlowsToCore()
	{
		throw new NotImplementedException("The member IEnumerable<AutomationPeer> AutomationPeer.GetFlowsToCore() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual IEnumerable<AutomationPeer> GetFlowsFromCore()
	{
		throw new NotImplementedException("The member IEnumerable<AutomationPeer> AutomationPeer.GetFlowsFromCore() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected virtual int GetCultureCore()
	{
		throw new NotImplementedException("The member int AutomationPeer.GetCultureCore() is not implemented in Uno.");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static RawElementProviderRuntimeId GenerateRawElementProviderRuntimeId()
	{
		throw new NotImplementedException("The member RawElementProviderRuntimeId AutomationPeer.GenerateRawElementProviderRuntimeId() is not implemented in Uno.");
	}

	[NotImplemented]
	public static bool ListenerExists(AutomationEvents eventId)
	{
		return false;
	}

	public object GetPattern(PatternInterface patternInterface)
	{
		return GetPatternCore(patternInterface);
	}

	public void SetParent(AutomationPeer peer)
	{
		_parent = peer;
	}

	public AutomationPeer GetParent()
	{
		return _parent;
	}

	public string GetAcceleratorKey()
	{
		return GetAcceleratorKeyCore();
	}

	public string GetAccessKey()
	{
		return GetAcceleratorKeyCore();
	}

	public string GetAutomationId()
	{
		return GetAutomationIdCore();
	}

	public Rect GetBoundingRectangle()
	{
		return GetBoundingRectangleCore();
	}

	public IList<AutomationPeer> GetChildren()
	{
		return GetChildrenCore();
	}

	public Point GetClickablePoint()
	{
		return GetClickablePointCore();
	}

	public string GetHelpText()
	{
		return GetHelpTextCore();
	}

	public string GetItemStatus()
	{
		return GetItemStatusCore();
	}

	public string GetItemType()
	{
		return GetItemTypeCore();
	}

	public AutomationOrientation GetOrientation()
	{
		return GetOrientationCore();
	}

	public bool HasKeyboardFocus()
	{
		return HasKeyboardFocusCore();
	}

	public bool IsKeyboardFocusable()
	{
		return IsKeyboardFocusableCore();
	}

	public bool IsOffscreen()
	{
		return IsOffscreenCore();
	}

	public bool IsRequiredForForm()
	{
		return IsRequiredForFormCore();
	}

	public AutomationPeer GetPeerFromPoint(Point point)
	{
		return GetPeerFromPointCore(point);
	}

	public AutomationLiveSetting GetLiveSetting()
	{
		return GetLiveSettingCore();
	}

	public object Navigate(AutomationNavigationDirection direction)
	{
		return NavigateCore(direction);
	}

	public object GetElementFromPoint(Point pointInWindowCoordinates)
	{
		return GetElementFromPointCore(pointInWindowCoordinates);
	}

	public object GetFocusedElement()
	{
		return GetFocusedElementCore();
	}

	public void ShowContextMenu()
	{
		ShowContextMenuCore();
	}

	public IReadOnlyList<AutomationPeer> GetControlledPeers()
	{
		return GetControlledPeersCore();
	}

	public IList<AutomationPeerAnnotation> GetAnnotations()
	{
		return GetAnnotationsCore();
	}

	public int GetPositionInSet()
	{
		return GetPositionInSetCore();
	}

	public int GetSizeOfSet()
	{
		return GetSizeOfSetCore();
	}

	public int GetLevel()
	{
		return GetLevelCore();
	}

	public AutomationLandmarkType GetLandmarkType()
	{
		return GetLandmarkTypeCore();
	}

	public string GetLocalizedLandmarkType()
	{
		return GetLocalizedLandmarkTypeCore();
	}

	public bool IsPeripheral()
	{
		return IsPeripheralCore();
	}

	public bool IsDataValidForForm()
	{
		return IsDataValidForFormCore();
	}

	public string GetFullDescription()
	{
		return GetFullDescriptionCore();
	}

	public AutomationHeadingLevel GetHeadingLevel()
	{
		return GetHeadingLevelCore();
	}

	public bool IsDialog()
	{
		return IsDialogCore();
	}

	public bool IsContentElement()
	{
		return IsContentElementCore();
	}

	public bool IsControlElement()
	{
		return IsControlElementCore();
	}

	public bool IsEnabled()
	{
		return IsEnabledCore();
	}

	public bool IsPassword()
	{
		return IsPasswordCore();
	}

	public void SetFocus()
	{
		SetFocusCore();
	}

	public string GetClassName()
	{
		return GetClassNameCore();
	}

	public AutomationControlType GetAutomationControlType()
	{
		return GetAutomationControlTypeCore();
	}

	public string GetLocalizedControlType()
	{
		return GetLocalizedControlTypeCore();
	}

	public string GetName()
	{
		return GetNameCore();
	}

	public AutomationPeer GetLabeledBy()
	{
		return GetLabeledByCore();
	}

	protected virtual object GetPatternCore(PatternInterface patternInterface)
	{
		return null;
	}

	protected virtual string GetAcceleratorKeyCore()
	{
		return string.Empty;
	}

	protected virtual string GetAccessKeyCore()
	{
		return string.Empty;
	}

	protected virtual string GetAutomationIdCore()
	{
		return string.Empty;
	}

	protected virtual Rect GetBoundingRectangleCore()
	{
		return default(Rect);
	}

	protected virtual IList<AutomationPeer> GetChildrenCore()
	{
		return null;
	}

	protected virtual Point GetClickablePointCore()
	{
		return default(Point);
	}

	protected virtual string GetHelpTextCore()
	{
		return string.Empty;
	}

	protected virtual string GetItemStatusCore()
	{
		return string.Empty;
	}

	protected virtual string GetItemTypeCore()
	{
		return string.Empty;
	}

	protected virtual AutomationOrientation GetOrientationCore()
	{
		return AutomationOrientation.None;
	}

	protected virtual bool HasKeyboardFocusCore()
	{
		return false;
	}

	protected virtual bool IsKeyboardFocusableCore()
	{
		return false;
	}

	protected virtual bool IsOffscreenCore()
	{
		return false;
	}

	protected virtual bool IsRequiredForFormCore()
	{
		return false;
	}

	protected virtual AutomationPeer GetPeerFromPointCore(Point point)
	{
		return this;
	}

	protected virtual AutomationLiveSetting GetLiveSettingCore()
	{
		return AutomationLiveSetting.Off;
	}

	protected virtual void ShowContextMenuCore()
	{
	}

	protected virtual object NavigateCore(AutomationNavigationDirection direction)
	{
		return null;
	}

	protected virtual IReadOnlyList<AutomationPeer> GetControlledPeersCore()
	{
		return null;
	}

	protected virtual object GetElementFromPointCore(Point pointInWindowCoordinates)
	{
		return this;
	}

	protected virtual object GetFocusedElementCore()
	{
		return this;
	}

	protected virtual IList<AutomationPeerAnnotation> GetAnnotationsCore()
	{
		return null;
	}

	protected virtual int GetPositionInSetCore()
	{
		return -1;
	}

	protected virtual int GetSizeOfSetCore()
	{
		return -1;
	}

	protected virtual int GetLevelCore()
	{
		return -1;
	}

	protected virtual AutomationLandmarkType GetLandmarkTypeCore()
	{
		return AutomationLandmarkType.None;
	}

	protected virtual string GetLocalizedLandmarkTypeCore()
	{
		return string.Empty;
	}

	protected virtual bool IsPeripheralCore()
	{
		return false;
	}

	protected virtual bool IsDataValidForFormCore()
	{
		return true;
	}

	protected virtual string GetFullDescriptionCore()
	{
		return string.Empty;
	}

	protected virtual AutomationHeadingLevel GetHeadingLevelCore()
	{
		return AutomationHeadingLevel.None;
	}

	protected virtual bool IsDialogCore()
	{
		return false;
	}

	protected virtual bool IsContentElementCore()
	{
		return false;
	}

	protected virtual bool IsControlElementCore()
	{
		return false;
	}

	protected virtual bool IsEnabledCore()
	{
		return true;
	}

	protected virtual string GetClassNameCore()
	{
		return "";
	}

	protected virtual string GetNameCore()
	{
		return "";
	}

	protected virtual string GetLocalizedControlTypeCore()
	{
		return LocalizeControlType(GetAutomationControlType());
	}

	protected virtual AutomationControlType GetAutomationControlTypeCore()
	{
		return AutomationControlType.Custom;
	}

	protected virtual bool IsPasswordCore()
	{
		return false;
	}

	protected virtual void SetFocusCore()
	{
	}

	protected virtual AutomationPeer GetLabeledByCore()
	{
		return null;
	}

	protected virtual IEnumerable<AutomationPeer> GetDescribedByCore()
	{
		return null;
	}

	private static string LocalizeControlType(AutomationControlType controlType)
	{
		return Enum.GetName(typeof(AutomationControlType), controlType)!.ToLowerInvariant();
	}

	internal bool InvokeAutomationPeer()
	{
		if (this is IInvokeProvider invokeProvider)
		{
			invokeProvider.Invoke();
			return true;
		}
		if (this is IToggleProvider toggleProvider)
		{
			toggleProvider.Toggle();
			return true;
		}
		return false;
	}

	internal static void RaiseEventIfListener(DependencyObject target, AutomationEvents eventId)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "RaiseEventIfListener");
	}

	[NotImplemented]
	public static bool ListenerfExists(AutomationEvents eventId)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AutomationPeer", "bool AutomationPeer.ListenerExists");
		return false;
	}

	[NotImplemented]
	public void InvalidatePeer()
	{
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected internal IRawElementProviderSimple ProviderFromPeer(AutomationPeer peer)
	{
		throw new NotImplementedException("The member IRawElementProviderSimple AutomationPeer.ProviderFromPeer(AutomationPeer peer) is not implemented in Uno.");
	}

	[NotImplemented]
	internal static bool ListenerExistsHelper(AutomationEvents eventId)
	{
		return false;
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

	public override string ToString()
	{
		return GetType().FullName;
	}

	protected internal virtual void OnDataContextChanged(DependencyPropertyChangedEventArgs e)
	{
		this.DataContextChanged?.Invoke(null, new DataContextChangedEventArgs(DataContext));
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
}
