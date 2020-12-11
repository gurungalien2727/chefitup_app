using System;
using System.Collections.Generic;
using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using testApp.Services;

namespace testApp.Pages
{
    public partial class AddImagePage : ContentPage
    {
        private MediaFile file;
        private int _postId;
        public AddImagePage(int postId)
        {
            InitializeComponent();
            _postId = postId;
        }

        private async void PickImageFromGallery(Image imageControl )
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( Your device does not support this feature.", "OK");
                return;
            }

            file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
            {
                CompressionQuality = 50,
                PhotoSize = PhotoSize.Large

            }) ;

            if (file == null)
                return;

     

            var x = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;
            });

            imageControl.Source = x;


        }

        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());  //convert image stream to byte array;
            file.Dispose();
            var response = await ApiService.AddImage(_postId,imageArray);
            if (response) return;
            await DisplayAlert("Something went wrong", "Upload again", "Cancel");

        }

        void TapImg1_Tapped(System.Object sender, System.EventArgs e)
        {
            PickImageFromGallery(Img1);
        }

        void BtnDone_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MyPostPage());
            Navigation.RemovePage(this);

        }
       
        

    }
}
