using System;

namespace Windows.UI.Xaml.Controls.Primitives;

internal class ContainerManager
{
	public int TotalGroupCount;

	private readonly CalendarPanel _owner;

	public int TotalItemsCount => Host?.Count ?? 0;

	public CalendarViewGeneratorHost? Host { get; set; }

	public int StartOfContainerVisualSection()
	{
		return Math.Max(0, _owner.FirstVisibleIndex);
	}

	public ContainerManager(CalendarPanel owner)
	{
		_owner = owner;
	}
}
