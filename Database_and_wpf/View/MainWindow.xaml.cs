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
            AddChildren();
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

        public void AddChildren()
        {
            var list = MainWindowViewModel.Projectviews;
            PanelMainWindow.Children.Clear();
            foreach(var child in list)
                PanelMainWindow.Children.Add(child);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement  element)
            {
                object dropitem = element.DataContext;
                DragDropEffects dragdropResult = DragDrop.DoDragDrop(element, new DataObject(DataFormats.Serializable, dropitem), DragDropEffects.Move);

                if(dragdropResult == DragDropEffects.None)
                {
                    AddItem(dropitem);
                }
            }

        }

        private void AddItem(object dropitem)
        {
            if(DropItemDropCommand?.CanExecute(null)?? false)
            {
                IncomingDropItem = dropitem;
                DropItemDropCommand?.Execute(null);
            }
        }



        public object IncomingDropItem
        {
            get { return (object)GetValue(IncomingDropItemProperty); }
            set { SetValue(IncomingDropItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IncomingDropItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncomingDropItemProperty =
            DependencyProperty.Register("IncomingDropItem", typeof(object), typeof(MainWindow), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public ICommand DropItemDropCommand
        {
            get { return (ICommand)GetValue(DropItemDropCommandProperty); }
            set { SetValue(DropItemDropCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DropItemDropCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DropItemDropCommandProperty =
            DependencyProperty.Register("DropItemDropCommand", typeof(ICommand), typeof(MainWindow), new PropertyMetadata(null));


    }
}
