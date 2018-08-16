using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis
{
    class PatientController
    {
        private List<int> patient_ids;
        public List<int> Patient_ids { get => patient_ids; set => patient_ids = value; }
        public void addId(int id)
        {
            Patient_ids.Add(id);
        }
        public void deleteIdAt(int element_at)
        {
            Patient_ids.RemoveAt(element_at);
        }

        public PatientController() { Patient_ids = new List<int>(); }

        public List<Patient> getPatients(DBConnect con)
        {
            return con.getPatients();
        }
        public Patient getPatientById(int id,DBConnect con)
        {
            return con.getPatientById(id);
        }
        public void updatePatient(Patient patient,DBConnect con)
        {
            con.updatePatient(patient);
        }
        public void addPatient(Patient patient, DBConnect con)
        {
            con.addPatient(patient);
        }
        public void deletePatientById(int id, DBConnect con)
        {
            con.deletePatientById(id);      
        }
        public List<Patient> searchPatientByName(string name, DBConnect con)
        {
            return con.searchPatient(name);
        }
    }
}
