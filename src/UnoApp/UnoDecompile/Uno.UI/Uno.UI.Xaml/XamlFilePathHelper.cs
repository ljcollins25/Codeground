using System;
using System.IO;
using Uno.Extensions;

namespace Uno.UI.Xaml;

internal static class XamlFilePathHelper
{
	private const string WinUIThemeResourceURLFormatString = "Microsoft.UI.Xaml/Themes/themeresources_v{0}.xaml";

	public const string AppXIdentifier = "ms-appx:///";

	public const string MSResourceIdentifier = "ms-resource:///";

	public const string WinUICompactURL = "Microsoft.UI.Xaml/DensityStyles/Compact.xaml";

	public static string LocalResourcePrefix => "ms-resource:///Files/";

	internal static string ResolveAbsoluteSource(string origin, string relativeTargetPath)
	{
		if (IsAbsolutePath(relativeTargetPath))
		{
			return relativeTargetPath.TrimStart("ms-appx:///");
		}
		if (relativeTargetPath.StartsWith("/", StringComparison.Ordinal))
		{
			return relativeTargetPath.Substring(1);
		}
		string directoryName = Path.GetDirectoryName(origin);
		if (directoryName.IsNullOrWhiteSpace())
		{
			return relativeTargetPath;
		}
		string absolutePath = GetAbsolutePath(directoryName, relativeTargetPath);
		return absolutePath.Replace('\\', '/');
	}

	internal static bool IsAbsolutePath(string relativeTargetPath)
	{
		if (!relativeTargetPath.StartsWith("ms-appx:///", StringComparison.InvariantCulture))
		{
			return relativeTargetPath.StartsWith("ms-resource:///", StringComparison.InvariantCulture);
		}
		return true;
	}

	internal static string GetWinUIThemeResourceUrl(int version)
	{
		return $"Microsoft.UI.Xaml/Themes/themeresources_v{version}.xaml";
	}

	private static string GetAbsolutePath(string originDirectory, string relativeTargetPath)
	{
		int startIndex = 0;
		if (Path.GetPathRoot(originDirectory)!.Length == 0)
		{
			string pathRoot = Path.GetPathRoot(Directory.GetCurrentDirectory());
			startIndex = pathRoot.Length;
			originDirectory = pathRoot + originDirectory;
		}
		string fullPath = Path.GetFullPath(Path.Combine(originDirectory, relativeTargetPath));
		return fullPath.Substring(startIndex);
	}
}
