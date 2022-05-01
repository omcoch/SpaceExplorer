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
        public OpenLinkCommand OpenLinkCommand { get; set; }

        private ObservableCollection<string> SuggestionValues { get; set; }

        public ObservableCollection<Media> SearchResult { get; set;  }

        public SearchVM()
        {
            Model = new SearchModel();
            OpenLinkCommand = new OpenLinkCommand();
            
            SuggestionValues = new ObservableCollection<string>(); //todo: remove from here the function and in the search itself (func below), extract qith linq only the one word that needed
            SuggestionValues.CollectionChanged += SuggestionValues_CollectionChanged;

            SuggestionCommand = new SuggestionEventCommand();
            SuggestionCommand.Suggestion += SuggestionBoxOnTextChanged;

            SearchCommand = new SearchCommand(this);
            SearchResult = new ObservableCollection<Media>();
            SearchResult.CollectionChanged += SearchResult_CollectionChanged;

        }

        private void SearchResult_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newData = e.NewItems[0] as Media;
                if (newData != null)
                    Model.SearchResults.Add(newData);
            }
        }

        private void SuggestionValues_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newData = e.NewItems[0] as string;
                Model.AddSuggestion(newData);
            }
        }

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
                currentSuggestion = Model.GetSuggestion(input);
                if (currentSuggestion != "")
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

        /**
         * Doing the search for real. Get from tyhe model the data and update the observable-collection in the VM
         * Returns true if there is at least one result, false else (no results), used by the command
         */
        public bool SearchByName(string input)
        {
            SearchResult.Clear();
            var result = Model.SearchByName(input);
            if (result == null || result.Count() <= 0)
            {
                // update a default "result", which means no real result. 
                SearchResult.Add(new Media()
                {
                    Title = "No Results",
                    Description = "No results were found for your search term.",
                    Uri = "/Assets/Images/404search.png"
                });
                return false;
            }

            // adds the search results into the observable-collection
            result.ToList().ForEach(s => SearchResult.Add(s)); 
            
            // treats the suggestions words list
            SuggestionValues.Add(input); 

            return true;
        }
    }
}
