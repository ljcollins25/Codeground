using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI;

internal static class StoryboardExtensions
{
	internal static async Task Run(this Storyboard storyboard)
	{
		TaskCompletionSource<bool> cts = new TaskCompletionSource<bool>();
		storyboard.Completed += OnCompleted;
		storyboard.Begin();
		await cts.Task;
		void OnCompleted(object sender, object e)
		{
			cts.SetResult(result: true);
			storyboard.Completed -= OnCompleted;
		}
	}
}
