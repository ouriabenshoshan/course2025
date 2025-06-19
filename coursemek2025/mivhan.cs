using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Calc
{
    private static char[] Peolot = new char[] { '!', '^', '*', '/', '+', '%' };
    private static char[] Digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','.','e','-','p'};
    private static char[] Brackets = new char[] { '(', ')' };

    private static string[] Func = new string[] { };
    public static void Main()
    {

        Console.WriteLine("ENTER YOUR EXPRESSION:");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No input provided.");
            return;
        }
        input = "(" + input + ")";
        List<char> arr = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ' ') continue;
            else if (input[i] == '-')
            {
                if (arr[arr.Count - 1] == '-') arr.RemoveAt(arr.Count - 1);
                else if (Digits.Contains(arr[arr.Count - 1])) { arr.Add('+'); arr.Add('-'); }
                else arr.Add('-');
            }
            else if (input[i] == '+')
            {
                if (arr[arr.Count - 1] == '+' || arr[arr.Count - 1] == '-') continue;
                else if (!Digits.Contains(arr[arr.Count - 1])) continue;
                else arr.Add('+');
            }
            else arr.Add(input[i]);

        }
        try
        {
            (bool ret_bo, int ret_in) = isOkForm(arr);
            if (ret_bo)
            {
                Console.WriteLine($"your expression is equale to {EvaluteExpression(arr, ret_in)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    public static (bool,int) isOkForm(List<char> expression)
    {
        for (int i = 0; i < expression.Count; i++)
        {
            if (Peolot.Contains(expression[i]))
            {
                if (i == 0 || i == expression.Count - 1)
                {
                    throw new Exception($"Error: Operator '{expression[i]}' cannot be at the start or end of the expression.");
                }
                else if (Peolot.Contains(expression[i - 1]) || Peolot.Contains(expression[i + 1]))
                {
                    throw new Exception("Error: Two operators cannot be adjacent.");
                }
                else if (expression[i - 1] == '(')
                {
                    throw new Exception($"Error: Operator '{expression[i]}' cannot come after a bracket (.");
                }
                else if (expression[i + 1] == ')') {
                    throw new Exception($"Error: Operator '{expression[i]}' cannot come before a bracket ).");
                }
            }
            else if (!Digits.Contains(expression[i]) && !(expression[i] == '(' || expression[i] == ')'))
            {
                throw new Exception($"Error: Invalid character '{expression[i]}' in the expression.");
            }
            else if (i != (expression.Count - 1) && expression[i] == '(' && expression[i + 1] == ')')
            {
                throw new Exception("Error: Empty parentheses '()' are not allowed.");
            }
        }

        int er = 0;
        int max_er = 0;
        foreach (char c in expression)
        {
            if (c == '(')
                er++;
            else if (c == ')')
                er--;
            if (er < 0)
                return (false,-1);
            max_er = Math.Max(max_er, er);
        }

        return (er == 0,max_er);
    }

    private static string EvaluteExpression(List<char> expr,int numSteps)
    {  
        bool flag = false;
        List<char> cur_arr = new List<char> { };
        int lb = 0;
        while ((numSteps--)>0)
        {
            for (int idx = 0; idx < expr.Count; idx++)
            {
                char c = expr[idx];

                if (c == '(')
                {
                    cur_arr = new List<char> { };
                    flag = true;
                    lb = idx;
                }
                else if (c == ')')
                {
                    if (flag)
                    {
                        foreach (char peol in Peolot)
                        {
                            for (int i = 0; i < cur_arr.Count; i++)
                            {
                                int n = cur_arr.Count;
                                char cr = cur_arr[i];
                                if (cr == peol)
                                {
                                    int tmpi = i + 1, tmpl, tmpr;
                                    string num1 = "", num2 = "";
                                    while (tmpi < n && Digits.Contains(cur_arr[tmpi]))
                                    {
                                        num2 += cur_arr[tmpi];
                                        tmpi++;
                                    }
                                    tmpr = tmpi - 1;
                                    tmpi = i - 1;
                                    while (tmpi >= 0 && Digits.Contains(cur_arr[tmpi]))
                                    {
                                        num1 += cur_arr[tmpi];
                                        tmpi--;
                                    }
                                    tmpl = tmpi + 1;
                                    var tmp_num1 = num1.ToCharArray();
                                    Array.Reverse(tmp_num1);
                                    num1 = "";
                                    foreach (char ch in tmp_num1) num1 += ch;

                                    string ans = Hishov(num1, peol, num2);
                                    List<char> tmp_arr = new List<char> { };
                                    for (int j = 0; j < tmpl; j++) tmp_arr.Add(cur_arr[j]);
                                    foreach (char a in ans) tmp_arr.Add(a);
                                    i = tmp_arr.Count-1;
                                    for (int j = tmpr + 1; j < n; j++) tmp_arr.Add(cur_arr[j]);
                                    cur_arr = tmp_arr;
                                }
                            }
                        }
                        List<char> tmp_exp = new List<char> { };
                        for (int j = 0; j < lb; j++) tmp_exp.Add(expr[j]);
                        foreach (char ch in cur_arr) tmp_exp.Add(ch);
                        int lr = idx;
                        idx = tmp_exp.Count-1;
                        for (int j = lr + 1; j < expr.Count; j++) tmp_exp.Add(expr[j]);
                        expr = tmp_exp;
                    }
                    flag = false;
                }
                else cur_arr.Add(c);
            }
        }
        string ret_ans = "";
        foreach (char ch in expr) ret_ans += ch;
        return ret_ans;
    }
    private static string Hishov(string x, char p, string y)
    {
                // Try parsing the strings to numbers
        if (!double.TryParse(x, out double num1) || !double.TryParse(y, out double num2))
        {
            throw new ArgumentException("Invalid number format");
        }

        // Perform calculation
        double result = p switch
        {
            '+' => num1 + num2,
            '-' => num1 - num2,
            '*' => num1 * num2,
            '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Division by zero"),
            '^' => Math.Pow(num1, num2),
            '%' => num1%num2,
            _   => throw new InvalidOperationException($"Unsupported operator: {p}")
        };

        // Return result as string
        return result.ToString();
    }
}