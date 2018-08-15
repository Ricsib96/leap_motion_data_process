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
            fillListBox();
        }

        private void Initialize()
        {
            con = new DBConnect();
        }

        private void fillListBox()
        {
            ids = new List<int>();
            List<NameValueCollection> patients = con.getPatients();

            foreach (NameValueCollection it in patients)
            {
                int id = Int32.Parse(it["id"]);
                ids.Add(id);

                String name = it["firstname"] + " " + it["lastname"];
                lbox_patients.Items.Add(name);
            }
        }
        private void fillLabels(String firstname, String lastname)
        {
            NameValueCollection patient = con.getPatientById(ids.ElementAt(lbox_patients.SelectedIndex));

            tb_fname.Text = patient["firstname"];
            tb_lname.Text = patient["lastname"];
            tb_address.Text = patient["address"];
            dp_birth.Text = patient["birth"];
            tb_tel.Text = patient["tel"];

            lb_id.Content = patient["id"];
        }


        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        private void lbox_patients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbox_patients.Items.Count > 0 && cbox_new.IsChecked == false)
            {
                String name = lbox_patients.SelectedItem.ToString();
                String firstname = name.Split(' ')[0];
                String lastname = name.Split(' ')[1];

                fillLabels(firstname, lastname);
            }
            
        }

        private void btn_modify_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btn_modify_Click(object sender, RoutedEventArgs e)
        {
            if (tb_fname.Text.Length > 0 &&
                tb_lname.Text.Length > 0 &&
                tb_address.Text.Length > 0 &&
                tb_tel.Text.Length > 0 &&
                dp_birth.Text.Length > 0)
            {
                NameValueCollection data = new NameValueCollection();
                data.Add("id", lb_id.Content.ToString());
                data.Add("first_name", tb_fname.Text);
                data.Add("last_name", tb_lname.Text);
                data.Add("address", tb_address.Text);
                data.Add("birth", dp_birth.Text);
                data.Add("tel_number", tb_tel.Text);

                if (cbox_new.IsChecked == false)
                {
                    con.updatePatient(data);
                }
                else
                {
                    data.Add("sex", cb_sex.Text);
                    con.addPatient(data);
                    cbox_new.IsChecked = false;
                }
                

                lbox_patients.Items.Clear();
                fillListBox();
            }
        }

        private void cbox_new_Click(object sender, RoutedEventArgs e)
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if(lbox_patients.SelectedIndex > -1)
            {
                con.deletePatientById(ids.ElementAt(lbox_patients.SelectedIndex));
                ids.RemoveAt(lbox_patients.SelectedIndex);

                lbox_patients.Items.Clear();
                fillListBox();

                clearAllTextBox();
            }
        }
    }
}
