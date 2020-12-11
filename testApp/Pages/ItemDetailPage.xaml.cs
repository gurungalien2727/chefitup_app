using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using testApp.Services;
using Image = testApp.Models.Image;
using Xamarin.Forms;

namespace testApp.Pages
{
    public partial class ItemDetailPage : ContentPage
    {
        public ObservableCollection<Image> dishImage;
        public ItemDetailPage(int id) { 
            
             dishImage=new ObservableCollection<Image>();
             InitializeComponent();
             GetDishDetails(id);
        }

        private async void GetDishDetails(int id)
        {
          var dish= await ApiService.GetDishDetail(id);
            Dish.Text = dish.DishName;
            Name.Text = dish.preparedBy;
            Instruction.Text = dish.Instructions;
            Ingredients.Text = dish.Ingredients;
        
            ImgUser.Source = dish.FullImageUrl;
            var image = dish.imageUrl;
            
            

            CrvImages.ItemsSource = image;

       
        }

       
    }
}
