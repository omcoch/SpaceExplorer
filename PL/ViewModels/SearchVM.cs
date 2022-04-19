using PL.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PL.ViewModels
{
    public class SearchVM : INotifyPropertyChanged
    {
        SearchCommand DoSearch;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private string currentInput = "";
        private string currentSuggestion = "";
        private string currentText = "";
        private int _selectionStart;
        private int _selectionLength;

        // todo: put here model that takse the data from the images saved in LocalDB
        public readonly string[] SuggestionValues = {
            "England",
            "USA",
            "France",
            "Estonia"
        };


        public string CurrentInput
        {
            get { return currentInput; }
            set
            {
                currentInput = value;
                if (null != PropertyChanged)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentInput"));
            }
        }

        public SearchVM()
        {
            DoSearch = new SearchCommand();
        }

        public void SuggestionBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox theTextBox = sender as TextBox;
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
