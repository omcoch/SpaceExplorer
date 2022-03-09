using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class PicOfTheDay
    {
        private ImageDetial DAL;

        public PicOfTheDay()
        {
            DAL = new ImageDetial();
        }

        public List<DataProtocol.Image> GetDailyImage()
        {
            List<DataProtocol.Image> ImageDetails = DAL.GetDailyImage();
            if (ImageDetails != null && ImageDetails.Count > 0)
                return ImageDetails;
            else
                return SetDefaults();
        }

        private List<DataProtocol.Image> SetDefaults()
        {
            return new List<DataProtocol.Image>()
            {
                new DataProtocol.Image() {Title = "תמונת ברירת מחדל", Description="זוהי תמונת ברירת מחדל", Uri=""}
            };

        }
    }
}
