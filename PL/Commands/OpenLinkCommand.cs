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
        protected override void OnExecute(object input)
        {
            string message = input as string;
            System.Diagnostics.Process.Start("https://wa.me/?text=Recommended for you to see: " + message);
        }

        public override bool CanExecute(object input)
        {
            return !string.IsNullOrEmpty(input as string);
        }
    }
}
