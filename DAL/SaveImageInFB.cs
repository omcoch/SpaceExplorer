using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using DataProtocol;
using FireSharp;

namespace DAL
{
     public class SaveImageInFB
    {
        static IFirebaseConfig Config = new FirebaseConfig()
        {
            BasePath = "https://console.firebase.google.com/u/0/project/space-explorer-images/storage/space-explorer-images.appspot.com/files",
            AuthSecret = "65a3f51b3dc3483b57d75534b2b635dd78f7d6a7"
        };
        public static void addImage(Image image)
        {
            var client = new FirebaseClient(Config);
            client.Set("Information/", image.Name);
        }

    }
}
