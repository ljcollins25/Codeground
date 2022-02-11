using Uno.UI.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uno.UI.__Resources;

internal class _TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_TwoPaneView_v1RDSC0
{
	private ElementNameSubject _PART_ColumnLeftSubject = new ElementNameSubject();

	private ElementNameSubject _PART_ColumnMiddleSubject = new ElementNameSubject();

	private ElementNameSubject _PART_ColumnRightSubject = new ElementNameSubject();

	private ElementNameSubject _PART_RowTopSubject = new ElementNameSubject();

	private ElementNameSubject _PART_RowMiddleSubject = new ElementNameSubject();

	private ElementNameSubject _PART_RowBottomSubject = new ElementNameSubject();

	private ElementNameSubject _PART_Pane1ScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _PART_Pane2ScrollViewerSubject = new ElementNameSubject();

	private ElementNameSubject _RootGridSubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_LeftRightSubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_RightLeftSubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_TopBottomSubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_BottomTopSubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_OneOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ViewMode_TwoOnlySubject = new ElementNameSubject();

	private ElementNameSubject _ModeStatesSubject = new ElementNameSubject();

	private ColumnDefinition PART_ColumnLeft
	{
		get
		{
			return (ColumnDefinition)_PART_ColumnLeftSubject.ElementInstance;
		}
		set
		{
			_PART_ColumnLeftSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition PART_ColumnMiddle
	{
		get
		{
			return (ColumnDefinition)_PART_ColumnMiddleSubject.ElementInstance;
		}
		set
		{
			_PART_ColumnMiddleSubject.ElementInstance = value;
		}
	}

	private ColumnDefinition PART_ColumnRight
	{
		get
		{
			return (ColumnDefinition)_PART_ColumnRightSubject.ElementInstance;
		}
		set
		{
			_PART_ColumnRightSubject.ElementInstance = value;
		}
	}

	private RowDefinition PART_RowTop
	{
		get
		{
			return (RowDefinition)_PART_RowTopSubject.ElementInstance;
		}
		set
		{
			_PART_RowTopSubject.ElementInstance = value;
		}
	}

	private RowDefinition PART_RowMiddle
	{
		get
		{
			return (RowDefinition)_PART_RowMiddleSubject.ElementInstance;
		}
		set
		{
			_PART_RowMiddleSubject.ElementInstance = value;
		}
	}

	private RowDefinition PART_RowBottom
	{
		get
		{
			return (RowDefinition)_PART_RowBottomSubject.ElementInstance;
		}
		set
		{
			_PART_RowBottomSubject.ElementInstance = value;
		}
	}

	private ScrollViewer PART_Pane1ScrollViewer
	{
		get
		{
			return (ScrollViewer)_PART_Pane1ScrollViewerSubject.ElementInstance;
		}
		set
		{
			_PART_Pane1ScrollViewerSubject.ElementInstance = value;
		}
	}

	private ScrollViewer PART_Pane2ScrollViewer
	{
		get
		{
			return (ScrollViewer)_PART_Pane2ScrollViewerSubject.ElementInstance;
		}
		set
		{
			_PART_Pane2ScrollViewerSubject.ElementInstance = value;
		}
	}

	private Grid RootGrid
	{
		get
		{
			return (Grid)_RootGridSubject.ElementInstance;
		}
		set
		{
			_RootGridSubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_LeftRight
	{
		get
		{
			return (VisualState)_ViewMode_LeftRightSubject.ElementInstance;
		}
		set
		{
			_ViewMode_LeftRightSubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_RightLeft
	{
		get
		{
			return (VisualState)_ViewMode_RightLeftSubject.ElementInstance;
		}
		set
		{
			_ViewMode_RightLeftSubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_TopBottom
	{
		get
		{
			return (VisualState)_ViewMode_TopBottomSubject.ElementInstance;
		}
		set
		{
			_ViewMode_TopBottomSubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_BottomTop
	{
		get
		{
			return (VisualState)_ViewMode_BottomTopSubject.ElementInstance;
		}
		set
		{
			_ViewMode_BottomTopSubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_OneOnly
	{
		get
		{
			return (VisualState)_ViewMode_OneOnlySubject.ElementInstance;
		}
		set
		{
			_ViewMode_OneOnlySubject.ElementInstance = value;
		}
	}

	private VisualState ViewMode_TwoOnly
	{
		get
		{
			return (VisualState)_ViewMode_TwoOnlySubject.ElementInstance;
		}
		set
		{
			_ViewMode_TwoOnlySubject.ElementInstance = value;
		}
	}

	private VisualStateGroup ModeStates
	{
		get
		{
			return (VisualStateGroup)_ModeStatesSubject.ElementInstance;
		}
		set
		{
			_ModeStatesSubject.ElementInstance = value;
		}
	}

	public UIElement Build(object __ResourceOwner_2586)
	{
		NameScope nameScope = new NameScope();
		UIElement uIElement = null;
		uIElement = new Grid
		{
			IsParsing = true,
			Name = "RootGrid",
			HorizontalAlignment = HorizontalAlignment.Stretch,
			VerticalAlignment = VerticalAlignment.Stretch,
			ColumnDefinitions = 
			{
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Auto)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(ColumnDefinition c0)
				{
					nameScope.RegisterName("PART_ColumnLeft", c0);
					PART_ColumnLeft = c0;
				}),
				new ColumnDefinition
				{
					Width = new GridLength(0.0, GridUnitType.Pixel)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(ColumnDefinition c1)
				{
					nameScope.RegisterName("PART_ColumnMiddle", c1);
					PART_ColumnMiddle = c1;
				}),
				new ColumnDefinition
				{
					Width = new GridLength(1.0, GridUnitType.Star)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(ColumnDefinition c2)
				{
					nameScope.RegisterName("PART_ColumnRight", c2);
					PART_ColumnRight = c2;
				})
			},
			RowDefinitions = 
			{
				new RowDefinition
				{
					Height = new GridLength(1.0, GridUnitType.Star)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(RowDefinition c3)
				{
					nameScope.RegisterName("PART_RowTop", c3);
					PART_RowTop = c3;
				}),
				new RowDefinition
				{
					Height = new GridLength(0.0, GridUnitType.Pixel)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(RowDefinition c4)
				{
					nameScope.RegisterName("PART_RowMiddle", c4);
					PART_RowMiddle = c4;
				}),
				new RowDefinition
				{
					Height = new GridLength(0.0, GridUnitType.Pixel)
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(RowDefinition c5)
				{
					nameScope.RegisterName("PART_RowBottom", c5);
					PART_RowBottom = c5;
				})
			},
			Children = 
			{
				(UIElement)new ScrollViewer
				{
					IsParsing = true,
					Name = "PART_Pane1ScrollViewer",
					Content = new Border
					{
						IsParsing = true
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(Border c6)
					{
						c6.SetBinding(Border.ChildProperty, new Binding
						{
							Path = "Pane1",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c6.CreationComplete();
					})
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(ScrollViewer c7)
				{
					nameScope.RegisterName("PART_Pane1ScrollViewer", c7);
					PART_Pane1ScrollViewer = c7;
					Grid.SetColumn(c7, 0);
					ScrollViewer.SetVerticalScrollBarVisibility(c7, ScrollBarVisibility.Auto);
					c7.CreationComplete();
				}),
				(UIElement)new ScrollViewer
				{
					IsParsing = true,
					Name = "PART_Pane2ScrollViewer",
					Content = new Border
					{
						IsParsing = true
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(Border c8)
					{
						c8.SetBinding(Border.ChildProperty, new Binding
						{
							Path = "Pane2",
							RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
						});
						c8.CreationComplete();
					})
				}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(ScrollViewer c9)
				{
					nameScope.RegisterName("PART_Pane2ScrollViewer", c9);
					PART_Pane2ScrollViewer = c9;
					Grid.SetColumn(c9, 2);
					ScrollViewer.SetVerticalScrollBarVisibility(c9, ScrollBarVisibility.Auto);
					c9.CreationComplete();
				})
			}
		}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(Grid c10)
		{
			nameScope.RegisterName("RootGrid", c10);
			RootGrid = c10;
			c10.SetBinding(FrameworkElement.BackgroundProperty, new Binding
			{
				Path = "Background",
				RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
			});
			VisualStateManager.SetVisualStateGroups(c10, new VisualStateGroup[1] { new VisualStateGroup
			{
				Name = "ModeStates",
				States = 
				{
					new VisualState
					{
						Name = "ViewMode_LeftRight"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c11)
					{
						nameScope.RegisterName("ViewMode_LeftRight", c11);
						ViewMode_LeftRight = c11;
					}),
					new VisualState
					{
						Name = "ViewMode_RightLeft"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c12)
					{
						nameScope.RegisterName("ViewMode_RightLeft", c12);
						ViewMode_RightLeft = c12;
						MarkupHelper.SetVisualStateLazy(c12, delegate
						{
							c12.Name = "ViewMode_RightLeft";
							c12.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "2"));
							c12.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
						});
					}),
					new VisualState
					{
						Name = "ViewMode_TopBottom"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c13)
					{
						nameScope.RegisterName("ViewMode_TopBottom", c13);
						ViewMode_TopBottom = c13;
						MarkupHelper.SetVisualStateLazy(c13, delegate
						{
							c13.Name = "ViewMode_TopBottom";
							c13.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
							c13.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "0"));
							c13.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
							c13.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "2"));
						});
					}),
					new VisualState
					{
						Name = "ViewMode_BottomTop"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c14)
					{
						nameScope.RegisterName("ViewMode_BottomTop", c14);
						ViewMode_BottomTop = c14;
						MarkupHelper.SetVisualStateLazy(c14, delegate
						{
							c14.Name = "ViewMode_BottomTop";
							c14.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
							c14.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "2"));
							c14.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
							c14.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Row)"), "0"));
						});
					}),
					new VisualState
					{
						Name = "ViewMode_OneOnly"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c15)
					{
						nameScope.RegisterName("ViewMode_OneOnly", c15);
						ViewMode_OneOnly = c15;
						MarkupHelper.SetVisualStateLazy(c15, delegate
						{
							c15.Name = "ViewMode_OneOnly";
							c15.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"Visibility"), "Collapsed"));
						});
					}),
					new VisualState
					{
						Name = "ViewMode_TwoOnly"
					}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualState c16)
					{
						nameScope.RegisterName("ViewMode_TwoOnly", c16);
						ViewMode_TwoOnly = c16;
						MarkupHelper.SetVisualStateLazy(c16, delegate
						{
							c16.Name = "ViewMode_TwoOnly";
							c16.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane1ScrollViewerSubject, (PropertyPath)"Visibility"), "Collapsed"));
							c16.Setters.Add(new Setter(new TargetPropertyPath(_PART_Pane2ScrollViewerSubject, (PropertyPath)"(Windows.UI.Xaml.Controls:Grid.Column)"), "0"));
						});
					})
				}
			}.TwoPaneView_v1_7e9080b57b351020fc0c831f6c5ae1ca_XamlApply(delegate(VisualStateGroup c17)
			{
				nameScope.RegisterName("ModeStates", c17);
				ModeStates = c17;
			}) });
			c10.CreationComplete();
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
