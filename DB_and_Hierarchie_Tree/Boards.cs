using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_and_Hierarchie_Tree
{
    public  class Boards : IListInterface
    {
        public List<IListInterface> Parent { get; set; }
        public List<IListInterface> Children { get; set; }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private int id;
        public int ID { get { return id; } set { id = value; } }
        private string description;
        public string Description { get { return description; } set { description = value; } }

        public Boards( int id,string name, string description)
        {
            Parent = new List<IListInterface>();
            Children = new List<IListInterface>();
            Name = name;
            Description = description;  
            ID = id;
        }
    }
}
