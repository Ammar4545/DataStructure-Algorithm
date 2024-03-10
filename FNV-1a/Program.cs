using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FNV_1a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hash hash
                = new Hash();
            hash.Hash32("Ammar.Dev");
        }
        public class Hash
        {
            public uint Hash32(string strForHash)
            {
                uint offSetBasis = 2166136261;
                uint FNVPrime = 16777619;

                byte[] data = Encoding.ASCII.GetBytes(strForHash);
                uint hash = offSetBasis;
                for (int i = 0; i <data.Length; i++)
                {
                    hash = hash ^ data[i];
                    hash = hash * FNVPrime;
                    
                }
                Console.WriteLine($"string to be hashes => {strForHash} + hash => {hash} + {hash.ToString("X")}");
                return hash;
                
            }
        }
    }
}
