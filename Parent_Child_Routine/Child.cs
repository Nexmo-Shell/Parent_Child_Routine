using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parent_Child_Routine;


namespace Parent_Child_Routine
{
    public class Child
    {

        string name;

        public string Name { get { return name; } set { name = value; } }

        public Child()
        {
            string test = "Hans";
            Parent NewParent = new(test);
        }
    }
}

    
    

