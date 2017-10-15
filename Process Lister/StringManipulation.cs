using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Lister
{
    public class StringManipulation
    {
        public byte[] ToByteArray(String input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

        public String ByteArrayToString(byte[] input)
        {
            return Encoding.ASCII.GetString(input,0,input.Length);
        }
    }
}
