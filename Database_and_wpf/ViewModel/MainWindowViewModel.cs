using Database_and_wpf.Commands;
using Database_and_wpf.Model;
using Database_and_wpf.View;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database_and_wpf.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        private ObservableCollection<ProjectView> projectviews;
        public ObservableCollection<ProjectView> Projectviews
        {
            get => projectviews;
            set => SetPropertyRef(ref projectviews, value);
        }
        private List<Project> projects;
        public List<Project> Projects { get => projects; set => SetPropertyRef(ref projects, value); }

        public MainWindowViewModel()
        {
            projects = new List<Project>();
            projectviews = new ObservableCollection<ProjectView>();
            Datenabfrage();
            Datenanpassung();

        }

        private ICommand newContentCommand;
        public ICommand NewContentCommand
        {
            get
            {
                return newContentCommand ??= new DelegateCommand((o) => true, (o) => AddProject());
            }
        }

        public void AddProject()
        {
            DatenSpeichern();
            Projectviews.Add(new ProjectView());

        }

        public void DatenSpeichern()
        {
            DataBaseConnection connect = DataBaseConnection.GetDataBaseConnection();
            SqliteConnection con = connect.connect();
            string safedata = "Insert Into Projects(Name, Id_Project_Parent) Values(@name, @id)";
            SqliteCommand com = new(safedata, con);
            SqliteParameter name = new();
            name.ParameterName = "@name";
            name.Value = "Neues Project";
            com.Parameters.Add(name);

            SqliteParameter id = new();
            id.ParameterName = "@id";
            id.Value = 1;
            com.Parameters.Add(id);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public void Datenabfrage()
        {
            DataBaseConnection database = DataBaseConnection.GetDataBaseConnection();
            SqliteConnection con = database.connect();
            string getData = "Select ID_Project, Name From Projects WHERE Id_Project_Parent = 1";
            SqliteCommand com = new(getData, con);
            con.Open();
            SqliteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Projects.Add(new Project()
                    {
                        ID_Project = reader.GetInt32(reader.GetOrdinal("ID_Project")),
                        Name = reader.GetString(reader.GetOrdinal("Name"))
                    });

                }
            }
        }

        public void Datenanpassung()
        {
            foreach (var project in Projects)
            {
                if (project.ID_Project != 1)
                {
                    Projectviews.Add(new ProjectView(project.ID_Project));
                }
            }
        }
    }
}
