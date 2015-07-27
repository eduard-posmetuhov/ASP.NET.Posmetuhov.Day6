using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortTest
{
    public class SummCompare : JaggedArraySot.ICustomCompare 
    {                                                        
        public int CustomCompare(int[] first, int[] second)
        {
            int sumFirst = Summ(first);
            int sumSecond = Summ(second);
            if (sumFirst > sumSecond)
                return 1;
            else if (sumFirst < sumSecond)
                return -1;
            else
                return 0;
        }
        private int Summ(int[] arr)
        {
            int sum = 0;
            foreach (int a in arr)
                sum += a;
            return sum;
        }
    }
}
