using System;
using Windows.UI.Xaml;

namespace Uno.UI.Xaml;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
internal sealed class GeneratedDependencyPropertyAttribute : Attribute
{
	public FrameworkPropertyMetadataOptions Options { get; set; }

	public object? DefaultValue { get; set; }

	public bool CoerceCallback { get; set; }

	public bool ChangedCallback { get; set; }

	public bool LocalCache { get; set; } = true;


	public bool Attached { get; set; }

	public Type? AttachedBackingFieldOwner { get; set; }

	public string? ChangedCallbackName { get; set; }
}
