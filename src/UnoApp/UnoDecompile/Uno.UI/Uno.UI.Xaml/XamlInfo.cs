using System;
using Uno.UI.DataBinding;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml;

public class XamlInfo
{
	private readonly ManagedWeakReference _owner;

	public DependencyObject Owner => _owner.Target as DependencyObject;

	public static DependencyProperty XamlInfoProperty { get; } = DependencyProperty.RegisterAttached("XamlInfo", typeof(XamlInfo), typeof(XamlInfo), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));


	public XamlInfo(DependencyObject xamlOwner)
	{
		if (xamlOwner is IWeakReferenceProvider weakReferenceProvider)
		{
			_owner = weakReferenceProvider.WeakReference;
			return;
		}
		throw new NotSupportedException("The provided reference must be an IWeakReferenceProvider");
	}

	public static XamlInfo GetXamlInfo(DependencyObject obj)
	{
		return (XamlInfo)obj.GetValue(XamlInfoProperty);
	}

	public static void SetXamlInfo(DependencyObject obj, XamlInfo owner)
	{
		obj.SetValue(XamlInfoProperty, owner);
	}
}
