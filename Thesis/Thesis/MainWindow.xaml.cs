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
        private List<NameValueCollection> patients;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            fillListBox();
        }

        private void Initialize()
        {
            con = new DBConnect();
            patients = con.getPatients();
        }

        private void fillListBox()
        {
            foreach(NameValueCollection it in patients)
            {
                String name = it["firstname"] + " " + it["lastname"];
                lb_patients.Items.Add(name);
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
    }
}
