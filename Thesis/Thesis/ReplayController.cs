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
        public int selectedReplayId { get; set; }
        public List<int> Ids { get => ids; set => ids = value; }

        public ReplayController() { Ids = new List<int>(); selectedReplayId = -1; }

        public List<Replay> getPatientReplays(int id, DBConnect con)
        {
            return con.getPatientReplays(id);
        }
        public void addReplay(Replay replay, DBConnect con)
        {
            con.addReplay(replay);
        }
        public void deleteReplayById(int id, string path, FTPClient ftp ,DBConnect con)
        {
            con.deleteReplayById(id);
            ftp.deleteFile(path);
        }
    }
}
