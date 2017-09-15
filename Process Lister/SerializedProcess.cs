using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Lister
{
        [Serializable]
        class SerializedProcess
        {
            private String name;
            public string Name { get => name; set => name = value; }
        }
}
