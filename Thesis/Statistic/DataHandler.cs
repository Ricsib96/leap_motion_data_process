using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Statistic
{
    class DataHandler
    {
        public string[] Joints = { "dpn_lf","dpn_rf","dpn_mf","dpn_if","dpn_t","" +
                            "dpc_lf","dpc_rf","dpc_mf","dpc_if","dpc_t","" +
                            "ipn_lf","ipn_rf","ipn_mf","ipn_if","ipn_t","" +
                            "ipc_lf","ipc_rf","ipc_mf","ipc_if","ipc_t","" +
                            "ppn_lf","ppn_rf","ppn_mf","ppn_if","ppn_t","" +
                            "ppc_lf","ppc_rf","ppc_mf","ppc_if","ppc_t","" +
                            "mn_lf","mn_rf","mn_mf","mn_if","mn_t",
                            "mc_lf","mc_rf","mc_mf","mc_if",
                            "mp_lf","mp_rf","mp_mf","mp_if"};

        public IDictionary<string, List<double>> Angles { get; set; }
        public IDictionary<string, List<double>> Distances { get; set; }
       // public List<double> Distances { get; set; }
        public double TotalTime { get; set; }
        public double UnitTime { get; set; }
        public double MaxAngle { get; set; }
        public double MaxDistance { get; set; }
        public double MinAngle { get; set; }
        public double MinDistance { get; set; }
        public DataHandler()
        {
            Angles = new Dictionary<string, List<double>>();
            Angles["IndexFinger"] = new List<double>();
            Angles["MiddleFinger"] = new List<double>();
            Angles["RingFinger"] = new List<double>();
            Angles["LittleFinger"] = new List<double>();
            Angles["Thumb"] = new List<double>();

            Distances = new Dictionary<string, List<double>>();
            Distances["IndexFinger"] = new List<double>();
            Distances["MiddleFinger"] = new List<double>();
            Distances["RingFinger"] = new List<double>();
            Distances["LittleFinger"] = new List<double>();
            //  Distances = new List<double>();

            MaxAngle = 0;
            MinAngle = 100;

            MaxDistance = 0;
            MinDistance = 100;
        }
        public void LoadData(string FileName)
        {
            FileHandler Handler = new FileHandler(FileName);
            var Points = Handler.Read(Joints);

            TotalTime = Points.Count / 30d;

            int count = 0;

            foreach (var Hand in Points)
            {
         /*       foreach (var Finger in Hand)
                {
                    if (count % 10 == 0)
                    {
                        double AngleTemp = GetAngle(Finger);
                        Angles[Finger.Name].Add(AngleTemp);

                        MaxAngle = AngleTemp > MaxAngle ? AngleTemp : MaxAngle;
                        MinAngle = AngleTemp < MinAngle ? AngleTemp : MinAngle;
                    }
                } */
                if(count % 10 == 0)
                {
                    foreach (var Finger in Hand)
                    {
                        double AngleTemp = GetAngle(Finger);
                        Angles[Finger.Name].Add(AngleTemp);

                        MaxAngle = AngleTemp > MaxAngle ? AngleTemp : MaxAngle;
                        MinAngle = AngleTemp < MinAngle ? AngleTemp : MinAngle;
                    } 
                    GetDistance(Hand, Distances);
                }
                count++;
            }

            UnitTime = TotalTime / Angles["IndexFinger"].Count;
        }
        public double GetAngle(Finger Finger)
        {
            string first = "mp";
            string second = "mn";
            string third = "ppn";

            if (Finger.Name == "Thumb")
            {
                first = "mn";
                second = "ppn";
                third = "ipn";
            }

            double x1 = Finger.Points[first].X;
            double y1 = Finger.Points[first].Y;
            double z1 = Finger.Points[first].Z;
            Point3D p1 = new Point3D(x1, y1, z1);

            double x2 = Finger.Points[second].X;
            double y2 = Finger.Points[second].Y;
            double z2 = Finger.Points[second].Z;
            Point3D p2 = new Point3D(x2, y2, z2);

            double x3 = Finger.Points[second].X;
            double y3 = Finger.Points[second].Y;
            double z3 = Finger.Points[second].Z;
            Point3D p3 = new Point3D(x3, y3, z3);

            double x4 = Finger.Points[third].X;
            double y4 = Finger.Points[third].Y;
            double z4 = Finger.Points[third].Z;
            Point3D p4 = new Point3D(x4, y4, z4);

            Vector3D v1 = p2 - p1;
            Vector3D v2 = p4 - p3;

            double angle = Vector3D.AngleBetween(v1, v2);

            return angle;
        }

        public double GetJointDistance(Point p1, Point p2)
        {
            Point3D po1 = new Point3D(p1.X, p1.Y, p1.Z);
            Point3D po2 = new Point3D(p2.X, p2.Y, p2.Z);

            Vector3D v = po2 - po1;

            return v.Length;
        }

        public void GetDistance(List<Finger> Hand, IDictionary<string, List<double>> Distances)
        {
         //   List<double> Distances = new List<double>();
           
            for(int i = 1; i < Hand.Count; i++)
            {
                double DistanceTemp = GetJointDistance(Hand.ElementAt(i).Points["dpn"], Hand.ElementAt(0).Points["dpn"]);
                Distances[Hand.ElementAt(i).Name].Add(DistanceTemp);

                MaxDistance = DistanceTemp > MaxDistance ? DistanceTemp : MaxDistance;
                MinDistance = DistanceTemp < MinDistance ? DistanceTemp : MinDistance;
            }
        }

    }
}
