using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;

namespace Windows.UI.Xaml.Media.Animation;

[Windows.UI.Xaml.Data.Bindable]
public class KeySpline : DependencyObject, IDependencyObjectStoreProvider, IWeakReferenceProvider
{
	private const int Steps = 64;

	private Point[] _positions;

	private bool _isDirty;

	private Point _controlPoint1;

	private Point _controlPoint2;

	private DependencyObjectStore __storeBackingField;

	private static readonly IEventProvider _binderTrace = Tracing.Get(DependencyObjectStore.TraceProvider.Id);

	private BinderReferenceHolder _refHolder;

	private ManagedWeakReference _selfWeakReference;

	public Point ControlPoint1
	{
		get
		{
			return _controlPoint1;
		}
		set
		{
			_controlPoint1 = ValidateControlPointValue(value);
			_isDirty = true;
		}
	}

	public Point ControlPoint2
	{
		get
		{
			return _controlPoint2;
		}
		set
		{
			_controlPoint2 = ValidateControlPointValue(value);
			_isDirty = true;
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

	public static DependencyProperty DataContextProperty { get; } = DependencyProperty.Register("DataContext", typeof(object), typeof(KeySpline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((KeySpline)s).OnDataContextChanged(e);
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

	public static DependencyProperty TemplatedParentProperty { get; } = DependencyProperty.Register("TemplatedParent", typeof(DependencyObject), typeof(KeySpline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext | FrameworkPropertyMetadataOptions.WeakStorage, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((KeySpline)s).OnTemplatedParentChanged(e);
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

	public KeySpline()
	{
		ControlPoint1 = new Point(0.0, 0.0);
		ControlPoint2 = new Point(1.0, 1.0);
	}

	public KeySpline(double x1, double y1, double x2, double y2)
	{
		ControlPoint1 = new Point(x1, y1);
		ControlPoint2 = new Point(x2, y2);
	}

	public KeySpline(Point controlPoint1, Point controlPoint2)
	{
		ControlPoint1 = controlPoint1;
		ControlPoint2 = controlPoint2;
	}

	public override string ToString()
	{
		return "CP1: {0}, CP2: {1}".InvariantCultureFormat(ControlPoint1, ControlPoint2);
	}

	private static Point ValidateControlPointValue(Point controlPointValue)
	{
		if (controlPointValue.X > 1.0 || controlPointValue.X < 0.0 || controlPointValue.Y > 1.0 || controlPointValue.Y < 0.0)
		{
			throw new ArgumentOutOfRangeException("A control point's coordinates must be between 0 and 1, inclusive");
		}
		return controlPointValue;
	}

	public static KeySpline FromString(string input)
	{
		List<string> list = (from t in input.Split(',', ' ')
			where t.HasValue()
			select t).ToList();
		if (list.Count != 4)
		{
			throw new ArgumentOutOfRangeException("A KeySpline must have 4 tokens: x1, y1, x2, y2. Yours had {0} (input: \"{1}\").".InvariantCultureFormat(list.Count, input));
		}
		return new KeySpline(double.Parse(list[0], CultureInfo.InvariantCulture), double.Parse(list[1], CultureInfo.InvariantCulture), double.Parse(list[2], CultureInfo.InvariantCulture), double.Parse(list[3], CultureInfo.InvariantCulture));
	}

	public static implicit operator KeySpline(string input)
	{
		return FromString(input);
	}

	public double GetSplineProgress(double linearProgress)
	{
		Build();
		for (int num = _positions.Length - 2; num >= 0; num--)
		{
			Point point = _positions[num];
			if (linearProgress >= point.X)
			{
				Point point2 = _positions[num + 1];
				double num2 = point2.X - point.X;
				double num3 = point2.Y - point.Y;
				double num4 = (linearProgress - point.X) / num2;
				return point.Y + num3 * num4;
			}
		}
		return -1.0;
	}

	private Point GetProgress(float t)
	{
		double x = ControlPoint1.X;
		double y = ControlPoint1.Y;
		double x2 = ControlPoint2.X;
		double y2 = ControlPoint2.Y;
		double num = (double)(3f * t) * Math.Pow(1f - t, 2.0);
		double num2 = 3.0 * Math.Pow(t, 2.0) * (double)(1f - t);
		double num3 = Math.Pow(t, 3.0);
		double x3 = num * x + num2 * x2 + num3;
		double y3 = num * y + num2 * y2 + num3;
		return new Point(x3, y3);
	}

	private void Build()
	{
		if (_isDirty)
		{
			_isDirty = false;
			_positions = new Point[65];
			for (int i = 0; i < 65; i++)
			{
				_positions[i] = GetProgress((float)i / 64f);
			}
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
