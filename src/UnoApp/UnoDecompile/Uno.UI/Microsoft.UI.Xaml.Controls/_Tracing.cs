using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Microsoft.UI.Xaml.Controls;

internal static class _Tracing
{
	[Conditional("REPEATER_TRACE_ENABLED")]
	public static void REPEATER_TRACE_INFO(string text, params object[] parameters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator enumerator = parameters.GetEnumerator();
		if (text.Count((char c) => c == '%') < parameters.Length && enumerator.MoveNext() && enumerator.Current is int repeatCount)
		{
			stringBuilder.Append('\t', repeatCount);
		}
		for (int i = 0; i < text.Length; i++)
		{
			char c2 = text[i];
			if (c2 == '%' && enumerator.MoveNext())
			{
				if (text.Length > i + 4 && text.Substring(i, 4) == "%.0f" && enumerator.Current is IFormattable formattable)
				{
					i += 3;
					stringBuilder.Append(formattable.ToString("F1", CultureInfo.InvariantCulture));
				}
				else
				{
					stringBuilder.Append(enumerator.Current);
				}
			}
			else
			{
				stringBuilder.Append(c2);
			}
		}
		Console.Write(stringBuilder.ToString());
	}

	[Conditional("REPEATER_TRACE_ENABLED")]
	public static void REPEATER_TRACE_PERF(string text)
	{
		Console.WriteLine(text);
	}

	[Conditional("DEBUG")]
	public static void MUX_ASSERT(bool assertion, string message = null)
	{
	}
}
