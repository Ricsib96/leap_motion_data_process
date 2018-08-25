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
using sensors.kinect2;
using Microsoft.Kinect;

namespace sensors
{
    namespace kinect2
    {
        class Kinect2Controller
        {
            private BodyConfiguration _body_config = new BodyConfiguration();

            private KinectSensor _sensor;
            private MultiSourceFrameReader _reader;

            IList<Body> _bodies;

            class BodyFrameStorage
            {
                public Vector4 FloorClipPlane;
                public TimeSpan RelativeTime;
                public IList<Body> Bodies;
            }

            private List<BodyFrameStorage> saved_frames_ = new List<BodyFrameStorage>();

            public void SetBodyConfiguration(BodyConfiguration body_config)
            {
                _body_config = body_config;
            }

            public void StartReading()
            {
                saved_frames_.Clear();
                if (!_sensor.IsOpen) _sensor.Open();
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }

            public void StopReading()
            {

                _reader.MultiSourceFrameArrived -= Reader_MultiSourceFrameArrived;
                
                _sensor.Close();
            }

            public Kinect2Controller()
            {
                _sensor = KinectSensor.GetDefault();

                if (_sensor != null)
                {
                    _sensor.Open();

                    _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Body);
                }
            }
            
            private void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
            {
                var reference = e.FrameReference.AcquireFrame();

                using (var frame = reference.BodyFrameReference.AcquireFrame())
                {
                    if (frame != null)
                    {

                        _bodies = new Body[frame.BodyFrameSource.BodyCount];
                        frame.GetAndRefreshBodyData(_bodies);

                        saved_frames_.Add(new BodyFrameStorage
                            {
                                FloorClipPlane = frame.FloorClipPlane,
                                RelativeTime = frame.RelativeTime,
                                Bodies = _bodies

                            }
                        );
                    }
                }
            }

            public void Logging()
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss"));

                file.WriteLine("elapsed_millisecs; head_x; head_y; head_z; hand_tip_right_x; hand_tip_right_y; hand_tip_right_z;" + 
                    " thumb_right_x; thumb_right_y; thumb_right_z; hand_right_x; hand_right_y; hand_right_z; wrist_right_x; wrist_right_y; wrist_right_z;" + 
                    " elbow_right_x; elbow_right_y; elbow_right_z; shoulder_right_x; shoulder_right_y; shoulder_right_z;" + 
                    " spine_shoulder_x; spine_shoulder_y; spine_shoulder_z; neck_x; neck_y; neck_z; shoulder_left_x; shoulder_left_y; shoulder_left_z" +
                    " elbow_left_x; elbow_left_y; elbow_left_z; wrist_left_x; wrist_left_y; wrist_left_z; hand_left_x; hand_left_y; hand_left_z" +
                    " hand_tip_left_x; hand_tip_left_y; hand_tip_left_z; thumb_left_x; thumb_left_y; thumb_left_z" +
                    " spine_mid_x; spine_mid_y; spine_mid_z; spine_base_x; spine_base_y; spine_base_z; hip_right_x; hip_right_y; hip_right_z" +
                    " hip_left_x; hip_left_y; hip_left_z; knee_right_x; knee_right_y; knee_right_z; knee_left_x; knee_left_y; knee_left_z" +
                    " ankle_right_x; ankle_right_y; ankle_right_z; ankle_left_x; ankle_left_y; ankle_left_z; foot_right_x; foot_right_y; foot_right_z" +
                    " foot_left_x; foot_left_y; foot_left_z");

                foreach (var frame in saved_frames_)
                {
                    foreach (var body in frame.Bodies)
                    {
                        file.Write(frame.RelativeTime.Milliseconds+"; ");
                        if (body.IsTracked)
                        {
                            if(_body_config.head)
                            {
                                file.Write(body.Joints[JointType.Head].Position.X + "; " + body.Joints[JointType.Head].Position.Y + "; " + body.Joints[JointType.Head].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hand_tip_right)
                            {
                                file.Write(body.Joints[JointType.HandTipRight].Position.X + "; " + body.Joints[JointType.HandTipRight].Position.Y + "; " + body.Joints[JointType.HandTipRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.thumb_right)
                            {
                                file.Write(body.Joints[JointType.ThumbRight].Position.X + "; " + body.Joints[JointType.ThumbRight].Position.Y + "; " + body.Joints[JointType.ThumbRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hand_right)
                            {
                                file.Write(body.Joints[JointType.HandRight].Position.X + "; " + body.Joints[JointType.HandRight].Position.Y + "; " + body.Joints[JointType.HandRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.wrist_right)
                            {
                                file.Write(body.Joints[JointType.WristRight].Position.X + "; " + body.Joints[JointType.WristRight].Position.Y + "; " + body.Joints[JointType.WristRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.elbow_right)
                            {
                                file.Write(body.Joints[JointType.ElbowRight].Position.X + "; " + body.Joints[JointType.ElbowRight].Position.Y + "; " + body.Joints[JointType.ElbowRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.shoulder_right)
                            {
                                file.Write(body.Joints[JointType.ShoulderRight].Position.X + "; " + body.Joints[JointType.ShoulderRight].Position.Y + "; " + body.Joints[JointType.ShoulderRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.spine_shoulder)
                            {
                                file.Write(body.Joints[JointType.SpineShoulder].Position.X + "; " + body.Joints[JointType.SpineShoulder].Position.Y + "; " + body.Joints[JointType.SpineShoulder].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.neck)
                            {
                                file.Write(body.Joints[JointType.Neck].Position.X + "; " + body.Joints[JointType.Neck].Position.Y + "; " + body.Joints[JointType.Neck].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.shoulder_left)
                            {
                                file.Write(body.Joints[JointType.ShoulderLeft].Position.X + "; " + body.Joints[JointType.ShoulderLeft].Position.Y + "; " + body.Joints[JointType.ShoulderLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.elbow_left)
                            {
                                file.Write(body.Joints[JointType.ElbowLeft].Position.X + "; " + body.Joints[JointType.ElbowLeft].Position.Y + "; " + body.Joints[JointType.ElbowLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.wrist_left)
                            {
                                file.Write(body.Joints[JointType.WristLeft].Position.X + "; " + body.Joints[JointType.WristLeft].Position.Y + "; " + body.Joints[JointType.WristLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hand_left)
                            {
                                file.Write(body.Joints[JointType.HandLeft].Position.X + "; " + body.Joints[JointType.HandLeft].Position.Y + "; " + body.Joints[JointType.HandLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hand_tip_left)
                            {
                                file.Write(body.Joints[JointType.HandTipLeft].Position.X + "; " + body.Joints[JointType.HandTipLeft].Position.Y + "; " + body.Joints[JointType.HandTipLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.thumb_left)
                            {
                                file.Write(body.Joints[JointType.ThumbLeft].Position.X + "; " + body.Joints[JointType.ThumbLeft].Position.Y + "; " + body.Joints[JointType.ThumbLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.spine_mid)
                            {
                                file.Write(body.Joints[JointType.SpineMid].Position.X + "; " + body.Joints[JointType.SpineMid].Position.Y + "; " + body.Joints[JointType.SpineMid].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.spine_base)
                            {
                                file.Write(body.Joints[JointType.SpineBase].Position.X + "; " + body.Joints[JointType.SpineBase].Position.Y + "; " + body.Joints[JointType.SpineBase].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hip_right)
                            {
                                file.Write(body.Joints[JointType.HipRight].Position.X + "; " + body.Joints[JointType.HipRight].Position.Y + "; " + body.Joints[JointType.HipRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.hip_left)
                            {
                                file.Write(body.Joints[JointType.HipLeft].Position.X + "; " + body.Joints[JointType.HipLeft].Position.Y + "; " + body.Joints[JointType.HipLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.knee_right)
                            {
                                file.Write(body.Joints[JointType.KneeRight].Position.X + "; " + body.Joints[JointType.KneeRight].Position.Y + "; " + body.Joints[JointType.KneeRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.knee_left)
                            {
                                file.Write(body.Joints[JointType.KneeLeft].Position.X + "; " + body.Joints[JointType.KneeLeft].Position.Y + "; " + body.Joints[JointType.KneeLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.ankle_right)
                            {
                                file.Write(body.Joints[JointType.AnkleRight].Position.X + "; " + body.Joints[JointType.AnkleRight].Position.Y + "; " + body.Joints[JointType.AnkleRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.ankle_left)
                            {
                                file.Write(body.Joints[JointType.AnkleLeft].Position.X + "; " + body.Joints[JointType.AnkleLeft].Position.Y + "; " + body.Joints[JointType.AnkleLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.foot_right)
                            {
                                file.Write(body.Joints[JointType.FootRight].Position.X + "; " + body.Joints[JointType.FootRight].Position.Y + "; " + body.Joints[JointType.FootRight].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }

                            if (_body_config.foot_left)
                            {
                                file.Write(body.Joints[JointType.FootLeft].Position.X + "; " + body.Joints[JointType.FootLeft].Position.Y + "; " + body.Joints[JointType.FootLeft].Position.Z + "; ");
                            }
                            else
                            {
                                file.Write("; ; ; ");
                            }
                            break;
                        }
                        file.WriteLine();
                    }
                }
                file.Close();
            }
        }
    }
}
