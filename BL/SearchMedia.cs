using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.LocalDB;
using DataProtocol;

namespace BL
{
    public class SearchMedia
    {
        private NasaApi NasaApi = new NasaApi();
        private ImaggaApi ImaggaApi = new ImaggaApi();
        private MediaDetail MediaDetail = new MediaDetail();   
        private SearchTermHistory SearchTermHistory = new SearchTermHistory();   

        public IEnumerable<Media> SearchByName(string name)
        {
            // Save search terms history
            if (!SearchTermHistory.TermInDB(name))
                SearchTermHistory.AddTerm(name);


            // Get Image from DB/Nasa          
            var Medias = NasaApi.imageVideoSearch(name)
                .GroupBy(x => x.Title)
                .Select(x => x.First())
                .Take(10);

            foreach (var media in Medias)
            {
                if (!MediaDetail.ExistsInDB(media.NasaId))
                {
                    media.Categories = ImaggaApi.getImageCategories(media); // Imagga useage
                    SaveMediaInDB(media); // save in db the media + its categories
                }
                else
                {
                    media.Categories = MediaDetail.GetCategoriesDB(media.NasaId);
                }
            }

            return Medias;
        }

        public NasaLinksForObject SearchById(string id)
        {
            return NasaApi.imageVideoSearchById(id);
        }

        private int SaveMediaInDB(Media media)
        {
            return MediaDetail.SaveMediaInDB(media);
        }

    }
}
