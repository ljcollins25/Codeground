using System;
using System.Collections.Generic;
using Uno;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml.Controls;

[NotImplemented]
public class Hub : Control, ISemanticZoomInformation
{
	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Orientation Orientation
	{
		get
		{
			return (Orientation)GetValue(OrientationProperty);
		}
		set
		{
			SetValue(OrientationProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public DataTemplate HeaderTemplate
	{
		get
		{
			return (DataTemplate)GetValue(HeaderTemplateProperty);
		}
		set
		{
			SetValue(HeaderTemplateProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
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

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public int DefaultSectionIndex
	{
		get
		{
			return (int)GetValue(DefaultSectionIndexProperty);
		}
		set
		{
			SetValue(DefaultSectionIndexProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IObservableVector<object> SectionHeaders
	{
		get
		{
			throw new NotImplementedException("The member IObservableVector<object> Hub.SectionHeaders is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<HubSection> Sections
	{
		get
		{
			throw new NotImplementedException("The member IList<HubSection> Hub.Sections is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public IList<HubSection> SectionsInView
	{
		get
		{
			throw new NotImplementedException("The member IList<HubSection> Hub.SectionsInView is not implemented in Uno.");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public SemanticZoom SemanticZoomOwner
	{
		get
		{
			return (SemanticZoom)GetValue(SemanticZoomOwnerProperty);
		}
		set
		{
			SetValue(SemanticZoomOwnerProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsZoomedInView
	{
		get
		{
			return (bool)GetValue(IsZoomedInViewProperty);
		}
		set
		{
			SetValue(IsZoomedInViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public bool IsActiveView
	{
		get
		{
			return (bool)GetValue(IsActiveViewProperty);
		}
		set
		{
			SetValue(IsActiveViewProperty, value);
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty DefaultSectionIndexProperty { get; } = DependencyProperty.Register("DefaultSectionIndex", typeof(int), typeof(Hub), new FrameworkPropertyMetadata(0));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderProperty { get; } = DependencyProperty.Register("Header", typeof(object), typeof(Hub), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty HeaderTemplateProperty { get; } = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Hub), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsActiveViewProperty { get; } = DependencyProperty.Register("IsActiveView", typeof(bool), typeof(Hub), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty IsZoomedInViewProperty { get; } = DependencyProperty.Register("IsZoomedInView", typeof(bool), typeof(Hub), new FrameworkPropertyMetadata(false));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty OrientationProperty { get; } = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Hub), new FrameworkPropertyMetadata(Orientation.Vertical));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public static DependencyProperty SemanticZoomOwnerProperty { get; } = DependencyProperty.Register("SemanticZoomOwner", typeof(SemanticZoom), typeof(Hub), new FrameworkPropertyMetadata((object)null));


	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event HubSectionHeaderClickEventHandler SectionHeaderClick
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "event HubSectionHeaderClickEventHandler Hub.SectionHeaderClick");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "event HubSectionHeaderClickEventHandler Hub.SectionHeaderClick");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public event SectionsInViewChangedEventHandler SectionsInViewChanged
	{
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		add
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "event SectionsInViewChangedEventHandler Hub.SectionsInViewChanged");
		}
		[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
		remove
		{
			ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "event SectionsInViewChangedEventHandler Hub.SectionsInViewChanged");
		}
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public Hub()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "Hub.Hub()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void ScrollToSection(HubSection section)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.ScrollToSection(HubSection section)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void InitializeViewChange()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.InitializeViewChange()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChange()
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChange()");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void MakeVisible(SemanticZoomLocation item)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.MakeVisible(SemanticZoomLocation item)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}

	[NotImplemented(new string[] { "__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__" })]
	public void CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
	{
		ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
	}
}
