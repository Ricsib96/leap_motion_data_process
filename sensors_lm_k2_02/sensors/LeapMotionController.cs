using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.IO;

namespace sensors
{
    namespace leap_motion
    {
        class LeapMotionController
        {

            private HandConfiguration _hand_config = new HandConfiguration();
            //leap sensor
            private Controller _controller = new Controller();
            private byte[] imagedata = new byte[1];
            public WriteableBitmap bitmap;
            private long currentId,lastId;

            public ObservableCollection<PointDataObject> hand_data = new ObservableCollection<PointDataObject>();
            public ObservableCollection<ObservableCollection<PointDataObject>> hand_data2 = new ObservableCollection<ObservableCollection<PointDataObject>>();
            //public System.IO.StreamWriter file = new System.IO.StreamWriter("test.csv");
            public System.IO.StreamWriter file;
            public class PointDataObject
            {
                public String little_finger { get; set; }
                public String ring_finger { get; set; }
                public String middle_finger { get; set; }
                public String index_finger { get; set; }
                public String thumb { get; set; }
            }

            public void SetHandConfiguration(HandConfiguration hand_config)
            {
                _hand_config = hand_config;
            }

            public void StartReading(string file_name)
            {
                file = new System.IO.StreamWriter(file_name);
                _controller.StartConnection();
                file.WriteLine("dpn_lf; dpn_rf; dpn_mf; dpn_if; dpn_t;" +
                               "dpc_lf; dpc_rf; dpc_mf; dpc_if; dpc_t;" +
                               "ipn_lf; ipn_rf; ipn_mf; ipn_if; ipn_t;" +
                               "ipc_lf; ipc_rf; ipc_mf; ipc_if; ipc_t;" +
                               "ppn_lf; ppn_rf; ppn_mf; ppn_if; ppn_t;" +
                               "ppc_lf; ppc_rf; ppc_mf; ppc_if; ppc_t;" +
                               "mn_lf; mn_rf; mn_mf; mn_if; mn_t;" +
                               "mc_lf; mc_rf; mc_mf; mc_if;" +
                               "mp_lf; mp_rf; mp_mf; mp_if;;;");

            }
            
            public void StopReading()
            {
                _controller.StopConnection();
                // Logging();
                file.Close();
            }

            public LeapMotionController()
            {
                
                List<Color> grayscale = new List<Color>();
                for (byte i = 0; i < 0xff; i++)
                {
                    grayscale.Add(Color.FromArgb(0xff, i, i, i));
                }
                BitmapPalette palette = new BitmapPalette(grayscale);
                bitmap = new WriteableBitmap(640, 480, 72, 72, PixelFormats.Gray8, palette);

                _controller.EventContext = SynchronizationContext.Current;
                _controller.StopConnection();
                _controller.FrameReady += newFrameHandler;
                _controller.ImageReady += onImageReady;
                _controller.ImageRequestFailed += onImageRequestFailed;
            }

            private String GetCoordinatesAsString(Leap.Vector vector_prm)
            {

                return "x: " + vector_prm.x + "  y: " + vector_prm.y + "  z: " + vector_prm.z;
            }

            void newFrameHandler(object sender, FrameEventArgs eventArgs)
            {
                Leap.Frame frame = eventArgs.frame;
                //The following are Label controls added in design view for the form
                /*this.displayID.Content = frame.Id.ToString();
                this.displayTimestamp.Content = frame.Timestamp.ToString();
                this.displayFPS.Content = frame.CurrentFramesPerSecond.ToString();
                this.displayHandCount.Content = frame.Hands.Count.ToString();*/

                currentId = frame.Id;
                

                if (frame.Hands.Count==1 /* && (currentId-lastId>=2) */)
                {
                    lastId = currentId;
                    hand_data.Clear();

                    //distal phalanges next
                    var distal_phalanges_next = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_distal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[3].NextJoint) /*+ " ID: " + currentId + " Timestamp: " + frame.Timestamp*0.001*/ : "",
                        ring_finger = _hand_config.ring_finger_distal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[3].NextJoint) : "",
                        middle_finger = _hand_config.middle_finger_distal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[3].NextJoint) : "",
                        index_finger = _hand_config.index_finger_distal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[3].NextJoint) : "",
                        thumb = _hand_config.thumb_distal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[3].NextJoint) : ""
                    };

                    //distal phalanges center
                    var distal_phalanges_center = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_distal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[3].Center) : "",
                        ring_finger = _hand_config.ring_finger_distal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[3].Center) : "",
                        middle_finger = _hand_config.middle_finger_distal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[3].Center) : "",
                        index_finger = _hand_config.index_finger_distal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[3].Center) : "",
                        thumb = _hand_config.thumb_distal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[3].Center) : ""
                    };

                    //intermediate_phalanges_next
                    var intermediate_phalanges_next = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_intermediate_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[2].NextJoint) : "",
                        ring_finger = _hand_config.ring_finger_intermediate_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[2].NextJoint) : "",
                        middle_finger = _hand_config.middle_finger_intermediate_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[2].NextJoint) : "",
                        index_finger = _hand_config.index_finger_intermediate_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[2].NextJoint) : "",
                        thumb = _hand_config.thumb_intermediate_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[2].NextJoint) : ""
                    };

                    //intermediate_phalanges_center
                    var intermediate_phalanges_center = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_intermediate_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[2].Center) : "",
                        ring_finger = _hand_config.ring_finger_intermediate_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[2].Center) : "",
                        middle_finger = _hand_config.middle_finger_intermediate_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[2].Center) : "",
                        index_finger = _hand_config.index_finger_intermediate_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[2].Center) : "",
                        thumb = _hand_config.thumb_intermediate_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[2].Center) : ""
                    };

                    //proximal_phalanges_next
                    var proximal_phalanges_next = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_proximal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[1].NextJoint) : "",
                        ring_finger = _hand_config.ring_finger_proximal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[1].NextJoint) : "",
                        middle_finger = _hand_config.middle_finger_proximal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[1].NextJoint) : "",
                        index_finger = _hand_config.index_finger_proximal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[1].NextJoint) : "",
                        thumb = _hand_config.thumb_proximal_phalanges_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[1].NextJoint) : ""
                    };

                    //proximal_phalanges_center
                    var proximal_phalanges_center = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_proximal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[1].Center) : "",
                        ring_finger = _hand_config.ring_finger_proximal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[1].Center) : "",
                        middle_finger = _hand_config.middle_finger_proximal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[1].Center) : "",
                        index_finger = _hand_config.index_finger_proximal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[1].Center) : "",
                        thumb = _hand_config.thumb_proximal_phalanges_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[1].Center) : ""
                    };

                    //metacarpals_next
                    var metacarpals_next = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_metacarpals_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[0].NextJoint) : "",
                        ring_finger = _hand_config.ring_finger_metacarpals_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[0].NextJoint) : "",
                        middle_finger = _hand_config.middle_finger_metacarpals_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[0].NextJoint) : "",
                        index_finger = _hand_config.index_finger_metacarpals_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[0].NextJoint) : "",
                        thumb = _hand_config.thumb_metacarpals_next ? GetCoordinatesAsString(frame.Hands[0].Fingers[0].bones[0].NextJoint) : ""
                    };

                    //metacarpals_center
                    var metacarpals_center = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_metacarpals_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[0].Center) : "",
                        ring_finger = _hand_config.ring_finger_metacarpals_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[0].Center) : "",
                        middle_finger = _hand_config.middle_finger_metacarpals_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[0].Center) : "",
                        index_finger = _hand_config.index_finger_metacarpals_center ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[0].Center) : "",
                    };

                    //metacarpals_prev
                    var metacarpals_prev = new PointDataObject()
                    {
                        little_finger = _hand_config.little_finger_metacarpals_prev ? GetCoordinatesAsString(frame.Hands[0].Fingers[4].bones[0].PrevJoint) : "",
                        ring_finger = _hand_config.ring_finger_metacarpals_prev ? GetCoordinatesAsString(frame.Hands[0].Fingers[3].bones[0].PrevJoint) : "",
                        middle_finger = _hand_config.middle_finger_metacarpals_prev ? GetCoordinatesAsString(frame.Hands[0].Fingers[2].bones[0].PrevJoint) : "",
                        index_finger = _hand_config.index_finger_metacarpals_prev ? GetCoordinatesAsString(frame.Hands[0].Fingers[1].bones[0].PrevJoint) : "",
                    };


                    hand_data.Add(distal_phalanges_next);
                    hand_data.Add(distal_phalanges_center);
                    hand_data.Add(intermediate_phalanges_next);
                    hand_data.Add(intermediate_phalanges_center);
                    hand_data.Add(proximal_phalanges_next);
                    hand_data.Add(proximal_phalanges_center);
                    hand_data.Add(metacarpals_next);
                    hand_data.Add(metacarpals_center);
                    hand_data.Add(metacarpals_prev);


                    for (int j = 0; j < 9; j++)
                    {
                        if (j < 7)
                        {
                            file.Write(hand_data[j].little_finger.ToString() + ";" +
                                       hand_data[j].ring_finger.ToString() + ";" +
                                       hand_data[j].middle_finger.ToString() + ";" +
                                       hand_data[j].index_finger.ToString() + ";" +
                                       hand_data[j].thumb.ToString() + ";");
                        }
                        else
                            file.Write(hand_data[j].little_finger.ToString() + ";" +
                                       hand_data[j].ring_finger.ToString() + ";" +
                                       hand_data[j].middle_finger.ToString() + ";" +
                                       hand_data[j].index_finger.ToString() + ";");

                    }
                    file.WriteLine(";;; ");


                }
                _controller.RequestImages(frame.Id, Leap.Image.ImageType.DEFAULT, imagedata);
            }
           

            void onImageRequestFailed(object sender, ImageRequestFailedEventArgs e)
            {
                if (e.reason == Leap.Image.RequestFailureReason.Insufficient_Buffer)
                {
                    imagedata = new byte[e.requiredBufferSize];
                }
               // debugText.AppendText("Image request failed: " + e.message + "\n");
            }

            void onImageReady(object sender, ImageEventArgs e)
            {
                bitmap.WritePixels(new Int32Rect(0, 0, 640, 480), imagedata, 640, 0);
            }
        }
    }
}
