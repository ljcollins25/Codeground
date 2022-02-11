using System;

namespace Uno.UI.Xaml;

internal interface IApplicationExtension
{
	bool CanExit { get; }

	event EventHandler SystemThemeChanged;

	void Exit();
}
