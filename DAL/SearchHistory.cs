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
            using (var ctx = new SearchHistoryDBContext())
            {
                var item = new LocalDB.SearchHistory()
                {
                    SearchTerm = term
                };

                ctx.Objects.Add(item);
                return ctx.SaveChanges();

            }
        }

        private bool TermInDB(string term)
        {
            using (var ctx = new SearchHistoryDBContext())
            {
                return (from m in ctx.Objects
                        where m.SearchTerm == term
                        select m)
                       .Count() > 0;
            }
        }
    }
}
