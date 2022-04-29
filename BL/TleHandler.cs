using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataProtocol;
namespace BL
{
    /// <summary>
    /// מחפש לווינים ונותן עליהם מידע בעיקרון לא ממש רלוונטי לפריוקט אבל הוא ביקש 
    /// </summary>
   public class TleHandler
    {
        private TleApi tle = new TleApi();
        public IEnumerable<TleInfo> Search(string SearchWords)
        {
            return tle.getTleCollection(search: SearchWords, pageSize: 20);
        }
        public TleInfo GetInfoSatellite(int id)
        {
            return tle.GetTleInfo(id);
        }
        public TlePropagate GetTlePropagate(int id, DateTime date = default(DateTime))
        {
            return date == default(DateTime) ? tle.GetTlePropagate(id, "") : tle.GetTlePropagate(id, date.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
        }
    }
}
