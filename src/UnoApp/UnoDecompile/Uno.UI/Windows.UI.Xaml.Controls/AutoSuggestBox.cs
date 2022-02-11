using System.Collections.Specialized;
using System.Linq;
using Uno;
using Uno.Extensions.Specialized;
using Uno.Foundation.Logging;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class AutoSuggestBox : ItemsControl, IValueChangedListener
{
	private TextBox _textBox;

	private Popup _popup;

	private Grid _layoutRoot;

	private ListView _suggestionsList;

	private Button _queryButton;

	private AutoSuggestionBoxTextChangeReason _textChangeReason;

	private string userInput;

	private BindingPath _textBoxBinding;

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public LightDismissOverlayMode LightDismissOverlayMode
	{
		get
		{
			return (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
		}
		set
		{
			SetValue(LightDismissOverlayModeProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public object Description
	{
		get
		{
			return GetValue(DescriptionProperty);
		}
		set
		{
			SetValue(DescriptionProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty LightDismissOverlayModeProperty { get; } = DependencyProperty.Register("LightDismissOverlayMode", typeof(LightDismissOverlayMode), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(LightDismissOverlayMode.Auto));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DescriptionProperty { get; } = DependencyProperty.Register("Description", typeof(object), typeof(AutoSuggestBox), new FrameworkPropertyMetadata((object)null));


	public string PlaceholderText
	{
		get
		{
			return (string)GetValue(PlaceholderTextProperty);
		}
		set
		{
			SetValue(PlaceholderTextProperty, value);
		}
	}

	public double MaxSuggestionListHeight
	{
		get
		{
			return (double)GetValue(MaxSuggestionListHeightProperty);
		}
		set
		{
			SetValue(MaxSuggestionListHeightProperty, value);
		}
	}

	public bool IsSuggestionListOpen
	{
		get
		{
			return (bool)GetValue(IsSuggestionListOpenProperty);
		}
		set
		{
			SetValue(IsSuggestionListOpenProperty, value);
		}
	}

	public object Header
	{
		get
		{
			return GetValue(HeaderProperty);
		}
		set
		{
			SetValue(HeaderProperty, value);
		}
	}

	public bool AutoMaximizeSuggestionArea
	{
		get
		{
			return (bool)GetValue(AutoMaximizeSuggestionAreaProperty);
		}
		set
		{
			SetValue(AutoMaximizeSuggestionAreaProperty, value);
		}
	}

	public bool UpdateTextOnSelect
	{
		get
		{
			return (bool)GetValue(UpdateTextOnSelectProperty);
		}
		set
		{
			SetValue(UpdateTextOnSelectProperty, value);
		}
	}

	public string TextMemberPath
	{
		get
		{
			return (string)GetValue(TextMemberPathProperty);
		}
		set
		{
			SetValue(TextMemberPathProperty, value);
		}
	}

	public Style TextBoxStyle
	{
		get
		{
			return (Style)GetValue(TextBoxStyleProperty);
		}
		set
		{
			SetValue(TextBoxStyleProperty, value);
		}
	}

	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	public IconElement QueryIcon
	{
		get
		{
			return (IconElement)GetValue(QueryIconProperty);
		}
		set
		{
			SetValue(QueryIconProperty, value);
		}
	}

	public static DependencyProperty MaxSuggestionListHeightProperty { get; } = DependencyProperty.Register("MaxSuggestionListHeight", typeof(double), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(double.PositiveInfinity));


	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(""));


	public static DependencyProperty TextBoxStyleProperty { get; } = DependencyProperty.Register("TextBoxStyle", typeof(Style), typeof(AutoSuggestBox), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TextMemberPathProperty { get; } = DependencyProperty.Register("TextMemberPath", typeof(string), typeof(AutoSuggestBox), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty TextProperty { get; } = DependencyProperty.Register("Text", typeof(string), typeof(AutoSuggestBox), new FrameworkPropertyMetadata("", OnTextChanged));


	public static DependencyProperty UpdateTextOnSelectProperty { get; } = DependencyProperty.Register("UpdateTextOnSelect", typeof(bool), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(true));


	public static DependencyProperty AutoMaximizeSuggestionAreaProperty { get; } = DependencyProperty.Register("AutoMaximizeSuggestionArea", typeof(bool), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(false));


	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(AutoSuggestBox), new FrameworkPropertyMetadata((object)null));


	public static DependencyProperty IsSuggestionListOpenProperty { get; } = DependencyProperty.Register("IsSuggestionListOpen", typeof(bool), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as AutoSuggestBox)?.OnIsSuggestionListOpenChanged(e);
	}));


	public static DependencyProperty QueryIconProperty { get; } = DependencyProperty.Register("QueryIcon", typeof(IconElement), typeof(AutoSuggestBox), new FrameworkPropertyMetadata(null, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		(s as AutoSuggestBox)?.UpdateQueryButton();
	}));


	public event TypedEventHandler<AutoSuggestBox, AutoSuggestBoxSuggestionChosenEventArgs> SuggestionChosen;

	public event TypedEventHandler<AutoSuggestBox, AutoSuggestBoxTextChangedEventArgs> TextChanged;

	public event TypedEventHandler<AutoSuggestBox, AutoSuggestBoxQuerySubmittedEventArgs> QuerySubmitted;

	public AutoSuggestBox()
	{
		base.Items.VectorChanged += OnItemsChanged;
		base.DefaultStyleKey = typeof(AutoSuggestBox);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_textBox = GetTemplateChild("TextBox") as TextBox;
		_popup = GetTemplateChild("SuggestionsPopup") as Popup;
		_layoutRoot = GetTemplateChild("LayoutRoot") as Grid;
		_suggestionsList = GetTemplateChild("SuggestionsList") as ListView;
		_queryButton = GetTemplateChild("QueryButton") as Button;
		UpdateQueryButton();
		UpdateTextBox();
		_textBoxBinding = new BindingPath("Text", null)
		{
			DataContext = _textBox,
			ValueChangedListener = this
		};
		base.Loaded += delegate
		{
			RegisterEvents();
		};
		base.Unloaded += delegate
		{
			UnregisterEvents();
		};
		if (base.IsLoaded)
		{
			RegisterEvents();
		}
	}

	void IValueChangedListener.OnValueChanged(object value)
	{
		if (value is string text)
		{
			Text = text;
		}
	}

	private void OnItemsChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
	{
		UpdateSuggestionList();
	}

	protected override void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateSuggestionList();
		base.OnItemsSourceChanged(e);
	}

	internal override void OnItemsSourceSingleCollectionChanged(object sender, NotifyCollectionChangedEventArgs args, int section)
	{
		base.OnItemsSourceSingleCollectionChanged(sender, args, section);
		UpdateSuggestionList();
	}

	internal override void OnItemsSourceGroupsChanged(object sender, NotifyCollectionChangedEventArgs args)
	{
		base.OnItemsSourceGroupsChanged(sender, args);
		UpdateSuggestionList();
	}

	private void UpdateSuggestionList()
	{
		if (_suggestionsList == null)
		{
			return;
		}
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug("ItemsChanged, refreshing suggestion list");
		}
		_suggestionsList.ItemsSource = GetItems();
		if (GetItems().Count() == 0)
		{
			IsSuggestionListOpen = false;
			return;
		}
		TextBox textBox = _textBox;
		if (textBox != null && textBox.IsFocused)
		{
			IsSuggestionListOpen = true;
			_suggestionsList.ItemsSource = GetItems();
			LayoutPopup();
		}
	}

	private void UpdateTextFromSuggestion(object o)
	{
		_textChangeReason = AutoSuggestionBoxTextChangeReason.SuggestionChosen;
		Text = GetObjectText(o) ?? "";
	}

	private void UpdateUserInput(object o)
	{
		userInput = GetObjectText(o);
	}

	private void LayoutPopup()
	{
		if (_popup == null || !_popup.IsOpen || !(_popup.Child is FrameworkElement frameworkElement))
		{
			return;
		}
		Popup popup = _popup;
		if (popup == null)
		{
			return;
		}
		FrameworkElement layoutRoot = _layoutRoot;
		if (layoutRoot == null)
		{
			return;
		}
		popup.VerticalOffset = 0.0;
		popup.HorizontalOffset = 0.0;
		frameworkElement.MinHeight = layoutRoot.ActualHeight;
		frameworkElement.MinWidth = layoutRoot.ActualWidth;
		frameworkElement.MaxHeight = MaxSuggestionListHeight;
		Rect bounds = Window.Current.Bounds;
		MatrixTransform matrixTransform = (MatrixTransform)popup.TransformToVisual(Window.Current.Content);
		Rect rect = new Rect(matrixTransform.Matrix.OffsetX, matrixTransform.Matrix.OffsetY, popup.ActualWidth, popup.ActualHeight);
		MatrixTransform matrixTransform2 = (MatrixTransform)layoutRoot.TransformToVisual(Window.Current.Content);
		Rect rect2 = new Rect(matrixTransform2.Matrix.OffsetX, matrixTransform2.Matrix.OffsetY + layoutRoot.ActualHeight, layoutRoot.ActualWidth, layoutRoot.ActualHeight);
		foreach (Control item in frameworkElement.EnumerateAllChildren().OfType<Control>())
		{
			item.ApplyTemplate();
		}
		frameworkElement.Measure(bounds.Size);
		Rect rect3 = new Rect(default(Point), frameworkElement.DesiredSize);
		rect3.X = rect2.Left;
		if (rect3.Right > bounds.Right)
		{
			rect3.X = rect2.Right - rect3.Width;
		}
		if (rect3.Left < bounds.Left)
		{
			rect3.X = (bounds.Width - rect3.Width) / 2.0;
		}
		rect3.Y = rect2.Top;
		if (rect3.Bottom > bounds.Bottom)
		{
			rect3.Y = rect2.Bottom - rect3.Height;
		}
		if (rect3.Top < bounds.Top)
		{
			rect3.Y = (bounds.Height - rect3.Height) / 2.0;
		}
		popup.HorizontalOffset = rect3.X - rect.X;
		popup.VerticalOffset = rect3.Y - rect.Y;
	}

	private void RegisterEvents()
	{
		if (_textBox != null)
		{
			_textBox.KeyDown += OnTextBoxKeyDown;
		}
		if (_queryButton != null)
		{
			_queryButton.Click += OnQueryButtonClick;
		}
		if (_suggestionsList != null)
		{
			_suggestionsList.ItemClick += OnSuggestionListItemClick;
		}
		if (_popup != null)
		{
			_popup.Closed += OnPopupClosed;
		}
	}

	private void UnregisterEvents()
	{
		if (_textBox != null)
		{
			_textBox.KeyDown -= OnTextBoxKeyDown;
		}
		if (_queryButton != null)
		{
			_queryButton.Click -= OnQueryButtonClick;
		}
		if (_suggestionsList != null)
		{
			_suggestionsList.ItemClick -= OnSuggestionListItemClick;
		}
		if (_popup != null)
		{
			_popup.Closed -= OnPopupClosed;
		}
	}

	private void OnPopupClosed(object sender, object e)
	{
		IsSuggestionListOpen = false;
	}

	private void OnIsSuggestionListOpenChanged(DependencyPropertyChangedEventArgs e)
	{
		object newValue = e.NewValue;
		if (newValue is bool)
		{
			bool isOpen = (bool)newValue;
			if (_popup != null)
			{
				_popup.IsOpen = isOpen;
			}
		}
	}

	private void UpdateQueryButton()
	{
		if (_queryButton != null)
		{
			_queryButton.Content = QueryIcon;
			_queryButton.Visibility = ((QueryIcon == null) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private void UpdateTextBox()
	{
		if (_textBox != null)
		{
			_textBox.Text = Text;
		}
	}

	private void OnSuggestionListItemClick(object sender, ItemClickEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug($"Suggestion item clicked {e.ClickedItem}");
		}
		ChoseItem(e.ClickedItem);
		SubmitSearch();
	}

	private void OnQueryButtonClick(object sender, RoutedEventArgs e)
	{
		if (this.Log().IsEnabled(LogLevel.Debug))
		{
			this.Log().Debug("Query button clicked");
		}
		SubmitSearch();
	}

	private void SubmitSearch()
	{
		this.QuerySubmitted?.Invoke(this, new AutoSuggestBoxQuerySubmittedEventArgs(null, Text));
		IsSuggestionListOpen = false;
	}

	private void OnTextBoxKeyDown(object sender, KeyRoutedEventArgs e)
	{
		if (e.Key == VirtualKey.Enter)
		{
			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug("Enter key pressed");
			}
			SubmitSearch();
		}
		else if ((e.Key == VirtualKey.Up || e.Key == VirtualKey.Down) && IsSuggestionListOpen)
		{
			HandleUpDownKeys(e);
		}
		else if (e.Key == VirtualKey.Escape && IsSuggestionListOpen)
		{
			RevertTextToUserInput();
			IsSuggestionListOpen = false;
		}
		else
		{
			_textChangeReason = AutoSuggestionBoxTextChangeReason.UserInput;
		}
	}

	private void HandleUpDownKeys(KeyRoutedEventArgs e)
	{
		int selectedIndex = _suggestionsList.SelectedIndex;
		int numberOfItems = _suggestionsList.NumberOfItems;
		int num = -1;
		if (e.Key == VirtualKey.Up)
		{
			num = (selectedIndex % numberOfItems + numberOfItems) % numberOfItems - ((selectedIndex != -1) ? 1 : 0);
		}
		else if (e.Key == VirtualKey.Down)
		{
			int num2 = selectedIndex + 1;
			num = (num2 % numberOfItems + numberOfItems) % numberOfItems - ((num2 == numberOfItems) ? 1 : 0);
		}
		_suggestionsList.SelectedIndex = num;
		if (num == -1)
		{
			RevertTextToUserInput();
		}
		else
		{
			ChoseSuggestion();
		}
	}

	private void ChoseSuggestion()
	{
		ChoseItem(_suggestionsList.SelectedItem);
	}

	private void ChoseItem(object o)
	{
		if (UpdateTextOnSelect)
		{
			UpdateTextFromSuggestion(o);
		}
		this.SuggestionChosen?.Invoke(this, new AutoSuggestBoxSuggestionChosenEventArgs(o));
	}

	private void RevertTextToUserInput()
	{
		_suggestionsList.SelectedIndex = -1;
		_textChangeReason = AutoSuggestionBoxTextChangeReason.ProgrammaticChange;
		Text = userInput ?? "";
	}

	private string GetObjectText(object o)
	{
		if (o is string result)
		{
			return result;
		}
		object obj = o;
		if (TextMemberPath != null)
		{
			using BindingPath bindingPath = new BindingPath(TextMemberPath, "", null, allowPrivateMembers: true)
			{
				DataContext = o
			};
			obj = bindingPath.Value;
		}
		return obj?.ToString() ?? "";
	}

	private static void OnTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		string o = (args.NewValue as string) ?? string.Empty;
		if (dependencyObject is AutoSuggestBox autoSuggestBox)
		{
			autoSuggestBox.UpdateTextBox();
			autoSuggestBox.UpdateSuggestionList();
			if (autoSuggestBox._textChangeReason == AutoSuggestionBoxTextChangeReason.UserInput)
			{
				autoSuggestBox.UpdateUserInput(o);
			}
			autoSuggestBox.TextChanged?.Invoke(autoSuggestBox, new AutoSuggestBoxTextChangedEventArgs
			{
				Reason = autoSuggestBox._textChangeReason,
				Owner = autoSuggestBox
			});
		}
	}
}
