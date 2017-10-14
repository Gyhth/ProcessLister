using System;
using System.Runtime.InteropServices;

namespace Process_Lister
{
    [Serializable]
    class SerializedProcessEncrypted
    {
        private String name;
        public String Name { get => name; set => name = value; }
    }
}
