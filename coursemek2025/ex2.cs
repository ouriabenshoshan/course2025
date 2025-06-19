using System;

class ex2
{
    public static void dict_hist(string[] arr)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (string s in arr)
        {
            if (dict.ContainsKey(s))
            {
                dict[s]++;
            }
            else
            {
                dict[s] = 1;
            }
        }

        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }


}