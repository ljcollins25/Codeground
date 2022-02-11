using System;
using System.Collections.Concurrent;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml.Controls;

public class RadioMenuFlyoutItem : ToggleMenuFlyoutItem
{
	[ThreadStatic]
	private static ConcurrentDictionary<string, WeakReference<RadioMenuFlyoutItem>> s_selectionMap;

	private bool m_isChecked;

	private string m_groupName;

	private bool m_isSafeUncheck;

	public static readonly DependencyProperty AreCheckStatesEnabledProperty = DependencyProperty.RegisterAttached("AreCheckStatesEnabled", typeof(bool), typeof(RadioMenuFlyoutItem), new FrameworkPropertyMetadata(false, OnAreCheckStatesEnabledPropertyChanged));

	public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(RadioMenuFlyoutItem), new FrameworkPropertyMetadata(string.Empty, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RadioMenuFlyoutItem)?.OnPropertyChanged(e);
	}));

	public new static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(RadioMenuFlyoutItem), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as RadioMenuFlyoutItem)?.OnPropertyChanged(e);
	}));

	public string GroupName
	{
		get
		{
			return (string)GetValue(GroupNameProperty);
		}
		set
		{
			SetValue(GroupNameProperty, value);
		}
	}

	public new bool IsChecked
	{
		get
		{
			return (bool)GetValue(IsCheckedProperty);
		}
		set
		{
			SetValue(IsCheckedProperty, value);
		}
	}

	public RadioMenuFlyoutItem()
	{
		RegisterPropertyChangedCallback(ToggleMenuFlyoutItem.IsCheckedProperty, OnInternalIsCheckedChanged);
		if (s_selectionMap == null)
		{
			s_selectionMap = new ConcurrentDictionary<string, WeakReference<RadioMenuFlyoutItem>>();
		}
		SetDefaultStyleKey(this);
	}

	~RadioMenuFlyoutItem()
	{
		if (m_isChecked && m_groupName != null)
		{
			s_selectionMap?.TryRemove(m_groupName, out var _);
		}
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == IsCheckedProperty)
		{
			if (base.IsChecked != IsChecked)
			{
				m_isSafeUncheck = true;
				base.IsChecked = IsChecked;
				m_isSafeUncheck = false;
				UpdateCheckedItemInGroup();
			}
			m_isChecked = IsChecked;
		}
		else if (property == GroupNameProperty)
		{
			m_groupName = GroupName;
		}
	}

	private void OnInternalIsCheckedChanged(DependencyObject sender, DependencyProperty args)
	{
		if (!base.IsChecked)
		{
			if (m_isSafeUncheck)
			{
				IsChecked = false;
			}
			else
			{
				base.IsChecked = true;
			}
		}
		else if (!IsChecked)
		{
			IsChecked = true;
			UpdateCheckedItemInGroup();
		}
	}

	private void UpdateCheckedItemInGroup()
	{
		if (IsChecked)
		{
			string groupName = GroupName;
			if (s_selectionMap.TryGetValue(groupName, out var value) && value.TryGetTarget(out var target))
			{
				target.IsChecked = false;
			}
			s_selectionMap[groupName] = new WeakReference<RadioMenuFlyoutItem>(this);
		}
	}

	private static void OnAreCheckStatesEnabledPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		object newValue = args.NewValue;
		if (!(newValue is bool) || !(bool)newValue)
		{
			return;
		}
		MenuFlyoutSubItem subMenu = sender as MenuFlyoutSubItem;
		if (subMenu == null)
		{
			return;
		}
		subMenu.Loaded += delegate
		{
			bool flag = false;
			foreach (MenuFlyoutItemBase item in subMenu.Items)
			{
				if (item is RadioMenuFlyoutItem radioMenuFlyoutItem)
				{
					flag = flag || radioMenuFlyoutItem.IsChecked;
				}
			}
			VisualStateManager.GoToState(subMenu, flag ? "Checked" : "Unchecked", useTransitions: false);
		};
	}

	public static bool GetAreCheckStatesEnabled(DependencyObject obj)
	{
		return (bool)obj.GetValue(AreCheckStatesEnabledProperty);
	}

	public static void SetAreCheckStatesEnabled(DependencyObject obj, bool value)
	{
		obj.SetValue(AreCheckStatesEnabledProperty, value);
	}
}
