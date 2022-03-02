using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataProtocol;
using Newtonsoft.Json;

namespace DAL
{
    public class NasaApi
    {
        private string dateFormat = "yyyy-MM-dd";
        public static string ApiKey = "3c9WFghad2gXj8beUc9TtwjdjRITVH4rFPZ2F5Oe";
        Image getDailyImage(DateTime date)
        {
            Image result = new Image();
            string url = String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString(dateFormat));
            var responseStr = MakeHttpReq.Get(url);           
            result.UniqueName = "NasaDailyImageFor" + date.ToString(dateFormat);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
            if(dict.ContainsKey("url"))
               result.Uri = dict["url"];
            if (dict.ContainsKey("explanation"))
                result.Description = dict["explanation"];
            if (dict.ContainsKey("title"))
                result.Title = dict["title"];
            return result;
        }
        public IEnumerable<Asteroid> asteroids(DateTime StartDate, DateTime EndDate)
        {
            TimeSpan time = StartDate - EndDate;
            if (time.TotalDays > 7)
                throw new ArgumentException("Between the dates there must be a difference of less than or equal to seven days.");
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + StartDate.ToString(dateFormat) + "&end_date=" + EndDate.ToString(dateFormat) + "&api_key=" + ApiKey;
            var responseStr = MakeHttpReq.Get(url);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
            return null;

        }
         

    }
}
