using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        //private List<NameValueCollection> patients;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            fillListBox();
        }

        private void Initialize()
        {
            con = new DBConnect();
            //patients = con.getPatients();
        }

        private void fillListBox()
        {
            List<NameValueCollection> patients = con.getPatients();

            foreach (NameValueCollection it in patients)
            {
                String name = it["firstname"] + " " + it["lastname"];
                lbox_patients.Items.Add(name);
            }
        }
        private void fillLabels(String firstname, String lastname)
        {
            List<NameValueCollection> patients = con.getPatientByName(firstname, lastname);

            foreach(NameValueCollection it in patients)
            {
                tb_fname.Text = it["firstname"];
                tb_lname.Text = it["lastname"];
                tb_address.Text = it["address"];
                dp_birth.Text = it["birth"];
                tb_tel.Text = it["tel"];

                lb_id.Content = it["id"];
            }
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
            if(lbox_patients.Items.Count > 0)
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
            if (lb_id.Content.ToString().Length > 0 &&
                tb_fname.Text.Length > 0 &&
                tb_lname.Text.Length > 0 &&
                tb_address.Text.Length > 0 &&
                tb_tel.Text.Length > 0 &&
                dp_birth.Text.Length > 0)
            {
                NameValueCollection data = new NameValueCollection();
                data.Add("id", lb_id.Content.ToString());
                data.Add("firstname", tb_fname.Text);
                data.Add("lastname", tb_lname.Text);
                data.Add("address", tb_address.Text);
                data.Add("birth", dp_birth.Text);
                data.Add("tel", tb_tel.Text);

                con.updatePatient(data);

                lbox_patients.Items.Clear();
                fillListBox();
            }
        }
    }
}
