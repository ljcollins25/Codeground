namespace Windows.UI.Xaml;

public class FontFamilyHelper
{
	public static string RemoveUri(string familyName)
	{
		int num = familyName.LastIndexOf("/");
		if (num != -1)
		{
			familyName = familyName.Substring(num + 1);
		}
		return familyName;
	}

	public static string RemoveHashFamilyName(string familyName)
	{
		int num = familyName.IndexOf("#");
		if (num != -1)
		{
			familyName = familyName.Substring(0, num);
		}
		return familyName;
	}
}
