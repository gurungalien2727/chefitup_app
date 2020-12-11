using System;
using System.Collections.Generic;
using Xamarin.Forms;
using testApp.Services;
using testApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace testApp.Pages
{
    public partial class ExplorePage : ContentPage
    {
        public ObservableCollection<DishType> dishCollection;
        public List<String> comments;
        public ExplorePage()
        {
            InitializeComponent();
            dishCollection = new ObservableCollection<DishType>();
           

            GetDishes();
        }

        private async void GetDishes()
        {
            var vehicles = await ApiService.GetDishByType(3);
            foreach (var vehicle in vehicles)
            {
                dishCollection.Add(vehicle);
            }
            dishes.ItemsSource = dishCollection;
        }

        private void dishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = (DishType)e.CurrentSelection.FirstOrDefault();
            Navigation.PushAsync(new ItemDetailPage(currentSelection.id));
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Button clicked", "This is a like button", "Cancel");
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            
          //  Navigation.PushAsync(new CommentPage(comments));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ObservableCollection<DishType> temp = new ObservableCollection<DishType>();
            var d= await ApiService.GetDishByType(3);
            foreach (var dish in d)
            {
                temp.Add(dish);
            }
            dishCollection =temp;
            dishes.ItemsSource = dishCollection;



        }


    }
}
