﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataSetTest
{
    class Program
    {
        public static ObservableCollection<ObservableCollection<Point>> data = new ObservableCollection<ObservableCollection<Point>>();
        public static string[] header = new string[] {"dpn_lf","dpn_rf","dpn_mf","dpn_if","dpn_t",
                               "dpc_lf","dpc_rf","dpc_mf","dpc_if","dpc_t",
                               "ipn_lf","ipn_rf","ipn_mf","ipn_if","ipn_t",
                               "ipc_lf","ipc_rf","ipc_mf","ipc_if","ipc_t",
                               "ppn_lf","ppn_rf","ppn_mf","ppn_if","ppn_t",
                               "ppc_lf","ppc_rf","ppc_mf","ppc_if","ppc_t",
                               "mn_lf","mn_rf","mn_mf","mn_if","mn_t",
                               "mc_lf","mc_rf","mc_mf","mc_if",
                               "mp_lf","mp_rf","mp_mf","mp_if" };

        
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("test.csv"))
            {
                var line = reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');
                    ObservableCollection<Point> temp = new ObservableCollection<Point>();
                    for (int i=0;i<values.Length;i++)
                    {
                        if (values[i].Length > 10)
                        {
                            var coordinates = values[i].Split(' ');
                            Point pointData = new Point(new Coordinate(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[4]), Convert.ToDouble(coordinates[7])),header[i]);
                            temp.Add(pointData);
                        }
                    }
                    data.Add(temp);
                }
            }
            Console.ReadLine();
        }
    }
    public class Coordinate
    {
        private double x,y,z;
        public Coordinate()
        {
        }
        public Coordinate(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public override string ToString()
        {
            return this.x + "," + this.y + "," + this.z;
        }
    }

    public class Point
    {
        private Coordinate coord;
        private string name;

        public Point()
        { }
        public Point(Coordinate c,string name)
        {
            this.coord = c;
            this.name = name;
        }
        public Coordinate getCoordinate()
        {
            return coord;
        }
        public void setCoordinate(Coordinate c)
        {
            this.coord = c;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Name: " + this.name + "(" + this.coord + ")";
        }
    }
}
