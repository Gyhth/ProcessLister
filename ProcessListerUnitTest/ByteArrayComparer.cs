using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessListerUnitTest
{
    class ByteArrayComparer
    {
        public bool Compare(byte[] x, byte[] y)
        {

            /*  if (x.Length != y.Length) { return false; }
             int longest = (x.Length > y.Length) ? x.Length : y.Length;

              for(int i = 0; i < longest; i++)
              {
                  if (x[i] != y[i])
                  {
                      return false;
                  }
                  return true;
              }
          }*/
            return StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
        }
    }
}
