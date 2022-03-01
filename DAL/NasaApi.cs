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
        public static string ApiKey = "3c9WFghad2gXj8beUc9TtwjdjRITVH4rFPZ2F5Oe";
        Image getDailyImage(DateTime date)
        {
            Image result = new Image();
            string url = String.Format("https://api.nasa.gov/planetary/apod?api_key={0}&date={1}", ApiKey, date.ToString("yyyy-MM-dd"));
            var responseStr = MakeHttpReq.Get(url);           
            result.Name = "NasaDailyImageFor" + date.ToString("yyyy-MM-dd");
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
            if(dict.ContainsKey("url"))
               result.Uri = dict["url"];
            if (dict.ContainsKey("explanation"))
                result.Description = dict["explanation"];
            if (dict.ContainsKey("title"))
                result.Title = dict["title"];
            return result;
        }

    }
}
