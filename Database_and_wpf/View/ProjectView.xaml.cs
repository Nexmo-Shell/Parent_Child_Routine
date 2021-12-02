using Database_and_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database_and_wpf.View
{
    /// <summary>
    /// Interaktionslogik für ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {

        private readonly ProjectViewModel ProjectViewModel;
        public ProjectView()
        {
            InitializeComponent();
            ProjectViewModel = ((ProjectViewModel)DataContext);
           
            ProjectViewModel.DashboardViews.CollectionChanged += AddChildren;
        }

        public ProjectView(int id)
        {
            InitializeComponent();
            ProjectViewModel viewModel = new ProjectViewModel(id);
            DataContext = viewModel; 
            ProjectViewModel = ((ProjectViewModel)DataContext);
            AddChildren();
            ProjectViewModel.DashboardViews.CollectionChanged += AddChildren;



        }

        private void AddChildren(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var list = ProjectViewModel.DashboardViews;
            DashboardViewer.Children.Clear();
            foreach (var child in list)
            {
                DashboardViewer.Children.Add(child);
            }
        }

        public void AddChildren()
        {
            var list = ProjectViewModel.DashboardViews;
            DashboardViewer.Children.Clear();
            foreach (var child in list)
            {
                DashboardViewer.Children.Add(child);
            }
        }
    }
}
