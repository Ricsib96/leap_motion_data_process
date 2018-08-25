using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelModification
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = File.ReadAllText(@"E:\sensors_lm_k2_02\sensors\bin\Debug\test.csv");
            text = text.Replace(",", ".");
            File.WriteAllText(@"E:\sensors_lm_k2_02\sensors\bin\Debug\test.csv", text);

        }
    }
}
