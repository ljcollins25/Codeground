namespace Windows.UI.Xaml.Media.Animation;

internal sealed class RenderingLoopColorAnimator : RenderingLoopAnimator<ColorOffset>
{
	public RenderingLoopColorAnimator(ColorOffset from, ColorOffset to)
		: base(from, to)
	{
	}

	protected override ColorOffset GetUpdatedValue(long frame, ColorOffset from, ColorOffset to)
	{
		if (_easing != null)
		{
			return _easing.Ease(frame, from, to, base.Duration);
		}
		ColorOffset colorOffset = to - from;
		float num = (float)frame / (float)base.Duration;
		ColorOffset colorOffset2 = num * colorOffset;
		return from + colorOffset2;
	}
}
