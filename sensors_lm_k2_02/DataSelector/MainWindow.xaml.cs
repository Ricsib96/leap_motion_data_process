using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;


namespace DataSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection();

        public MainWindow()
        {
            InitializeComponent();

            conn.ConnectionString = "Server=(localdb)\\v11.0;Integrated Security=true;";

          //  var query = "CREATE DATABASE testDB;";
            conn.Open();
            lb_names.Content = conn.Database;
        }
    }
}
