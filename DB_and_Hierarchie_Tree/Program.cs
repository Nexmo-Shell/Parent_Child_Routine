using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_and_Hierarchie_Tree
{
    internal class Program
    {
        static Boards firstchild = new Boards(2, "FirstChild", "This is the Second Element. It's the Child from RootElement");
        static Boards secondchild = new Boards(3, "SecondChild", "This is the third Element.It's the second Child from RootElement");
        static Boards secondgrandchild = new Boards(5, "SecondGrandchild", "This is the fifth Element. It's a Child from FirstChild");
        static Boards firstGrandchild = new Boards(4, "FirstGrandchild", "This is the fourth Element. It's a Child from FirstChild");
        static Boards thirdgrandchild = new Boards(6, "ThirdtGrandchild", "This is the sixth Element. It's a Child from FirstChild");

        private static IListInterface rootElement;
        public static IListInterface RootElement
        {
            get => rootElement;
            set => rootElement = value;
        }

        public static List<IListInterface> Parentlist = new List<IListInterface>();
        public static List<IListInterface> AllList = new List<IListInterface>();

        private static void FindAllParentRecursive(IListInterface pers)
        {
            Parentlist.Add(pers);
            if (pers.Parent == null)
                return;

            if (pers.Children.Count > 0)
            {
                foreach (var persChild in pers.Children.Where(persChild => !Parentlist.Contains(persChild)))
                {
                    Parentlist.Add(persChild);
                }
            }

            FindAllParentRecursive(pers.Parent.First());
        }

        public static void GetAllNames()
        {
            foreach (var person in Parentlist)
            {
                Console.WriteLine($"Der Name ist : {person.Name}");
            }


        }

        public static void GetAll()
        {
            int i = 1;
            foreach (var person in AllList)
            {
                Console.WriteLine(i + " -- " +  person.Name + " " + person.Description);
                i++;
            }
        }


        static void Main(string[] args)
        {

            AllList.Add(firstchild);
            AllList.Add(secondchild);
            AllList.Add(secondgrandchild);
            AllList.Add(firstGrandchild);
            AllList.Add(thirdgrandchild);

            RootElement = new Boards(1, "RootElement", "This is the First Element. It's not able to delete");
            RootElement.Parent = null;
            RootElement.Children.Add(firstchild); //new Boards(2, "FirstChild", "This is the Second Element. It's the Child from RootElement"));
            RootElement.Children.Add(secondchild);  //new Boards(3, "SecondChild", "This is the third Element.It's the second Child from RootElement"));


            foreach (var FirstChild in RootElement.Children)
            {
                FirstChild.Parent.Add(RootElement);
                if (FirstChild.Name == "FirstChild")
                {


                    FirstChild.Children.Add(firstGrandchild); //new Boards(4, "FirstGrandchild", "This is the fourth Element. It's a Child from FirstChild"));
                    FirstChild.Children.Add(secondgrandchild);   //new Boards(5, "SecondGrandchild", "This is the fifth Element. It's a Child from FirstChild"));
                    FirstChild.Children.Add(thirdgrandchild);//new Boards(6, "ThirdtGrandchild", "This is the sixth Element. It's a Child from FirstChild"));

                }

                if (FirstChild.Name == "SecondChild")
                {
                    FirstChild.Children.Add(new Boards(7, "FourthGrandchild", "This is the fourth Element. It's a Child from SecondChild"));
                    FirstChild.Children.Add(new Boards(8, "FifthGrandchild", "This is the fifth Element. It's a Child from SecondChild"));
                    FirstChild.Children.Add(new Boards(9, "SixthGrandchild", "This is the sixth Element. It's a Child from SecondChild"));

                }
            }

            foreach (var grandChilds in RootElement.Children.SelectMany(x => x.Children))
            {
                if (string.Equals(grandChilds.Name, "firstgrandchild", StringComparison.InvariantCultureIgnoreCase) || grandChilds.Name == "SecondGrandChild" || grandChilds.Name == "ThirdtGrandchild")
                {
                    grandChilds.Parent.Add(RootElement.Children.First(x => x.Name == "FirstChild"));
                }
                if (grandChilds.Name == "FourthGrandchild" || grandChilds.Name == "FifthGrandchild" || grandChilds.Name == "SixthGrandchild")
                {
                    grandChilds.Parent.Add(RootElement.Children.First(x => x.Name == "SecondChild"));
                }
            }

            GetAll();


            FindAllParentRecursive(GetEqual());   //RootElement.Children.SelectMany(x => x.Children).FirstOrDefault(x => x.Name == "SixthGrandchild"));
            GetAllNames();
        }

        public static IListInterface GetEqual()
        {
            Console.WriteLine("Select out of the given Names");
            int id_person = int.Parse(Console.ReadLine());

            switch (id_person)
            {
                case 1:
                    return firstchild;
                case 2:
                    return secondchild;
                case 3: return firstGrandchild;
                case 4: return secondgrandchild;
                case 5: return thirdgrandchild;
                default: return null;
            }

            

        }

    }
}
