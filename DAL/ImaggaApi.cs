using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProtocol;
using Newtonsoft.Json;

namespace DAL
{
    public static class ImaggaApi
    {
        //public static string apiKey = "acc_25f4ba630907383"+ ':'+"e0721045a68349a43d7f61aab8a12488";
        public static string apiKey = "Basic YWNjXzI1ZjRiYTYzMDkwNzM4MzplMDcyMTA0NWE2ODM0OWE0M2Q3ZjYxYWFiOGExMjQ4OA==";

        public static ImaggaTagsForImage getImageTags(string ImageUri,string ResultLanguage="")
        {
            ImaggaTagsForImage tags = new ImaggaTagsForImage();
            string requeststr = "https://api.imagga.com/v2/tags?";
            if (ResultLanguage != "") requeststr += "language=" + ResultLanguage+'&';
            else ResultLanguage = "en";
            requeststr+= "image_url=" + ImageUri;
            string responseStr= MakeHttpReq.Get(requeststr, apiKey);
            if(responseStr==null)  return tags;          
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            foreach (var item in (dict["result"] as Newtonsoft.Json.Linq.JObject)["tags"])
            {
                tags.Tags.Add((string)(item as Newtonsoft.Json.Linq.JObject)["tag"][ResultLanguage]);
            }
            tags.imageUri = ImageUri;
            return tags;
        }

        public static ImaggaTagsForImage getImageCategories(string ImageUri, string ResultLanguage = "")
        {
            ImaggaTagsForImage tags = new ImaggaTagsForImage();
            string requeststr = "https://api.imagga.com/v2/categories/personal_photos?";
            if (ResultLanguage != "") requeststr += "language=" + ResultLanguage + '&';
            else ResultLanguage = "en";
            requeststr += "image_url=" + ImageUri;
            string responseStr = MakeHttpReq.Get(requeststr, apiKey);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            foreach (var item in (dict["result"] as Newtonsoft.Json.Linq.JObject)["categories"])
            {
                tags.Tags.Add((string)(item as Newtonsoft.Json.Linq.JObject)["name"][ResultLanguage]);
            }
            tags.imageUri = ImageUri;
            return tags;
        }
        }
}
