using System;

namespace Windows.UI.Xaml.Data;

[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public sealed class NonBindableAttribute : Attribute
{
}
