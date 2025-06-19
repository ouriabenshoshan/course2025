using System;
using System.Runtime.CompilerServices;

class LinqEx
{
    private static Random rnd = new Random();
    public static void ex2()
    {
        int[] number = new int[100];
        for (int i = 0; i < 100; i++) number[i] = rnd.Next(-1000, 1000);
        var positiveNumbers = number.Where(n => n > 0);
        foreach (var n in positiveNumbers)
        {
            Console.WriteLine(n);
        }
    }
    public static void ex3()
    {
        int[] number = new int[100];
        for (int i = 0; i < 100; i++) number[i] = rnd.Next(-1000, 1000);
        var squaredNumbers = number.Select(n => (n, n * n));
        foreach (var (original, squared) in squaredNumbers)
        {
            Console.WriteLine($"Original: {original}, Squared: {squared}");
        }
    }

    public static void ex9()
    {
        int[] numbers = new int[] { 55, 200, 740, 76, 230, 482, 95 };
        var numbers80 = numbers.Where(n => n > 80).ToList();

        foreach (var n in numbers80)
        {
            Console.WriteLine(n);
        }
    }

    static Action<ConsoleKey> OnKeyPressed;
    private static void HandleKeyPress(ConsoleKey key)
    {
        Console.WriteLine($"You pressed: {key}");

        if (key == ConsoleKey.Enter)
        {
            Console.WriteLine("Enter key action triggered!");
        }
    }
    public static void ex10()
    {
        OnKeyPressed += HandleKeyPress;
        int n;
        Console.Write("Input the number of members on the List :");
        while (true)
        {
            var keyInfo = Console.ReadKey(true);
            if (Char.IsDigit(keyInfo.KeyChar))
            {
                n = int.Parse(keyInfo.KeyChar.ToString());
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        Console.WriteLine(n);
        int[] members = new int[n];
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                if (Char.IsDigit(keyInfo.KeyChar))
                {
                    members[i] = int.Parse(keyInfo.KeyChar.ToString());
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            Console.WriteLine($"Member {i} is {members[i]}");
        }
        Console.WriteLine("Input the value above you want to display the members of the List : ");
        int value;
        while (true)
        {
            var keyInfo = Console.ReadKey(true);
            if (Char.IsDigit(keyInfo.KeyChar))
            {
                value = int.Parse(keyInfo.KeyChar.ToString());
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        Console.WriteLine($"the value chosen is {value}");

        var filteredMembers = members.Where(m => m > value).ToList();
        Console.WriteLine($"Members greater than {value}:");
        if (filteredMembers.Count == 0)
        {
            Console.WriteLine("No members greater than the specified value.");
        }
        else
        {
            foreach (var member in filteredMembers)
            {
                Console.WriteLine(member);
            }
            Thread.Sleep(10000); // 10,000 milliseconds = 10 seconds
        }
    }
}