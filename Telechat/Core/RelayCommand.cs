using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Telechat.Core
{
  public class RelayCommand : ICommand
  {

    private Action<object> _execute;
    private Func<object, bool> _executeFunc;


    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object> execute, Func<object, bool> executeFunc = null)
    {
      _execute = execute;
      _executeFunc = executeFunc;
    }

    public bool CanExecute(object para)
    {
      return _executeFunc == null || _executeFunc(para);
    }

    public void Execute(object para)
    {
      _execute(para);
    }



  }
}
