using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Finger
    {
        public IDictionary<string, Point> Points { get; set; }
        public string Name { get; set;}
        public Finger(string name)
        {
            this.Name = name;
            Points = new Dictionary<string, Point>();        
        }

    }
}
