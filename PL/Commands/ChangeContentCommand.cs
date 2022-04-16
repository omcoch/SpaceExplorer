using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignPL.Commands
{
    public class ChangeContentCommand : CommandBase
    {
        protected override void OnExecute(object parameter)
        {
            MessageBox.Show("102456");
        }
    }
}
