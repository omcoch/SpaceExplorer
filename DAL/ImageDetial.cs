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


        public List<Media> GetDailyImage()
        {
            Media Result;

            Result = GetImageFromUri();

            return new List<Media> { Result };
        }

        private Media GetImageFromUri()
        {
            return NasaApi.GetDailyImage(DateTime.Today);
        }

        private LocalDB.Media GetImageFromDB(int id)
        {
            using (var ctx = new LocalDB.MediaDBContext())
            {
                var query = from m in ctx.Objects
                            where m.MediaID == id
                            select m;

                return query.First();
            }
        }

        private bool ExistsInDB(int id)
        {
            using (var ctx = new LocalDB.MediaDBContext())
            {
                return (from m in ctx.Objects
                        where m.MediaID == id
                        select m)
                       .Count() > 0;
            }
        }
    }
}