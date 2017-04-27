using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using Java.IO;
using Xamarin.Forms;

namespace XApp.Droid
{
	[Activity (Label = "XApp", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new XApp.App ());
		}

        public event EventHandler<File> ImageCaptured;
        static readonly File file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "tmp.jpg");
        static int REQUEST_IMAGE_CAPTURE = 1;

        public void StartMediaCaptureActivity()
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
            StartActivityForResult(intent, REQUEST_IMAGE_CAPTURE);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Result.Ok)
            {
                ImageCaptured?.Invoke(this, file);
            }
        }
    }
}

