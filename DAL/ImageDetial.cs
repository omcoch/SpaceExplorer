using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;

namespace DAL
{
    public class ImageDetial
    {
        private NasaApi nasaApi = new NasaApi();

        public List<Image> GetDailyImage()
        {
            List<Image> Result = new List<Image>();

            Result.Add(nasaApi.GetDailyImage(DateTime.Today));

            return Result;
        }

    }
}
