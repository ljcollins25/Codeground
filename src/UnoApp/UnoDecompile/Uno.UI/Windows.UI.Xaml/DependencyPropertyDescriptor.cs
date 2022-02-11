using System;
using System.Reflection;
using Uno.Foundation.Logging;
using Uno.Foundation.Runtime.WebAssembly.Interop;
using Uno.UI.DataBinding;

namespace Windows.UI.Xaml;

internal class DependencyPropertyDescriptor
{
	private static readonly bool CanUseTypeGetType = PlatformHelper.IsNetCore && Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_MONO_RUNTIME_MODE") == "Interpreter";

	public string Name { get; }

	public Type OwnerType { get; }

	public DependencyPropertyDescriptor(Type ownerType, string name)
	{
		OwnerType = ownerType;
		Name = name;
	}

	internal static DependencyPropertyDescriptor Parse(string propertyPath)
	{
		if (propertyPath.Contains(":"))
		{
			string[] array = propertyPath.Trim('(', ')').Split(new char[1] { ':' });
			if (array.Length == 2)
			{
				string text = array[0];
				string[] array2 = array[1].Split(new char[1] { '.' });
				if (array2.Length == 2)
				{
					string text2 = array2[0];
					string name = array2[1];
					string text3 = text + "." + text2;
					Type type = BindingPropertyHelper.BindableMetadataProvider?.GetBindableTypeByFullName(text3)?.Type;
					if (type == null)
					{
						type = (CanUseTypeGetType ? Type.GetType(text3) : null);
						if (type == null)
						{
							Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
							foreach (Assembly assembly in assemblies)
							{
								type = assembly.GetType(text3);
								if (type != null)
								{
									break;
								}
							}
						}
					}
					if (type != null)
					{
						return new DependencyPropertyDescriptor(type, name);
					}
				}
				else if (typeof(DependencyPropertyDescriptor).Log().IsEnabled(LogLevel.Debug))
				{
					typeof(DependencyPropertyDescriptor).Log().DebugFormat("The property path [" + propertyPath + "] is not formatted properly (must only access one property)");
				}
			}
			else if (typeof(DependencyPropertyDescriptor).Log().IsEnabled(LogLevel.Debug))
			{
				typeof(DependencyPropertyDescriptor).Log().DebugFormat("The property path [" + propertyPath + "] is not formatted properly (must have exactly one ':')");
			}
		}
		return null;
	}
}
