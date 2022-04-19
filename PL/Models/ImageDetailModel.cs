using BL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class ImageDetailModel
    {
        private DailyImage BL;

        public string ImageUri { get; set; }
        public string ImageDescription { get; set; }
        public string ImageTitle { get; set; }

        public ImageDetailModel()
        {
            BL = new DailyImage();

            GetDailyImage();
        }

        // todo: maybe turn this function into a command
        private void GetDailyImage()
        {
            List<Media> ImageDetails = BL.GetDailyImage();
            ImageTitle = ImageDetails[0].Title;
            ImageDescription = ImageDetails[0].Description;
            ImageUri = ImageDetails[0].Uri;
        }
    }
}
