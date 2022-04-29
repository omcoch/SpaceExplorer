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
            if (!SearchTermHistory.TermInDB(name))
                SearchTermHistory.AddTerm(name);

            return NasaApi.imageVideoSearch(name);
        }

        public NasaLinksForObject SearchById(string id)
        {
            return NasaApi.imageVideoSearchById(id);
        }

        public ImaggaTagsForImage GetTags(Media media)
        {
            if (media == null || string.IsNullOrEmpty(media.Uri))
                throw new ArgumentNullException(nameof(media.Uri));

            return ImaggaApi.getImageTags(media.Uri);
        }

        public ImaggaTagsForImage GetCategories(Media media)
        {
            if (media == null || string.IsNullOrEmpty(media.Uri))
                throw new ArgumentNullException(nameof(media.Uri));

            return ImaggaApi.getImageCategories(media.Uri);
        }

    }
}
