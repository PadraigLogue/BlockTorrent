using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

namespace DecentralizedBandwidth
{
    partial class Program
    {
        public static void Main()
        {
            string x = MetaInfoServer.grabPublicIP().Result;
            byte[] file = File.ReadAllBytes("lol.txt");
            Transaction t = new Transaction("lol.txt", file, "Padraig", DateTime.Now.AddDays(1));
        }
        
    }
}
