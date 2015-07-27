using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
     
    public class NOD
    {
        static const Func<int, int, int> Euclidian = GreatestCommonDivisor;
        static const Func<int, int, int> EuclidianBin = GreatestCommonDivisorBin;
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Допускаються только положительные значения");
            if (b > a)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            if (b == 0) return a;
            return Euclidian(b, a % b);
        }
        public static int GreatestCommonDivisor(int a, int b, int c)
        {
            return Euclidian(Euclidian(a, b), c);
        }
        public static int GreatestCommonDivisor(params int[] arr)
        {
            return arr.Aggregate<int>(Euclidian);
        }


        public static int GreatestCommonDivisorBin(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Числа должны быть положительные");
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * EuclidianBin(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return EuclidianBin(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return EuclidianBin(a, b / 2);
            return EuclidianBin(b, (int)Math.Abs(a - b));
        }
        public static int GreatestCommonDivisorBin(int a, int b, int c)
        {
            return EuclidianBin(EuclidianBin(a, b), b);
        }
        public static int GreatestCommonDivisorBin(params int[] arr)
        {
            return arr.Aggregate<int>(EuclidianBin);
        }
    }
}
