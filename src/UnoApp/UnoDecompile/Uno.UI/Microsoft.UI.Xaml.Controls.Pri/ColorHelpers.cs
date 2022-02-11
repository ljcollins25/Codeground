using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Uno.UI.Helpers.WinUI;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;

namespace Microsoft.UI.Xaml.Controls.Primitives;

internal static class ColorHelpers
{
	public enum IncrementDirection
	{
		Lower,
		Higher
	}

	public enum IncrementAmount
	{
		Small,
		Large
	}

	public const int CheckerSize = 4;

	public static Hsv IncrementColorChannel(Hsv originalHsv, ColorPickerHsvChannel channel, IncrementDirection direction, IncrementAmount amount, bool shouldWrap, double minBound, double maxBound)
	{
		Hsv result = originalHsv;
		if (amount == IncrementAmount.Small || !DownlevelHelper.ToDisplayNameExists())
		{
			result.S *= 100.0;
			result.V *= 100.0;
			ref double h = ref result.H;
			double num = 0.0;
			switch (channel)
			{
			case ColorPickerHsvChannel.Hue:
				h = ref result.H;
				num = ((amount == IncrementAmount.Small) ? 1 : 30);
				break;
			case ColorPickerHsvChannel.Saturation:
				h = ref result.S;
				num = ((amount == IncrementAmount.Small) ? 1 : 10);
				break;
			case ColorPickerHsvChannel.Value:
				h = ref result.V;
				num = ((amount == IncrementAmount.Small) ? 1 : 10);
				break;
			default:
				throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
			}
			double num2 = h;
			h += ((direction == IncrementDirection.Lower) ? (0.0 - num) : num);
			if (h < minBound)
			{
				h = ((shouldWrap && num2 == minBound) ? maxBound : minBound);
			}
			if (h > maxBound)
			{
				h = ((shouldWrap && num2 == maxBound) ? minBound : maxBound);
			}
			result.S /= 100.0;
			result.V /= 100.0;
		}
		else
		{
			if (channel == ColorPickerHsvChannel.Saturation || channel == ColorPickerHsvChannel.Value)
			{
				minBound /= 100.0;
				maxBound /= 100.0;
			}
			result = FindNextNamedColor(originalHsv, channel, direction, shouldWrap, minBound, maxBound);
		}
		return result;
	}

	public static Hsv FindNextNamedColor(Hsv originalHsv, ColorPickerHsvChannel channel, IncrementDirection direction, bool shouldWrap, double minBound, double maxBound)
	{
		Hsv hsv = originalHsv;
		string text = ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(originalHsv)));
		string text2 = text;
		double num = 0.0;
		ref double h = ref hsv.H;
		double num2 = 0.0;
		switch (channel)
		{
		case ColorPickerHsvChannel.Hue:
			num = originalHsv.H;
			h = ref hsv.H;
			num2 = 1.0;
			break;
		case ColorPickerHsvChannel.Saturation:
			num = originalHsv.S;
			h = ref hsv.S;
			num2 = 0.01;
			break;
		case ColorPickerHsvChannel.Value:
			num = originalHsv.V;
			h = ref hsv.V;
			num2 = 0.01;
			break;
		default:
			throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
		}
		bool flag = true;
		while (text2 == text)
		{
			double num3 = h;
			h += (double)((direction != 0) ? 1 : (-1)) * num2;
			bool flag2 = false;
			if (h > maxBound)
			{
				if (!shouldWrap)
				{
					h = maxBound;
					flag = false;
					text2 = ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(hsv)));
					break;
				}
				h = minBound;
				flag2 = true;
			}
			else if (h < minBound)
			{
				if (!shouldWrap)
				{
					h = minBound;
					flag = false;
					text2 = ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(hsv)));
					break;
				}
				h = maxBound;
				flag2 = true;
			}
			if (!flag2 && num3 != num && Math.Sign(h - num) != Math.Sign(num3 - num))
			{
				flag = false;
				break;
			}
			text2 = ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(hsv)));
		}
		if (flag)
		{
			Hsv hsv2 = hsv;
			Hsv hsv3 = hsv2;
			double num4 = 0.0;
			string text3 = text2;
			ref double h2 = ref hsv2.H;
			ref double h3 = ref hsv3.H;
			double num5 = 0.0;
			switch (channel)
			{
			case ColorPickerHsvChannel.Hue:
				h2 = ref hsv2.H;
				h3 = ref hsv3.H;
				num5 = 360.0;
				break;
			case ColorPickerHsvChannel.Saturation:
				h2 = ref hsv2.S;
				h3 = ref hsv3.S;
				num5 = 1.0;
				break;
			case ColorPickerHsvChannel.Value:
				h2 = ref hsv2.V;
				h3 = ref hsv3.V;
				num5 = 1.0;
				break;
			default:
				throw new InvalidOperationException("Invalid ColorPickerHsvChannel.");
			}
			while (text2 == text3)
			{
				h3 += (double)((direction != 0) ? 1 : (-1)) * num2;
				if (h3 > maxBound)
				{
					if (!shouldWrap)
					{
						h3 = maxBound;
						break;
					}
					h3 = minBound;
					num4 = maxBound - minBound;
				}
				else if (h3 < minBound)
				{
					if (!shouldWrap)
					{
						h3 = minBound;
						break;
					}
					h3 = maxBound;
					num4 = minBound - maxBound;
				}
				text3 = ColorHelper.ToDisplayName(ColorConversion.ColorFromRgba(ColorConversion.HsvToRgb(hsv3)));
			}
			h = (h2 + h3 + num4) / 2.0;
			double num6;
			for (num6 = Math.Abs(h); num6 > num2; num6 -= num2)
			{
			}
			h -= num6;
			while (h < minBound)
			{
				h += num5;
			}
			while (h > maxBound)
			{
				h -= num5;
			}
		}
		return hsv;
	}

	public static double IncrementAlphaChannel(double originalAlpha, IncrementDirection direction, IncrementAmount amount, bool shouldWrap, double minBound, double maxBound)
	{
		originalAlpha *= 100.0;
		originalAlpha = ((amount == IncrementAmount.Small) ? (originalAlpha + (double)((direction != 0) ? 1 : (-1)) * 1.0) : ((direction != 0) ? (Math.Floor((originalAlpha + 10.0) / 10.0) * 10.0) : (Math.Ceiling((originalAlpha - 10.0) / 10.0) * 10.0)));
		if (originalAlpha < minBound)
		{
			originalAlpha = (shouldWrap ? maxBound : minBound);
		}
		if (originalAlpha > maxBound)
		{
			originalAlpha = (shouldWrap ? minBound : maxBound);
		}
		return originalAlpha / 100.0;
	}

	public static async void CreateCheckeredBackgroundAsync(int width, int height, Color checkerColor, ArrayList<byte> bgraCheckeredPixelData, IAsyncAction asyncActionToAssign, CoreDispatcher dispatcherHelper, Action<WriteableBitmap> completedFunction)
	{
		if (width == 0 || height == 0)
		{
			return;
		}
		bgraCheckeredPixelData.Capacity = width * height * 4;
		await Task.Run(delegate
		{
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (((j / 4 + i / 4) % 2 == 0) ? true : false)
					{
						bgraCheckeredPixelData.Add(0);
						bgraCheckeredPixelData.Add(0);
						bgraCheckeredPixelData.Add(0);
						bgraCheckeredPixelData.Add(0);
					}
					else
					{
						bgraCheckeredPixelData.Add((byte)(checkerColor.B * checkerColor.A / 255));
						bgraCheckeredPixelData.Add((byte)(checkerColor.G * checkerColor.A / 255));
						bgraCheckeredPixelData.Add((byte)(checkerColor.R * checkerColor.A / 255));
						bgraCheckeredPixelData.Add(checkerColor.A);
					}
				}
			}
		});
		await dispatcherHelper.RunAsync(CoreDispatcherPriority.Normal, delegate
		{
			WriteableBitmap obj = CreateBitmapFromPixelData(width, height, bgraCheckeredPixelData);
			completedFunction?.Invoke(obj);
		});
	}

	public static WriteableBitmap CreateBitmapFromPixelData(int pixelWidth, int pixelHeight, ArrayList<byte> bgraPixelData)
	{
		WriteableBitmap writeableBitmap = new WriteableBitmap(pixelWidth, pixelHeight);
		using Stream stream = writeableBitmap.PixelBuffer.AsStream();
		stream.Write(bgraPixelData.Array, 0, bgraPixelData.Count);
		return writeableBitmap;
	}

	public static void CancelAsyncAction(IAsyncAction action)
	{
		if (action != null && action.Status == AsyncStatus.Started)
		{
			action.Cancel();
		}
	}
}
