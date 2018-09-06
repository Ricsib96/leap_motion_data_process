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
using System.Threading;
using System.Diagnostics;

namespace sensors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private leap_motion.LeapMotionController _lm_controller = new leap_motion.LeapMotionController();

        private leap_motion.HandConfiguration _lm_handconf = new leap_motion.HandConfiguration();

     //   private kinect2.Kinect2Controller _k2_controller = new kinect2.Kinect2Controller();
        
        private kinect2.BodyConfiguration _k2_bodyconf = new kinect2.BodyConfiguration();

        private PipeClient client;

        public MainWindow()
        {
            InitializeComponent();
            data_hand.ItemsSource = _lm_controller.hand_data;
            img_leap_live.Source = _lm_controller.bitmap;
            
            
        }



        //Leap motion
        private void but_leap_start_Click(object sender, RoutedEventArgs e)
        {
            _lm_controller.SetHandConfiguration(_lm_handconf);
            _lm_controller.StartReading(client.File_name);
        }

        private void but_leap_stop_Click(object sender, RoutedEventArgs e)
        {
            _lm_controller.StopReading();
            client.isRecording = false;
            Process.Start(@"E:\sensors_lm_k2_02\ExcelModification\bin\Debug\ExcelModification.exe");
        }

        private void chb_little_finger_distal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_distal_phalanges_next = chb_little_finger_distal_phalanges_next.IsChecked ?? false;
        }

        private void chb_little_finger_distal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_distal_phalanges_center = chb_little_finger_distal_phalanges_center.IsChecked ?? false;
        }

        private void chb_little_finger_intermediate_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_intermediate_phalanges_next = chb_little_finger_intermediate_phalanges_next.IsChecked ?? false;
        }

        private void chb_little_finger_intermediate_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_intermediate_phalanges_center = chb_little_finger_intermediate_phalanges_center.IsChecked ?? false;
        }

        private void chb_little_finger_proximal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_proximal_phalanges_next = chb_little_finger_proximal_phalanges_next.IsChecked ?? false; 
        }

        private void chb_little_finger_proximal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_proximal_phalanges_center = chb_little_finger_proximal_phalanges_center.IsChecked ?? false;
        }

        private void chb_little_finger_metacarpals_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_metacarpals_next = chb_little_finger_metacarpals_next.IsChecked ?? false;
        }

        private void chb_little_finger_metacarpals_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_metacarpals_center = chb_little_finger_metacarpals_center.IsChecked ?? false;
        }

        private void chb_little_finger_metacarpals_prev_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.little_finger_metacarpals_prev = chb_little_finger_metacarpals_prev.IsChecked ?? false;
        }

        private void chb_ring_finger_distal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_distal_phalanges_next = chb_ring_finger_distal_phalanges_next.IsChecked ?? false;
        }

        private void chb_ring_finger_distal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_distal_phalanges_center = chb_ring_finger_distal_phalanges_center.IsChecked ?? false;
        }

        private void chb_ring_finger_intermediate_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_intermediate_phalanges_next = chb_ring_finger_intermediate_phalanges_next.IsChecked ?? false;
        }

        private void chb_ring_finger_intermediate_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_intermediate_phalanges_center = chb_ring_finger_intermediate_phalanges_center.IsChecked ?? false;
        }

        private void chb_ring_finger_proximal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_proximal_phalanges_next = chb_ring_finger_proximal_phalanges_next.IsChecked ?? false;
        }

        private void chb_ring_finger_proximal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_proximal_phalanges_center = chb_ring_finger_proximal_phalanges_center.IsChecked ?? false;
        }

        private void chb_ring_finger_metacarpals_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_metacarpals_next = chb_ring_finger_metacarpals_next.IsChecked ?? false;
        }

        private void chb_ring_finger_metacarpals_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_metacarpals_center = chb_ring_finger_metacarpals_center.IsChecked ?? false;
        }

        private void chb_ring_finger_metacarpals_prev_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.ring_finger_metacarpals_prev = chb_ring_finger_metacarpals_prev.IsChecked ?? false;
        }

        private void chb_middle_finger_distal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_distal_phalanges_next = chb_middle_finger_distal_phalanges_next.IsChecked ?? false;
        }

        private void chb_middle_finger_distal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_distal_phalanges_center = chb_middle_finger_distal_phalanges_center.IsChecked ?? false;
        }

        private void chb_middle_finger_intermediate_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_intermediate_phalanges_next = chb_middle_finger_intermediate_phalanges_next.IsChecked ?? false;
        }

        private void chb_middle_finger_intermediate_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_intermediate_phalanges_center = chb_middle_finger_intermediate_phalanges_center.IsChecked ?? false;
        }

        private void chb_middle_finger_proximal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_proximal_phalanges_next = chb_middle_finger_proximal_phalanges_next.IsChecked ?? false;
        }

        private void chb_middle_finger_proximal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_proximal_phalanges_center = chb_middle_finger_proximal_phalanges_center.IsChecked ?? false;
        }

        private void chb_middle_finger_metacarpals_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_metacarpals_next = chb_middle_finger_metacarpals_next.IsChecked ?? false;
        }

        private void chb_middle_finger_metacarpals_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_metacarpals_center = chb_middle_finger_metacarpals_center.IsChecked ?? false;
        }

        private void chb_middle_finger_metacarpals_prev_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.middle_finger_metacarpals_prev = chb_middle_finger_metacarpals_prev.IsChecked ?? false;
        }

        private void chb_index_finger_distal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_distal_phalanges_next = chb_index_finger_distal_phalanges_next.IsChecked ?? false;
        }

        private void chb_index_finger_distal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_distal_phalanges_center = chb_index_finger_distal_phalanges_center.IsChecked ?? false;
        }

        private void chb_index_finger_intermediate_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_intermediate_phalanges_next = chb_index_finger_intermediate_phalanges_next.IsChecked ?? false;
        }

        private void chb_index_finger_intermediate_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_intermediate_phalanges_center = chb_index_finger_intermediate_phalanges_center.IsChecked ?? false;
        }

        private void chb_index_finger_proximal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_proximal_phalanges_next = chb_index_finger_proximal_phalanges_next.IsChecked ?? false;
        }

        private void chb_index_finger_proximal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_proximal_phalanges_center = chb_index_finger_proximal_phalanges_center.IsChecked ?? false;
        }

        private void chb_index_finger_metacarpals_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_metacarpals_next = chb_index_finger_metacarpals_next.IsChecked ?? false;
        }

        private void chb_index_finger_metacarpals_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_metacarpals_center = chb_index_finger_metacarpals_center.IsChecked ?? false;
        }

        private void chb_index_finger_metacarpals_prev_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.index_finger_metacarpals_prev = chb_index_finger_metacarpals_prev.IsChecked ?? false;
        }

        private void chb_thumb_distal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_distal_phalanges_next = chb_thumb_distal_phalanges_next.IsChecked ?? false;
        }

        private void chb_thumb_distal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_distal_phalanges_center = chb_thumb_distal_phalanges_center.IsChecked ?? false;
        }

        private void chb_thumb_intermediate_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_intermediate_phalanges_next = chb_thumb_intermediate_phalanges_next.IsChecked ?? false;
        }

        private void chb_thumb_intermediate_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_intermediate_phalanges_center = chb_thumb_intermediate_phalanges_center.IsChecked ?? false;
        }

        private void chb_thumb_proximal_phalanges_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_proximal_phalanges_next = chb_thumb_proximal_phalanges_next.IsChecked ?? false;
        }

        private void chb_thumb_proximal_phalanges_center_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_proximal_phalanges_center = chb_thumb_proximal_phalanges_center.IsChecked ?? false;
        }

        private void chb_thumb_metacarpals_next_Click(object sender, RoutedEventArgs e)
        {
            _lm_handconf.thumb_metacarpals_next = chb_thumb_metacarpals_next.IsChecked ?? false;
        }

        //Leap motion end

        //Kinect v2

        private void but_kinect2_start_Click(object sender, RoutedEventArgs e)
        {
        //    _k2_controller.SetBodyConfiguration(_k2_bodyconf);
        //    _k2_controller.StartReading();
        }

        private void but_kinect2_stop_Click(object sender, RoutedEventArgs e)
        {
          //  _k2_controller.StopReading();
        }

        private void but_kinect2_logging_Click(object sender, RoutedEventArgs e)
        {
          //  _k2_controller.Logging();
        }
         
        private void chb_head_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.head = chb_head.IsChecked ?? false;
        }

        private void chb_hand_tip_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hand_tip_right = chb_hand_tip_right.IsChecked ?? false;
        }

        private void chb_thumb_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.thumb_right = chb_thumb_right.IsChecked ?? false;
        }

        private void chb_hand_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hand_right = chb_hand_right.IsChecked ?? false;
        }

        private void chb_wrist_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.wrist_right = chb_wrist_right.IsChecked ?? false;
        }

        private void chb_elbow_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.elbow_right = chb_elbow_right.IsChecked ?? false;
        }

        private void chb_shoulder_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.shoulder_right = chb_shoulder_right.IsChecked ?? false;
        }
        
        private void chb_spine_shoulder_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.spine_shoulder = chb_spine_shoulder.IsChecked ?? false;
        }

        private void chb_neck_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.neck = chb_neck.IsChecked ?? false;
        }

        private void chb_shoulder_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.shoulder_left = chb_shoulder_left.IsChecked ?? false;
        }

        private void chb_elbow_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.elbow_left = chb_elbow_left.IsChecked ?? false;
        }

        private void chb_wrist_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.wrist_left = chb_wrist_left.IsChecked ?? false;
        }

        private void chb_hand_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hand_left = chb_hand_left.IsChecked ?? false;
        }

        private void chb_hand_tip_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hand_tip_left = chb_hand_tip_left.IsChecked ?? false;
        }

        private void chb_thumb_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.thumb_left = chb_thumb_left.IsChecked ?? false;
        }

        private void chb_spine_mid_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.spine_mid = chb_spine_mid.IsChecked ?? false;
        }

        private void chb_spine_base_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.spine_base = chb_spine_base.IsChecked ?? false;
        }

        private void chb_hip_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hip_right = chb_hip_right.IsChecked ?? false;
        }

        private void chb_hip_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.hip_left = chb_hip_left.IsChecked ?? false;
        }

        private void chb_knee_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.knee_right = chb_knee_right.IsChecked ?? false;
        }

        private void chb_knee_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.knee_left = chb_knee_left.IsChecked ?? false;
        }

        private void chb_ankle_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.ankle_right = chb_ankle_right.IsChecked ?? false;
        }

        private void chb_ankle_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.ankle_left = chb_ankle_left.IsChecked ?? false;
        }

        private void chb_foot_right_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.foot_right = chb_foot_right.IsChecked ?? false;
        }

        private void chb_foot_left_Click(object sender, RoutedEventArgs e)
        {
            _k2_bodyconf.foot_left = chb_foot_left.IsChecked ?? false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Presentation.exe");
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

            //Checkbox
            chb_little_finger_distal_phalanges_center.IsEnabled = true;
            chb_little_finger_distal_phalanges_next.IsEnabled = true;
            chb_little_finger_intermediate_phalanges_center.IsEnabled = true;
            chb_little_finger_intermediate_phalanges_next.IsEnabled = true;
            chb_little_finger_proximal_phalanges_next.IsEnabled = true;
            chb_little_finger_proximal_phalanges_center.IsEnabled = true;
            chb_little_finger_metacarpals_next.IsEnabled = true;
            chb_little_finger_metacarpals_center.IsEnabled = true;
            chb_little_finger_metacarpals_prev.IsEnabled = true;

            chb_ring_finger_distal_phalanges_next.IsEnabled = true;
            chb_ring_finger_distal_phalanges_center.IsEnabled = true;
            chb_ring_finger_intermediate_phalanges_next.IsEnabled = true;
            chb_ring_finger_intermediate_phalanges_center.IsEnabled = true;
            chb_ring_finger_proximal_phalanges_next.IsEnabled = true;
            chb_ring_finger_proximal_phalanges_center.IsEnabled = true;
            chb_ring_finger_metacarpals_next.IsEnabled = true;
            chb_ring_finger_metacarpals_center.IsEnabled = true;
            chb_ring_finger_metacarpals_prev.IsEnabled = true;

            chb_middle_finger_distal_phalanges_next.IsEnabled = true;
            chb_middle_finger_distal_phalanges_center.IsEnabled = true;
            chb_middle_finger_intermediate_phalanges_next.IsEnabled = true;
            chb_middle_finger_intermediate_phalanges_center.IsEnabled = true;
            chb_middle_finger_proximal_phalanges_next.IsEnabled = true;
            chb_middle_finger_proximal_phalanges_center.IsEnabled = true;
            chb_middle_finger_metacarpals_next.IsEnabled = true;
            chb_middle_finger_metacarpals_center.IsEnabled = true;
            chb_middle_finger_metacarpals_prev.IsEnabled = true;

            chb_index_finger_distal_phalanges_next.IsEnabled = true;
            chb_index_finger_distal_phalanges_center.IsEnabled = true;
            chb_index_finger_intermediate_phalanges_next.IsEnabled = true;
            chb_index_finger_intermediate_phalanges_center.IsEnabled = true;
            chb_index_finger_proximal_phalanges_next.IsEnabled = true;
            chb_index_finger_proximal_phalanges_center.IsEnabled = true;
            chb_index_finger_metacarpals_next.IsEnabled = true;
            chb_index_finger_metacarpals_center.IsEnabled = true;
            chb_index_finger_metacarpals_prev.IsEnabled = true;

            chb_thumb_distal_phalanges_next.IsEnabled = true;
            chb_thumb_distal_phalanges_center.IsEnabled = true;
            chb_thumb_intermediate_phalanges_next.IsEnabled = true;
            chb_thumb_intermediate_phalanges_center.IsEnabled = true;
            chb_thumb_proximal_phalanges_next.IsEnabled = true;
            chb_thumb_proximal_phalanges_center.IsEnabled = true;
            chb_thumb_metacarpals_next.IsEnabled = true;

            //LeapController
            _lm_handconf.little_finger_distal_phalanges_center = true;
            _lm_handconf.little_finger_distal_phalanges_next = true;
            _lm_handconf.little_finger_intermediate_phalanges_center = true;
            _lm_handconf.little_finger_intermediate_phalanges_next = true;
            _lm_handconf.little_finger_proximal_phalanges_next = true;
            _lm_handconf.little_finger_proximal_phalanges_center = true;
            _lm_handconf.little_finger_metacarpals_next = true;
            _lm_handconf.little_finger_metacarpals_center = true;
            _lm_handconf.little_finger_metacarpals_prev = true;

            _lm_handconf.ring_finger_distal_phalanges_next = true;
            _lm_handconf.ring_finger_distal_phalanges_center = true;
            _lm_handconf.ring_finger_intermediate_phalanges_next = true;
            _lm_handconf.ring_finger_intermediate_phalanges_center = true;
            _lm_handconf.ring_finger_proximal_phalanges_next = true;
            _lm_handconf.ring_finger_proximal_phalanges_center = true;
            _lm_handconf.ring_finger_metacarpals_next = true;
            _lm_handconf.ring_finger_metacarpals_center = true;
            _lm_handconf.ring_finger_metacarpals_prev = true;

            _lm_handconf.middle_finger_distal_phalanges_next = true;
            _lm_handconf.middle_finger_distal_phalanges_center = true;
            _lm_handconf.middle_finger_intermediate_phalanges_next = true;
            _lm_handconf.middle_finger_intermediate_phalanges_center = true;
            _lm_handconf.middle_finger_proximal_phalanges_next = true;
            _lm_handconf.middle_finger_proximal_phalanges_center = true;
            _lm_handconf.middle_finger_metacarpals_next = true;
            _lm_handconf.middle_finger_metacarpals_center = true;
            _lm_handconf.middle_finger_metacarpals_prev = true;

            _lm_handconf.index_finger_distal_phalanges_next = true;
            _lm_handconf.index_finger_distal_phalanges_center = true;
            _lm_handconf.index_finger_intermediate_phalanges_next = true;
            _lm_handconf.index_finger_intermediate_phalanges_center = true;
            _lm_handconf.index_finger_proximal_phalanges_next = true;
            _lm_handconf.index_finger_proximal_phalanges_center = true;
            _lm_handconf.index_finger_metacarpals_next = true;
            _lm_handconf.index_finger_metacarpals_center = true;
            _lm_handconf.index_finger_metacarpals_prev = true;

            _lm_handconf.thumb_distal_phalanges_next = true;
            _lm_handconf.thumb_distal_phalanges_center = true;
            _lm_handconf.thumb_intermediate_phalanges_next = true;
            _lm_handconf.thumb_intermediate_phalanges_center = true;
            _lm_handconf.thumb_proximal_phalanges_next = true;
            _lm_handconf.thumb_proximal_phalanges_center = true;
            _lm_handconf.thumb_metacarpals_next = true;
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            client = new PipeClient();
            client.StartClient();
            lb_test.Content = client.File_name;
            client.Write("DONE");
           
        }

        //Kinect v2 end
    }
}
