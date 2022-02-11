using Uno;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class SearchBox : Control
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool SearchHistoryEnabled
	{
		get
		{
			return (bool)GetValue(SearchHistoryEnabledProperty);
		}
		set
		{
			SetValue(SearchHistoryEnabledProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string SearchHistoryContext
	{
		get
		{
			return (string)GetValue(SearchHistoryContextProperty);
		}
		set
		{
			SetValue(SearchHistoryContextProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public string QueryText
	{
		get
		{
			return (string)GetValue(QueryTextProperty);
		}
		set
		{
			SetValue(QueryTextProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool FocusOnKeyboardInput
	{
		get
		{
			return (bool)GetValue(FocusOnKeyboardInputProperty);
		}
		set
		{
			SetValue(FocusOnKeyboardInputProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool ChooseSuggestionOnEnter
	{
		get
		{
			return (bool)GetValue(ChooseSuggestionOnEnterProperty);
		}
		set
		{
			SetValue(ChooseSuggestionOnEnterProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty ChooseSuggestionOnEnterProperty { get; } = DependencyProperty.Register("ChooseSuggestionOnEnter", typeof(bool), typeof(SearchBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty FocusOnKeyboardInputProperty { get; } = DependencyProperty.Register("FocusOnKeyboardInput", typeof(bool), typeof(SearchBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty PlaceholderTextProperty { get; } = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(SearchBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty QueryTextProperty { get; } = DependencyProperty.Register("QueryText", typeof(string), typeof(SearchBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SearchHistoryContextProperty { get; } = DependencyProperty.Register("SearchHistoryContext", typeof(string), typeof(SearchBox), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SearchHistoryEnabledProperty { get; } = DependencyProperty.Register("SearchHistoryEnabled", typeof(bool), typeof(SearchBox), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SearchBox, RoutedEventArgs> PrepareForFocusOnKeyboardInput
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, RoutedEventArgs> SearchBox.PrepareForFocusOnKeyboardInput");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, RoutedEventArgs> SearchBox.PrepareForFocusOnKeyboardInput");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SearchBox, SearchBoxQueryChangedEventArgs> QueryChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxQueryChangedEventArgs> SearchBox.QueryChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxQueryChangedEventArgs> SearchBox.QueryChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SearchBox, SearchBoxQuerySubmittedEventArgs> QuerySubmitted
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxQuerySubmittedEventArgs> SearchBox.QuerySubmitted");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxQuerySubmittedEventArgs> SearchBox.QuerySubmitted");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SearchBox, SearchBoxResultSuggestionChosenEventArgs> ResultSuggestionChosen
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxResultSuggestionChosenEventArgs> SearchBox.ResultSuggestionChosen");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxResultSuggestionChosenEventArgs> SearchBox.ResultSuggestionChosen");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event TypedEventHandler<SearchBox, SearchBoxSuggestionsRequestedEventArgs> SuggestionsRequested
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxSuggestionsRequestedEventArgs> SearchBox.SuggestionsRequested");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "event TypedEventHandler<SearchBox, SearchBoxSuggestionsRequestedEventArgs> SearchBox.SuggestionsRequested");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SearchBox()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "SearchBox.SearchBox()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void SetLocalContentSuggestionSettings(LocalContentSuggestionSettings settings)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.SearchBox", "void SearchBox.SetLocalContentSuggestionSettings(LocalContentSuggestionSettings settings)");
	}
}
