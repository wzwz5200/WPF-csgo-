using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2;

namespace WpfApp2
{
  public class Class1
    {
        public CommandBase CloseWindowsCommand { get; set; }//12

        public Class1()
        {
            this.CloseWindowsCommand = new CommandBase();
            this.CloseWindowsCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });
             this.CloseWindowsCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        


        }
    }
}
