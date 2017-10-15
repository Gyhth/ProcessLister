using System;

namespace Process_Lister
{
    [Serializable]
    public class SerializedProcess
        {
            private String name;
            public string Name { get => name; set => name = value; }
        }
}
