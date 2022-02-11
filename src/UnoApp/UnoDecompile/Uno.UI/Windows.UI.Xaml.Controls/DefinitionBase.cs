namespace Windows.UI.Xaml.Controls;

internal interface DefinitionBase
{
	internal double GetUserSizeValue();

	internal GridUnitType GetUserSizeType();

	internal double GetUserMaxSize();

	internal double GetUserMinSize();

	internal double GetEffectiveMinSize();

	internal void SetEffectiveMinSize(double value);

	internal double GetMeasureArrangeSize();

	internal void SetMeasureArrangeSize(double value);

	internal double GetSizeCache();

	internal void SetSizeCache(double value);

	internal double GetFinalOffset();

	internal void SetFinalOffset(double value);

	internal GridUnitType GetEffectiveUnitType();

	internal void SetEffectiveUnitType(GridUnitType type);

	internal double GetPreferredSize();

	internal void UpdateEffectiveMinSize(double newValue);
}
