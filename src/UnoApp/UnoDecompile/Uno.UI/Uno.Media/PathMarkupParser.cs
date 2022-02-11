using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace Uno.Media;

public class PathMarkupParser : IDisposable
{
	private enum Command
	{
		None,
		FillRule,
		Move,
		Line,
		HorizontalLine,
		VerticalLine,
		CubicBezierCurve,
		QuadraticBezierCurve,
		SmoothCubicBezierCurve,
		SmoothQuadraticBezierCurve,
		Arc,
		Close
	}

	private static readonly Dictionary<char, Command> s_commands = new Dictionary<char, Command>
	{
		{
			'F',
			Command.FillRule
		},
		{
			'M',
			Command.Move
		},
		{
			'L',
			Command.Line
		},
		{
			'H',
			Command.HorizontalLine
		},
		{
			'V',
			Command.VerticalLine
		},
		{
			'Q',
			Command.QuadraticBezierCurve
		},
		{
			'T',
			Command.SmoothQuadraticBezierCurve
		},
		{
			'C',
			Command.CubicBezierCurve
		},
		{
			'S',
			Command.SmoothCubicBezierCurve
		},
		{
			'A',
			Command.Arc
		},
		{
			'Z',
			Command.Close
		}
	};

	private StreamGeometryContext _geometryContext;

	private Point _currentPoint;

	private Point? _beginFigurePoint;

	private Point? _previousControlPoint;

	private bool _isOpen;

	private bool _isDisposed;

	public PathMarkupParser(StreamGeometryContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		_geometryContext = context;
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				_geometryContext = null;
			}
			_isDisposed = true;
		}
	}

	private static Point MirrorControlPoint(Point controlPoint, Point center)
	{
		Point point = controlPoint - center;
		return center + -point;
	}

	public void Parse(string s, ref FillRule fillRule)
	{
		ReadOnlySpan<char> span = s.AsSpan();
		_currentPoint = default(Point);
		Command command;
		bool relative;
		while (!span.IsEmpty && ReadCommand(ref span, out command, out relative))
		{
			bool flag = true;
			do
			{
				if (!flag)
				{
					span = ReadSeparator(span);
				}
				switch (command)
				{
				case Command.FillRule:
					fillRule = GetFillRule(ref span);
					break;
				case Command.Move:
					AddMove(ref span, relative);
					break;
				case Command.Line:
					AddLine(ref span, relative);
					break;
				case Command.HorizontalLine:
					AddHorizontalLine(ref span, relative);
					break;
				case Command.VerticalLine:
					AddVerticalLine(ref span, relative);
					break;
				case Command.CubicBezierCurve:
					AddCubicBezierCurve(ref span, relative);
					break;
				case Command.QuadraticBezierCurve:
					AddQuadraticBezierCurve(ref span, relative);
					break;
				case Command.SmoothCubicBezierCurve:
					AddSmoothCubicBezierCurve(ref span, relative);
					break;
				case Command.SmoothQuadraticBezierCurve:
					AddSmoothQuadraticBezierCurve(ref span, relative);
					break;
				case Command.Arc:
					AddArc(ref span, relative);
					break;
				case Command.Close:
					CloseFigure();
					break;
				default:
					throw new NotSupportedException("Unsupported command");
				case Command.None:
					break;
				}
				flag = false;
			}
			while (PeekArgument(span));
		}
		if (_isOpen)
		{
			_geometryContext.SetClosedState(closed: false);
		}
	}

	private void CreateFigure()
	{
		if (_isOpen)
		{
			_geometryContext.SetClosedState(closed: false);
		}
		_geometryContext.BeginFigure(_currentPoint, isFilled: true, isClosed: false);
		_beginFigurePoint = _currentPoint;
		_isOpen = true;
	}

	private FillRule GetFillRule(ref ReadOnlySpan<char> span)
	{
		if (!ReadArgument(ref span, out var argument) || argument.Length != 1)
		{
			throw new InvalidDataException("Invalid fill rule.");
		}
		return argument[0] switch
		{
			'0' => FillRule.EvenOdd, 
			'1' => FillRule.Nonzero, 
			_ => throw new InvalidDataException("Invalid fill rule"), 
		};
	}

	private void CloseFigure()
	{
		if (_isOpen)
		{
			_geometryContext.SetClosedState(closed: true);
			if (_beginFigurePoint.HasValue)
			{
				_currentPoint = _beginFigurePoint.Value;
				_beginFigurePoint = null;
			}
		}
		_previousControlPoint = null;
		_isOpen = false;
	}

	private void AddMove(ref ReadOnlySpan<char> span, bool relative)
	{
		Point point = (_currentPoint = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span)));
		CreateFigure();
		while (PeekArgument(span))
		{
			span = ReadSeparator(span);
			AddLine(ref span, relative);
		}
	}

	private void AddLine(ref ReadOnlySpan<char> span, bool relative)
	{
		_currentPoint = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.LineTo(_currentPoint, isStroked: true, isSmoothJoin: false);
	}

	private void AddHorizontalLine(ref ReadOnlySpan<char> span, bool relative)
	{
		_currentPoint = (relative ? new Point(_currentPoint.X + ReadDouble(ref span), _currentPoint.Y) : _currentPoint.WithX(ReadDouble(ref span)));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.LineTo(_currentPoint, isStroked: true, isSmoothJoin: false);
	}

	private void AddVerticalLine(ref ReadOnlySpan<char> span, bool relative)
	{
		_currentPoint = (relative ? new Point(_currentPoint.X, _currentPoint.Y + ReadDouble(ref span)) : _currentPoint.WithY(ReadDouble(ref span)));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.LineTo(_currentPoint, isStroked: true, isSmoothJoin: false);
	}

	private void AddCubicBezierCurve(ref ReadOnlySpan<char> span, bool relative)
	{
		Point point = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		span = ReadSeparator(span);
		Point point2 = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		_previousControlPoint = point2;
		span = ReadSeparator(span);
		Point point3 = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.BezierTo(point, point2, point3, isStroked: true, isSmoothJoin: false);
		_currentPoint = point3;
	}

	private void AddQuadraticBezierCurve(ref ReadOnlySpan<char> span, bool relative)
	{
		Point point = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		_previousControlPoint = point;
		span = ReadSeparator(span);
		Point point2 = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.QuadraticBezierTo(point, point2, isStroked: true, isSmoothJoin: false);
		_currentPoint = point2;
	}

	private void AddSmoothCubicBezierCurve(ref ReadOnlySpan<char> span, bool relative)
	{
		Point point = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		span = ReadSeparator(span);
		Point point2 = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (_previousControlPoint.HasValue)
		{
			_previousControlPoint = MirrorControlPoint(_previousControlPoint.Value, _currentPoint);
		}
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.BezierTo(_previousControlPoint ?? _currentPoint, point, point2, isStroked: true, isSmoothJoin: false);
		_previousControlPoint = point;
		_currentPoint = point2;
	}

	private void AddSmoothQuadraticBezierCurve(ref ReadOnlySpan<char> span, bool relative)
	{
		Point point = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (_previousControlPoint.HasValue)
		{
			_previousControlPoint = MirrorControlPoint(_previousControlPoint.Value, _currentPoint);
		}
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.QuadraticBezierTo(_previousControlPoint ?? _currentPoint, point, isStroked: true, isSmoothJoin: false);
		_currentPoint = point;
	}

	private void AddArc(ref ReadOnlySpan<char> span, bool relative)
	{
		Size size = ReadSize(ref span);
		span = ReadSeparator(span);
		double rotationAngle = ReadDouble(ref span);
		span = ReadSeparator(span);
		bool isLargeArc = ReadBool(ref span);
		span = ReadSeparator(span);
		SweepDirection sweepDirection = (ReadBool(ref span) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise);
		span = ReadSeparator(span);
		Point point = (relative ? ReadRelativePoint(ref span, _currentPoint) : ReadPoint(ref span));
		if (!_isOpen)
		{
			CreateFigure();
		}
		_geometryContext.ArcTo(point, size, rotationAngle, isLargeArc, sweepDirection, isStroked: true, isSmoothJoin: false);
		_currentPoint = point;
		_previousControlPoint = null;
	}

	private static bool PeekArgument(ReadOnlySpan<char> span)
	{
		span = SkipWhitespace(span);
		if (!span.IsEmpty)
		{
			if (span[0] != ',' && span[0] != '-' && span[0] != '.')
			{
				return char.IsDigit(span[0]);
			}
			return true;
		}
		return false;
	}

	private static bool ReadArgument(ref ReadOnlySpan<char> remaining, out ReadOnlySpan<char> argument)
	{
		remaining = SkipWhitespace(remaining);
		if (remaining.IsEmpty)
		{
			argument = ReadOnlySpan<char>.Empty;
			return false;
		}
		bool flag = false;
		int i = 0;
		if (remaining[i] == '-')
		{
			i++;
		}
		for (; i < remaining.Length && char.IsNumber(remaining[i]); i++)
		{
			flag = true;
		}
		if (i < remaining.Length && remaining[i] == '.')
		{
			flag = false;
			i++;
		}
		for (; i < remaining.Length && char.IsNumber(remaining[i]); i++)
		{
			flag = true;
		}
		if (i < remaining.Length && (remaining[i] == 'E' || remaining[i] == 'e'))
		{
			flag = false;
			i++;
			if (remaining[i] == '-' || remaining[i] == '+')
			{
				for (i++; i < remaining.Length && char.IsNumber(remaining[i]); i++)
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			argument = ReadOnlySpan<char>.Empty;
			return false;
		}
		argument = remaining.Slice(0, i);
		remaining = remaining.Slice(i);
		return true;
	}

	private static ReadOnlySpan<char> ReadSeparator(ReadOnlySpan<char> span)
	{
		span = SkipWhitespace(span);
		if (!span.IsEmpty && span[0] == ',')
		{
			span = span.Slice(1);
		}
		return span;
	}

	private static ReadOnlySpan<char> SkipWhitespace(ReadOnlySpan<char> span)
	{
		int i;
		for (i = 0; i < span.Length && char.IsWhiteSpace(span[i]); i++)
		{
		}
		return span.Slice(i);
	}

	private bool ReadBool(ref ReadOnlySpan<char> span)
	{
		span = SkipWhitespace(span);
		if (span.IsEmpty)
		{
			throw new InvalidDataException("Cannot read bool from empty span.");
		}
		char c = span[0];
		span = span.Slice(1);
		return c switch
		{
			'0' => false, 
			'1' => true, 
			_ => throw new InvalidDataException("Invalid bool rule"), 
		};
	}

	private double ReadDouble(ref ReadOnlySpan<char> span)
	{
		if (!ReadArgument(ref span, out var argument))
		{
			throw new InvalidDataException("Invalid double value");
		}
		return double.Parse(argument.ToString(), CultureInfo.InvariantCulture);
	}

	private Size ReadSize(ref ReadOnlySpan<char> span)
	{
		double width = ReadDouble(ref span);
		span = ReadSeparator(span);
		double height = ReadDouble(ref span);
		return new Size(width, height);
	}

	private Point ReadPoint(ref ReadOnlySpan<char> span)
	{
		double x = ReadDouble(ref span);
		span = ReadSeparator(span);
		double y = ReadDouble(ref span);
		return new Point(x, y);
	}

	private Point ReadRelativePoint(ref ReadOnlySpan<char> span, Point origin)
	{
		double num = ReadDouble(ref span);
		span = ReadSeparator(span);
		double num2 = ReadDouble(ref span);
		return new Point(origin.X + num, origin.Y + num2);
	}

	private bool ReadCommand(ref ReadOnlySpan<char> span, out Command command, out bool relative)
	{
		span = SkipWhitespace(span);
		if (span.IsEmpty)
		{
			command = Command.None;
			relative = false;
			return false;
		}
		char c = span[0];
		if (!s_commands.TryGetValue(char.ToUpperInvariant(c), out command))
		{
			throw new InvalidDataException("Unexpected path command '" + c + "'.");
		}
		relative = char.IsLower(c);
		span = span.Slice(1);
		return true;
	}
}
