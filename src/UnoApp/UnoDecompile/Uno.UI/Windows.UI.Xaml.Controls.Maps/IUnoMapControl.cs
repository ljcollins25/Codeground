namespace Windows.UI.Xaml.Controls.Maps;

public interface IUnoMapControl
{
	void RaiseCenterChanged(object sender, object args);

	void RaiseZoomLevelChanged(object sender, object args);
}
