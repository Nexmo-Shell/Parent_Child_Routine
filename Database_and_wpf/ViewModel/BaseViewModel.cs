using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Database_and_wpf.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        }

       

        public void SetPropertyRef<T>(ref T prop, T value, [CallerMemberName] string propertyName = "")
        {
            if (!Equals(prop, value))
            { prop = value; }
            NotifyPropertyChanged(propertyName);
        }


    }
}