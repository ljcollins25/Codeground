using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Uno;
using Uno.Diagnostics.Eventing;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml;

[Windows.UI.Xaml.Data.Bindable]
public class VisualStateManager : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	public static class TraceProvider
	{
		public static readonly Guid Id = Guid.Parse("{2F38E5F4-90A2-4872-BD49-3696F897BAD1}");

		public const int StoryBoard_GoToState = 1;
	}

	private static readonly IEventProvider _trace = Tracing.Get(TraceProvider.Id);

	private static readonly Logger _log = typeof(VisualStateManager).Log();

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public static DependencyProperty VisualStateGroupsProperty { get; } = DependencyProperty.RegisterAttached("VisualStateGroups", typeof(IList<VisualStateGroup>), typeof(VisualStateManager), new FrameworkPropertyMetadata(new VisualStateGroup[0], FrameworkPropertyMetadataOptions.ValueInheritsDataContext, OnVisualStateGroupsChanged));


	internal static DependencyProperty VisualStateManagerProperty { get; } = DependencyProperty.RegisterAttached("VisualStateManager", typeof(VisualStateManager), typeof(VisualStateManager), new FrameworkPropertyMetadata(null));


	public static DependencyProperty CustomVisualStateManagerProperty { get; } = DependencyProperty.RegisterAttached("CustomVisualStateManager", typeof(VisualStateManager), typeof(VisualStateManager), new FrameworkPropertyMetadata((object)null));


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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(VisualStateManager), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualStateManager)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(VisualStateManager), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((VisualStateManager)s).OnTemplatedParentChanged(e);
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
	protected void RaiseCurrentStateChanging(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.VisualStateManager", "void VisualStateManager.RaiseCurrentStateChanging(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	protected void RaiseCurrentStateChanged(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.VisualStateManager", "void VisualStateManager.RaiseCurrentStateChanged(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)");
	}

	public VisualStateManager()
	{
		IsAutoPropertyInheritanceEnabled = false;
	}

	internal static IList<VisualStateGroup> GetVisualStateGroups(IFrameworkElement obj)
	{
		return (IList<VisualStateGroup>)obj.GetValue(VisualStateGroupsProperty);
	}

	public static IList<VisualStateGroup> GetVisualStateGroups(FrameworkElement obj)
	{
		return (IList<VisualStateGroup>)obj.GetValue(VisualStateGroupsProperty);
	}

	public static void SetVisualStateGroups(FrameworkElement obj, IList<VisualStateGroup> value)
	{
		obj.SetValue(VisualStateGroupsProperty, value);
	}

	private static void OnVisualStateGroupsChanged(object sender, DependencyPropertyChangedEventArgs args)
	{
		if (!(sender is IFrameworkElement parent))
		{
			return;
		}
		if (args.OldValue is IList<VisualStateGroup> list)
		{
			foreach (VisualStateGroup item in list)
			{
				item.SetParent(null);
			}
		}
		if (!(args.NewValue is IList<VisualStateGroup> list2))
		{
			return;
		}
		foreach (VisualStateGroup item2 in list2)
		{
			item2.SetParent(parent);
		}
	}

	internal static VisualStateManager GetVisualStateManager(IFrameworkElement obj)
	{
		VisualStateManager visualStateManager = (VisualStateManager)obj.GetValue(VisualStateManagerProperty);
		if (visualStateManager == null)
		{
			obj.SetValue(VisualStateManagerProperty, visualStateManager = new VisualStateManager());
		}
		return visualStateManager;
	}

	internal static void SetVisualStateManager(IFrameworkElement obj, VisualStateManager value)
	{
		obj.SetValue(VisualStateManagerProperty, value);
	}

	public static VisualStateManager GetCustomVisualStateManager(FrameworkElement obj)
	{
		return (VisualStateManager)obj.GetValue(CustomVisualStateManagerProperty);
	}

	public static void SetCustomVisualStateManager(FrameworkElement obj, VisualStateManager value)
	{
		obj.SetValue(CustomVisualStateManagerProperty, value);
	}

	public static bool GoToState(Control control, string stateName, bool useTransitions)
	{
		IFrameworkElement templateRoot = control.GetTemplateRoot();
		if (templateRoot == null)
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.DebugFormat("Failed to set state [{0}], unable to find template root on [{1}]", stateName, control);
			}
			return false;
		}
		if (templateRoot is FrameworkElement frameworkElement && frameworkElement.GoToElementState(stateName, useTransitions))
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.DebugFormat($"GoToElementStateCore({stateName}) override on [{control}]");
			}
			return true;
		}
		IList<VisualStateGroup> visualStateGroups = GetVisualStateGroups(templateRoot);
		if (visualStateGroups == null)
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.DebugFormat("Failed to set state [{0}], no visual state group on [{1}]", stateName, control);
			}
			return false;
		}
		var (visualStateGroup, state) = GetValidGroupAndState(stateName, visualStateGroups);
		if (visualStateGroup == null)
		{
			if (_log.IsEnabled(LogLevel.Debug))
			{
				_log.DebugFormat("Failed to set state [{0}], there are no matching groups on [{1}]", stateName, control);
			}
			return false;
		}
		TryAssignDOMVisualStates(visualStateGroups, templateRoot);
		if (!(templateRoot is FrameworkElement frameworkElement2))
		{
			return GetVisualStateManager(control).GoToStateCorePrivateBaseImplementation(control, visualStateGroup, state, useTransitions);
		}
		VisualStateManager visualStateManager = GetCustomVisualStateManager(frameworkElement2) ?? GetVisualStateManager(control);
		return visualStateManager.GoToStateCore(control, frameworkElement2, stateName, visualStateGroup, state, useTransitions);
	}

	protected virtual bool GoToStateCore(Control control, FrameworkElement templateRoot, string stateName, VisualStateGroup group, VisualState state, bool useTransitions)
	{
		return GoToStateCorePrivateBaseImplementation(control, group, state, useTransitions);
	}

	private bool GoToStateCorePrivateBaseImplementation(Control control, VisualStateGroup group, VisualState state, bool useTransitions)
	{
		if (_trace.IsEnabled)
		{
			IEventProvider trace = _trace;
			object[] payload = new string[4]
			{
				control.GetType()?.ToString(),
				control?.GetDependencyObjectId().ToString(),
				state.Name,
				useTransitions ? "UseTransitions" : "NoTransitions"
			};
			trace.WriteEvent(1, EventOpcode.Send, payload);
		}
		VisualState originalState = group.CurrentState;
		if (object.Equals(originalState, state))
		{
			return true;
		}
		RaiseCurrentStateChanging(group, originalState, state);
		ManagedWeakReference wr = WeakReferencePool.RentWeakReference(this, control);
		group.GoToState(control, state, useTransitions, delegate
		{
			if (wr?.Target is Control)
			{
				RaiseCurrentStateChanged(group, originalState, state);
			}
		});
		return true;
	}

	protected virtual void RaiseCurrentStateChanging(VisualStateGroup stateGroup, VisualState oldState, VisualState newState)
	{
		stateGroup?.RaiseCurrentStateChanging(oldState, newState);
	}

	protected virtual void RaiseCurrentStateChanged(VisualStateGroup stateGroup, VisualState oldState, VisualState newState)
	{
		stateGroup?.RaiseCurrentStateChanged(oldState, newState);
	}

	internal static VisualState GetCurrentState(Control control, string groupName)
	{
		IFrameworkElement templateRoot = control.GetTemplateRoot();
		if (templateRoot == null)
		{
			return null;
		}
		return (GetVisualStateGroups(templateRoot)?.Where((VisualStateGroup g) => g.Name == groupName).FirstOrDefault())?.CurrentState;
	}

	private static (VisualStateGroup, VisualState) GetValidGroupAndState(string stateName, IList<VisualStateGroup> groups)
	{
		foreach (VisualStateGroup group in groups)
		{
			foreach (VisualState state in group.States)
			{
				string name = state.Name;
				if (name != null && name.Equals(stateName))
				{
					return (group, state);
				}
			}
		}
		return (null, null);
	}

	private static void TryAssignDOMVisualStates(IList<VisualStateGroup> groups, IFrameworkElement templateRoot)
	{
		if (!FeatureConfiguration.UIElement.AssignDOMXamlProperties)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		foreach (VisualStateGroup group in groups)
		{
			stringBuilder.Append($"{group}: {group.CurrentState}, ");
		}
		stringBuilder.Append(" ]");
		(templateRoot as UIElement)?.UpdateDOMXamlProperty("visualstates", stringBuilder.ToString());
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
