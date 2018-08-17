using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis
{
    class Patient
    {
        private int id;
        private string first_name;
        private string last_name;
        private string address;
        private string tel_number;
        private string birth;
        private string sex;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Address { get => address; set => address = value; }
        public string Tel_number { get => tel_number; set => tel_number = value; }
        public string Birth { get => birth; set => birth = value; }
        public string Sex { get => sex; set => sex = value; }


        public Patient() { }
        public Patient(int id, string first_name, string last_name, string address, string tel_number, string birth, string sex)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.birth = birth;
            this.sex = sex;
            this.tel_number = tel_number;
        }
        public Patient(string first_name, string last_name, string address, string tel_number, string birth, string sex)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.birth = birth;
            this.sex = sex;
            this.tel_number = tel_number;
        }

    }
}
