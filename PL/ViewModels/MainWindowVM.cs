using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Commands;

namespace PL.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public OpenLinkCommand OpenLinkCommand { get; set; }

        public MainWindowVM()
        {
            OpenLinkCommand = new OpenLinkCommand();
        }
    }
}
