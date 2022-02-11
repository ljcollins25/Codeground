using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using Uno.Collections;
using Uno.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls;

public class Grid : Panel
{
	[Flags]
	private enum GridFlags : byte
	{
		None = 0,
		HasStarRows = 1,
		HasStarColumns = 2,
		HasAutoRowsAndStarColumn = 4,
		DefinitionsChanged = 8
	}

	private struct SpanStoreEntry
	{
		internal int m_spanStart;

		internal int m_spanCount;

		internal double m_desiredSize;

		internal bool m_isColumnDefinition;

		internal SpanStoreEntry(int spanStart, int spanCount, double desiredSize, bool isColumnDefinition)
		{
			m_spanStart = spanStart;
			m_spanCount = spanCount;
			m_desiredSize = desiredSize;
			m_isColumnDefinition = isColumnDefinition;
		}
	}

	private class CellCacheStackVector : StackVector<CellCache>
	{
		internal CellCacheStackVector(int childrenCount)
			: base(c_cellCacheStackVectorSize, childrenCount)
		{
		}
	}

	private class SpanStoreStackVector : StackVector<SpanStoreEntry>
	{
		internal SpanStoreStackVector()
			: base(c_spanStoreStackVectorSize, 0)
		{
		}
	}

	[Flags]
	private enum CellUnitTypes : byte
	{
		None = 0,
		Auto = 1,
		Star = 2,
		Pixel = 4
	}

	private struct CellCache
	{
		internal UIElement m_child;

		internal int m_next;

		internal CellUnitTypes m_rowHeightTypes;

		internal CellUnitTypes m_columnWidthTypes;

		internal static bool IsStar(CellUnitTypes unitTypes)
		{
			return (unitTypes & CellUnitTypes.Star) == CellUnitTypes.Star;
		}

		internal static bool IsAuto(CellUnitTypes unitTypes)
		{
			return (unitTypes & CellUnitTypes.Auto) == CellUnitTypes.Auto;
		}
	}

	private struct CellGroups
	{
		internal int group1;

		internal int group2;

		internal int group3;

		internal int group4;
	}

	private const double REAL_EPSILON = 1.1920928955078125E-07;

	private const int GRID_STARVALUE_MAX = int.MaxValue;

	private static int c_spanStoreStackVectorSize = 16;

	private static int c_cellCacheStackVectorSize = 16;

	private RowDefinitionCollection m_pRowDefinitions;

	private ColumnDefinitionCollection m_pColumnDefinitions;

	private RowDefinitionCollection m_pRows;

	private ColumnDefinitionCollection m_pColumns;

	private DefinitionBase[] m_ppTempDefinitions;

	private int m_cTempDefinitions;

	private GridFlags m_gridFlags;

	private bool _BackgroundSizingPropertyBackingFieldSet;

	private BackgroundSizing _BackgroundSizingPropertyBackingField;

	private bool _BorderBrushPropertyBackingFieldSet;

	private Brush _BorderBrushPropertyBackingField;

	private bool _BorderThicknessPropertyBackingFieldSet;

	private Thickness _BorderThicknessPropertyBackingField;

	private bool _PaddingPropertyBackingFieldSet;

	private Thickness _PaddingPropertyBackingField;

	private bool _CornerRadiusPropertyBackingFieldSet;

	private CornerRadius _CornerRadiusPropertyBackingField;

	public RowDefinitionCollection RowDefinitions
	{
		get
		{
			if (m_pRowDefinitions == null)
			{
				m_pRowDefinitions = new RowDefinitionCollection(this);
				m_pRowDefinitions.CollectionChanged += delegate
				{
					InvalidateDefinitions();
				};
			}
			return m_pRowDefinitions;
		}
	}

	public ColumnDefinitionCollection ColumnDefinitions
	{
		get
		{
			if (m_pColumnDefinitions == null)
			{
				m_pColumnDefinitions = new ColumnDefinitionCollection(this);
				m_pColumnDefinitions.CollectionChanged += delegate
				{
					InvalidateDefinitions();
				};
			}
			return m_pColumnDefinitions;
		}
	}

	[GeneratedDependencyProperty(DefaultValue = BackgroundSizing.InnerBorderEdge, ChangedCallback = true)]
	public static DependencyProperty BackgroundSizingProperty { get; } = CreateBackgroundSizingProperty();


	public BackgroundSizing BackgroundSizing
	{
		get
		{
			return GetBackgroundSizingValue();
		}
		set
		{
			SetBackgroundSizingValue(value);
		}
	}

	public Brush BorderBrush
	{
		get
		{
			return GetBorderBrushValue();
		}
		set
		{
			SetBorderBrushValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderBrushPropertyChanged", Options = FrameworkPropertyMetadataOptions.ValueInheritsDataContext)]
	public static DependencyProperty BorderBrushProperty { get; } = CreateBorderBrushProperty();


	public Thickness BorderThickness
	{
		get
		{
			return GetBorderThicknessValue();
		}
		set
		{
			SetBorderThicknessValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnBorderThicknessPropertyChanged")]
	public static DependencyProperty BorderThicknessProperty { get; } = CreateBorderThicknessProperty();


	public Thickness Padding
	{
		get
		{
			return GetPaddingValue();
		}
		set
		{
			SetPaddingValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnPaddingPropertyChanged")]
	public static DependencyProperty PaddingProperty { get; } = CreatePaddingProperty();


	public CornerRadius CornerRadius
	{
		get
		{
			return GetCornerRadiusValue();
		}
		set
		{
			SetCornerRadiusValue(value);
		}
	}

	[GeneratedDependencyProperty(ChangedCallbackName = "OnCornerRadiusPropertyChanged")]
	public static DependencyProperty CornerRadiusProperty { get; } = CreateCornerRadiusProperty();


	[GeneratedDependencyProperty(DefaultValue = 0, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, ChangedCallbackName = "OnGenericPropertyChanged")]
	public static DependencyProperty RowProperty { get; } = CreateRowProperty();


	[GeneratedDependencyProperty(DefaultValue = 0, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, ChangedCallbackName = "OnGenericPropertyChanged")]
	public static DependencyProperty ColumnProperty { get; } = CreateColumnProperty();


	[GeneratedDependencyProperty(DefaultValue = 1, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, ChangedCallbackName = "OnGenericPropertyChanged")]
	public static DependencyProperty RowSpanProperty { get; } = CreateRowSpanProperty();


	[GeneratedDependencyProperty(DefaultValue = 1, AttachedBackingFieldOwner = typeof(UIElement), Attached = true, ChangedCallbackName = "OnGenericPropertyChanged")]
	public static DependencyProperty ColumnSpanProperty { get; } = CreateColumnSpanProperty();


	public double RowSpacing
	{
		get
		{
			return (double)GetValue(RowSpacingProperty);
		}
		set
		{
			SetValue(RowSpacingProperty, value);
		}
	}

	public static DependencyProperty RowSpacingProperty { get; } = DependencyProperty.Register("RowSpacing", typeof(double), typeof(Grid), new FrameworkPropertyMetadata(0.0, OnGenericPropertyChanged));


	public double ColumnSpacing
	{
		get
		{
			return (double)GetValue(ColumnSpacingProperty);
		}
		set
		{
			SetValue(ColumnSpacingProperty, value);
		}
	}

	public static DependencyProperty ColumnSpacingProperty { get; } = DependencyProperty.Register("ColumnSpacing", typeof(double), typeof(Grid), new FrameworkPropertyMetadata(0.0, OnGenericPropertyChanged));


	private int GetRowIndex(UIElement child)
	{
		return Math.Min(GetRow(child), m_pRows.Count - 1);
	}

	private int GetRowSpanAdjusted(UIElement child)
	{
		return Math.Min(GetRowSpan(child), m_pRows.Count - GetRowIndex(child));
	}

	private int GetColumnIndex(UIElement child)
	{
		return Math.Min(GetColumn(child), m_pColumns.Count - 1);
	}

	private int GetColumnSpanAdjusted(UIElement child)
	{
		return Math.Min(GetColumnSpan(child), m_pColumns.Count - GetColumnIndex(child));
	}

	private DefinitionBase GetRowNoRef(UIElement pChild)
	{
		m_pRows.TryGetElementAt(GetRowIndex(pChild), out var element);
		return element;
	}

	private DefinitionBase GetColumnNoRef(UIElement pChild)
	{
		m_pColumns.TryGetElementAt(GetColumnIndex(pChild), out var element);
		return element;
	}

	private void LockDefinitions()
	{
		((DefinitionCollectionBase)m_pRowDefinitions)?.Lock();
		((DefinitionCollectionBase)m_pColumnDefinitions)?.Lock();
	}

	private void UnlockDefinitions()
	{
		((DefinitionCollectionBase)m_pRowDefinitions)?.Unlock();
		((DefinitionCollectionBase)m_pColumnDefinitions)?.Unlock();
	}

	private void InitializeDefinitionStructure()
	{
		RowDefinition rowDefinition = null;
		ColumnDefinition columnDefinition = null;
		if (m_pRowDefinitions == null || m_pRowDefinitions.Count == 0)
		{
			m_pRows = new RowDefinitionCollection();
			rowDefinition = new RowDefinition();
			m_pRows.Add(rowDefinition);
		}
		else
		{
			m_pRows = m_pRowDefinitions;
		}
		if (m_pColumnDefinitions == null || m_pColumnDefinitions.Count == 0)
		{
			m_pColumns = new ColumnDefinitionCollection();
			columnDefinition = new ColumnDefinition();
			m_pColumns.Add(columnDefinition);
		}
		else
		{
			m_pColumns = m_pColumnDefinitions;
		}
	}

	private void ValidateDefinitions(DefinitionCollectionBase definitions, bool treatStarAsAuto)
	{
		IEnumerator<DefinitionBase> enumerator = definitions.GetItems().GetEnumerator();
		while (enumerator.MoveNext())
		{
			DefinitionBase current = enumerator.Current;
			bool useLayoutRounding = GetUseLayoutRounding();
			double val = double.PositiveInfinity;
			double num = (useLayoutRounding ? LayoutRound(current.GetUserMinSize()) : current.GetUserMinSize());
			double val2 = (useLayoutRounding ? LayoutRound(current.GetUserMaxSize()) : current.GetUserMaxSize());
			switch (current.GetUserSizeType())
			{
			case GridUnitType.Pixel:
				val = (useLayoutRounding ? LayoutRound(current.GetUserSizeValue()) : current.GetUserSizeValue());
				num = Math.Max(num, Math.Min(val, val2));
				current.SetEffectiveUnitType(GridUnitType.Pixel);
				break;
			case GridUnitType.Auto:
				current.SetEffectiveUnitType(GridUnitType.Auto);
				break;
			case GridUnitType.Star:
				if (treatStarAsAuto)
				{
					current.SetEffectiveUnitType(GridUnitType.Auto);
				}
				else
				{
					current.SetEffectiveUnitType(GridUnitType.Star);
				}
				break;
			}
			current.SetEffectiveMinSize(num);
			current.SetMeasureArrangeSize(Math.Max(num, Math.Min(val, val2)));
		}
	}

	private CellGroups ValidateCells(UIElementCollection children, ref CellCacheStackVector cellCacheVector)
	{
		m_gridFlags = GridFlags.None;
		CellGroups result = default(CellGroups);
		result.group1 = int.MaxValue;
		result.group2 = int.MaxValue;
		result.group3 = int.MaxValue;
		result.group4 = int.MaxValue;
		int count = children.Count;
		cellCacheVector.Resize(count);
		int num = count;
		while (num-- > 0)
		{
			UIElement child = children[num];
			ref CellCache reference = ref cellCacheVector[num];
			reference.m_child = child;
			reference.m_rowHeightTypes = GetLengthTypeForRange(m_pRows, GetRowIndex(child), GetRowSpanAdjusted(child));
			reference.m_columnWidthTypes = GetLengthTypeForRange(m_pColumns, GetColumnIndex(child), GetColumnSpanAdjusted(child));
			if (!CellCache.IsStar(reference.m_rowHeightTypes))
			{
				if (!CellCache.IsStar(reference.m_columnWidthTypes))
				{
					reference.m_next = result.group1;
					result.group1 = num;
				}
				else
				{
					reference.m_next = result.group3;
					result.group3 = num;
					if (CellCache.IsAuto(reference.m_rowHeightTypes))
					{
						SetGridFlags(GridFlags.HasAutoRowsAndStarColumn);
					}
				}
			}
			else
			{
				SetGridFlags(GridFlags.HasStarRows);
				if (CellCache.IsAuto(reference.m_columnWidthTypes) && !CellCache.IsStar(reference.m_columnWidthTypes))
				{
					reference.m_next = result.group2;
					result.group2 = num;
				}
				else
				{
					reference.m_next = result.group4;
					result.group4 = num;
				}
			}
			if (CellCache.IsStar(reference.m_columnWidthTypes))
			{
				SetGridFlags(GridFlags.HasStarColumns);
			}
		}
		return result;
	}

	private void MeasureCellsGroup(int cellsHead, int cellCount, double rowSpacing, double columnSpacing, bool ignoreColumnDesiredSize, bool forceRowToInfinity, ref CellCacheStackVector cellCacheVector)
	{
		SpanStoreStackVector spanStoreStackVector = new SpanStoreStackVector();
		if (cellsHead >= cellCount)
		{
			return;
		}
		do
		{
			CellCache cellCache = cellCacheVector[cellsHead];
			UIElement child = cellCache.m_child;
			MeasureCell(child, cellCache.m_rowHeightTypes, cellCache.m_columnWidthTypes, forceRowToInfinity, rowSpacing, columnSpacing);
			if (!ignoreColumnDesiredSize)
			{
				int columnSpanAdjusted = GetColumnSpanAdjusted(child);
				if (columnSpanAdjusted == 1)
				{
					DefinitionBase columnNoRef = GetColumnNoRef(child);
					columnNoRef.UpdateEffectiveMinSize(child.DesiredSize.Width);
				}
				else
				{
					RegisterSpan(spanStoreStackVector, GetColumnIndex(child), columnSpanAdjusted, child.DesiredSize.Width, isColumnDefinition: true);
				}
			}
			if (!forceRowToInfinity)
			{
				int rowSpanAdjusted = GetRowSpanAdjusted(child);
				if (rowSpanAdjusted == 1)
				{
					DefinitionBase rowNoRef = GetRowNoRef(child);
					rowNoRef.UpdateEffectiveMinSize(child.DesiredSize.Height);
				}
				else
				{
					RegisterSpan(spanStoreStackVector, GetRowIndex(child), rowSpanAdjusted, child.DesiredSize.Height, isColumnDefinition: false);
				}
			}
			cellsHead = cellCacheVector[cellsHead].m_next;
		}
		while (cellsHead < cellCount);
		Span<SpanStoreEntry> span = spanStoreStackVector.Memory.Span;
		for (int i = 0; i < span.Length; i++)
		{
			ref SpanStoreEntry reference = ref span[i];
			if (reference.m_isColumnDefinition)
			{
				EnsureMinSizeInDefinitionRange(m_pColumns, reference.m_spanStart, reference.m_spanCount, columnSpacing, reference.m_desiredSize);
			}
			else
			{
				EnsureMinSizeInDefinitionRange(m_pRows, reference.m_spanStart, reference.m_spanCount, rowSpacing, reference.m_desiredSize);
			}
		}
	}

	private void MeasureCell(UIElement child, CellUnitTypes rowHeightTypes, CellUnitTypes columnWidthTypes, bool forceRowToInfinity, double rowSpacing, double columnSpacing)
	{
		Size availableSize = default(Size);
		if (CellCache.IsAuto(columnWidthTypes) && !CellCache.IsStar(columnWidthTypes))
		{
			availableSize.Width = double.PositiveInfinity;
		}
		else
		{
			availableSize.Width = GetAvailableSizeForRange(m_pColumns, GetColumnIndex(child), GetColumnSpanAdjusted(child), columnSpacing);
		}
		if (forceRowToInfinity || (CellCache.IsAuto(rowHeightTypes) && !CellCache.IsStar(rowHeightTypes)))
		{
			availableSize.Height = double.PositiveInfinity;
		}
		else
		{
			availableSize.Height = GetAvailableSizeForRange(m_pRows, GetRowIndex(child), GetRowSpanAdjusted(child), rowSpacing);
		}
		MeasureElement(child, availableSize);
	}

	private unsafe void RegisterSpan(SpanStoreStackVector spanStore, int spanStart, int spanCount, double desiredSize, bool isColumnDefinition)
	{
		SpanStoreEntry item = default(SpanStoreEntry);
		spanStore.FirstOrDefault(IsEntry, ref item);
		SpanStoreEntry last = default(SpanStoreEntry);
		if (spanStore.LastOrDefault(ref last) && Unsafe.AsPointer(ref last) == Unsafe.AsPointer(ref item))
		{
			if (item.m_desiredSize < desiredSize)
			{
				item.m_desiredSize = desiredSize;
			}
		}
		else
		{
			spanStore.PushBack() = new SpanStoreEntry(spanStart, spanCount, desiredSize, isColumnDefinition);
		}
		bool IsEntry(ref SpanStoreEntry entry)
		{
			if (entry.m_isColumnDefinition == isColumnDefinition && entry.m_spanStart == spanStart)
			{
				return entry.m_spanCount == spanCount;
			}
			return false;
		}
	}

	private void EnsureMinSizeInDefinitionRange(DefinitionCollectionBase definitions, int spanStart, int spanCount, double spacing, double childDesiredSize)
	{
		double num = Math.Max(childDesiredSize - spacing * (double)(spanCount - 1), 0.0);
		if (num <= 1.1920928955078125E-07)
		{
			return;
		}
		int num2 = spanStart + spanCount;
		int num3 = 0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		EnsureTempDefinitionsStorage(spanCount);
		for (int i = spanStart; i < num2; i++)
		{
			DefinitionBase item = definitions.GetItem(i);
			double effectiveMinSize = item.GetEffectiveMinSize();
			double preferredSize = item.GetPreferredSize();
			double num8 = Math.Max(item.GetUserMaxSize(), effectiveMinSize);
			num4 += effectiveMinSize;
			num6 += preferredSize;
			num5 += num8;
			item.SetSizeCache(num8);
			num7 = Math.Max(num7, num8);
			if (item.GetUserSizeType() == GridUnitType.Auto)
			{
				num3++;
			}
			m_ppTempDefinitions[i - spanStart] = item;
		}
		if (num <= num4)
		{
			return;
		}
		if (num <= num6)
		{
			double num9 = num;
			SortDefinitionsForSpanPreferredDistribution(m_ppTempDefinitions, spanCount);
			for (int j = 0; j < num3; j++)
			{
				DefinitionBase definitionBase = m_ppTempDefinitions[j];
				num9 -= definitionBase.GetEffectiveMinSize();
			}
			for (int k = num3; k < spanCount; k++)
			{
				DefinitionBase definitionBase2 = m_ppTempDefinitions[k];
				double num10 = Math.Min(num9 / (double)(spanCount - k), definitionBase2.GetPreferredSize());
				definitionBase2.UpdateEffectiveMinSize(num10);
				num9 -= num10;
				if (num9 < 1.1920928955078125E-07)
				{
					break;
				}
			}
			return;
		}
		if (num <= num5)
		{
			double num11 = num - num6;
			SortDefinitionsForSpanMaxSizeDistribution(m_ppTempDefinitions, spanCount);
			int num12 = spanCount - num3;
			for (int l = 0; l < spanCount; l++)
			{
				DefinitionBase definitionBase3 = m_ppTempDefinitions[l];
				double preferredSize2 = definitionBase3.GetPreferredSize();
				preferredSize2 = ((l >= num12) ? (preferredSize2 + num11 / (double)(spanCount - l)) : (preferredSize2 + num11 / (double)(num12 - l)));
				double preferredSize3 = definitionBase3.GetPreferredSize();
				preferredSize2 = Math.Min(preferredSize2, definitionBase3.GetSizeCache());
				definitionBase3.UpdateEffectiveMinSize(preferredSize2);
				num11 -= definitionBase3.GetEffectiveMinSize() - preferredSize3;
				if (num11 < 1.1920928955078125E-07)
				{
					break;
				}
			}
			return;
		}
		double num13 = num / (double)spanCount;
		if (num13 < num7 && num7 - num13 > 1.1920928955078125E-07)
		{
			double num14 = num7 * (double)spanCount - num5;
			double num15 = num - num5;
			for (int m = 0; m < spanCount; m++)
			{
				DefinitionBase definitionBase4 = m_ppTempDefinitions[m];
				double num16 = (num7 - definitionBase4.GetSizeCache()) * num15 / num14;
				definitionBase4.UpdateEffectiveMinSize(definitionBase4.GetSizeCache() + num16);
			}
		}
		else
		{
			for (int n = 0; n < spanCount; n++)
			{
				m_ppTempDefinitions[n].UpdateEffectiveMinSize(num13);
			}
		}
	}

	private CellUnitTypes GetLengthTypeForRange(DefinitionCollectionBase definitions, int start, int count)
	{
		CellUnitTypes cellUnitTypes = CellUnitTypes.None;
		int num = start + count - 1;
		do
		{
			DefinitionBase item = definitions.GetItem(num);
			switch (item.GetEffectiveUnitType())
			{
			case GridUnitType.Auto:
				cellUnitTypes |= CellUnitTypes.Auto;
				break;
			case GridUnitType.Pixel:
				cellUnitTypes |= CellUnitTypes.Pixel;
				break;
			case GridUnitType.Star:
				cellUnitTypes |= CellUnitTypes.Star;
				break;
			}
		}
		while (num > 0 && --num >= start);
		return cellUnitTypes;
	}

	private double GetAvailableSizeForRange(DefinitionCollectionBase definitions, int start, int count, double spacing)
	{
		double num = 0.0;
		int num2 = start + count - 1;
		do
		{
			DefinitionBase item = definitions.GetItem(num2);
			num += ((item.GetEffectiveUnitType() == GridUnitType.Auto) ? item.GetEffectiveMinSize() : item.GetMeasureArrangeSize());
		}
		while (num2 > 0 && --num2 >= start);
		return num + spacing * (double)(count - 1);
	}

	private double GetFinalSizeForRange(DefinitionCollectionBase definitions, int start, int count, double spacing)
	{
		double num = 0.0;
		int num2 = start + count - 1;
		do
		{
			DefinitionBase item = definitions.GetItem(num2);
			num += item.GetMeasureArrangeSize();
		}
		while (num2 > 0 && --num2 >= start);
		return num + spacing * (double)(count - 1);
	}

	private double GetDesiredInnerSize(DefinitionCollectionBase definitions)
	{
		double num = 0.0;
		for (int i = 0; i < definitions.Count; i++)
		{
			DefinitionBase item = definitions.GetItem(i);
			num += item.GetEffectiveMinSize();
		}
		return num;
	}

	private void ResolveStar(DefinitionCollectionBase definitions, double availableSize)
	{
		int cStarDefinitions = 0;
		double pTotalResolvedSize = 0.0;
		double num = availableSize;
		EnsureTempDefinitionsStorage(definitions.Count);
		for (int i = 0; i < definitions.Count; i++)
		{
			DefinitionBase item = definitions.GetItem(i);
			if (item.GetEffectiveUnitType() == GridUnitType.Star)
			{
				m_ppTempDefinitions[cStarDefinitions++] = item;
				double userSizeValue = item.GetUserSizeValue();
				if (userSizeValue < 1.1920928955078125E-07)
				{
					item.SetMeasureArrangeSize(0.0);
					item.SetSizeCache(0.0);
					continue;
				}
				userSizeValue = Math.Min(userSizeValue, 2147483647.0);
				item.SetMeasureArrangeSize(userSizeValue);
				double num2 = Math.Min(2147483647.0, Math.Max(item.GetEffectiveMinSize(), item.GetUserMaxSize()));
				item.SetSizeCache(num2 / userSizeValue);
			}
			else if (item.GetEffectiveUnitType() == GridUnitType.Pixel)
			{
				pTotalResolvedSize += item.GetMeasureArrangeSize();
			}
			else if (item.GetEffectiveUnitType() == GridUnitType.Auto)
			{
				pTotalResolvedSize += item.GetEffectiveMinSize();
			}
		}
		if (GetUseLayoutRounding())
		{
			pTotalResolvedSize = LayoutRound(pTotalResolvedSize);
			num = LayoutRound(num);
		}
		DistributeStarSpace(m_ppTempDefinitions, cStarDefinitions, num - pTotalResolvedSize, ref pTotalResolvedSize);
	}

	private void DistributeStarSpace(DefinitionBase[] ppStarDefinitions, int cStarDefinitions, double availableSize, ref double pTotalResolvedSize)
	{
		double num = 0.0;
		if (cStarDefinitions < 0)
		{
			return;
		}
		SortDefinitionsForStarSizeDistribution(ppStarDefinitions, cStarDefinitions);
		double num2 = 0.0;
		int num3 = cStarDefinitions;
		while (num3 > 0)
		{
			num3--;
			num2 += ppStarDefinitions[num3].GetMeasureArrangeSize();
			ppStarDefinitions[num3].SetSizeCache(num2);
		}
		for (num3 = 0; num3 < cStarDefinitions; num3++)
		{
			double num4 = 0.0;
			double measureArrangeSize = ppStarDefinitions[num3].GetMeasureArrangeSize();
			if (measureArrangeSize == 0.0)
			{
				num4 = ppStarDefinitions[num3].GetEffectiveMinSize();
			}
			else
			{
				num4 = Math.Max(availableSize - num, 0.0) * (measureArrangeSize / ppStarDefinitions[num3].GetSizeCache());
				num4 = Math.Max(ppStarDefinitions[num3].GetEffectiveMinSize(), Math.Min(num4, ppStarDefinitions[num3].GetUserMaxSize()));
			}
			if (GetUseLayoutRounding())
			{
				num4 = LayoutRound(num4);
			}
			ppStarDefinitions[num3].SetMeasureArrangeSize(num4);
			num += num4;
		}
		pTotalResolvedSize += num;
	}

	private void EnsureTempDefinitionsStorage(int minCount)
	{
		if (m_ppTempDefinitions == null || m_cTempDefinitions < minCount)
		{
			m_ppTempDefinitions = new DefinitionBase[minCount];
			m_cTempDefinitions = minCount;
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		LockDefinitions();
		Size result = InnerMeasureOverride(availableSize);
		UnlockDefinitions();
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Size InnerMeasureOverride(Size availableSize)
	{
		Size size = Border.HelperGetCombinedThickness(this);
		Size availableSize2 = new Size(availableSize.Width - size.Width, availableSize.Height - size.Height);
		Size result = default(Size);
		if (IsWithoutRowAndColumnDefinitions())
		{
			IEnumerable<UIElement> children = GetChildren();
			if (children != null)
			{
				IEnumerator<UIElement> enumerator = children.GetEnumerator();
				while (enumerator.MoveNext())
				{
					UIElement current = enumerator.Current;
					MeasureElement(current, availableSize2);
					Size desiredSize = current.DesiredSize;
					result.Width = Math.Max(result.Width, desiredSize.Width);
					result.Height = Math.Max(result.Height, desiredSize.Height);
				}
			}
		}
		else
		{
			if (HasGridFlags(GridFlags.DefinitionsChanged))
			{
				ClearGridFlags(GridFlags.DefinitionsChanged);
				InitializeDefinitionStructure();
			}
			ValidateDefinitions(m_pRows, availableSize2.Height == double.PositiveInfinity);
			ValidateDefinitions(m_pColumns, availableSize2.Width == double.PositiveInfinity);
			double rowSpacing = RowSpacing;
			double columnSpacing = ColumnSpacing;
			double num = rowSpacing * (double)(m_pRows.Count - 1);
			double num2 = columnSpacing * (double)(m_pColumns.Count - 1);
			availableSize2.Width -= num2;
			availableSize2.Height -= num;
			UIElementCollection unsortedChildren = GetUnsortedChildren();
			int count = unsortedChildren.Count;
			CellCacheStackVector cellCacheVector = new CellCacheStackVector(count);
			CellGroups cellGroups = ValidateCells(unsortedChildren, ref cellCacheVector);
			MeasureCellsGroup(cellGroups.group1, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
			if (!HasGridFlags(GridFlags.HasAutoRowsAndStarColumn))
			{
				if (HasGridFlags(GridFlags.HasStarRows))
				{
					ResolveStar(m_pRows, availableSize2.Height);
				}
				MeasureCellsGroup(cellGroups.group2, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
				if (HasGridFlags(GridFlags.HasStarColumns))
				{
					ResolveStar(m_pColumns, availableSize2.Width);
				}
				MeasureCellsGroup(cellGroups.group3, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
			}
			else if (cellGroups.group2 > count)
			{
				if (HasGridFlags(GridFlags.HasStarColumns))
				{
					ResolveStar(m_pColumns, availableSize2.Width);
				}
				MeasureCellsGroup(cellGroups.group3, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
				if (HasGridFlags(GridFlags.HasStarRows))
				{
					ResolveStar(m_pRows, availableSize2.Height);
				}
			}
			else
			{
				MeasureCellsGroup(cellGroups.group2, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: true, ref cellCacheVector);
				if (HasGridFlags(GridFlags.HasStarColumns))
				{
					ResolveStar(m_pColumns, availableSize2.Width);
				}
				MeasureCellsGroup(cellGroups.group3, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
				if (HasGridFlags(GridFlags.HasStarRows))
				{
					ResolveStar(m_pRows, availableSize2.Height);
				}
				MeasureCellsGroup(cellGroups.group2, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: true, forceRowToInfinity: false, ref cellCacheVector);
			}
			MeasureCellsGroup(cellGroups.group4, count, rowSpacing, columnSpacing, ignoreColumnDesiredSize: false, forceRowToInfinity: false, ref cellCacheVector);
			result.Width = GetDesiredInnerSize(m_pColumns) + num2;
			result.Height = GetDesiredInnerSize(m_pRows) + num;
		}
		result.Width += size.Width;
		result.Height += size.Height;
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		LockDefinitions();
		Size result = InnerArrangeOverride(finalSize);
		m_ppTempDefinitions = null;
		m_cTempDefinitions = 0;
		UnlockDefinitions();
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Size InnerArrangeOverride(Size finalSize)
	{
		Rect finalRect = Border.HelperGetInnerRect(this, finalSize);
		if (IsWithoutRowAndColumnDefinitions())
		{
			IEnumerable<UIElement> children = GetChildren();
			if (children != null)
			{
				IEnumerator<UIElement> enumerator = children.GetEnumerator();
				while (enumerator.MoveNext())
				{
					UIElement current = enumerator.Current;
					Size desiredSize = current.DesiredSize;
					finalRect.Width = Math.Max(finalRect.Width, desiredSize.Width);
					finalRect.Height = Math.Max(finalRect.Height, desiredSize.Height);
					ArrangeElement(current, finalRect);
				}
			}
		}
		else
		{
			if (HasGridFlags(GridFlags.DefinitionsChanged))
			{
				return default(Size);
			}
			double num = RowSpacing;
			double num2 = ColumnSpacing;
			double num3 = num * (double)(m_pRows.Count - 1);
			double num4 = num2 * (double)(m_pColumns.Count - 1);
			SetFinalSize(m_pRows, finalRect.Height - num3);
			SetFinalSize(m_pColumns, finalRect.Width - num4);
			UIElementCollection unsortedChildren = GetUnsortedChildren();
			int count = unsortedChildren.Count;
			for (int i = 0; i < count; i++)
			{
				UIElement uIElement = unsortedChildren[i];
				DefinitionBase rowNoRef = GetRowNoRef(uIElement);
				DefinitionBase columnNoRef = GetColumnNoRef(uIElement);
				int columnIndex = GetColumnIndex(uIElement);
				int rowIndex = GetRowIndex(uIElement);
				Rect finalRect2 = default(Rect);
				finalRect2.X = columnNoRef.GetFinalOffset() + finalRect.X + num2 * (double)columnIndex;
				finalRect2.Y = rowNoRef.GetFinalOffset() + finalRect.Y + num * (double)rowIndex;
				finalRect2.Width = GetFinalSizeForRange(m_pColumns, columnIndex, GetColumnSpanAdjusted(uIElement), num2);
				finalRect2.Height = GetFinalSizeForRange(m_pRows, rowIndex, GetRowSpanAdjusted(uIElement), num);
				ArrangeElement(uIElement, finalRect2);
			}
		}
		return finalSize;
	}

	private void SetFinalSize(DefinitionCollectionBase definitions, double finalSize)
	{
		double pTotalResolvedSize = 0.0;
		DefinitionBase definitionBase = null;
		DefinitionBase definitionBase2 = null;
		int cStarDefinitions = 0;
		int num = definitions.Count;
		EnsureTempDefinitionsStorage(definitions.Count);
		for (int i = 0; i < definitions.Count; i++)
		{
			DefinitionBase item = definitions.GetItem(i);
			if (item.GetUserSizeType() == GridUnitType.Star)
			{
				m_ppTempDefinitions[cStarDefinitions++] = item;
				double userSizeValue = item.GetUserSizeValue();
				if (userSizeValue < 1.1920928955078125E-07)
				{
					item.SetMeasureArrangeSize(0.0);
					item.SetSizeCache(0.0);
					continue;
				}
				userSizeValue = Math.Min(userSizeValue, 2147483647.0);
				item.SetMeasureArrangeSize(userSizeValue);
				double num2 = Math.Min(2147483647.0, Math.Max(item.GetEffectiveMinSize(), item.GetUserMaxSize()));
				item.SetSizeCache(num2 / userSizeValue);
				continue;
			}
			bool useLayoutRounding = GetUseLayoutRounding();
			double val = 0.0;
			double val2 = (useLayoutRounding ? LayoutRound(item.GetUserMaxSize()) : item.GetUserMaxSize());
			m_ppTempDefinitions[--num] = item;
			switch (item.GetUserSizeType())
			{
			case GridUnitType.Pixel:
				val = (useLayoutRounding ? LayoutRound(item.GetUserSizeValue()) : item.GetUserSizeValue());
				break;
			case GridUnitType.Auto:
				val = item.GetEffectiveMinSize();
				break;
			}
			item.SetMeasureArrangeSize(Math.Max(item.GetEffectiveMinSize(), Math.Min(val, val2)));
			pTotalResolvedSize += item.GetMeasureArrangeSize();
		}
		DistributeStarSpace(m_ppTempDefinitions, cStarDefinitions, finalSize - pTotalResolvedSize, ref pTotalResolvedSize);
		if (pTotalResolvedSize > finalSize && XcpAbsF(pTotalResolvedSize - finalSize) > 1.1920928955078125E-07)
		{
			SortDefinitionsForOverflowSizeDistribution(m_ppTempDefinitions, definitions.Count);
			double num3 = finalSize - pTotalResolvedSize;
			for (int j = 0; j < definitions.Count; j++)
			{
				double val3 = m_ppTempDefinitions[j].GetMeasureArrangeSize() + num3 / (double)(definitions.Count - j);
				val3 = Math.Max(val3, m_ppTempDefinitions[j].GetEffectiveMinSize());
				val3 = Math.Min(val3, m_ppTempDefinitions[j].GetMeasureArrangeSize());
				num3 -= val3 - m_ppTempDefinitions[j].GetMeasureArrangeSize();
				m_ppTempDefinitions[j].SetMeasureArrangeSize(val3);
			}
		}
		definitionBase = definitions.GetItem(0);
		definitionBase.SetFinalOffset(0.0);
		for (int k = 0; k < definitions.Count - 1; k++)
		{
			definitionBase2 = definitions.GetItem(k + 1);
			definitionBase2.SetFinalOffset(definitionBase.GetFinalOffset() + definitionBase.GetMeasureArrangeSize());
			definitionBase = definitionBase2;
			definitionBase2 = null;
		}
	}

	private void SortDefinitionsForSpanPreferredDistribution(IList<DefinitionBase> ppDefinitions, int cDefinitions)
	{
		for (int i = 1; i < cDefinitions; i++)
		{
			DefinitionBase definitionBase = ppDefinitions[i];
			int num;
			for (num = i; num > 0; num--)
			{
				if (definitionBase.GetUserSizeType() == GridUnitType.Auto)
				{
					if (ppDefinitions[num - 1].GetUserSizeType() == GridUnitType.Auto && definitionBase.GetEffectiveMinSize() >= ppDefinitions[num - 1].GetEffectiveMinSize())
					{
						break;
					}
				}
				else if (ppDefinitions[num - 1].GetUserSizeType() == GridUnitType.Auto || definitionBase.GetPreferredSize() >= ppDefinitions[num - 1].GetPreferredSize())
				{
					break;
				}
				ppDefinitions[num] = ppDefinitions[num - 1];
			}
			ppDefinitions[num] = definitionBase;
		}
	}

	private void SortDefinitionsForSpanMaxSizeDistribution(IList<DefinitionBase> ppDefinitions, int cDefinitions)
	{
		for (int i = 1; i < cDefinitions; i++)
		{
			DefinitionBase definitionBase = ppDefinitions[i];
			int num;
			for (num = i; num > 0; num--)
			{
				if (definitionBase.GetUserSizeType() == GridUnitType.Auto)
				{
					if (ppDefinitions[num - 1].GetUserSizeType() != 0 || definitionBase.GetSizeCache() >= ppDefinitions[num - 1].GetSizeCache())
					{
						break;
					}
				}
				else if (ppDefinitions[num - 1].GetUserSizeType() != 0 && definitionBase.GetSizeCache() >= ppDefinitions[num - 1].GetSizeCache())
				{
					break;
				}
				ppDefinitions[num] = ppDefinitions[num - 1];
			}
			ppDefinitions[num] = definitionBase;
		}
	}

	private void SortDefinitionsForOverflowSizeDistribution(IList<DefinitionBase> ppDefinitions, int cDefinitions)
	{
		for (int i = 1; i < cDefinitions; i++)
		{
			DefinitionBase definitionBase = ppDefinitions[i];
			int num = i;
			while (num > 0 && !(definitionBase.GetMeasureArrangeSize() - definitionBase.GetEffectiveMinSize() >= ppDefinitions[num - 1].GetMeasureArrangeSize() - ppDefinitions[num - 1].GetEffectiveMinSize()))
			{
				ppDefinitions[num] = ppDefinitions[num - 1];
				num--;
			}
			ppDefinitions[num] = definitionBase;
		}
	}

	private void SortDefinitionsForStarSizeDistribution(IList<DefinitionBase> ppDefinitions, int cDefinitions)
	{
		for (int i = 1; i < cDefinitions; i++)
		{
			DefinitionBase definitionBase = ppDefinitions[i];
			int num = i;
			while (num > 0 && !(definitionBase.GetSizeCache() >= ppDefinitions[num - 1].GetSizeCache()))
			{
				ppDefinitions[num] = ppDefinitions[num - 1];
				num--;
			}
			ppDefinitions[num] = definitionBase;
		}
	}

	private bool IsWithoutRowAndColumnDefinitions()
	{
		if (m_pRowDefinitions == null || m_pRowDefinitions.Count == 0)
		{
			if (m_pColumnDefinitions != null)
			{
				return m_pColumnDefinitions.Count == 0;
			}
			return true;
		}
		return false;
	}

	[Conditional("DEBUG")]
	private static void ASSERT(bool assertion, string message = null)
	{
	}

	private void SetGridFlags(GridFlags mask)
	{
		m_gridFlags |= mask;
	}

	private void ClearGridFlags(GridFlags mask)
	{
		m_gridFlags &= (GridFlags)(byte)(~(int)mask);
	}

	private bool HasGridFlags(GridFlags mask)
	{
		return (m_gridFlags & mask) == mask;
	}

	internal void InvalidateDefinitions()
	{
		SetGridFlags(GridFlags.DefinitionsChanged);
		InvalidateMeasure();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private double XcpAbsF(double rValue)
	{
		return Math.Abs(rValue);
	}

	private UIElementCollection GetUnsortedChildren()
	{
		return base.Children;
	}

	private void OnBackgroundSizingChanged(DependencyPropertyChangedEventArgs e)
	{
		OnBackgroundSizingChangedInnerPanel(e);
	}

	private static Brush GetBorderBrushDefaultValue()
	{
		return SolidColorBrushHelper.Transparent;
	}

	private void OnBorderBrushPropertyChanged(Brush oldValue, Brush newValue)
	{
		base.BorderBrushInternal = newValue;
		OnBorderBrushChanged(oldValue, newValue);
	}

	private static Thickness GetBorderThicknessDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnBorderThicknessPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.BorderThicknessInternal = newValue;
		OnBorderThicknessChanged(oldValue, newValue);
	}

	private static Thickness GetPaddingDefaultValue()
	{
		return Thickness.Empty;
	}

	private void OnPaddingPropertyChanged(Thickness oldValue, Thickness newValue)
	{
		base.PaddingInternal = newValue;
		OnPaddingChanged(oldValue, newValue);
	}

	private static CornerRadius GetCornerRadiusDefaultValue()
	{
		return CornerRadius.None;
	}

	private void OnCornerRadiusPropertyChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		base.CornerRadiusInternal = newValue;
		OnCornerRadiusChanged(oldValue, newValue);
	}

	public static int GetRow(UIElement view)
	{
		return GetRowValue(view);
	}

	public static void SetRow(UIElement view, int row)
	{
		SetRowValue(view, row);
	}

	public static int GetColumn(UIElement view)
	{
		return GetColumnValue(view);
	}

	public static void SetColumn(UIElement view, int column)
	{
		SetColumnValue(view, column);
	}

	public static int GetRowSpan(UIElement view)
	{
		return GetRowSpanValue(view);
	}

	public static void SetRowSpan(UIElement view, int rowSpan)
	{
		if (rowSpan <= 0)
		{
			throw new ArgumentException("The value must be above zero", "rowSpan");
		}
		SetRowSpanValue(view, rowSpan);
	}

	public static int GetColumnSpan(UIElement view)
	{
		return GetColumnSpanValue(view);
	}

	public static void SetColumnSpan(UIElement view, int columnSpan)
	{
		if (columnSpan <= 0)
		{
			throw new ArgumentException("The value must be above zero", "columnSpan");
		}
		SetColumnSpanValue(view, columnSpan);
	}

	private static void OnGenericPropertyChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		(dependencyObject as UIElement)?.InvalidateMeasure();
		(dependencyObject as UIElement)?.InvalidateArrange();
	}

	private BackgroundSizing GetBackgroundSizingValue()
	{
		if (!_BackgroundSizingPropertyBackingFieldSet)
		{
			_BackgroundSizingPropertyBackingField = (BackgroundSizing)GetValue(BackgroundSizingProperty);
			_BackgroundSizingPropertyBackingFieldSet = true;
		}
		return _BackgroundSizingPropertyBackingField;
	}

	private void SetBackgroundSizingValue(BackgroundSizing value)
	{
		SetValue(BackgroundSizingProperty, value);
	}

	private static DependencyProperty CreateBackgroundSizingProperty()
	{
		return DependencyProperty.Register("BackgroundSizing", typeof(BackgroundSizing), typeof(Grid), new FrameworkPropertyMetadata((object)BackgroundSizing.InnerBorderEdge, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Grid)instance).OnBackgroundSizingChanged(args);
		}, (BackingFieldUpdateCallback)OnBackgroundSizingBackingFieldUpdate));
	}

	private static void OnBackgroundSizingBackingFieldUpdate(object instance, object newValue)
	{
		Grid grid = instance as Grid;
		grid._BackgroundSizingPropertyBackingField = (BackgroundSizing)newValue;
		grid._BackgroundSizingPropertyBackingFieldSet = true;
	}

	private Brush GetBorderBrushValue()
	{
		if (!_BorderBrushPropertyBackingFieldSet)
		{
			_BorderBrushPropertyBackingField = (Brush)GetValue(BorderBrushProperty);
			_BorderBrushPropertyBackingFieldSet = true;
		}
		return _BorderBrushPropertyBackingField;
	}

	private void SetBorderBrushValue(Brush value)
	{
		SetValue(BorderBrushProperty, value);
	}

	private static DependencyProperty CreateBorderBrushProperty()
	{
		return DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Grid), new FrameworkPropertyMetadata((object)GetBorderBrushDefaultValue(), FrameworkPropertyMetadataOptions.ValueInheritsDataContext, (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Grid)instance).OnBorderBrushPropertyChanged((Brush)args.OldValue, (Brush)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderBrushBackingFieldUpdate));
	}

	private static void OnBorderBrushBackingFieldUpdate(object instance, object newValue)
	{
		Grid grid = instance as Grid;
		grid._BorderBrushPropertyBackingField = (Brush)newValue;
		grid._BorderBrushPropertyBackingFieldSet = true;
	}

	private Thickness GetBorderThicknessValue()
	{
		if (!_BorderThicknessPropertyBackingFieldSet)
		{
			_BorderThicknessPropertyBackingField = (Thickness)GetValue(BorderThicknessProperty);
			_BorderThicknessPropertyBackingFieldSet = true;
		}
		return _BorderThicknessPropertyBackingField;
	}

	private void SetBorderThicknessValue(Thickness value)
	{
		SetValue(BorderThicknessProperty, value);
	}

	private static DependencyProperty CreateBorderThicknessProperty()
	{
		return DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(Grid), new FrameworkPropertyMetadata((object)GetBorderThicknessDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Grid)instance).OnBorderThicknessPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnBorderThicknessBackingFieldUpdate));
	}

	private static void OnBorderThicknessBackingFieldUpdate(object instance, object newValue)
	{
		Grid grid = instance as Grid;
		grid._BorderThicknessPropertyBackingField = (Thickness)newValue;
		grid._BorderThicknessPropertyBackingFieldSet = true;
	}

	private Thickness GetPaddingValue()
	{
		if (!_PaddingPropertyBackingFieldSet)
		{
			_PaddingPropertyBackingField = (Thickness)GetValue(PaddingProperty);
			_PaddingPropertyBackingFieldSet = true;
		}
		return _PaddingPropertyBackingField;
	}

	private void SetPaddingValue(Thickness value)
	{
		SetValue(PaddingProperty, value);
	}

	private static DependencyProperty CreatePaddingProperty()
	{
		return DependencyProperty.Register("Padding", typeof(Thickness), typeof(Grid), new FrameworkPropertyMetadata((object)GetPaddingDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Grid)instance).OnPaddingPropertyChanged((Thickness)args.OldValue, (Thickness)args.NewValue);
		}, (BackingFieldUpdateCallback)OnPaddingBackingFieldUpdate));
	}

	private static void OnPaddingBackingFieldUpdate(object instance, object newValue)
	{
		Grid grid = instance as Grid;
		grid._PaddingPropertyBackingField = (Thickness)newValue;
		grid._PaddingPropertyBackingFieldSet = true;
	}

	private CornerRadius GetCornerRadiusValue()
	{
		if (!_CornerRadiusPropertyBackingFieldSet)
		{
			_CornerRadiusPropertyBackingField = (CornerRadius)GetValue(CornerRadiusProperty);
			_CornerRadiusPropertyBackingFieldSet = true;
		}
		return _CornerRadiusPropertyBackingField;
	}

	private void SetCornerRadiusValue(CornerRadius value)
	{
		SetValue(CornerRadiusProperty, value);
	}

	private static DependencyProperty CreateCornerRadiusProperty()
	{
		return DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Grid), new FrameworkPropertyMetadata((object)GetCornerRadiusDefaultValue(), (PropertyChangedCallback)delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			((Grid)instance).OnCornerRadiusPropertyChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
		}, (BackingFieldUpdateCallback)OnCornerRadiusBackingFieldUpdate));
	}

	private static void OnCornerRadiusBackingFieldUpdate(object instance, object newValue)
	{
		Grid grid = instance as Grid;
		grid._CornerRadiusPropertyBackingField = (CornerRadius)newValue;
		grid._CornerRadiusPropertyBackingFieldSet = true;
	}

	private static int GetRowValue(UIElement instance)
	{
		if (instance != null)
		{
			if (!instance.__Grid_RowPropertyBackingFieldSet)
			{
				instance.__Grid_RowPropertyBackingField = (int)instance.GetValue(RowProperty);
				instance.__Grid_RowPropertyBackingFieldSet = true;
			}
			return instance.__Grid_RowPropertyBackingField;
		}
		return (int)instance.GetValue(RowProperty);
	}

	private static void SetRowValue(UIElement instance, int value)
	{
		instance.SetValue(RowProperty, value);
	}

	private static DependencyProperty CreateRowProperty()
	{
		return DependencyProperty.RegisterAttached("Row", typeof(int), typeof(Grid), new FrameworkPropertyMetadata(0, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnGenericPropertyChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Grid_RowPropertyBackingField = (int)instance.GetValue(RowProperty);
				uIElement.__Grid_RowPropertyBackingFieldSet = true;
			}
		}));
	}

	private static int GetColumnValue(UIElement instance)
	{
		if (instance != null)
		{
			if (!instance.__Grid_ColumnPropertyBackingFieldSet)
			{
				instance.__Grid_ColumnPropertyBackingField = (int)instance.GetValue(ColumnProperty);
				instance.__Grid_ColumnPropertyBackingFieldSet = true;
			}
			return instance.__Grid_ColumnPropertyBackingField;
		}
		return (int)instance.GetValue(ColumnProperty);
	}

	private static void SetColumnValue(UIElement instance, int value)
	{
		instance.SetValue(ColumnProperty, value);
	}

	private static DependencyProperty CreateColumnProperty()
	{
		return DependencyProperty.RegisterAttached("Column", typeof(int), typeof(Grid), new FrameworkPropertyMetadata(0, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnGenericPropertyChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Grid_ColumnPropertyBackingField = (int)instance.GetValue(ColumnProperty);
				uIElement.__Grid_ColumnPropertyBackingFieldSet = true;
			}
		}));
	}

	private static int GetRowSpanValue(UIElement instance)
	{
		if (instance != null)
		{
			if (!instance.__Grid_RowSpanPropertyBackingFieldSet)
			{
				instance.__Grid_RowSpanPropertyBackingField = (int)instance.GetValue(RowSpanProperty);
				instance.__Grid_RowSpanPropertyBackingFieldSet = true;
			}
			return instance.__Grid_RowSpanPropertyBackingField;
		}
		return (int)instance.GetValue(RowSpanProperty);
	}

	private static void SetRowSpanValue(UIElement instance, int value)
	{
		instance.SetValue(RowSpanProperty, value);
	}

	private static DependencyProperty CreateRowSpanProperty()
	{
		return DependencyProperty.RegisterAttached("RowSpan", typeof(int), typeof(Grid), new FrameworkPropertyMetadata(1, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnGenericPropertyChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Grid_RowSpanPropertyBackingField = (int)instance.GetValue(RowSpanProperty);
				uIElement.__Grid_RowSpanPropertyBackingFieldSet = true;
			}
		}));
	}

	private static int GetColumnSpanValue(UIElement instance)
	{
		if (instance != null)
		{
			if (!instance.__Grid_ColumnSpanPropertyBackingFieldSet)
			{
				instance.__Grid_ColumnSpanPropertyBackingField = (int)instance.GetValue(ColumnSpanProperty);
				instance.__Grid_ColumnSpanPropertyBackingFieldSet = true;
			}
			return instance.__Grid_ColumnSpanPropertyBackingField;
		}
		return (int)instance.GetValue(ColumnSpanProperty);
	}

	private static void SetColumnSpanValue(UIElement instance, int value)
	{
		instance.SetValue(ColumnSpanProperty, value);
	}

	private static DependencyProperty CreateColumnSpanProperty()
	{
		return DependencyProperty.RegisterAttached("ColumnSpan", typeof(int), typeof(Grid), new FrameworkPropertyMetadata(1, delegate(DependencyObject instance, DependencyPropertyChangedEventArgs args)
		{
			OnGenericPropertyChanged(instance, args);
		}, delegate(DependencyObject instance, object newValue)
		{
			if (instance is UIElement uIElement)
			{
				uIElement.__Grid_ColumnSpanPropertyBackingField = (int)instance.GetValue(ColumnSpanProperty);
				uIElement.__Grid_ColumnSpanPropertyBackingFieldSet = true;
			}
		}));
	}
}
