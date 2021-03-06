﻿using Microsoft.Win32;
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
        private ReplayController r_controller;
        private PipeServer pipeServer;
        private FTPClient ftpClient;

        //private string StatisticsPath = @"E:\Dokumentumok\PE\7.félév\Szakdolgozat\leap_motion_data_process\Thesis\Statistic\bin\Debug\Statistic.exe";
        //private string SensorsPath = @"E:\Dokumentumok\PE\7.félév\Szakdolgozat\leap_motion_data_process\sensors_lm_k2_02\sensors\bin\Debug\sensors.exe";
        //private string PresentationPath = @"E:\Dokumentumok\PE\7.félév\Szakdolgozat\leap_motion_data_process\sensors_lm_k2_02\sensors\bin\Debug\Presentation.exe";

        private string StatisticsPath = "";
        private string SensorsPath = "";
        private string PresentationPath = "";

        private string Ftp_User = "";
        private string Ftp_Password = "";
        private string Ftp_Host = "";
        private int Ftp_Port = 0;

        private string Db_Server = "";
        private string Db_Database = "";
        private string Db_Uid = "";
        private string Db_Password = "";

//--------------------------------------------
//***MAIN***
//--------------------------------------------


        public MainWindow()
        {
            if (ReadConfiguration("config.ini") && Connect())
            {
                //Connect();
                InitializeComponent();
                Initialize();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
        private Boolean Connect()
        {
            con = new DBConnect(Db_Server, Db_Database, Db_Uid, Db_Password);
            ftpClient = new FTPClient(Ftp_User, Ftp_Password, Ftp_Host, Ftp_Port);
            if(ftpClient.CheckConnection() && con.CheckConnection())
            {
                return true;
            }
            return false;
        }
//--------------------------------------------
//***INITIALIZE***
//--------------------------------------------
        private void Initialize()
        {
            p_controller = new PatientController();
            r_controller = new ReplayController();
            pipeServer = new PipeServer();
            initializeListBox();
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

                String name = p.First_name + " " + p.Last_name;
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
                fillLabels(lbox_patients.SelectedIndex);
                tb_replays.IsEnabled = true;
            }
            else
            {
                tb_replays.IsEnabled = false;
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

                    Patient temp = p_controller.getLastPatient(con);
                    string dirName = temp.Id.ToString() + "_" + temp.First_name + " " + temp.Last_name;
                    ftpClient.createDir(dirName);

                    writeInformation("New patient has been added succesfully!");
                }
                
                initializeListBox();
            }else
            {
                writeInformation("A data field is empty!");
            }

            lbox_patients.IsEnabled = true;
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
                lbox_patients.IsEnabled = false;
                clearAllTextBox();
            }
            else
            {
                btn_modify.Content = "Modify";
                cb_sex.Visibility = Visibility.Hidden;
                lbox_patients.IsEnabled = true;
            }
        }
        /*
         * ***DELETE BUTTON ONCLICK***
         */
        private void deletePatient(object sender, RoutedEventArgs e)
        {
            if(lbox_patients.SelectedIndex > -1)
            {
                int id = p_controller.Patient_ids.ElementAt(lbox_patients.SelectedIndex);

                p_controller.deletePatientById(id,con);
                p_controller.deleteIdAt(lbox_patients.SelectedIndex);

                ftpClient.deleteDir(id + "_" + lbox_patients.SelectedItem);

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
        /*
         * ***PATIENT DOUBLE CLICK***
         */
        private void lbox_patients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tb_replays.IsSelected = true;
        }


//--------------------------------------------
//***REPLAY TAB EVENTS***
//--------------------------------------------


        /*
        * ***SELECT REPLAY***
        */
        private void dg_replays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
            if (dg_replays.SelectedIndex != -1)
            {
                Replay temp = (Replay)dg_replays.SelectedItem;
                r_controller.selectedReplayId = dg_replays.SelectedIndex;
                tb_filename.Text = temp.File_name;
                tb_details.Text = temp.Detail;
            }
        }
        /*
         * ***RECORD***
         */
        private void btn_record_Click(object sender, RoutedEventArgs e)
        {
            if (tb_filename.Text.Length > 0
               && tb_details.Text.Length > 0)
            {

                Replay replay = new Replay();

                replay.File_name = tb_filename.Text;
                replay.Path = p_controller.Patient_ids.ElementAt(lbox_patients.SelectedIndex).ToString() +
                            "_" +
                            lbox_patients.SelectedItem.ToString() +
                            "/" +
                            tb_filename.Text +
                            ".csv";
                replay.Record_date = DateTime.Now.ToString();
                replay.Detail = tb_details.Text;
                replay.Patient_id = p_controller.Patient_ids.ElementAt(lbox_patients.SelectedIndex);

                r_controller.addReplay(replay, con);
                string to = AppDomain.CurrentDomain.BaseDirectory + replay.File_name + ".csv";
                Process.Start(SensorsPath);
                string msg = pipeServer.StartServerAndGetString(ftpClient,replay.Path,to);
                ftpClient.upload(replay.Path, to);

                fillReplays();
                clearAllTextBox();

            }
            else
            {
                writeInformation("A data field is empty!");
            }


        }
        /*
         * ***FILL REPLAY DATAGRID***
         */
        private void fillReplays()
        {
            int p_id = Int32.Parse(lb_id.Content.ToString());

            List<Replay> replays = r_controller.getPatientReplays(p_id, con);
            List<string> files = ftpClient.listFilesFromDirectory(p_id + "_" + lbox_patients.SelectedItem.ToString());

            dg_replays.ItemsSource = GetRelevantReplays(replays, files);
        }

        private void btn_playback_Click(object sender, RoutedEventArgs e)
        {
                           
            if(dg_replays.SelectedIndex > -1)
            {

             /*   SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Title = "Save File";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "CSV files (*.*)|*.csv";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true; */

                Replay temp = (Replay)dg_replays.SelectedItem;
                string to = AppDomain.CurrentDomain.BaseDirectory + temp.File_name;
                if(to.Length > 0)
                {
                    ftpClient.downloadFile(temp.Path, to);

                    pipeServer.StartServer(to);
                    Process.Start(PresentationPath);
                    
                }
                else
                {
                    writeInformation("The file has not been set!");
                }
                
            }
            else
            {
                writeInformation("Select a replay from the list!");
            }
            fillReplays();
        }

        private void deleteReplay(object sender, RoutedEventArgs e)
        {
            if (dg_replays.SelectedIndex > -1)
            {
                Replay temp = (Replay)dg_replays.Items[r_controller.selectedReplayId];
                r_controller.deleteReplayById(temp.Id, temp.Path, ftpClient, con);
                fillReplays();
            }
            else
            {
                writeInformation("Select a replay first!");
            }

        }
        private void btn_statistics_Click(object sender, RoutedEventArgs e)
        {
            if (dg_replays.SelectedIndex > -1)
            {
                Replay temp = (Replay)dg_replays.SelectedItem;
                string to = AppDomain.CurrentDomain.BaseDirectory + temp.File_name;
                if (to.Length > 0)
                {
                    ftpClient.downloadFile(temp.Path, to);

                    pipeServer.StartServer(to);

                    Process.Start(StatisticsPath);

                }
            }
            else
            {
                writeInformation("Select a replay first!");
            }
        }



        //--------------------------------------------
        //***OTHERS***
        //--------------------------------------------


        /*
         * ***WRITE INFORMATION***
         */
        public void writeInformation(string info)
        {
            MessageBox.Show(info,"Error");
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
            tb_filename.Text = "";
            tb_details.Text = "";
        }
        /*
         * ***TAB SELECTION***
         */
        private void tabSelected(object sender, SelectionChangedEventArgs e)
        {
            if(tabControl.SelectedIndex == 1 && lbox_patients.SelectedIndex > -1)
            {
                fillReplays();
                lb_patient_name.Content = lbox_patients.SelectedItem;
            }
        }
        /*
         * ***GET RELEVANT REPLAYS DATA***
         */
        private List<Replay> GetRelevantReplays(List<Replay> replays, List<string> files)
        {
            List<Replay> fordelete = new List<Replay>();
            List<Replay> temp1 = replays;
            

            foreach (Replay it in temp1)
            {
                bool gotIt = false;
                foreach (string it2 in files)
                {
                    if (it.File_name == it2)
                    {
                        gotIt = true;
                    }
                }
                if (!gotIt)
                {
                    fordelete.Add(it);
                }
            }
            foreach (Replay it in fordelete)
            {
                temp1.Remove(it);
            }

            return temp1;
        }


        private void dg_replays_LostFocus(object sender, RoutedEventArgs e)
        {
            tb_filename.Text = "";
            tb_details.Text = "";
        }

        private Boolean ReadConfiguration(String file)
        {
            String[] lines = System.IO.File.ReadAllLines(file);
            foreach(String line in lines)
            {

                switch (line.Split('=')[0])
                {
                    case "Statistics":
                        StatisticsPath = line.Split('=')[1];
                        break;
                    case "Presentation":
                        PresentationPath = line.Split('=')[1];
                        break;
                    case "Sensors":
                        SensorsPath = line.Split('=')[1];
                        break;
                    case "Ftp_User":
                        Ftp_User = line.Split('=')[1];
                        break;
                    case "Ftp_Password":
                        Ftp_Password = line.Split('=')[1];
                        break;
                    case "Ftp_Host":
                        Ftp_Host = line.Split('=')[1];
                        break;
                    case "Ftp_Port":
                        Ftp_Port = Int32.Parse(line.Split('=')[1]);
                        break;
                    case "Db_Server":
                        Db_Server = line.Split('=')[1];
                        break;
                    case "Db_Database":
                        Db_Database = line.Split('=')[1];
                        break;
                    case "Db_Uid":
                        Db_Uid = line.Split('=')[1];
                        break;
                    case "Db_Password":
                        Db_Password = line.Split('=')[1];
                        break;

                }
            }
            if(StatisticsPath == "" || PresentationPath == "" || SensorsPath == ""
                || Ftp_User == "" || Ftp_Password == "" || Ftp_Host == "" || Ftp_Port == 0
                || Db_Server == "" || Db_Database == "" || Db_Uid == "" || Db_Password == ""
                )
            {
                writeInformation("There was an error reading the configuration file(" + file +")");
                return false;
            }
            return true;
        }

    }
}
