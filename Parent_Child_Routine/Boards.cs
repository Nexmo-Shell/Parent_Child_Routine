using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_Child_Routine
{
    public class Boards : MyInterface
    {
        public List<MyInterface>? Parent { get; set; }
        public List<MyInterface>? Child { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                Console.WriteLine("Bitte geben Sie den Namen ein");
                name = Console.ReadLine();
            }
        }
        private int id;
        public int ID
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
            }
        }

        public Boards(string name)
        {
            Parent = new List<MyInterface>();
            Child = new List<MyInterface>();
            Name = name;
        }
    }
}
