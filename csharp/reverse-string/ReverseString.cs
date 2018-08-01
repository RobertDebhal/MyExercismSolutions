using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        string buf = "";
        for (int i=input.Length-1;i>=0;i--) {
            if (input=="") {
                break;
            }
            buf+=input[i];
        };
        return buf;
    }
}