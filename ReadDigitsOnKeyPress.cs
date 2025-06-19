using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Press number keys (0-9). Press 'q' to quit.");
        while (true)
        {
            var keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.KeyChar == 'q')
                break;
            if (char.IsDigit(keyInfo.KeyChar))
            {
                Console.WriteLine($"You pressed number: {keyInfo.KeyChar}");
            }
        }
    }
}
