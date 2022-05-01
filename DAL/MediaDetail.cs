using System;
using System.Collections.Generic;
using System.Globalization;
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
            return NasaApi.GetDailyImage(DateTime.Parse(DateTime.Today.ToString(), new CultureInfo("en-US")));
        }

        public Media GetImageByName(string name)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                var query = from m in ctx.MediaObjects
                            where m.Name == name
                            select m;

                return query.FirstOrDefault();
            }
        }

        public Media GetMediaDBNasa(string nasaId)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return ctx.MediaObjects.Where(m => m.NasaId == nasaId).FirstOrDefault();
            }
        }

        public List<ImaggaTagForImage> GetTagsDB(string nasaId)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return ctx.MediaObjects.Where(m => m.NasaId == nasaId).Select(x => x.Tags).FirstOrDefault();
            }
        }

        public List<ImaggaTagForImage> GetCategoriesDB(string nasaId)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return ctx.MediaObjects.Where(m => m.NasaId == nasaId).Select(x => x.Categories).FirstOrDefault();
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
            using (var ctx = new SpaceExplorerDBContext())
            {
                return (from m in ctx.MediaObjects
                        where m.Day == today
                        select m)
                       .Count() > 0;
            }
        }

        public bool ExistsInDB(string nasaId)
        {
            using (var ctx = new SpaceExplorerDBContext())
            {
                return (from m in ctx.MediaObjects
                        where m.NasaId == nasaId
                        select m)
                       .Count() > 0;
            }
        }
    }
}