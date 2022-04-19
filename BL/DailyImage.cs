using DAL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class DailyImage
    {
        private ImageDetial DAL;

        public DailyImage()
        {
            DAL = new ImageDetial();
        }

        public List<Media> GetDailyImage()
        {
            var ImageDetails = DAL.GetImageFromDB(DateTime.Today);
            if (ImageDetails != null)
                return new List<Media> { ImageDetails };

            ImageDetails = DAL.GetImageOnline();

            if (ImageDetails != null)
            {

                return new List<Media> { ImageDetails };
            }
            else // for some other problems, Lo Aleinu
                return SetDefaults();
        }

        private List<Media> SetDefaults()
        {
            return new List<Media>()
            {
                new Media() {Title = "No Image", Description="This is default image", Uri=""}
            };

        }
    }
}
