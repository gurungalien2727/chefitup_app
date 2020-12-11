using System;
using Xamarin.Forms;
using testApp.Models;
using testApp.Services;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace testApp.Pages
{
    public partial class SellPage : ContentPage
    {
        public ObservableCollection<DishType>DishCollection;
        private int categoryId;
        private string condition;

        public SellPage()
        {
            InitializeComponent();
            DishCollection = new ObservableCollection<DishType>();
            GetDishType();
        }

        private async void GetDishType()
        {
            var types = await ApiService.GetDishByType(1);
            foreach(var type in types)
            {

                DishCollection.Add(type);
            }


        }

        private async void BtnPost_Clicked(System.Object sender, System.EventArgs e)
        {
            var post=new Post();
            post.DishName = Dish.Text;
            post.preparedBy= Name.Text;
            post.Instructions = Instructions.Text;
            post.Ingredients = Ingredients.Text ;
     
           var response= await ApiService.AddPost(post);
            if (response == null) return;
            var dishId = response.id;

            await Navigation.PushAsync(new AddImagePage(dishId));



        }

       

      
    }
}
