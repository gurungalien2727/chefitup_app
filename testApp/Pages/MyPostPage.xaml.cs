using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using testApp.Models;
using testApp.Services;
using Xamarin.Forms;

namespace testApp.Pages
{
    public partial class MyPostPage : ContentPage
    {


        public ObservableCollection<MyPost> MyPostCollection;
        public MyPostPage()
        {
          
            MyPostCollection = new ObservableCollection<MyPost>();
            GetPosts();
        }

        private async void GetPosts()
        {
            var dishes=await ApiService.GetMyPost();

            foreach (var dish in dishes)
            {
                MyPostCollection.Add(dish);
            }

            d.ItemsSource = MyPostCollection;
        }

          private void dish_ItemSelected_1(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as MyPost;
            Navigation.PushAsync(new ItemDetailPage(selectedItem.id));
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ObservableCollection<MyPost> temp = new ObservableCollection<MyPost>();
            var posts = await ApiService.GetMyPost();
            foreach (var post in posts)
            {
                temp.Add(post);
            }
            MyPostCollection = temp;
            d.ItemsSource = MyPostCollection;



        }
    }
}
