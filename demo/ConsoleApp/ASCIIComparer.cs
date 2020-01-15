using System.Collections;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class ASCIIComparer : IComparer<string>
    {


        public int Compare(string x, string y)
        {


            int index = 0;
            while (x.Length > index + 1)
            {
                if (y.Length <= index + 1)
                {
                    return 1;
                }

                if (x[index] > y[index])
                {
                    return 1;
                }
                else if (x[index] == y[index])
                {
                    index++;
                }
                else
                {
                    return -1;
                }

            }
            return -1;
        }
    }
}
