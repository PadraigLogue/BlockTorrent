using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace DecentralizedBandwidth
{
    class Hashing
    {
        public static string computeByteHash(byte[] bites)
        {
            byte[] sha256 = null;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                sha256 = mySHA256.ComputeHash(bites);
            }
            //Convert that SHA256 hash to a 20 byte long hexadecimal format. 
            //hex 4 bits per char, 
            StringBuilder result = new StringBuilder(40);
            for (int i = 0; i < 20; i++)
            {
                result.Append(sha256[i].ToString("x2")); //lowercase
            }
            return result.ToString();
        }
    }
}
