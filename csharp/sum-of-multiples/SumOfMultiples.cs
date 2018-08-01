using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        for (int i=1; i<max; i++) {
            bool matched = false;
            foreach (int n in multiples) {
                if (i%n==0 && !matched) {
                    sum += i;
                    matched = true;
                }
            }
        }
        return sum;
    }
}