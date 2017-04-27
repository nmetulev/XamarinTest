using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XApp.Data;

namespace XApp
{
	public partial class MainPage : ContentPage
	{

        string translatedNumber;
        Nose _nose;

        public MainPage(Nose nose)
		{
            _nose = nose;
			InitializeComponent();

#if WINDOWS_UWP
        var inkingWrapper = (Xamarin.Forms.Platform.UWP.NativeViewWrapper)InkingContent.Content;
        var inkCanvas = (Windows.UI.Xaml.Controls.InkCanvas)inkingWrapper.NativeElement;
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Touch |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Set initial ink stroke attributes.
        //var drawingAttributes = new Windows.UI.Input.Inking.InkDrawingAttributes();
        //drawingAttributes.Color = Windows.UI.Colors.Black;
        //drawingAttributes.IgnorePressure = false;
        //drawingAttributes.FitToCurve = true;
        //inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        var inkToolbarWrapper = (Xamarin.Forms.Platform.UWP.NativeViewWrapper)InkingToolbar.Content;
        var inkToolbar = (Windows.UI.Xaml.Controls.InkToolbar)inkToolbarWrapper.NativeElement;
        inkToolbar.TargetInkCanvas = inkCanvas;
#endif


        }

        private async void captureButton_Clicked(object sender, EventArgs e)
        {
            var photoService = DependencyService.Get<IPhotoService>();
            if(photoService != null)
            {
                var source = await photoService.TakePhotoAsync();
                noseImage.Source = ImageSource.FromUri(new Uri(_nose.Image));
                InkingToolbar.IsVisible = true;
                ImageGrid.IsVisible = true;
                image.Source = source;
            }
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            Debug.WriteLine($"{e.StatusType.ToString()} X:{e.TotalX} - y:{e.TotalY}");
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    var bounds = AbsoluteLayout.GetLayoutBounds(noseImage);
                    bounds.X += noseImage.TranslationX;
                    bounds.Y += noseImage.TranslationY;
                    AbsoluteLayout.SetLayoutBounds(noseImage, bounds);
                    noseImage.TranslationX = 0;
                    noseImage.TranslationY = 0;
                    break;

                case GestureStatus.Running:
                    noseImage.TranslationX = e.TotalX;
                    noseImage.TranslationY = e.TotalY;
                    break;
            }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Running:
                    noseImage.Scale *= e.Scale;
                    break;
            }
        }
    }
}
