using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_and_wpf.Model
{
    public class Project
    {

        int id_Project;
        int? id_Project_Parent;
        string name;

        [Key]
        [ForeignKey("Parent_Child")]
        public int ID_Project
        { get => id_Project; set => id_Project = value; }

        public string Name { get => name; set => name = value; }

        public int? ID_Project_Parent { get => id_Project_Parent; set { id_Project_Parent = value; } }


    }
}