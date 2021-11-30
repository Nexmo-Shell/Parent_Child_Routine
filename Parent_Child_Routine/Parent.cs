using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_Child_Routine
{
    public class Parent
    {
        private string name;
        public string Name { get { return name; } set { } } 
        public Parent(string _name)
        {
            Name = _name;
        }
    }


}
