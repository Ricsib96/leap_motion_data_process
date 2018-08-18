using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis
{
    class Replay
    {

        private int id;
        private string file_name;
        private string path;
        private string record_date;
        private string detail;
        private int patient_id;

        public int Id { get => id; set => id = value; }
        public string File_name { get => file_name; set => file_name = value; }
        public string Path { get => path; set => path = value; }
        public string Record_date { get => record_date; set => record_date = value; }
        public string Detail { get => detail; set => detail = value; }
        public int Patient_id { get => patient_id; set => patient_id = value; }


    }
}
