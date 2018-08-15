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

        private DBConnect con;
        private List<int> ids;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            initializeListBox();
        }

        private void Initialize()
        {
            con = new DBConnect();
        }
        private void initializeListBox()
        {
            fillListBox(con.getPatients());
        }
        private void fillListBox(List<Patient> patients)
        {
            ids = new List<int>();
            lbox_patients.Items.Clear();

            foreach(Patient p in patients)
            {
                int id = p.Id;
                ids.Add(id);

                String name = p.First_name + " " + p.Last_name;
                lbox_patients.Items.Add(name);
            }
        }

        private void fillLabels(String firstname, String lastname)
        {
            Patient patient = con.getPatientById(ids.ElementAt(lbox_patients.SelectedIndex));

            tb_fname.Text = patient.First_name;
            tb_lname.Text = patient.Last_name;
            tb_address.Text = patient.Address;
            dp_birth.Text = patient.Birth;
            tb_tel.Text = patient.Tel_number;

            lb_id.Content = patient.Id;
        }

        private void patientSelect(object sender, SelectionChangedEventArgs e)
        {
            if(lbox_patients.Items.Count > 0 && cbox_new.IsChecked == false && lbox_patients.SelectedIndex != -1)
            {
                String name = lbox_patients.SelectedItem.ToString();
                String firstname = name.Split(' ')[0];
                String lastname = name.Split(' ')[1];

                fillLabels(firstname, lastname);
            }
            
        }

        private void modifyPatient(object sender, RoutedEventArgs e)
        {
            if (tb_fname.Text.Length > 0 &&
                tb_lname.Text.Length > 0 &&
                tb_address.Text.Length > 0 &&
                tb_tel.Text.Length > 0 &&
                dp_birth.Text.Length > 0)
            {
                Patient data = new Patient();

                data.Id = Int32.Parse(lb_id.Content.ToString());
                data.First_name = tb_fname.Text;
                data.Last_name = tb_lname.Text;
                data.Address = tb_address.Text;
                data.Birth = dp_birth.Text;
                data.Tel_number = tb_tel.Text;

                if (cbox_new.IsChecked == false)
                {
                    con.updatePatient(data);

                    writeInformation("Patients' data has been modified succesfully!");
                }
                else
                {
                    data.Sex = cb_sex.Text;
                    con.addPatient(data);
                    cbox_new.IsChecked = false;
                    cb_sex.Visibility = Visibility.Hidden;

                    writeInformation("New patient has been added succesfully!");
                }
                

                //lbox_patients.Items.Clear();
                initializeListBox();
            }else
            {
                writeInformation("A data field is empty!");
            }
        }

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

        private void clearAllTextBox()
        {
            tb_fname.Text = "";
            tb_lname.Text = "";
            tb_address.Text = "";
            tb_tel.Text = "";
            dp_birth.Text = "";
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            if(lbox_patients.SelectedIndex > -1)
            {
                con.deletePatientById(ids.ElementAt(lbox_patients.SelectedIndex));
                ids.RemoveAt(lbox_patients.SelectedIndex);

                initializeListBox();
                clearAllTextBox();

                writeInformation("Patient has been removed!");
            }
            else
            {
                writeInformation("There is no selected patient!");
            }
        }

        private void searchPatient(object sender, RoutedEventArgs e)
        {
            if(tb_search.Text.Length > 0)
            {
                fillListBox(con.searchPatient(tb_search.Text));
            }else
            {
                writeInformation("The search box is empty!");
            }
        }

        private void searchTextChanged(object sender, TextChangedEventArgs e)
        {
            if(tb_search.Text.Length <= 0)
            {
                fillListBox(con.getPatients());
            }
        }
        public void writeInformation(string info)
        {
            tb_info.Text = info;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
