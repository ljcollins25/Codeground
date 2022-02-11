using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Uno.Diagnostics.Eventing;
using Uno.Disposables;
using Uno.UI.DataBinding;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls;

public class BackdropMaterial
{
	[Windows.UI.Xaml.Data.Bindable]
	private class BackdropMaterialState : DependencyObject, IDisposable, IDependencyObjectStoreProvider, IWeakReferenceProvider
	{
		private readonly DispatcherHelper _dispatcherHelper;

		private readonly WeakReference<Control> _target;

		private readonly IDisposable _themeChangedRevoker;

		private readonly IDisposable _colorValuesChangedRevoker;

		private readonly UISettings _uiSettings = new UISettings();

		private readonly IDisposable _highContrastChangedRevoker;

		private bool _isHighContrast;

		private bool _isDisposed;

		private DependencyObjectStore __storeBackingField;

		private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

		private BinderReferenceHolder _refHolder;

		private ManagedWeakReference _selfWeakReference;

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

		public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(BackdropMaterialState), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((BackdropMaterialState)s).OnDataContextChanged(e);
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

		public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(BackdropMaterialState), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((BackdropMaterialState)s).OnTemplatedParentChanged(e);
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

		public BackdropMaterialState(Control target)
		{
			_dispatcherHelper = new DispatcherHelper(this);
			_target = new WeakReference<Control>(target);
			_connectedBrushCount.Value++;
			CreateOrDestroyMicaController();
			if (SharedHelpers.IsRS3OrHigher())
			{
				FrameworkElement targetThemeChanged = target;
				if (targetThemeChanged != null)
				{
					targetThemeChanged.ActualThemeChanged += OnActualThemeChanged;
					_themeChangedRevoker = Disposable.Create(delegate
					{
						targetThemeChanged.ActualThemeChanged -= OnActualThemeChanged;
					});
				}
			}
			_uiSettings.ColorValuesChanged += OnColorValuesChanged;
			_colorValuesChangedRevoker = Disposable.Create(delegate
			{
				_uiSettings.ColorValuesChanged -= OnColorValuesChanged;
			});
			AccessibilitySettings accessibilitySettings = new AccessibilitySettings();
			_isHighContrast = accessibilitySettings.HighContrast;
			accessibilitySettings.HighContrastChanged += OnHighContrastChanged;
			_highContrastChangedRevoker = Disposable.Create(delegate
			{
				accessibilitySettings.HighContrastChanged -= OnHighContrastChanged;
			});
			UpdateFallbackBrush();
			void OnActualThemeChanged(FrameworkElement sender, object args)
			{
				UpdateFallbackBrush();
			}
			void OnColorValuesChanged(UISettings uiSettings, object args)
			{
				_dispatcherHelper.RunAsync(delegate
				{
					UpdateFallbackBrush();
				});
			}
			void OnHighContrastChanged(AccessibilitySettings sender, object args)
			{
				_dispatcherHelper.RunAsync(delegate
				{
					_isHighContrast = accessibilitySettings.HighContrast;
					UpdateFallbackBrush();
				});
			}
		}

		public BackdropMaterialState()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_isDisposed = true;
				_connectedBrushCount.Value--;
				CreateOrDestroyMicaController();
				_highContrastChangedRevoker.Dispose();
				_themeChangedRevoker.Dispose();
				_colorValuesChangedRevoker.Dispose();
			}
		}

		private void UpdateFallbackBrush()
		{
			ElementTheme theme;
			if (_target.TryGetTarget(out var target))
			{
				if (_micaController.Value == null)
				{
					theme = GetTheme();
					Color color = GetColor();
					target.Background = new SolidColorBrush(color);
				}
				else
				{
					target.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
				}
			}
			Color GetColor()
			{
				if (_isHighContrast)
				{
					return _uiSettings.GetColorValue(UIColorType.Background);
				}
				if (theme == ElementTheme.Dark)
				{
					return MicaController.DarkThemeColor;
				}
				return MicaController.LightThemeColor;
			}
			ElementTheme GetTheme()
			{
				if (SharedHelpers.IsRS3OrHigher())
				{
					FrameworkElement frameworkElement = target;
					if (frameworkElement != null)
					{
						return frameworkElement.ActualTheme;
					}
				}
				if (_uiSettings.GetColorValue(UIColorType.Background).B == 0)
				{
					return ElementTheme.Dark;
				}
				return ElementTheme.Light;
			}
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

	private static readonly ThreadLocal<int> _connectedBrushCount = new ThreadLocal<int>();

	private static readonly ThreadLocal<MicaController> _micaController = new ThreadLocal<MicaController>();

	internal static DependencyProperty StateProperty { get; } = DependencyProperty.RegisterAttached("State", typeof(BackdropMaterialState), typeof(BackdropMaterial), new FrameworkPropertyMetadata(null));


	public static DependencyProperty ApplyToRootOrPageBackgroundProperty { get; } = DependencyProperty.RegisterAttached("ApplyToRootOrPageBackground", typeof(bool), typeof(BackdropMaterial), new FrameworkPropertyMetadata(false, OnApplyToRootOrPageBackgroundChanged));


	private static void OnApplyToRootOrPageBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (!(sender is Control control))
		{
			return;
		}
		if (GetApplyToRootOrPageBackground(control))
		{
			control.SetValue(StateProperty, new BackdropMaterialState(control));
			return;
		}
		if (control.GetValue(StateProperty) is BackdropMaterialState backdropMaterialState)
		{
			backdropMaterialState.Dispose();
		}
		control.ClearValue(StateProperty);
	}

	private static void CreateOrDestroyMicaController()
	{
		if (_connectedBrushCount.Value > 0 && _micaController.Value == null)
		{
			Window current = Window.Current;
			_micaController.Value = new MicaController();
			if (!_micaController.Value.SetTarget(current))
			{
				_micaController.Value = null;
			}
		}
		else if (_connectedBrushCount.Value == 0 && _micaController.Value != null)
		{
			_micaController.Value = null;
		}
	}

	public static bool GetApplyToRootOrPageBackground(Control element)
	{
		return (bool)element.GetValue(ApplyToRootOrPageBackgroundProperty);
	}

	public static void SetApplyToRootOrPageBackground(Control element, bool value)
	{
		element.SetValue(ApplyToRootOrPageBackgroundProperty, value);
	}
}
