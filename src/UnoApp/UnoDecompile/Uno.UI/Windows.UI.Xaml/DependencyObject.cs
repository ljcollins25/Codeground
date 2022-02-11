using Windows.UI.Core;

namespace Windows.UI.Xaml;

public interface DependencyObject
{
	CoreDispatcher Dispatcher { get; }

	object GetValue(DependencyProperty dp);

	void SetValue(DependencyProperty dp, object value);

	void ClearValue(DependencyProperty dp);

	object ReadLocalValue(DependencyProperty dp);

	object GetAnimationBaseValue(DependencyProperty dp);

	long RegisterPropertyChangedCallback(DependencyProperty dp, DependencyPropertyChangedCallback callback);

	void UnregisterPropertyChangedCallback(DependencyProperty dp, long token);
}
