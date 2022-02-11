namespace Windows.UI.Xaml.Data;

public class RelativeSource
{
	public static readonly RelativeSource TemplatedParent = new RelativeSource(RelativeSourceMode.TemplatedParent);

	internal static readonly RelativeSource Self = new RelativeSource(RelativeSourceMode.Self);

	public RelativeSourceMode Mode { get; set; }

	public RelativeSource()
	{
	}

	public RelativeSource(RelativeSourceMode mode)
	{
		Mode = mode;
	}

	public override int GetHashCode()
	{
		return Mode.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is RelativeSource relativeSource)
		{
			return relativeSource.Mode == Mode;
		}
		return false;
	}
}
