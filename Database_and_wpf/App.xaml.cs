using Database_and_wpf.Model;
using Database_and_wpf.ViewModel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Database_and_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    
       
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new DatabaseCreator());
            
            if(facade.EnsureCreated() == true)
            {
                InsertStandard();
            };

            MainWindow = new MainWindow();
            MainWindow.Show();
            base.OnStartup(e);
        }

        public void InsertStandard()
        {
            DataBaseConnection connector = DataBaseConnection.GetDataBaseConnection();
            SqliteConnection con = connector.connect();
            string setData = "Insert Into Projects(Name) Values(@Name)";
            SqliteCommand com = new(setData, con);
            
            SqliteParameter name = new SqliteParameter();
            name.ParameterName = "@Name";
            name.Value = "Root";
            com.Parameters.Add(name);
            
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

      

    }
}
