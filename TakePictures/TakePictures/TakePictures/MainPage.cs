using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;

namespace TakePictures
{
    public class MainPage : ContentPage
    {
        private ImageSource imageSource;
        private IMediaPicker mediaPicker;
        private Image img;
        private string status;

        public MainPage()
        {
            this.Title = "Camera Test";


            NavigationPage.SetHasNavigationBar(this, false);


            img = new Image() { HeightRequest = 300, WidthRequest = 300, BackgroundColor = Color.FromHex("#D6D6D2"), Aspect = Aspect.AspectFit };


            var addPictureButton = new Button()
            {
                Text = "Take Picture",
                Command = new Command(async () => { await TakePicture(); })
            };

            Content = addPictureButton;
        }

        private async Task TakePicture()
        {

            mediaPicker = DependencyService.Get<IMediaPicker>();

            imageSource = null;

            try
            {
                var mediaFile = await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });
                imageSource = ImageSource.FromStream(() => mediaFile.Source);
                img.Source = imageSource;
            }
            catch (System.Exception ex)
            {
                this.status = ex.Message;
            }
        }
    }
}
