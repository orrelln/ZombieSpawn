using System;
using System.Collections.Generic;

public class Helper
{
    public static T GetRandomFromList<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            throw new ArgumentException("The list is null or empty.");
        }

        Random rnd = new Random();
        int index = rnd.Next(list.Count);
        return list[index];
    }
}

