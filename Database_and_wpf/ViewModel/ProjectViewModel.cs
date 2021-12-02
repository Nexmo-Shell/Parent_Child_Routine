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
    public class ProjectViewModel : BaseViewModel
    {

        private ObservableCollection<DashboardView> dashboardViews;
        public ObservableCollection<DashboardView> DashboardViews
        {
            get => dashboardViews;
            set=>SetPropertyRef(ref dashboardViews, value);
        }

        private List<DashBoard> dashboards;
        public List<DashBoard> Dashboards
        { get=> dashboards;
        set=>SetPropertyRef(ref dashboards, value);}

        private Project _project;
        public Project Project
        {
            get
            {
                if (_project == null)
                    _project = new();
                return _project;
            }
            set
            {
                _project = value;
            }
        }


        public ProjectViewModel()
        {
            Abfrage();
            dashboardViews = new ObservableCollection<DashboardView>();
            dashboards = new List<DashBoard>();
           

        }

        public ProjectViewModel(int id)
        {
            Project.ID_Project = id;
            dashboardViews = new ObservableCollection<DashboardView>();
            dashboards = new List<DashBoard>();
            Datenabfrage();
            Datenanpassung();
        }

        private ICommand newDashboard;
        public ICommand NewDashboard
        {
            get
            {
                return newDashboard ??= new DelegateCommand((o) => true, (o) => AddProject());
            }
        }

        public void AddProject()
        {
            Datenspeicherung();
            DashboardViews.Add(new DashboardView());
        }

        public void Datenspeicherung()
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
            id.Value = Project.ID_Project;
            com.Parameters.Add(id);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Abfrage()
        {
            DataBaseConnection database = DataBaseConnection.GetDataBaseConnection();
            SqliteConnection con = database.connect();
            string getData = "Select max(ID_Project) as ID_Project From Projects";
            SqliteCommand com = new(getData, con);
            con.Open();
            SqliteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Project.ID_Project = reader.GetInt32(reader.GetOrdinal("ID_Project"));
                    //Name = reader.GetString(reader.GetOrdinal("Name"))

                }
            }
            con.Close();
        }

        public void Datenabfrage()
        {
            DataBaseConnection database = DataBaseConnection.GetDataBaseConnection();
            SqliteConnection con = database.connect();
            string getData = "Select ID_Project, Name From Projects WHERE Id_Project_Parent = @id";
            SqliteCommand com = new(getData, con);
            SqliteParameter id = new();
            id.ParameterName = "@id";
            id.Value =Project.ID_Project;
            com.Parameters.Add(id);

            con.Open();
            SqliteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dashboards.Add(new DashBoard()
                    {
                        Id_Dashboard = reader.GetInt32(reader.GetOrdinal("ID_Project")),
                        Name = reader.GetString(reader.GetOrdinal("Name"))
                    });

                }
            }
        }

        public void Datenanpassung()
        {
            foreach (var project in Dashboards)
            {
                    DashboardViews.Add(new DashboardView(project.Id_Dashboard));
            }
        }


    }
}
