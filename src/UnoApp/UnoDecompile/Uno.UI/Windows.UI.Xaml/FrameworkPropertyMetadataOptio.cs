using System;

namespace Windows.UI.Xaml;

[Flags]
public enum FrameworkPropertyMetadataOptions
{
	None = 0,
	Inherits = 1,
	ValueInheritsDataContext = 2,
	AutoConvert = 4,
	ValueDoesNotInheritDataContext = 8,
	WeakStorage = 0x10,
	LogicalChild = 0x20,
	AffectsArrange = 0x40,
	AffectsMeasure = 0x80,
	AffectsRender = 0x100,
	Default = 2
}
public static class FrameworkPropertyMetadataOptionsExtensions
{
	public static bool HasInherits(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.Inherits) != 0;
	}

	public static bool HasValueInheritsDataContext(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.ValueInheritsDataContext) != 0;
	}

	public static bool HasAutoConvert(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.AutoConvert) != 0;
	}

	public static bool HasValueDoesNotInheritDataContext(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext) != 0;
	}

	public static bool HasAffectsRender(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.AffectsRender) != 0;
	}

	public static bool HasAffectsArrange(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.AffectsArrange) != 0;
	}

	public static bool HasAffectsMeasure(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.AffectsMeasure) != 0;
	}

	public static bool HasLogicalChild(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.LogicalChild) != 0;
	}

	public static bool HasWeakStorage(this FrameworkPropertyMetadataOptions options)
	{
		return (options & FrameworkPropertyMetadataOptions.WeakStorage) != 0;
	}

	internal static FrameworkPropertyMetadataOptions WithDefault(this FrameworkPropertyMetadataOptions options)
	{
		if ((options & (FrameworkPropertyMetadataOptions.ValueInheritsDataContext | FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext)) != 0)
		{
			return options;
		}
		return options | FrameworkPropertyMetadataOptions.ValueInheritsDataContext;
	}
}
