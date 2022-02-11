namespace Windows.UI.Xaml.Media.Animation;

internal sealed class RenderingLoopFloatAnimator : RenderingLoopAnimator<float>
{
	public RenderingLoopFloatAnimator(float from, float to)
		: base(from, to)
	{
	}

	protected override float GetUpdatedValue(long frame, float from, float to)
	{
		return (float)_easing.Ease(frame, from, to, base.Duration);
	}
}
