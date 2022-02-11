using System;
using Uno.UI.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.__Resources;

internal class _ProgressRing_09242e98778da8e36c54a331b05303b2_ProgressRingRDSC0
{
	private ElementNameSubject _LottiePlayerSubject = new ElementNameSubject();

	private ElementNameSubject _LayoutRootSubject = new ElementNameSubject();

	private ElementNameSubject _ActiveSubject = new ElementNameSubject();

	private ElementNameSubject _InactiveSubject = new ElementNameSubject();

	private ElementNameSubject _DeterminateActiveSubject = new ElementNameSubject();

	private ElementNameSubject _CommonStatesSubject = new ElementNameSubject();

	private AnimatedVisualPlayer LottiePlayer
	{
		get
		{
			return (AnimatedVisualPlayer)_LottiePlayerSubject.ElementInstance;
		}
		set
		{
			_LottiePlayerSubject.ElementInstance = value;
		}
	}

	private Grid LayoutRoot
	{
		get
		{
			return (Grid)_LayoutRootSubject.ElementInstance;
		}
		set
		{
			_LayoutRootSubject.ElementInstance = value;
		}
	}

	private VisualState Active
	{
		get
		{
			return (VisualState)_ActiveSubject.ElementInstance;
		}
		set
		{
			_ActiveSubject.ElementInstance = value;
		}
	}

	private VisualState Inactive
	{
		get
		{
			return (VisualState)_InactiveSubject.ElementInstance;
		}
		set
		{
			_InactiveSubject.ElementInstance = value;
		}
	}

	private VisualState DeterminateActive
	{
		get
		{
			return (VisualState)_DeterminateActiveSubject.ElementInstance;
		}
		set
		{
			_DeterminateActiveSubject.ElementInstance = value;
		}
	}

	private VisualStateGroup CommonStates
	{
		get
		{
			return (VisualStateGroup)_CommonStatesSubject.ElementInstance;
		}
		set
		{
			_CommonStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_385)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "LayoutRoot",
			Background = SolidColorBrushHelper.Transparent,
			Children = { (UIElement)new AnimatedVisualPlayer
			{
				IsParsing = true,
				Name = "LottiePlayer",
				AutoPlay = false,
				Stretch = Stretch.Fill
			}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(AnimatedVisualPlayer c0)
			{
				nameScope.RegisterName("LottiePlayer", c0);
				LottiePlayer = c0;
				c0.CreationComplete();
			}) }
		}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(Grid c1)
		{
			nameScope.RegisterName("LayoutRoot", c1);
			LayoutRoot = c1;
			VisualStateManager.SetVisualStateGroups(c1, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "CommonStates",
				States = 
				{
					new VisualState
					{
						Name = "Active"
					}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(VisualState c2)
					{
						nameScope.RegisterName("Active", c2);
						Active = c2;
						MarkupHelper.SetVisualStateLazy(c2, delegate
						{
							c2.Name = "Active";
							c2.Storyboard = new Storyboard
							{
								Children = { (Timeline)new DoubleAnimation
								{
									To = 1.0,
									Duration = new Duration(TimeSpan.FromTicks(1500000L))
								}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(DoubleAnimation c3)
								{
									Storyboard.SetTargetName(c3, "LayoutRoot");
									Storyboard.SetTarget(c3, _LayoutRootSubject);
									Storyboard.SetTargetProperty(c3, "Opacity");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "Inactive"
					}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(VisualState c4)
					{
						nameScope.RegisterName("Inactive", c4);
						Inactive = c4;
						MarkupHelper.SetVisualStateLazy(c4, delegate
						{
							c4.Name = "Inactive";
							c4.Storyboard = new Storyboard
							{
								Children = { (Timeline)new DoubleAnimation
								{
									To = 0.0,
									Duration = new Duration(TimeSpan.FromTicks(0L))
								}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(DoubleAnimation c5)
								{
									Storyboard.SetTargetName(c5, "LayoutRoot");
									Storyboard.SetTarget(c5, _LayoutRootSubject);
									Storyboard.SetTargetProperty(c5, "Opacity");
								}) }
							};
						});
					}),
					new VisualState
					{
						Name = "DeterminateActive"
					}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(VisualState c6)
					{
						nameScope.RegisterName("DeterminateActive", c6);
						DeterminateActive = c6;
						MarkupHelper.SetVisualStateLazy(c6, delegate
						{
							c6.Name = "DeterminateActive";
							c6.Storyboard = new Storyboard
							{
								Children = { (Timeline)new DoubleAnimation
								{
									To = 1.0,
									Duration = new Duration(TimeSpan.FromTicks(1500000L))
								}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(DoubleAnimation c7)
								{
									Storyboard.SetTargetName(c7, "LayoutRoot");
									Storyboard.SetTarget(c7, _LayoutRootSubject);
									Storyboard.SetTargetProperty(c7, "Opacity");
								}) }
							};
						});
					})
				}
			}.ProgressRing_09242e98778da8e36c54a331b05303b2_XamlApply(delegate(VisualStateGroup c8)
			{
				nameScope.RegisterName("CommonStates", c8);
				CommonStates = c8;
			}) });
			c1.CreationComplete();
		});
		DependencyObject dependencyObject = uIElement;
		if (dependencyObject != null)
		{
			NameScope.SetNameScope(dependencyObject, nameScope);
			nameScope.Owner = dependencyObject;
			FrameworkElementHelper.AddObjectReference(dependencyObject, this);
		}
		return uIElement;
	}
}
