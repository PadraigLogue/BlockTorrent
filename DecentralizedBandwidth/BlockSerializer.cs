using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace DecentralizedBandwidth
{
    public class Serializer
    {
        public const int TRANSACTIONSLIST_MAX_SIZE = 1000000;
        public Serializer()
        {
        }
        public string ComputeBlockHash(Serializer instance)
        {
            byte[] sha256 = null;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                //Serialize this class instance
                //to a byte[]
                byte[] classData = SerializeClass(instance);
                sha256 = mySHA256.ComputeHash(classData);

            }
            //Convert that SHA256 hash to a 64 char long hexadecimal format. 
            StringBuilder result = new StringBuilder(sha256.Length * 2);
            for (int i = 0; i < sha256.Length; i++)
            {
                result.Append(sha256[i].ToString("x2")); //lowercase
            }
            return result.ToString();
        }

        public byte[] SerializeClass(object instance)
        {
            byte[] classDataBuffer = null;
            FileStream fs = new FileStream("block.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                //Serialize this instance
                //then read that to the buffer
                formatter.Serialize(fs, instance);

                classDataBuffer = new byte[fs.Length];
                fs.Read(classDataBuffer, 0, (int)fs.Length);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
                fs.Dispose();
                File.Delete("block.dat");
            }

            return classDataBuffer;
        }

        public int getObjectListFilesize(Serializer[] transactions)
        {
            int bytes = 0;
            for (int i = 0; i < transactions.Length; i++)
            {
                int transactionLength = transactions[i].SerializeClass(transactions).Length;
                int newLength = bytes + transactionLength;
                if (newLength > TRANSACTIONSLIST_MAX_SIZE)
                {
                    return bytes;
                }
                else
                {
                    bytes = newLength;
                }
            }

            return bytes;
        }
    }
}
