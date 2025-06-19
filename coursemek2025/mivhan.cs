using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Calc
{
    private static char[] Peolot = new char[] { '*', '/', '+', '-', '^', '%', '!' };
    private static char[] Digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private static char[] Brackets = new char[] { '(', ')' };
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
        string[] sarr = input.Split(" ");
        List<char> arr = new List<char>();
        foreach (string s in sarr)
        {
            char[] chars = s.ToCharArray();
            foreach (char c in chars) arr.Add(c);
        }
        try
        {
            if (isOkForm(arr))
            {
                Console.WriteLine($"your expression is equale to {EvaluteExpression(arr)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    public static bool isOkForm(List<char> expression)
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
                else if (expression[i - 1] == '(' || expression[i - 1] == ')')
                {
                    throw new Exception($"Error: Operator '{expression[i]}' cannot come after a bracket.");
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

        foreach (char c in expression)
        {
            if (c == '(')
                er++;
            else if (c == ')')
                er--;
            if (er < 0)
                return false;
        }

        return er == 0;
    }

    private static double EvaluteExpression(List<char> expr)
    {
        // List<(int, int, int)> bark = new List<(int, int, int)> { };
        bool[] flag = new bool[expr.Count];
        int cur_er = 0, i = 0, lb = 0;
        List<char> cur_arr = new List<char> { };
        foreach (char c in expr)
        {

            flag[i] = false;
            if (c == '(')
            {
                cur_er++;
                lb = i;
                cur_arr = new List<char> { };
                
            }
            else if (c == ')')
            {
                cur_er--;

            }
            i++;
        }
        return 0f;
    }
}