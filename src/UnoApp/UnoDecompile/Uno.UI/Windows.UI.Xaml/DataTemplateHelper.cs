using Uno.UI;
using Windows.UI.Xaml.Controls;

namespace Windows.UI.Xaml;

public static class DataTemplateHelper
{
	public static DataTemplate ResolveTemplate(DataTemplate dataTemplate, DataTemplateSelector dataTemplateSelector, object data, DependencyObject container)
	{
		if (dataTemplate != null)
		{
			return dataTemplate;
		}
		if (dataTemplateSelector != null)
		{
			DataTemplate dataTemplate2 = dataTemplateSelector.SelectTemplate(data);
			if (dataTemplate2 == null && container != null && !FeatureConfiguration.DataTemplateSelector.UseLegacyTemplateSelectorOverload)
			{
				dataTemplate2 = dataTemplateSelector.SelectTemplate(data, container);
			}
			return dataTemplate2;
		}
		return null;
	}
}
