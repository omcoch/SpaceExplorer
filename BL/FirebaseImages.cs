using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FirebaseImages
    {
        FirebaseHandle DAL = new FirebaseHandle();

        public FirebaseImages()
        {
        }

        public Task UploadImage(string path, string name)
        {
            try
            {
                // path: @"C:\Users\nocks\Desktop\pic.jpg"
                var task = DAL.UploadImage(path, name);
                return task;
            }
            catch (Exception ex)
            {
                throw new Exception("Firebase, something wrong happen: " + ex);
            }
        }

        public List<string> GetImages(List<string> imagesNames)
        {
            try { return DAL.GetImages(imagesNames); }
            catch (Exception ex) { throw new Exception("Firebase, something wrong happen: " + ex); }
        }

    }
    
}
