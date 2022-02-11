using System;
using Uno.Foundation;
using Uno.Foundation.Interop;

namespace Windows.UI.Xaml.Media.Animation;

internal abstract class RenderingLoopAnimator<T> : CPUBoundAnimator<T>, IJSObject where T : struct
{
	private class Metadata : IJSObjectMetadata
	{
		public static Metadata Instance { get; } = new Metadata();


		private Metadata()
		{
		}

		public long CreateNativeInstance(IntPtr managedHandle)
		{
			long num = RenderingLoopAnimatorMetadataIdProvider.Next();
			WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopFloatAnimator.createInstance(\"{managedHandle}\", \"{num}\")");
			return num;
		}

		public string GetNativeInstance(IntPtr managedHandle, long jsHandle)
		{
			return $"Windows.UI.Xaml.Media.Animation.RenderingLoopFloatAnimator.getInstance(\"{jsHandle}\")";
		}

		public void DestroyNativeInstance(IntPtr managedHandle, long jsHandle)
		{
			WebAssemblyRuntime.InvokeJS($"Windows.UI.Xaml.Media.Animation.RenderingLoopFloatAnimator.destroyInstance(\"{jsHandle}\")");
		}

		public object InvokeManaged(object instance, string method, string parameters)
		{
			if (method == "OnFrame")
			{
				((RenderingLoopAnimator<T>)instance).OnFrame();
				return null;
			}
			throw new ArgumentOutOfRangeException("method");
		}
	}

	public JSObjectHandle Handle { get; }

	protected RenderingLoopAnimator(T from, T to)
		: base(from, to)
	{
		Handle = JSObjectHandle.Create(this, Metadata.Instance);
	}

	protected override void EnableFrameReporting()
	{
		WebAssemblyRuntime.InvokeJSWithInterop($"{this}.EnableFrameReporting();");
	}

	protected override void DisableFrameReporting()
	{
		WebAssemblyRuntime.InvokeJSWithInterop($"{this}.DisableFrameReporting();");
	}

	protected override void SetStartFrameDelay(long delayMs)
	{
		WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetStartFrameDelay({delayMs});");
	}

	protected override void SetAnimationFramesInterval()
	{
		WebAssemblyRuntime.InvokeJSWithInterop($"{this}.SetAnimationFramesInterval();");
	}

	private void OnFrame()
	{
		OnFrame(null, null);
	}
}
