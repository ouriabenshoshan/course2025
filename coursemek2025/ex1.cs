using System;

class ex1
{
    public static void PithagoreanTriplet()
    {
        // This function finds the Pythagorean triplet (a, b, c) such that a + b + c = 1000
        // and a^2 + b^2 = c^2.
        for (int a = 1; a <= 1e3; a++)
        {
            for (int b = a + 1; b <= 1e3; b++)
            {
                int c = 1000 - a - b;
                if (c > b && a * a + b * b == c * c)
                {
                    Console.WriteLine($"a: {a}, b: {b}, c: {c}");
                    break;
                }
            }
        }
    }

    public static void PithagoreanTripletMax(int n,int max_val)
    {
        int cnt = 0;
        for (int a = 1; a <= n; a++)
        {
            for (int b = a + 1; b <= n; b++)
            {
                int c = n - a - b;
                if (c > b && a * a + b * b == c * c)
                {
                    Console.WriteLine($"a: {a}, b: {b}, c: {c}");
                    cnt++;
                    if(cnt> max_val)
                        return;
                }
            }
        }
    }

}