using System;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Markup;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
[WebHostHidden]
public sealed class MarkupExtensionReturnTypeAttribute : Attribute
{
	public Type ReturnType;
}
