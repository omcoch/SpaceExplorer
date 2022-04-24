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
    public class SuggestionCommand : CommandBase
    {
        private string currentInput = "";
        private string currentSuggestion = "";
        private string currentText = "";
        private int _selectionStart;
        private int _selectionLength;
        private TextBox theTextBox;

        // todo: put here model that takse the data from the images saved in LocalDB
        public readonly string[] SuggestionValues = {
            "england",
            "uSA",
            "rance",
            "estonia"
        };

        public SuggestionCommand(TextBox textBox)
        {
            theTextBox = textBox;
        }

        protected override void OnExecute(object theText)
        {
            var input = theTextBox.Text;

            if (input.Length > currentInput.Length && input != currentSuggestion)
            {
                currentSuggestion = SuggestionValues.FirstOrDefault(x => x.ToLower().StartsWith(input.ToLower()));
                if (currentSuggestion != null)
                {
                    currentText = currentSuggestion;
                    _selectionStart = input.Length;
                    _selectionLength = currentSuggestion.Length - input.Length;

                    theTextBox.Text = currentText;
                    theTextBox.Select(_selectionStart, _selectionLength);
                }
            }
            currentInput = input;
        }
    }
}
