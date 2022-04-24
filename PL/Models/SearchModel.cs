using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace PL.Models
{
    public class SearchModel
    {

        private Suggestions SuggestionsBL;

        public List<string> Suggestions { get; set; }
        public string SearchInput { get; set; }

        public SearchModel()
        {
            SuggestionsBL = new Suggestions();
        }

        public List<string> GetSuggestions()
        {
            if (Suggestions == null)
                Suggestions = SuggestionsBL.GetSuggestions();

            return Suggestions;
        }

        public void AddSuggestion(string newData)
        {
            // put in DB
            SuggestionsBL.AddSuggestion(newData);

            // assign into the local variable
            Suggestions.Add(newData);
        }
    }
}
