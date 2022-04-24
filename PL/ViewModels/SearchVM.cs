using DataProtocol;
using PL.Models;
using PL.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Specialized;

namespace PL.ViewModels
{
    public class SearchVM : ViewModelBase, ISearchVM
    {

        private SearchModel Model;

        public SuggestionEventCommand SuggestionCommand { get; set; }

        public SearchCommand SearchCommand { get; set; }

        private ObservableCollection<string> SuggestionValues { get; set; }

        public ObservableCollection<Media> SearchResult { get; set;  }

        public SearchVM()
        {
            Model = new SearchModel();
            SuggestionValues = new ObservableCollection<string>(Model.GetSuggestions());
            SuggestionValues.CollectionChanged += SuggestionValues_CollectionChanged;

            SuggestionCommand = new SuggestionEventCommand();
            SuggestionCommand.Suggestion += SuggestionBoxOnTextChanged;

            SearchCommand = new SearchCommand(this);
            SearchResult = new ObservableCollection<Media>();
        }

        private void SuggestionValues_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newData = e.NewItems[0] as string;
                Model.AddSuggestion(newData);
            }
        }

        public Action<string> Callback { get => (val) => SuggestionValues.Add(val);  }


        /**
         * Suggest search words based on previous searches.
         * Turn into action by the the search command, after the event of keyup wake up.
         */
        public void SuggestionBoxOnTextChanged(TextBox sender)
        {
            string currentInput = "";
            string currentSuggestion = "";
            string currentText = "";
            int _selectionStart;
            int _selectionLength;

            TextBox theTextBox = sender;
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
