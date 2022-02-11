using System;
using System.ComponentModel;
using Windows.UI.Xaml.Data;

namespace Uno.UI.Helpers.Xaml;

public static class ApplyExtensions
{
	public delegate Binding BindingApplyHandler(Binding binding);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Binding BindingApply(this Binding instance, BindingApplyHandler apply)
	{
		apply(instance);
		return instance;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static TType GenericApply<TType>(this TType instance, Action<TType> apply)
	{
		apply(instance);
		return instance;
	}
}
