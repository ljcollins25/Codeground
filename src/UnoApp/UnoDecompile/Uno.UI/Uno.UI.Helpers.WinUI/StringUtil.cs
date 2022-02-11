using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Uno.UI.Helpers.WinUI;

internal static class StringUtil
{
	private static Regex _cppFormat = new Regex("\\%(\\d+)!.*?!", RegexOptions.Singleline);

	internal static string FormatString(string format, params object[] parms)
	{
		string format2 = _cppFormat.Replace(format, "{$1}");
		List<object> list = parms.ToList();
		list.Insert(0, null);
		return string.Format(CultureInfo.CurrentUICulture, format2, list.ToArray());
	}
}
