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
        public static string apiKey = "acc_25f4ba630907383"+ ':'+"e0721045a68349a43d7f61aab8a12488";
        public static ImaggaTagsForImage getImageTags(string ImageUri,string ResultLanguage="")
        {
            ImaggaTagsForImage tags = new ImaggaTagsForImage();
            string responseStr= MakeHttpReq.Get("https://api.imagga.com/v2/tags?image_url="+ImageUri,"basic"+ apiKey);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);
            tags.imageUri = ImageUri;
            return tags;
        }
    }
}
