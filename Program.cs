using System;

namespace RationFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1,0,2,4);
            Fraction b = new Fraction(1,0,3,4);
            
            Console.WriteLine(a-b);
        }
    }
}