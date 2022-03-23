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
        

        public List<Media> GetDailyImage()
        {
            List<Media> Result = new List<Media>();

            Result.Add(NasaApi.GetDailyImage(DateTime.Today));

            return Result;
        }

    }
}
