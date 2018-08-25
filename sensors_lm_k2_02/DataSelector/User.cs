using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSelector
{
    class User
    {
        private String name,filename;

        public User() { }
        public User(String name, String file)
        {
            this.name = name;
            this.filename = file;
        }

        public string Name { get => name; set => name = value; }
        public string Filename { get => filename; set => filename = value; }


    }
}
