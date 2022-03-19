
using Firebase.Storage;
using Firebase.Auth;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class SaveImageInFB
    {
        private static string ApiKey = "AIzaSyCMLZRTm4RBgSb5ch_5022CP2yHJt4whEY";
        private static string Bucket = "spaceexplorer-f675f.appspot.com";
        private static string AuthEmail = "csprj@gmail.com";
        private static string AuthPassword = "123456";

        public static async Task Run()
        {
            // FirebaseStorage.Put method accepts any type of stream.
            var stream = File.Open(@"C:\Users\nocks\Desktop\pic.jpg", FileMode.Open);

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
                .Child("someFile.jpg")
                //.PutAsync(stream, cancellation.Token);
                .PutAsync(stream);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();

            try
            {
                var downloadUrl = await task;
            }
            catch (Exception ex)
            {
                throw new Exception("Firebase, something wrong happend: " + ex);
            }
        }
    }
}
