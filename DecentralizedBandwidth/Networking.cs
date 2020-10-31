using BencodeNET.Parsing;
using BencodeNET.Objects;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace DecentralizedBandwidth
{
    public class MetaInfoServer
    {
        public MetaInfoServer()
        {

        }

        public static async Task<string> grabPublicIP()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string getRequest = await client.GetStringAsync("http://checkip.dyndns.org/");
                    string[] strManipulation = getRequest.Split(':')[1].Split('<');
                    return strManipulation[0];
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
