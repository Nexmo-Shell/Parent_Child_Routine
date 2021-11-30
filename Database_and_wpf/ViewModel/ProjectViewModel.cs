﻿using Database_and_wpf.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_and_wpf.ViewModel
{
    public class ProjectViewModel : BaseViewModel
    {

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

        }

    }
}
