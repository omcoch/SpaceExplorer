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

        public List<string> GetTags(Media media)
        {
            var existsMedia = MediaDetail.GetMediaDBNasa(media.NasaId);

            if (existsMedia != null)
                return existsMedia.Tags;

            var tags = ImaggaApi.getImageTags(media.Uri).Tags;

            // before returning the tags, save the media details in local db for later useages
            media.Tags = tags;
            MediaDetail.SaveMediaInDB(media);

            return tags;

        }

    }
}
