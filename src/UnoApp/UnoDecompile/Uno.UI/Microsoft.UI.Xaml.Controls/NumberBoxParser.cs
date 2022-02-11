using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.Foundation.Metadata;
using Windows.Globalization.NumberFormatting;

namespace Microsoft.UI.Xaml.Controls;

internal class NumberBoxParser
{
	private static string c_numberBoxOperators = "+-*/^";

	private static List<MathToken> GetTokens(string input, INumberParser numberParser)
	{
		List<MathToken> list = new List<MathToken>();
		bool flag = true;
		while (input.Length > 0)
		{
			char c = input[0];
			if (c != ' ')
			{
				if (flag)
				{
					if (c == '(')
					{
						list.Add(new MathToken(MathTokenType.Parenthesis, c));
					}
					else
					{
						var (d, num) = GetNextNumber(input, numberParser);
						if (num <= 0)
						{
							return new List<MathToken>();
						}
						list.Add(new MathToken(MathTokenType.Numeric, d));
						input = input.Substring(num - 1);
						flag = false;
					}
				}
				else if (c_numberBoxOperators.IndexOf(c) != -1)
				{
					list.Add(new MathToken(MathTokenType.Operator, c));
					flag = true;
				}
				else
				{
					if (c != ')')
					{
						return new List<MathToken>();
					}
					list.Add(new MathToken(MathTokenType.Parenthesis, c));
				}
			}
			input = input.Substring(1);
		}
		return list;
	}

	private static (double, int) GetNextNumber(string input, INumberParser numberParser)
	{
		Regex regex = new Regex("^-?([^-+/*\\(\\)\\^\\s]+)");
		Match match = regex.Match(input);
		if (match.Success)
		{
			int length = match.Groups[0].Length;
			double result;
			double? num = (ApiInformation.IsTypePresent(numberParser?.GetType().FullName) ? numberParser.ParseDouble(input.Substring(0, length)) : (double.TryParse(input.Substring(0, length), out result) ? new double?(result) : null));
			if (num.HasValue)
			{
				return (num.Value, length);
			}
		}
		return (double.NaN, 0);
	}

	private static int GetPrecedenceValue(char c)
	{
		int result = 0;
		switch (c)
		{
		case '*':
		case '/':
			result = 1;
			break;
		case '^':
			result = 2;
			break;
		}
		return result;
	}

	private static List<MathToken> ConvertInfixToPostfix(List<MathToken> infixTokens)
	{
		List<MathToken> list = new List<MathToken>();
		Stack<MathToken> stack = new Stack<MathToken>();
		foreach (MathToken infixToken in infixTokens)
		{
			if (infixToken.Type == MathTokenType.Numeric)
			{
				list.Add(infixToken);
			}
			else if (infixToken.Type == MathTokenType.Operator)
			{
				while (stack.Count != 0)
				{
					MathToken mathToken = stack.Peek();
					if (mathToken.Type == MathTokenType.Parenthesis || GetPrecedenceValue(mathToken.Char) < GetPrecedenceValue(infixToken.Char))
					{
						break;
					}
					list.Add(stack.Peek());
					stack.Pop();
				}
				stack.Push(infixToken);
			}
			else
			{
				if (infixToken.Type != MathTokenType.Parenthesis)
				{
					continue;
				}
				if (infixToken.Char == '(')
				{
					stack.Push(infixToken);
					continue;
				}
				while (stack.Count != 0 && stack.Peek().Char != '(')
				{
					list.Add(stack.Peek());
					stack.Pop();
				}
				if (stack.Count == 0)
				{
					return new List<MathToken>();
				}
				stack.Pop();
			}
		}
		while (stack.Count != 0)
		{
			if (stack.Peek().Type == MathTokenType.Parenthesis)
			{
				return new List<MathToken>();
			}
			list.Add(stack.Peek());
			stack.Pop();
		}
		return list;
	}

	private static double? ComputePostfixExpression(List<MathToken> tokens)
	{
		Stack<double> stack = new Stack<double>();
		foreach (MathToken token in tokens)
		{
			if (token.Type == MathTokenType.Operator)
			{
				if (stack.Count < 2)
				{
					return null;
				}
				double num = stack.Peek();
				stack.Pop();
				double num2 = stack.Peek();
				stack.Pop();
				double item;
				switch (token.Char)
				{
				case '-':
					item = num2 - num;
					break;
				case '+':
					item = num + num2;
					break;
				case '*':
					item = num * num2;
					break;
				case '/':
					if (num == 0.0)
					{
						return double.NaN;
					}
					item = num2 / num;
					break;
				case '^':
					item = Math.Pow(num2, num);
					break;
				default:
					return null;
				}
				stack.Push(item);
			}
			else if (token.Type == MathTokenType.Numeric)
			{
				stack.Push(token.Value);
			}
		}
		if (stack.Count != 1)
		{
			return null;
		}
		return stack.Peek();
	}

	public static double? Compute(string expr, INumberParser numberParser)
	{
		List<MathToken> tokens = GetTokens(expr, numberParser);
		if (tokens.Count > 0)
		{
			List<MathToken> list = ConvertInfixToPostfix(tokens);
			if (list.Count > 0)
			{
				return ComputePostfixExpression(list);
			}
		}
		return null;
	}
}
