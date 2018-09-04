using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Program
    {
        static string[] Joints = { "dpn_lf","dpn_rf","dpn_mf","dpn_if","dpn_t","" +
                            "dpc_lf","dpc_rf","dpc_mf","dpc_if","dpc_t","" +
                            "ipn_lf","ipn_rf","ipn_mf","ipn_if","ipn_t","" +
                            "ipc_lf","ipc_rf","ipc_mf","ipc_if","ipc_t","" +
                            "ppn_lf","ppn_rf","ppn_mf","ppn_if","ppn_t","" +
                            "ppc_lf","ppc_rf","ppc_mf","ppc_if","ppc_t","" +
                            "mn_lf","mn_rf","mn_mf","mn_if","mn_t","mc_lf","" +
                            "mc_rf","mc_mf","mc_if","mp_lf","mp_rf","mp_mf","mp_if"};

        static void Main(string[] args)
        {
            FileHandler handler = new FileHandler(@"E:\test.csv");
            var Points = handler.Read(Joints);

        }

    }
}
