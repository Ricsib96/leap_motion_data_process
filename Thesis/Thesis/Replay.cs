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
        private string name;
        private string file_name;
        private string date;
        private string detail;
        private int patient_id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string File_name { get => file_name; set => file_name = value; }
        public string Date { get => date; set => date = value; }
        public string Detail { get => detail; set => detail = value; }
        public int Patient_id { get => patient_id; set => patient_id = value; }


    }
}
