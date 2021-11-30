using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_Child_Routine
{
    public interface MyInterface
    {

        List<MyInterface>? Parent { get; set; }
        List<MyInterface>? Child { get; set; }  

        string Name { get; set; }
        int ID { get; set; }
        string Description { get; set; }


    }
}
