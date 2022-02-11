namespace Windows.UI.Xaml.Controls;

public static class GridExtensions
{
	public static Grid ColumnDefinitions(this Grid grid, params string[] definitions)
	{
		foreach (string text in definitions)
		{
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = text
			});
		}
		return grid;
	}

	public static Grid RowDefinitions(this Grid grid, params string[] definitions)
	{
		foreach (string text in definitions)
		{
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = text
			});
		}
		return grid;
	}

	public static T GridRow<T>(this T view, int row) where T : UIElement
	{
		Grid.SetRow(view, row);
		return view;
	}

	public static T GridRowSpan<T>(this T view, int rowSpan) where T : UIElement
	{
		Grid.SetRowSpan(view, rowSpan);
		return view;
	}

	public static T GridColumn<T>(this T view, int column) where T : UIElement
	{
		Grid.SetColumn(view, column);
		return view;
	}

	public static T GridColumnSpan<T>(this T view, int columnSpan) where T : UIElement
	{
		Grid.SetColumnSpan(view, columnSpan);
		return view;
	}

	public static T GridPosition<T>(this T view, int row, int column) where T : UIElement
	{
		Grid.SetColumn(view, column);
		Grid.SetRow(view, row);
		return view;
	}
}
