using DAL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BL
{
    public class DailyImage
    {
        private MediaDetail DAL;

        public DailyImage()
        {
            DAL = new MediaDetail();
        }

        public List<Media> GetDailyImage()
        {
            Media ImageDetails;

            ImageDetails = DAL.GetImageByName(DateNameFormat());
            if (ImageDetails != null)
                return new List<Media> { ImageDetails };

            ImageDetails = DAL.GetImageOnline();
            if (ImageDetails != null)
            {
                // Save in db for the next time.
                // Validation doesn't necessary because it base on data from the code itself
                ImageDetails.Name = DateNameFormat();
                DAL.SaveMediaInDB(ImageDetails);

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

        private string DateNameFormat()
        {
            //TimeZoneInfo tzObject = TimeZoneInfo.Local;
            //DateTime tstTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, tzObject);
            return "NasaDailyImage" + DateTime.Parse(DateTime.Today.ToString(), new CultureInfo("en-US"));
        }
    }
}
