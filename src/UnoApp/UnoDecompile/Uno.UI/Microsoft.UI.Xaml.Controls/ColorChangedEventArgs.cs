using Windows.UI;

namespace Microsoft.UI.Xaml.Controls;

public class ColorChangedEventArgs : IColorChangedEventArgs
{
	private Color m_oldColor;

	private Color m_newColor;

	public Color OldColor
	{
		get
		{
			return m_oldColor;
		}
		internal set
		{
			m_oldColor = value;
		}
	}

	public Color NewColor
	{
		get
		{
			return m_newColor;
		}
		internal set
		{
			m_newColor = value;
		}
	}
}
