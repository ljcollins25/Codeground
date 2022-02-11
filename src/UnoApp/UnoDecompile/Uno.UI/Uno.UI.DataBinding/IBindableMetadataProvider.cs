using System;

namespace Uno.UI.DataBinding;

public interface IBindableMetadataProvider
{
	IBindableType GetBindableTypeByType(Type type);

	IBindableType GetBindableTypeByFullName(string fullName);
}
