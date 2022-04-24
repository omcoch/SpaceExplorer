using DAL.LocalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SearchHistory
    {

        private int AddTerm(string term)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var item = new DataProtocol.SearchHistory()
                {
                    SearchTerm = term
                };

                ctx.SearchHistoryObjects.Add(item);
                return ctx.SaveChanges();

            }
        }

        private bool TermInDB(string term)
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
