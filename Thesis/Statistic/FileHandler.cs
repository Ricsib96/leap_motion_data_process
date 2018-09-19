using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistic
{
    class FileHandler
    {
        public string FileName { get; set; }

        public FileHandler(string filename)
        {
            this.FileName = filename;
        }

        public List<List<Finger>> Read(string[] Joints)
        {
            List<List<Finger>> hand = new List<List<Finger>>();
            try
            {
                using (var Reader = new StreamReader(FileName))
                {
                    var RawLine = Reader.ReadLine();
                    //   int count = 0;
                    while (!Reader.EndOfStream)
                    {
                        RawLine = Reader.ReadLine();
                        var Line = RawLine.Split(';');

                        List<Finger> Fingers = new List<Finger>();
                        Finger thumb = new Finger("Thumb");
                        Finger index = new Finger("IndexFinger");
                        Finger middle = new Finger("MiddleFinger");
                        Finger ring = new Finger("RingFinger");
                        Finger little = new Finger("LittleFinger");

                        for (int i = 0; i < Line.Length; i++)
                        {
                            if (Line[i].Length > 10)
                            {
                                var Point = Line[i].Split(' ');
                                Point[1] = Point[1].Replace('.', ',');
                                Point[4] = Point[4].Replace('.', ',');
                                Point[7] = Point[7].Replace('.', ',');

                                switch (Joints[i].Split('_')[1])
                                {
                                    case "lf":
                                        Point temp = new Point(Convert.ToDouble(Point[1]), Convert.ToDouble(Point[4]), Convert.ToDouble(Point[7]));
                                        little.Points.Add(Joints[i].Split('_')[0], temp);
                                        break;
                                    case "rf":
                                        Point temp2 = new Point(Double.Parse(Point[1]), Double.Parse(Point[4]), Double.Parse(Point[7]));
                                        ring.Points.Add(Joints[i].Split('_')[0], temp2);
                                        break;
                                    case "mf":
                                        Point temp3 = new Point(Double.Parse(Point[1]), Double.Parse(Point[4]), Double.Parse(Point[7]));
                                        middle.Points.Add(Joints[i].Split('_')[0], temp3);
                                        break;
                                    case "if":
                                        Point temp4 = new Point(Double.Parse(Point[1]), Double.Parse(Point[4]), Double.Parse(Point[7]));
                                        index.Points.Add(Joints[i].Split('_')[0], temp4);
                                        break;
                                    case "t":
                                        Point temp5 = new Point(Double.Parse(Point[1]), Double.Parse(Point[4]), Double.Parse(Point[7]));
                                        thumb.Points.Add(Joints[i].Split('_')[0], temp5);
                                        break;
                                }
                            }
                        }
                        Fingers.Add(thumb);
                        Fingers.Add(index);
                        Fingers.Add(middle);
                        Fingers.Add(ring);
                        Fingers.Add(little);

                        //   if(count%2 == 0)
                        //   {
                        hand.Add(Fingers);
                        //   }                   
                        //   count++;
                    }
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.StackTrace);
            }
            

            return hand;
        }
    }
}
