using Process_Lister;
using System.Collections.Generic;

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
