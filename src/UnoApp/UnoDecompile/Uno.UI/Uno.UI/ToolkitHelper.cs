using System;
using Windows.UI.Xaml;

namespace Uno.UI;

internal static class ToolkitHelper
{
	public static DependencyProperty GetProperty(string ownerTypeName, string propertyName)
	{
		Type type = Type.GetType(ownerTypeName + ",Uno.UI.Toolkit");
		return DependencyProperty.GetProperty(type, propertyName);
	}
}
