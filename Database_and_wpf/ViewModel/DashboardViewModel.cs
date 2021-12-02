using Database_and_wpf.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_and_wpf.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {

        private DashBoard dashboard;
        public DashBoard Dashboard
        {
            get
            {
                if (dashboard == null)
                {
                    dashboard = new();                  
                }
                return dashboard;
            }
            set => dashboard=value;

        }

        public DashboardViewModel()
        {
            Abfrage();
        }
        public DashboardViewModel(int id)
        {

            Dashboard.Id_Dashboard = id;
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
                    Dashboard.Id_Dashboard = reader.GetInt32(reader.GetOrdinal("ID_Project"));
                    //Name = reader.GetString(reader.GetOrdinal("Name"))
                }
            }
            con.Close();
        }
    }

}
