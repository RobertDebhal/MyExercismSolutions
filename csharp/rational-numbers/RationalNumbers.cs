using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber,Convert.ToDouble(r.x)/Convert.ToDouble(r.y));
    }
}

public static class Simplifier 
{

     public static RationalNumber Simplify(int numerator, int denominator) {
        int a = numerator;
        int b = denominator;
        int Remainder;
        if (numerator==0)
            return new RationalNumber(0,1);
        else
            while( b != 0 )
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }
            int gcd = a;
            int simpNum = numerator/gcd;
            int simpDen = denominator/gcd;
            if (simpNum <0 && simpDen <0)
                return new RationalNumber(Math.Abs(simpNum),Math.Abs(simpDen));
            else if (simpNum <0 && simpDen >0)
                return new RationalNumber(simpNum,simpDen);
            else if (simpNum >0 && simpDen >0)
                return new RationalNumber(simpNum,simpDen);
            else
                return new RationalNumber(-simpNum,Math.Abs(simpDen));
}
}
public struct RationalNumber
{

    public int x, y;

    public RationalNumber(int numerator, int denominator)
    {
        x = numerator;
        y = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        int denominator = this.y * r.y;
        int numerator = this.x * r.y + r.x*this.y;
        return Simplifier.Simplify(numerator,denominator);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        int denominator = this.y * r.y;
        int numerator = this.x * r.y - r.x*this.y;
        return Simplifier.Simplify(numerator,denominator);

    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        int denominator = this.y * r.y;
        int numerator = this.x * r.x;
        return Simplifier.Simplify(numerator,denominator);
    }   

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return r1.Mul(r2);
    }

    public RationalNumber Div(RationalNumber r)
    {
        int denominator = this.y * r.x;
        int numerator = this.x * r.y;
        return Simplifier.Simplify(numerator,denominator);
    }   

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1.Div(r2);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(this.x),Math.Abs(this.y));
    }

    public RationalNumber Reduce()
    {
        return Simplifier.Simplify(this.x,this.y);
    }

    public RationalNumber Exprational(int power)
    {
        int numerator = Convert.ToInt32(Math.Pow(Convert.ToDouble(this.x),power));
        int denominator = Convert.ToInt32(Math.Pow(Convert.ToDouble(this.y),power));
        return Simplifier.Simplify(numerator,denominator);
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(baseNumber,Convert.ToDouble(this.x)/Convert.ToDouble(this.y));
    }
}
