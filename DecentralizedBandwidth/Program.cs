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
            byte[] file = File.ReadAllBytes("file.txt");
            Transaction t = new Transaction("file.txt", file, "Padraig", DateTime.Now.AddDays(1));
        }
        
    }
}
