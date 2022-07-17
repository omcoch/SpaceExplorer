
using Firebase.Storage;
using Firebase.Auth;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DAL
{
    public class FirebaseHandle
    {
        private static string ApiKey = "***";
        private static string Bucket = "***";
        private static string AuthEmail = "c***";
        private static string AuthPassword = "***";

        public async Task UploadImage(string path, string name)
        {
            // FirebaseStorage.Put method accepts any type of stream.
            var stream = File.Open(path, FileMode.Open);

            // of course you can login using other method, not just email+password
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            //var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("DailyImage")
                .Child(name + ".jpg")
                //.PutAsync(stream, cancellation.Token);
                .PutAsync(stream);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();

            var downloadUrl = await task;
            // todo: insert into database the image link.
        }

        public List<string> GetImages(List<string> imagesNames)
        {
            List<string> result = new List<string>();

            // todo: get from DB the url for each image

            return result;
        }
    }
}
