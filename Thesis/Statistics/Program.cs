using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Statistics
{
    class Program
    {
        static string[] Joints = { "dpn_lf","dpn_rf","dpn_mf","dpn_if","dpn_t","" +
                            "dpc_lf","dpc_rf","dpc_mf","dpc_if","dpc_t","" +
                            "ipn_lf","ipn_rf","ipn_mf","ipn_if","ipn_t","" +
                            "ipc_lf","ipc_rf","ipc_mf","ipc_if","ipc_t","" +
                            "ppn_lf","ppn_rf","ppn_mf","ppn_if","ppn_t","" +
                            "ppc_lf","ppc_rf","ppc_mf","ppc_if","ppc_t","" +
                            "mn_lf","mn_rf","mn_mf","mn_if","mn_t","mc_lf","" +
                            "mc_rf","mc_mf","mc_if","mp_lf","mp_rf","mp_mf","mp_if"};

        static void Main(string[] args)
        {
            FileHandler handler = new FileHandler(@"E:\test.csv");
            var Points = handler.Read(Joints);

            Trace.WriteLine(Points.Count);

            foreach(var Hand in Points)
            {

                foreach(var Finger in Hand)
                {
                    
                    if(Finger.Name != "Thumb")
                    {
                        Trace.WriteLine(Finger.Name);

                        double x1 = Finger.Points["mp"].X;
                        double y1 = Finger.Points["mp"].Y;
                        double z1 = Finger.Points["mp"].Z;
                        Point3D p1 = new Point3D(x1, y1, z1);

                        double x2 = Finger.Points["mn"].X;
                        double y2 = Finger.Points["mn"].Y;
                        double z2 = Finger.Points["mn"].Z;
                        Point3D p2 = new Point3D(x2, y2, z2);

                        double x3 = Finger.Points["mn"].X;
                        double y3 = Finger.Points["mn"].Y;
                        double z3 = Finger.Points["mn"].Z;
                        Point3D p3 = new Point3D(x3, y3, z3);

                        double x4 = Finger.Points["ppn"].X;
                        double y4 = Finger.Points["ppn"].Y;
                        double z4 = Finger.Points["ppn"].Z;
                        Point3D p4 = new Point3D(x4, y4, z4);

                        Vector3D v1 = p2 - p1;
                        Vector3D v2 = p4 - p3;

                        Trace.WriteLine("Point1: " + p1);
                        Trace.WriteLine("Point2: " + p2);
                        Trace.WriteLine("Point3: " + p3);
                        Trace.WriteLine("Point4: " + p4);

                        Trace.WriteLine("Vector1: " + v1);
                        Trace.WriteLine("Vector2: " + v2);
                      
                        double angle = Vector3D.AngleBetween(v1, v2);
                        Trace.WriteLine(angle);
                    }
                    
                }
            }

            
        }

    }
}
