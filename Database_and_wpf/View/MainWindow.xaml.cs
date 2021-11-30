using Database_and_wpf.View;
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

namespace Database_and_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel MainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel = ((MainWindowViewModel)DataContext);
            MainWindowViewModel.Projectviews.CollectionChanged += AddChildren;
        }


        private void AddChildren(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var list = MainWindowViewModel.Projectviews;
            PanelMainWindow.Children.Clear();
            foreach (var child in list)
            {
                PanelMainWindow.Children.Add(child);
            }
        } 
    }
}
