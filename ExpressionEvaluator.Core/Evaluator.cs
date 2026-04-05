using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExpressionEvaluator.Core
{
    public class Evaluator
    {
        public static double Evaluate(string expression)
        {
            try
            {
                var postfix = InfixToPostfix(expression);
                return EvaluatePostfix(postfix);
            }
            catch (Exception ex)
            {
                throw new Exception($"Evaluation error: {ex.Message}");
            }
        }

        private static string InfixToPostfix(string infix)
        {
            string output = "";
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];

                // If digit or decimal point, read complete number
                if (char.IsDigit(c) || c == '.')
                {
                    string number = "";
                    while (i < infix.Length && (char.IsDigit(infix[i]) || infix[i] == '.'))
                    {
                        number += infix[i];
                        i++;
                    }
                    output += number + " ";
                    i--;
                }
                // If operator
                else if (IsOperator(c))
                {
                    if (c == '(')
                    {
                        operators.Push(c);
                    }
                    else if (c == ')')
                    {
                        while (operators.Count > 0 && operators.Peek() != '(')
                        {
                            output += operators.Pop() + " ";
                        }
                        if (operators.Count > 0 && operators.Peek() == '(')
                            operators.Pop();
                    }
                    else
                    {
                        while (operators.Count > 0 && Priority(c) <= Priority(operators.Peek()))
                        {
                            output += operators.Pop() + " ";
                        }
                        operators.Push(c);
                    }
                }
            }

            while (operators.Count > 0)
            {
                output += operators.Pop() + " ";
            }

            return output.Trim();
        }

        private static double EvaluatePostfix(string postfix)
        {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfix.Split(' ');

            foreach (string token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                }
                else if (token.Length == 1 && IsOperator(token[0]))
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result = token[0] switch
                    {
                        '+' => a + b,
                        '-' => a - b,
                        '*' => a * b,
                        '/' => a / b,
                        '^' => Math.Pow(a, b),
                        _ => throw new Exception($"Invalid operator: {token}")
                    };
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '(' || c == ')';
        }

        private static int Priority(char op)
        {
            return op switch
            {
                '+' => 1,
                '-' => 1,
                '*' => 2,
                '/' => 2,
                '^' => 3,
                '(' => 0,
                _ => 0
            };
        }
    }
}