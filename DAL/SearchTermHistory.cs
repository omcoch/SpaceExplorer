using DAL.LocalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SearchTermHistory
    {

        public int AddTerm(string term)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var item = new DataProtocol.SearchHistory()
                {
                    SearchTerm = term
                };

                if (!TermInDB(term))
                    ctx.SearchHistoryObjects.Add(item);
                return ctx.SaveChanges();

            }
        }

        public List<string> GetAllSuggestions()
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return (from m in ctx.SearchHistoryObjects
                        select m.SearchTerm)
                        .ToList();
            }
        }


        public bool TermInDB(string term)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return (from m in ctx.SearchHistoryObjects
                        where m.SearchTerm == term
                        select m)
                       .Count() > 0;
            }
        }
    }
}
