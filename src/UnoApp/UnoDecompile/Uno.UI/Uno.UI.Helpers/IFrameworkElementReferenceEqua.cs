using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Uno.UI.Helpers;

internal class IFrameworkElementReferenceEqualityComparer : IEqualityComparer<IFrameworkElement>
{
	public static readonly IFrameworkElementReferenceEqualityComparer Default = new IFrameworkElementReferenceEqualityComparer();

	private IFrameworkElementReferenceEqualityComparer()
	{
	}

	public bool Equals(IFrameworkElement left, IFrameworkElement right)
	{
		return left == right;
	}

	public int GetHashCode(IFrameworkElement obj)
	{
		return obj.GetHashCode();
	}
}
