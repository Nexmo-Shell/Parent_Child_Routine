using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_and_Hierarchie_Tree
{
    public interface IListInterface
    {

        List<IListInterface> Parent { get; set; }
        List<IListInterface> Children { get; set; }

        string Name { get; set; }
        int ID { get; set; }
        string Description { get; set; }
    }
}
