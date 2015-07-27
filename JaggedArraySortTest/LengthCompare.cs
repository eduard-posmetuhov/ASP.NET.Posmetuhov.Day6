using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortTest
{


    public class LengthCompare : JaggedArraySot.ICustomCompare
    {
        public int CustomCompare(int[] first, int[] second)
        {
            if (first.Length > second.Length)
                return 1;
            else if (first.Length < second.Length)
                return -1;
            else
                return 0;
        }       
    }
}
