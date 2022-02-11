using System;
using System.Collections.Generic;

namespace Windows.UI.Xaml.Controls.Primitives;

public class LoopingSelectorPanel : Canvas, IScrollSnapPointsInfo
{
	private float _snapPointOffset;

	private float _snapPointSpacing;

	public bool AreHorizontalSnapPointsRegular => true;

	public bool AreVerticalSnapPointsRegular => true;

	public event EventHandler<object> HorizontalSnapPointsChanged;

	public event EventHandler<object> VerticalSnapPointsChanged;

	internal LoopingSelectorPanel()
	{
		_snapPointOffset = 0f;
		_snapPointSpacing = 0f;
		InitializeImpl();
	}

	public IReadOnlyList<float> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment alignment)
	{
		throw new NotImplementedException();
	}

	public float GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment alignment, out float offset)
	{
		if (orientation != 0)
		{
			throw new InvalidOperationException();
		}
		offset = _snapPointOffset;
		return _snapPointSpacing;
	}

	private void InitializeImpl()
	{
	}

	internal void SetOffsetInPixels(float offset)
	{
		if (_snapPointOffset != offset)
		{
			_snapPointOffset = offset;
			RaiseSnapPointsChangedEvents();
		}
	}

	internal void SetSizeInPixels(float size)
	{
		if (_snapPointSpacing != size)
		{
			_snapPointSpacing = size;
			RaiseSnapPointsChangedEvents();
		}
	}

	private void RaiseSnapPointsChangedEvents()
	{
		this.VerticalSnapPointsChanged?.Invoke(this, this);
	}
}
