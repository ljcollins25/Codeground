namespace Windows.UI.Xaml.Media.Animation;

internal interface IAnimation<T> where T : struct
{
	T? To { get; }

	T? From { get; }

	T? By { get; }

	bool EnableDependentAnimation { get; }

	IEasingFunction EasingFunction { get; }

	T Subtract(T minuend, T subtrahend);

	T Add(T first, T second);

	T Multiply(float multiplier, T t);

	T Convert(object value);
}
