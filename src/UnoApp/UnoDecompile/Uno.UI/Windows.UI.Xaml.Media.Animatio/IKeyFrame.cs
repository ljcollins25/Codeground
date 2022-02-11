namespace Windows.UI.Xaml.Media.Animation;

internal interface IKeyFrame
{
	KeyTime KeyTime { get; }
}
internal interface IKeyFrame<out TValue> : IKeyFrame
{
	TValue Value { get; }
}
