using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Storage;
using Xamarin.Forms;
using XApp.UWP;

[assembly: Dependency(typeof(PhotoService))]
namespace XApp.UWP
{
    public class PhotoService : IPhotoService
    {
        public async Task<ImageSource> TakePhotoAsync()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            var stream =  await photo.OpenStreamForReadAsync();
            return ImageSource.FromStream(() => stream);
        }
    }
}
