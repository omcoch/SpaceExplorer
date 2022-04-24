using PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.Commands
{
    public class SuggestionEventCommand : CommandBase
    {
        public event Action<TextBox> Suggestion;



        protected override void OnExecute(object theTextBox)
        {
            if (Suggestion != null)
                Suggestion(theTextBox as TextBox);
        }
    }
}
