using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortTest
{   
    public class ABSCompare : JaggedArraySot.ICustomCompare 
    {
        public int CustomCompare(int[] first, int[] second)
        {
            int MaxAbsFirst = MaxAbs(first);
            int MaxAbsSecond = MaxAbs(second);
            if (MaxAbsFirst > MaxAbsSecond)
                return 1;
            else if (MaxAbsFirst < MaxAbsSecond)
                return -1;
            else
                return 0;
        }

        private int MaxAbs(int[] arr)
        {
            int MaxAbsValue = Math.Abs(arr[0]);
            foreach (int a in arr)
                if (Math.Abs(a) > MaxAbsValue)
                    MaxAbsValue = Math.Abs(a);
            return MaxAbsValue;
        }
    }
}
