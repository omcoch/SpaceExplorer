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
            Media ImageDetails;

            ImageDetails = DAL.GetImageFromDB(DateTime.Today);
            if (ImageDetails != null)
                return new List<Media> { ImageDetails };

            ImageDetails = DAL.GetImageOnline();
            if (ImageDetails != null)
            {
                // Save in db for the next time.
                // Validation doesn't necessary because it base on data from the code itself
                DAL.SaveImageInDB(ImageDetails);

                return new List<Media> { ImageDetails };
            }

            else 
                // for some other problems, Lo Aleinu
                return new List<Media> { SetDefaults() };
        }

        private Media SetDefaults()
        {
            return new Media() { Title = "No Image", Description = "This is default image", Uri = "" };

        }
    }
}
