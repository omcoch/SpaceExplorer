using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;

namespace DAL
{
    public class ImageDetial
    {

        

        public Media GetImageOnline()
        {
            return  NasaApi.GetDailyImage(DateTime.Today);
        }

        public LocalDB.Media GetImageFromDB(DateTime today)
        {
            using (var ctx = new LocalDB.MediaDBContext())
            {
                var query = from m in ctx.Objects
                            where m.Day == today
                            select m;

                return query.First();
            }
        }

        public bool ExistsInDB(DateTime today)
        {
            using (var ctx = new LocalDB.MediaDBContext())
            {
                return (from m in ctx.Objects
                        where m.Day == today
                        select m)
                       .Count() > 0;
            }
        }
    }
}