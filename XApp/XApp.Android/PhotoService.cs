using Android.Content;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XApp.Droid;

[assembly: Dependency(typeof(PhotoService))]
namespace XApp.Droid
{
    public class PhotoService : IPhotoService
    {
        public Task<ImageSource> TakePhotoAsync()
        {
            var mainActivity = Forms.Context as MainActivity;
            var tcs = new TaskCompletionSource<ImageSource>();
            EventHandler<Java.IO.File> handler = (s, e) =>
            {
                tcs.SetResult(e.Path);
            };

            mainActivity.ImageCaptured += handler;
            mainActivity.StartMediaCaptureActivity();
            return tcs.Task;
        }
        
    }
}
