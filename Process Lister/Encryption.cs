using System.Security.Cryptography;

namespace Process_Lister
{
    class Encryption
    {
        private SHA256 shaM;

        public Encryption() {
            SHA256 shaM = new SHA256Managed();
        }

        public byte[] generateHash(string input)
        {
            StringManipulation stringManipulator = new StringManipulation();
            return shaM.ComputeHash(stringManipulator.ToByteArray(input));
        }
    }
}
