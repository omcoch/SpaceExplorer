using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;
using Newtonsoft.Json;

namespace DAL
{
    public class ImaggaApi
    {
        //public static string apiKey = "acc_25f4ba630907383"+ ':'+"e0721045a68349a43d7f61aab8a12488";
        public static string apiKey = "Basic YWNjXzI1ZjRiYTYzMDkwNzM4MzplMDcyMTA0NWE2ODM0OWE0M2Q3ZjYxYWFiOGExMjQ4OA==";

        public List<ImaggaTagForImage> getImageTags(Media media, string ResultLanguage = "")
        {
            var ImageUri = media.Uri;
            List<ImaggaTagForImage> tags = new List<ImaggaTagForImage>();
            string requeststr = "https://api.imagga.com/v2/tags?";
            if (ResultLanguage != "") requeststr += "language=" + ResultLanguage + '&';
            else ResultLanguage = "en";
            requeststr += "image_url=" + ImageUri;
            string responseStr = MakeHttpReq.Get(requeststr, apiKey);
            if (responseStr == null) return tags;
            try
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            
                foreach (var item in (dict["result"] as Newtonsoft.Json.Linq.JObject)["tags"])
                {
                    var ImaggaTag = new ImaggaTagForImage();
                    ImaggaTag.Tag = (string)(item as Newtonsoft.Json.Linq.JObject)["tag"][ResultLanguage];
                    ImaggaTag.Confidence = (double)(item as Newtonsoft.Json.Linq.JObject)["confidence"];

                    tags.Add(ImaggaTag);
                }
                return tags;
            }
            catch
            {
                return tags;
            }
        }

        public List<ImaggaTagForImage> getImageCategories(Media media, string ResultLanguage = "")
        {
            var ImageUri = media.Uri;
            List<ImaggaTagForImage> tags = new List<ImaggaTagForImage>();
            string requeststr = "https://api.imagga.com/v2/categories/personal_photos?";
            if (ResultLanguage != "") requeststr += "language=" + ResultLanguage + '&';
            else ResultLanguage = "en";
            requeststr += "image_url=" + ImageUri;
            string responseStr = MakeHttpReq.Get(requeststr, apiKey);
            if (responseStr == null) return tags;
            try
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);

                foreach (var item in (dict["result"] as Newtonsoft.Json.Linq.JObject)["categories"])
                {
                    var ImaggaTag = new ImaggaTagForImage();
                    ImaggaTag.Tag = (string)(item as Newtonsoft.Json.Linq.JObject)["name"][ResultLanguage];
                    ImaggaTag.Confidence = (double)(item as Newtonsoft.Json.Linq.JObject)["confidence"];
                    tags.Add(ImaggaTag);
                }
                return tags;
            }
            catch
            {
                return tags;
            }
        }
    }
}
