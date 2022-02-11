using System;
using System.Threading.Tasks;
using Uno.UI.Helpers.WinUI;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls;

public class PersonPicture : Control
{
	private TextBlock m_initialsTextBlock;

	private TextBlock m_badgeNumberTextBlock;

	private FontIcon m_badgeGlyphIcon;

	private ImageBrush m_badgeImageBrush;

	private Ellipse m_badgingEllipse;

	private Ellipse m_badgingBackgroundEllipse;

	private IAsyncOperation<IRandomAccessStreamWithContentType> m_profilePictureReadAsync;

	private string m_displayNameInitials = string.Empty;

	private string m_contactDisplayNameInitials = string.Empty;

	private ImageSource m_contactImageSource;

	public ImageSource ProfilePicture
	{
		get
		{
			return (ImageSource)GetValue(ProfilePictureProperty);
		}
		set
		{
			SetValue(ProfilePictureProperty, value);
		}
	}

	public bool PreferSmallImage
	{
		get
		{
			return (bool)GetValue(PreferSmallImageProperty);
		}
		set
		{
			SetValue(PreferSmallImageProperty, value);
		}
	}

	public bool IsGroup
	{
		get
		{
			return (bool)GetValue(IsGroupProperty);
		}
		set
		{
			SetValue(IsGroupProperty, value);
		}
	}

	public string Initials
	{
		get
		{
			return (string)GetValue(InitialsProperty);
		}
		set
		{
			SetValue(InitialsProperty, value);
		}
	}

	public string DisplayName
	{
		get
		{
			return (string)GetValue(DisplayNameProperty);
		}
		set
		{
			SetValue(DisplayNameProperty, value);
		}
	}

	public Contact Contact
	{
		get
		{
			return (Contact)GetValue(ContactProperty);
		}
		set
		{
			SetValue(ContactProperty, value);
		}
	}

	public string BadgeText
	{
		get
		{
			return (string)GetValue(BadgeTextProperty);
		}
		set
		{
			SetValue(BadgeTextProperty, value);
		}
	}

	public int BadgeNumber
	{
		get
		{
			return (int)GetValue(BadgeNumberProperty);
		}
		set
		{
			SetValue(BadgeNumberProperty, value);
		}
	}

	public ImageSource BadgeImageSource
	{
		get
		{
			return (ImageSource)GetValue(BadgeImageSourceProperty);
		}
		set
		{
			SetValue(BadgeImageSourceProperty, value);
		}
	}

	public string BadgeGlyph
	{
		get
		{
			return (string)GetValue(BadgeGlyphProperty);
		}
		set
		{
			SetValue(BadgeGlyphProperty, value);
		}
	}

	public PersonPictureTemplateSettings TemplateSettings
	{
		get
		{
			return (PersonPictureTemplateSettings)GetValue(TemplateSettingsProperty);
		}
		internal set
		{
			SetValue(TemplateSettingsProperty, value);
		}
	}

	public static DependencyProperty BadgeGlyphProperty { get; } = DependencyProperty.Register("BadgeGlyph", typeof(string), typeof(PersonPicture), new FrameworkPropertyMetadata("", OnPropertyChanged));


	public static DependencyProperty BadgeImageSourceProperty { get; } = DependencyProperty.Register("BadgeImageSource", typeof(ImageSource), typeof(PersonPicture), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public static DependencyProperty BadgeNumberProperty { get; } = DependencyProperty.Register("BadgeNumber", typeof(int), typeof(PersonPicture), new FrameworkPropertyMetadata(0, OnPropertyChanged));


	public static DependencyProperty BadgeTextProperty { get; } = DependencyProperty.Register("BadgeText", typeof(string), typeof(PersonPicture), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public static DependencyProperty ContactProperty { get; } = DependencyProperty.Register("Contact", typeof(Contact), typeof(PersonPicture), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public static DependencyProperty DisplayNameProperty { get; } = DependencyProperty.Register("DisplayName", typeof(string), typeof(PersonPicture), new FrameworkPropertyMetadata("", OnPropertyChanged));


	public static DependencyProperty InitialsProperty { get; } = DependencyProperty.Register("Initials", typeof(string), typeof(PersonPicture), new FrameworkPropertyMetadata("", OnPropertyChanged));


	public static DependencyProperty IsGroupProperty { get; } = DependencyProperty.Register("IsGroup", typeof(bool), typeof(PersonPicture), new FrameworkPropertyMetadata(false, OnPropertyChanged));


	public static DependencyProperty PreferSmallImageProperty { get; } = DependencyProperty.Register("PreferSmallImage", typeof(bool), typeof(PersonPicture), new FrameworkPropertyMetadata(false, OnPropertyChanged));


	public static DependencyProperty ProfilePictureProperty { get; } = DependencyProperty.Register("ProfilePicture", typeof(ImageSource), typeof(PersonPicture), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	internal static DependencyProperty TemplateSettingsProperty { get; } = DependencyProperty.Register("TemplateSettings", typeof(PersonPictureTemplateSettings), typeof(PersonPicture), new FrameworkPropertyMetadata(null, OnPropertyChanged));


	public PersonPicture()
	{
		base.DefaultStyleKey = typeof(PersonPicture);
		TemplateSettings = new PersonPictureTemplateSettings();
		base.Unloaded += OnUnloaded;
		base.SizeChanged += OnSizeChanged;
	}

	private async Task<BitmapImage> LoadImageAsync(IRandomAccessStreamReference thumbStreamReference)
	{
		m_profilePictureReadAsync = null;
		throw new NotSupportedException("Contact is not yet supported");
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		return new PersonPictureAutomationPeer(this);
	}

	protected override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		m_initialsTextBlock = GetTemplateChild("InitialsTextBlock") as TextBlock;
		m_badgeNumberTextBlock = GetTemplateChild("BadgeNumberTextBlock") as TextBlock;
		m_badgeGlyphIcon = GetTemplateChild("BadgeGlyphIcon") as FontIcon;
		m_badgingEllipse = GetTemplateChild("BadgingEllipse") as Ellipse;
		m_badgingBackgroundEllipse = GetTemplateChild("BadgingBackgroundEllipse") as Ellipse;
		UpdateBadge();
		UpdateIfReady();
	}

	private string GetInitials()
	{
		if (!string.IsNullOrEmpty(Initials))
		{
			return Initials;
		}
		if (!string.IsNullOrEmpty(m_displayNameInitials))
		{
			return m_displayNameInitials;
		}
		return m_contactDisplayNameInitials;
	}

	private ImageSource GetImageSource()
	{
		if (ProfilePicture != null)
		{
			return ProfilePicture;
		}
		return m_contactImageSource;
	}

	private void UpdateIfReady()
	{
		string initials = GetInitials();
		ImageSource imageSource = GetImageSource();
		PersonPictureTemplateSettings templateSettings = TemplateSettings;
		templateSettings.ActualInitials = initials;
		if (imageSource != null)
		{
			ImageBrush imageBrush = templateSettings.ActualImageBrush;
			if (imageBrush == null)
			{
				imageBrush = new ImageBrush();
				imageBrush.Stretch = Stretch.UniformToFill;
				templateSettings.ActualImageBrush = imageBrush;
			}
			imageBrush.ImageSource = imageSource;
		}
		else
		{
			templateSettings.ActualImageBrush = null;
		}
		if (IsGroup)
		{
			VisualStateManager.GoToState(this, "Group", useTransitions: false);
		}
		else if (imageSource != null)
		{
			VisualStateManager.GoToState(this, "Photo", useTransitions: false);
		}
		else if (!string.IsNullOrEmpty(initials))
		{
			VisualStateManager.GoToState(this, "Initials", useTransitions: false);
		}
		else
		{
			VisualStateManager.GoToState(this, "NoPhotoOrInitials", useTransitions: false);
		}
		UpdateAutomationName();
	}

	private void UpdateBadge()
	{
		if (BadgeImageSource != null)
		{
			UpdateBadgeImageSource();
		}
		else if (BadgeNumber != 0)
		{
			UpdateBadgeNumber();
		}
		else if (!string.IsNullOrEmpty(BadgeGlyph))
		{
			UpdateBadgeGlyph();
		}
		else
		{
			VisualStateManager.GoToState(this, "NoBadge", useTransitions: false);
			if (m_badgeNumberTextBlock != null)
			{
				m_badgeNumberTextBlock.Text = "";
			}
			if (m_badgeGlyphIcon != null)
			{
				m_badgeGlyphIcon.Glyph = "";
			}
		}
		UpdateAutomationName();
	}

	private void UpdateBadgeNumber()
	{
		if (m_badgingEllipse == null || m_badgeNumberTextBlock == null)
		{
			return;
		}
		int badgeNumber = BadgeNumber;
		if (badgeNumber <= 0)
		{
			VisualStateManager.GoToState(this, "NoBadge", useTransitions: false);
			m_badgeNumberTextBlock.Text = "";
			return;
		}
		VisualStateManager.GoToState(this, "BadgeWithoutImageSource", useTransitions: false);
		if (badgeNumber <= 99)
		{
			m_badgeNumberTextBlock.Text = badgeNumber.ToString();
		}
		else
		{
			m_badgeNumberTextBlock.Text = "99+";
		}
	}

	private void UpdateBadgeGlyph()
	{
		if (m_badgingEllipse != null && m_badgeGlyphIcon != null)
		{
			string badgeGlyph = BadgeGlyph;
			if (string.IsNullOrEmpty(badgeGlyph))
			{
				VisualStateManager.GoToState(this, "NoBadge", useTransitions: false);
				m_badgeGlyphIcon.Glyph = "";
			}
			else
			{
				VisualStateManager.GoToState(this, "BadgeWithoutImageSource", useTransitions: false);
				m_badgeGlyphIcon.Glyph = badgeGlyph;
			}
		}
	}

	private void UpdateBadgeImageSource()
	{
		if (m_badgeImageBrush == null)
		{
			m_badgeImageBrush = GetTemplateChild("BadgeImageBrush") as ImageBrush;
		}
		if (m_badgingEllipse != null && m_badgeImageBrush != null)
		{
			m_badgeImageBrush.ImageSource = BadgeImageSource;
			if (BadgeImageSource != null)
			{
				VisualStateManager.GoToState(this, "BadgeWithImageSource", useTransitions: false);
			}
			else
			{
				VisualStateManager.GoToState(this, "NoBadge", useTransitions: false);
			}
		}
	}

	private void UpdateAutomationName()
	{
		Contact contact = Contact;
		string text = (IsGroup ? ResourceAccessor.GetLocalizedStringResource("GroupName") : ((contact != null && !string.IsNullOrEmpty(contact.DisplayName)) ? contact.DisplayName : ((!string.IsNullOrEmpty(DisplayName)) ? DisplayName : (string.IsNullOrEmpty(Initials) ? ResourceAccessor.GetLocalizedStringResource("PersonName") : Initials))));
		string value = ((BadgeNumber > 0) ? (string.IsNullOrEmpty(BadgeText) ? StringUtil.FormatString(GetLocalizedPluralBadgeItemStringResource(BadgeNumber), text, BadgeNumber) : StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("BadgeItemTextOverride"), text, BadgeNumber, BadgeText)) : ((string.IsNullOrEmpty(BadgeGlyph) && BadgeImageSource == null) ? text : (string.IsNullOrEmpty(BadgeText) ? StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("BadgeIcon"), text) : StringUtil.FormatString(ResourceAccessor.GetLocalizedStringResource("BadgeIconTextOverride"), text, BadgeText))));
		AutomationProperties.SetName(this, value);
	}

	private string GetLocalizedPluralBadgeItemStringResource(int numericValue)
	{
		int num = numericValue % 10;
		switch (numericValue)
		{
		case 1:
			return ResourceAccessor.GetLocalizedStringResource("BadgeItemSingular");
		case 2:
			return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural7");
		case 3:
		case 4:
			return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural2");
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural5");
		default:
			if (numericValue >= 11 && numericValue <= 19)
			{
				return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural6");
			}
			switch (num)
			{
			case 1:
				return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural1");
			case 2:
			case 3:
			case 4:
				return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural3");
			default:
				return ResourceAccessor.GetLocalizedStringResource("BadgeItemPlural4");
			}
		}
	}

	private void UpdateControlForContact(bool isNewContact)
	{
		Contact contact = Contact;
		if (contact == null)
		{
			m_contactDisplayNameInitials = "";
			m_contactImageSource = null;
			UpdateIfReady();
			return;
		}
		if (m_profilePictureReadAsync != null)
		{
			m_profilePictureReadAsync.Cancel();
		}
		m_contactDisplayNameInitials = InitialsGenerator.InitialsFromContactObject(contact);
		IRandomAccessStreamReference randomAccessStreamReference = null;
		if (PreferSmallImage && contact.SmallDisplayPicture != null)
		{
			randomAccessStreamReference = contact.SmallDisplayPicture;
		}
		else if (contact.LargeDisplayPicture != null)
		{
			randomAccessStreamReference = contact.LargeDisplayPicture;
		}
		else if (contact.SmallDisplayPicture != null)
		{
			randomAccessStreamReference = contact.SmallDisplayPicture;
		}
		else if (contact.SourceDisplayPicture != null)
		{
			randomAccessStreamReference = contact.SourceDisplayPicture;
		}
		else if (contact.Thumbnail != null)
		{
			randomAccessStreamReference = contact.Thumbnail;
		}
		if (randomAccessStreamReference != null)
		{
			if (isNewContact)
			{
				m_contactImageSource = null;
			}
			if (!SharedHelpers.IsInDesignMode())
			{
				throw new NotSupportedException("Contact is not yet supported");
			}
		}
		else
		{
			m_contactImageSource = null;
		}
		UpdateIfReady();
	}

	private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
	{
		DependencyProperty property = args.Property;
		if (property == BadgeNumberProperty || property == BadgeGlyphProperty || property == BadgeImageSourceProperty)
		{
			UpdateBadge();
		}
		else if (property == BadgeTextProperty)
		{
			UpdateAutomationName();
		}
		else if (property == ContactProperty)
		{
			OnContactChanged(args);
		}
		else if (property == DisplayNameProperty)
		{
			OnDisplayNameChanged(args);
		}
		else if (property == ProfilePictureProperty || property == InitialsProperty || property == IsGroupProperty)
		{
			UpdateIfReady();
		}
	}

	private void OnDisplayNameChanged(DependencyPropertyChangedEventArgs args)
	{
		m_displayNameInitials = InitialsGenerator.InitialsFromDisplayName(DisplayName);
		UpdateIfReady();
	}

	private void OnContactChanged(DependencyPropertyChangedEventArgs args)
	{
		bool isNewContact = true;
		if (args != null && args.OldValue != null && args.NewValue != null)
		{
			Contact contact = args.OldValue as Contact;
			Contact contact2 = args.NewValue as Contact;
			if (!string.IsNullOrWhiteSpace(contact.Id) || !string.IsNullOrWhiteSpace(contact2.Id))
			{
				isNewContact = contact.Id != contact2.Id;
			}
		}
		UpdateControlForContact(isNewContact);
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs args)
	{
		bool flag = args.NewSize.Width != args.PreviousSize.Width;
		bool flag2 = args.NewSize.Height != args.PreviousSize.Height;
		double num;
		if (flag && flag2)
		{
			num = ((args.NewSize.Width < args.NewSize.Height) ? args.NewSize.Width : args.NewSize.Height);
		}
		else if (flag)
		{
			num = args.NewSize.Width;
		}
		else
		{
			if (!flag2)
			{
				return;
			}
			num = args.NewSize.Height;
		}
		base.Height = num;
		base.Width = num;
		double fontSize = Math.Max(1.0, base.Width * 0.42);
		if (m_initialsTextBlock != null)
		{
			m_initialsTextBlock.FontSize = fontSize;
		}
		if (m_badgingEllipse != null && m_badgingBackgroundEllipse != null && m_badgeNumberTextBlock != null && m_badgeGlyphIcon != null)
		{
			double num2 = ((args.NewSize.Width < args.NewSize.Height) ? args.NewSize.Width : args.NewSize.Height);
			m_badgingEllipse.Height = num2 * 0.5;
			m_badgingEllipse.Width = num2 * 0.5;
			m_badgingBackgroundEllipse.Height = num2 * 0.5;
			m_badgingBackgroundEllipse.Width = num2 * 0.5;
			m_badgeNumberTextBlock.FontSize = Math.Max(1.0, m_badgingEllipse.Height * 0.6);
			m_badgeGlyphIcon.FontSize = Math.Max(1.0, m_badgingEllipse.Height * 0.6);
		}
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		if (m_profilePictureReadAsync != null)
		{
			m_profilePictureReadAsync.Cancel();
		}
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		PersonPicture personPicture = (PersonPicture)sender;
		personPicture.OnPropertyChanged(args);
	}
}
