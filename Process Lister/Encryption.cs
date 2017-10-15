using System.Security.Cryptography;

namespace Process_Lister
{
    public class Encryption
    {
        private SHA256 shaM;

        public Encryption() {
            shaM = new SHA256Managed();
        }

        public byte[] generateHash(string input)
        {
            StringManipulation stringManipulator = new StringManipulation();
            return shaM.ComputeHash(stringManipulator.ToByteArray(input));
        }
    }
}
