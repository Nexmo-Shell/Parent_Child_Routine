using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_and_wpf.Model
{
    public class DashBoard
    {
       
        int id_Dashboard;
        string name;

        [Key]
        public int Id_Dashboard { get => id_Dashboard; set { id_Dashboard = value; } }

        public string Name { get { return name; } set { name = value; } }

      

    }
}