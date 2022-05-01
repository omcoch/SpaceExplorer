using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.Commands
{
    public class OpenLinkCommand : CommandBase
    {
        protected override void OnExecute(object parameter)
        {
            string link = parameter as string;
            System.Diagnostics.Process.Start(link);
        }

       
    }
}
