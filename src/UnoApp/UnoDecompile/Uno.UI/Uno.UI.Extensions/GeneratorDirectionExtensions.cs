using System;
using Windows.UI.Xaml.Controls.Primitives;

namespace Uno.UI.Extensions;

internal static class GeneratorDirectionExtensions
{
	public static GeneratorDirection Inverse(this GeneratorDirection generatorDirection)
	{
		return generatorDirection switch
		{
			GeneratorDirection.Forward => GeneratorDirection.Backward, 
			GeneratorDirection.Backward => GeneratorDirection.Forward, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
