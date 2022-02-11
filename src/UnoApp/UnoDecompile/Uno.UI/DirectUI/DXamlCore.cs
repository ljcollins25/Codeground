using System;
using System.Collections.Generic;
using Uno.UI.Xaml.Controls;
using Uno.UI.Xaml.Core;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace DirectUI;

internal class DXamlCore
{
	private static readonly Lazy<DXamlCore> _current = new Lazy<DXamlCore>(() => new DXamlCore());

	private Dictionary<string, List<WeakReference<RadioButton>>>? _radioButtonGroupsByName;

	private BuildTreeService? _buildTreeService;

	private BudgetManager? _budgetManager;

	public static DXamlCore Current => _current.Value;

	public static DXamlCore GetCurrentNoCreate()
	{
		return Current;
	}

	public CoreServices GetHandle()
	{
		return CoreServices.Instance;
	}

	public Rect DipsToPhysicalPixels(float scale, Rect dipRect)
	{
		Rect result = dipRect;
		result.X = dipRect.X * (double)scale;
		result.Y = dipRect.Y * (double)scale;
		result.Width = dipRect.Width * (double)scale;
		result.Height = dipRect.Height * (double)scale;
		return result;
	}

	public ApplicationBarService? TryGetApplicationBarService()
	{
		return null;
	}

	public string GetLocalizedResourceString(string key)
	{
		ResourceLoader forCurrentView = ResourceLoader.GetForCurrentView();
		return forCurrentView.GetString(key);
	}

	public BuildTreeService GetBuildTreeService()
	{
		return _buildTreeService ?? (_buildTreeService = new BuildTreeService());
	}

	public BudgetManager GetBudgetManager()
	{
		return _budgetManager ?? (_budgetManager = new BudgetManager());
	}

	public ElementSoundPlayerService GetElementSoundPlayerServiceNoRef()
	{
		return ElementSoundPlayerService.Instance;
	}

	internal Dictionary<string, List<WeakReference<RadioButton>>>? GetRadioButtonGroupsByName(bool ensure)
	{
		if (_radioButtonGroupsByName == null && ensure)
		{
			_radioButtonGroupsByName = new Dictionary<string, List<WeakReference<RadioButton>>>();
		}
		return _radioButtonGroupsByName;
	}
}
