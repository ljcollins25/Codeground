using Windows.Foundation.Collections;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls;

[ContentProperty(Name = "Items")]
public class NativePivotPresenter : Control
{
	public ItemCollection Items { get; private set; }

	public NativePivotPresenter()
	{
		Initialize();
	}

	private void Initialize()
	{
		Items = new ItemCollection();
		Items.VectorChanged += Items_VectorChanged;
	}

	private void Items_VectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
	{
		_ = @event.CollectionChange;
		_ = 1;
	}
}
