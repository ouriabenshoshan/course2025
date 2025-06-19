using System;

class NumberSpeller 
{
    public static void counter()
    {
        int[] arr_ahadot = new int[] { 0, 3, 3, 5, 4, 4, 3, 5, 5, 4 };
        int[] arr_ahadot_2 = new int[] { 3, 6, 6, 8, 8, 7, 7, 9, 8, 8 };
        int[] arr_asarot = new int[] { 6, 6, 5, 5, 5, 7, 6, 6 };

        int ans = 0;
        foreach (int i in arr_ahadot) ans += i;
        foreach (int i in arr_ahadot_2) ans += i;

        foreach (int i in arr_asarot)
        {
            foreach (int j in arr_ahadot)
            {
                ans += i + j;
            }
        }
        ans+= (3+7); //for one hundred
        Console.WriteLine($"Total count of letters in numbers from 1 to : {ans}");
    }


}