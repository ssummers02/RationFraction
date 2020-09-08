using System;

namespace RationFraction
{
    public class Fraction
    {
        private int sign; // значение дроби(+,-) 
        private int intPart; // целая часть 
        private int numerator; //числитель дроби 
        private int denominator; //знаменатель 

        // метод преобразования дроби в смешанный вид 
        void GetMixedView()
        {
            GetIntPart(); // выделение целой части числа
            Cancellation(); // сокращение дроби
        }

        // метод сокращения дроби 
        void Cancellation()
        {
            if (numerator != 0)
            {
                int m = denominator,
                    n = numerator,
                    ost = m % n;

                while (ost != 0)
                {
                    m = n;
                    n = ost;
                    ost = m % n;
                }

                int nod = n;

                if (nod != 1)
                {
                    numerator /= nod;
                    denominator /= nod;
                }
            }
        }

        // метод отделения целой части 
        void GetIntPart()
        {
            if (numerator >= denominator)
            {
                intPart = numerator / denominator;
                numerator %= denominator;
            }
        }

        public Fraction()
        {
            intPart = 0;
            numerator = 0;
            denominator = 1;
            sign = 1;
        }

        // деструктор
        ~Fraction()
        {
            Console.WriteLine("Дробь " + this + " уничтожена.");
        }

        // деструктор должен относиться к закрытым элементам класса 
        public Fraction(int sign, int intPart, int numerator, int denominator)
        {
            this.sign = sign;
            this.intPart = intPart;
            this.numerator = numerator;
            this.denominator = denominator;
            GetMixedView();
        }

        // метод сложения дробей 
        public static Fraction operator +(Fraction obj1, Fraction obj2)
        {
            Fraction temp = new Fraction();
            temp.numerator = obj1.sign * (obj1.intPart * obj1.denominator +
                                          obj1.numerator) * obj2.denominator + obj2.sign * (obj2.intPart *
                obj2.denominator + obj2.numerator) * obj1.denominator;
            temp.denominator = obj1.denominator * obj2.denominator;

            if (temp.numerator < 0)
            {
                temp.numerator *= -1;
                temp.sign = -1;
            }

            temp.GetMixedView();
            return temp;
        }

        // метод сложения числа с дробью 
        public static Fraction operator +(int a, Fraction obj)
        {
            if (a == 0)
                return new Fraction(obj.numerator, obj.denominator,
                    obj.intPart, obj.sign);
            Fraction obj2 = new Fraction(0, 1, Math.Abs(a), a / Math.Abs(a));
            Fraction res = obj + obj2;
            return res;
        }
  public static bool operator >(Fraction obj1, Fraction obj2)
        {
            return !((double) obj1 <= (double) obj2);
        }

        public static bool operator <(Fraction obj1, Fraction obj2)
        {
            return !((double) obj1 >= (double) obj2);
        }

        public static bool operator ==(Fraction obj1, Fraction obj2)
        {
            return !(obj1.sign != obj2.sign || obj1.intPart != obj2.intPart ||
                     obj1.numerator * obj2.denominator !=
                     obj1.denominator * obj2.numerator);
        }

        public static bool operator !=(Fraction obj1, Fraction obj2)
        {
            return !(obj1.sign == obj2.sign) || !(obj1.intPart == obj2.intPart) ||
                   !(obj1.numerator * obj2.denominator ==
                     obj1.denominator * obj2.numerator);
        }

        public static bool operator >=(Fraction obj1, Fraction obj2)
        {
            return !((double) obj1 < (double) obj2);
        }

        public static bool operator <=(Fraction obj1, Fraction obj2)
        {
            return !((double) obj1 > (double) obj2);
        }

        public static Fraction Parse(string str)
        {
            int intPart, numerator, denominator, sign;

            string[] strs = str.Split(' ');
            string[] strs1;
            Fraction res;

            if (strs.Length == 1)
            {
                strs1 = str.Split('/');

                if (strs1.Length == 1)
                {
                    intPart = int.Parse(strs1[0]);
                    if (intPart != 0)
                        res = new Fraction(0, 1, Math.Abs(intPart),
                            intPart / Math.Abs(intPart));
                    else
                        res = new Fraction(0, 1, Math.Abs(intPart), 1);
                    return res;
                }

                numerator = int.Parse(strs1[0]);
                denominator = int.Parse(strs1[1]);
                sign = 1;

                if (numerator < 0)
                {
                    numerator = -numerator;
                    sign = -1;
                }

                res = new Fraction(numerator, denominator, 0, sign);
                res.GetMixedView();
                return res;
            }

            strs1 = strs[1].Split('/');
            intPart = int.Parse(strs[0]);

            if (intPart < 0)
            {
                intPart = -intPart;
                sign = -1;
            }
            else
                sign = 1;

            numerator = int.Parse(strs1[0]);
            denominator = int.Parse(strs1[1]);
            res = new Fraction(numerator, denominator, intPart, sign);
            res.GetMixedView();
            return res;
        }

        public static implicit operator string(Fraction obj)
        {
            string res = "";
            if (obj.sign < 0)
                res = res + "-";
            if (obj.intPart != 0)
                res = res + obj.intPart;
            if (obj.numerator != 0)
                res = res + " " + obj.numerator + "/" + obj.denominator;
            if (obj.intPart == 0 && obj.numerator == 0)
                res = "0";
            return res;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // метод вычитания дробей 
        public static Fraction operator -(Fraction obj1, Fraction obj2)
        {
        }

        // метод вычитания из дроби
        public static Fraction operator -(Fraction obj, int n)
        {
        }

        // метод вычитания дроби из числа
        public static Fraction operator -(int n, Fraction obj)
        {
        }


        // метод умножения дробей 
        public static Fraction operator *(Fraction obj1, Fraction obj2)
        {
        }

        // метод умножения числа с дробью 
        public static Fraction operator *(int n, Fraction obj)
        {
        }

        // метод деления дробей 
        public static Fraction operator /(Fraction obj1, Fraction obj2)
        {
        }

        // метод деления числа на дробью 
        public static Fraction operator /(int n, Fraction obj)
        {
        }

        // метод дробь на число
        public static Fraction operator /(Fraction obj, int n)
        {
        }

        // изменнение знака дроби на противоположный
        public static Fraction operator -(Fraction obj1)
        {
        }

        // превращение в дробь
        public static explicit operator double(Fraction obj)
        {
        }

      
    }
}