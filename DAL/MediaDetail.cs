using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.LocalDB;
using DataProtocol;

namespace DAL
{
    public class MediaDetail
    {
        private NasaApi NasaApi = new NasaApi();
        

        public Media GetImageOnline()
        {
            return NasaApi.GetDailyImage(DateTime.Today);
        }

        public Media GetImageFromDB(DateTime today)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var query = from m in ctx.MediaObjects
                            where m.Day.Month == today.Month && m.Day.Year == today.Year && m.Day.Day == today.Day
                            select m;

                return query.FirstOrDefault();
            }
        }

        public Media GetMediaDBNasa(int nasaId)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var query = from m in ctx.MediaObjects
                            where m.NasaId == nasaId
                            select m;

                return query.FirstOrDefault();
            }
        }

        public int SaveMediaInDB(Media media)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                ctx.MediaObjects.Add(media);
                return ctx.SaveChanges();
            }
        }

        public bool ExistsInDB(DateTime today)
        {
            using (var ctx = new LocalDB.SpaceExplorerDBContext())
            {
                return (from m in ctx.MediaObjects
                        where m.Day == today
                        select m)
                       .Count() > 0;
            }
        }
    }
}