using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class SearchModel
    {
        private List<string> suggestions = new List<string>()
        {
            "A1",
            "A2",
            "A3",
            "A4",
            "A556"
        };

        public SearchModel()
        {

        }

        public List<string> Suggestions { get; set; }
    }
}
