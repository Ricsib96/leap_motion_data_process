using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Thesis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
//--------------------------------------------
//***VARIABLES***
//--------------------------------------------

        private DBConnect con;
        private PatientController p_controller;

//--------------------------------------------
//***MAIN***
//--------------------------------------------


        public MainWindow()
        {
            
            InitializeComponent();
            Initialize();
            initializeListBox();
        }
//--------------------------------------------
//***INITIALIZE***
//--------------------------------------------
        private void Initialize()
        {
            con = new DBConnect();
            p_controller = new PatientController();
        }
        private void initializeListBox()
        {
            fillListBox(p_controller.getPatients(con));
        }
       

//--------------------------------------------
//***PATIENT TAB EVENTS***
//--------------------------------------------

        /*
         * ***FILL LIST BOX***
         */
        private void fillListBox(List<Patient> patients)
        {
            lbox_patients.Items.Clear();
            p_controller.clearIds();

            foreach (Patient p in patients)
            {

                p_controller.addId(p.Id);
                Trace.WriteLine(p.Id);

                String name = p.First_name + " " + p.Last_name + " " + p.Id;
                lbox_patients.Items.Add(name);
            }
        }

        /*
         * ***FILL LABELS***
         */
        private void fillLabels(int id)
        {
            Patient patient = p_controller.getPatientById(p_controller.Patient_ids.ElementAt(id),con);

            tb_fname.Text = patient.First_name;
            tb_lname.Text = patient.Last_name;
            tb_address.Text = patient.Address;
            dp_birth.Text = patient.Birth;
            tb_tel.Text = patient.Tel_number;

            lb_id.Content = patient.Id;
        }

         /*
         * ***LISTBOX PATIENT SELECT***
         */
        private void patientSelect(object sender, SelectionChangedEventArgs e)
        {
            if(lbox_patients.Items.Count > 0 && cbox_new.IsChecked == false && lbox_patients.SelectedIndex != -1)
            {
                String name = lbox_patients.SelectedItem.ToString();
                String firstname = name.Split(' ')[0];
                String lastname = name.Split(' ')[1];

                lb_id.Content = p_controller.Patient_ids.ElementAt(lbox_patients.SelectedIndex);
                /*Trace.WriteLine("NEW");
                foreach (int it in p_controller.Patient_ids)
                {
                    Trace.WriteLine("selected index: " + lbox_patients.SelectedIndex + " - " + it);
                }
                lb_id.Content = a;
                */
                fillLabels(lbox_patients.SelectedIndex);
            }
            else
            {
            }
            
        }

        /*
         * ***MODIFY/ADD BUTTON ONCLICK***
         */
        private void modifyPatient(object sender, RoutedEventArgs e)
        {
            if (tb_fname.Text.Length > 0 &&
                tb_lname.Text.Length > 0 &&
                tb_address.Text.Length > 0 &&
                tb_tel.Text.Length > 0 &&
                dp_birth.Text.Length > 0)
            {
                Patient data = new Patient();
                
                data.First_name = tb_fname.Text;
                data.Last_name = tb_lname.Text;
                data.Address = tb_address.Text;
                data.Birth = dp_birth.Text;
                data.Tel_number = tb_tel.Text;

                if (cbox_new.IsChecked == false)
                {
                    p_controller.updatePatient(data,con);

                    writeInformation("Patients' data has been modified succesfully!");
                }
                else
                {
                    data.Sex = cb_sex.Text;
                    p_controller.addPatient(data,con);
                    cbox_new.IsChecked = false;
                    cb_sex.Visibility = Visibility.Hidden;
                    btn_modify.Content = "Modify";

                    writeInformation("New patient has been added succesfully!");
                }
                
                initializeListBox();
            }else
            {
                writeInformation("A data field is empty!");
            }
        }

        /*
         * ***NEWPATIENT CHECKBOX CHECK***
         */
        private void newPatientCheck(object sender, RoutedEventArgs e)
        {
            if(cbox_new.IsChecked == true)
            {
                btn_modify.Content = "Add";
                cb_sex.Visibility = Visibility.Visible;
                lbox_patients.SelectedIndex = -1;
                clearAllTextBox();
            }
            else
            {
                btn_modify.Content = "Modify";
                cb_sex.Visibility = Visibility.Hidden;
            }
        }


        /*
         * ***DELETE BUTTON ONCLICK***
         */
        private void deletePatient(object sender, RoutedEventArgs e)
        {
            if(lbox_patients.SelectedIndex > -1)
            {
                p_controller.deletePatientById(p_controller.Patient_ids.ElementAt(lbox_patients.SelectedIndex),con);
                p_controller.deleteIdAt(lbox_patients.SelectedIndex);

                initializeListBox();
                clearAllTextBox();

                writeInformation("Patients' datas have been removed!");
            }
            else
            {
                writeInformation("There is no selected patient!");
            }
        }

        /*
         * ***SEARCH BUTTON ONCLICK***
         */
        private void searchPatient(object sender, RoutedEventArgs e)
        {
            if(tb_search.Text.Length > 0)
            {
                fillListBox(p_controller.searchPatientByName(tb_search.Text,con));
            }else
            {
                writeInformation("The search box is empty!");
            }
        }

        /*
         * ***SEARCH TEXTBOX ONCHANGE***
         */
        private void searchTextChanged(object sender, TextChangedEventArgs e)
        {
            if(tb_search.Text.Length <= 0)
            {
                fillListBox(p_controller.getPatients(con));
            }
        }


//--------------------------------------------
//***REPLAY TAB EVENTS***
//--------------------------------------------





//--------------------------------------------
//***OTHERS***
//--------------------------------------------


        /*
         * ***WRITE INFORMATION***
         */
        public void writeInformation(string info)
        {
            tb_info.Text = info;
        }

        /*
         * ***CLEAR ALL TEXTBOXES***
         */
        private void clearAllTextBox()
        {
            tb_fname.Text = "";
            tb_lname.Text = "";
            tb_address.Text = "";
            tb_tel.Text = "";
            dp_birth.Text = "";
        }

        private void tabSelected(object sender, SelectionChangedEventArgs e)
        {
            if(tabControl.SelectedIndex == 1)
            {
                fillReplays();
            }
        }
        private void fillReplays()
        {

        }
    }
}
