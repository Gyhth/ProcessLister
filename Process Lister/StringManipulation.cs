using System;
using System.Text;

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
