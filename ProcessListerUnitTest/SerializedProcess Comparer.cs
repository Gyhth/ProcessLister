using Process_Lister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessListerUnitTest
{
    class SerializedProcess_Comparer : Comparer<SerializedProcess>
    {
            public override int Compare(SerializedProcess x, SerializedProcess y)
            {
                // compare the two mountains
                // for the purpose of this tests they are considered equal when their identifiers (names) match
                return x.Name.CompareTo(y.Name);
            }
    }
}
