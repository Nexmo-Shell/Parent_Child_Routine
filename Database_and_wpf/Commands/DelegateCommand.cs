using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_and_wpf.Commands
{
    internal class DelegateCommand : CommandBase
    {

        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute) => 
            (this.canExecute, this.execute) = (canExecute, execute);

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public override bool CanExecute(object parameter) => this.canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => this.execute?.Invoke(parameter);
    }
}
