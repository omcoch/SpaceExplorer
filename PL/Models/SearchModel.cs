using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DataProtocol;

namespace PL.Models
{
    public class SearchModel
    {
        private SearchMedia SearchBL;
        private Suggestions SuggestionsBL;

        public List<string> Suggestions { get; set; }
        public string SearchInput { get; set; }
        public List<Media> SearchResults { get; set; }

        public SearchModel()
        {
            SearchBL = new SearchMedia();
            SuggestionsBL = new Suggestions();
            SearchResults = new List<Media>();
            Suggestions = new List<string>();
        }

        /** Suggestions
         * *************
        **/
        public List<string> GetAllSuggestions()
        {
            if (Suggestions == null)
                Suggestions = SuggestionsBL.GetSuggestions();

            return Suggestions;
        }

        public string GetSuggestion(string input)
        {
            string r;
            if (Suggestions != null && (r = FindInList(Suggestions, input)) != null)
                return r;
            else if ((r = SuggestionsBL.GetSuggestion(input)) != null)
                return r;
            else
                return "";
        }

        public void AddSuggestion(string newData)
        {
            // put in DB
            SuggestionsBL.AddSuggestion(newData);

            // assign into the local variable
            Suggestions.Add(newData);
        }

        private string FindInList(IEnumerable<string> l, string v)
        {
            return l.FirstOrDefault(x => x.ToLower().StartsWith(v.ToLower()));
        }



        /** Media search results 
         * **********************
         */
        public IEnumerable<Media> SearchByName(string input)
        {
            return SearchBL.SearchByName(input);
        }
    }
}
