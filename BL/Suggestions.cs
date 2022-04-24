using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Suggestions
    {
        private DAL.SearchTermHistory TermHistory = new DAL.SearchTermHistory();

        public List<string> GetSuggestions()
        {
            return TermHistory.GetAllSuggestions();
        }

        public void AddSuggestion(string newData)
        {
            if (!string.IsNullOrEmpty(newData))
                TermHistory.AddTerm(newData);
        }
    }
}
