using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis
{
    class ReplayController
    {

        List<int> ids;
        public List<int> Ids { get => ids; set => ids = value; }

        public ReplayController() { Ids = new List<int>(); }

        public List<Replay> getPatientReplays(int id, DBConnect con)
        {
            return con.getPatientReplays(id);
        }
    }
}
