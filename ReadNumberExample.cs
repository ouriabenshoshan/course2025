using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        int number;
        if (int.TryParse(input, out number))
        {
            Console.WriteLine("You entered: " + number);
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
    }
}
