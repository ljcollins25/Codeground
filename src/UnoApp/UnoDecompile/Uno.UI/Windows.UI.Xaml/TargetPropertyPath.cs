namespace Windows.UI.Xaml;

public sealed class TargetPropertyPath
{
	public object? Target { get; set; }

	public PropertyPath? Path { get; set; }

	internal string? TargetName { get; }

	public TargetPropertyPath(DependencyProperty targetProperty)
	{
	}

	public TargetPropertyPath()
	{
	}

	public TargetPropertyPath(object target, PropertyPath path)
	{
		Target = target;
		Path = path;
	}

	internal TargetPropertyPath(string targetName, PropertyPath path)
	{
		TargetName = targetName;
		Path = path;
	}
}
