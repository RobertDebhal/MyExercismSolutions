using System;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        List<int> factors = new List<int>();
        for (int i=1; i<=number; i++) {
            if (number%i==0)
                factors.Add(i);
        }

        string speak = "";

        if (factors.Contains(3))
            speak += "Pling";
        if (factors.Contains(5))
            speak += "Plang";
        if (factors.Contains(7))
            speak += "Plong";
        if (!(factors.Contains(3) || factors.Contains(5) || factors.Contains(7)))
            speak = number.ToString();
        return speak;
    }
}