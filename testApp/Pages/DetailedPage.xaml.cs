using System;
using System.Collections.Generic;

using Xamarin.Forms;
namespace testApp.Pages
{
    public partial class DetailedPage : ContentPage
    {
        Meal m;
        public DetailedPage(Meal meal)
        {
            m = meal;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Ingredients.Text = m.strIngredient1 + "  " + m.strIngredient2 + "  " + m.strIngredient3 + "  " + m.strIngredient4 + "  " + m.strIngredient5 + "  " + m.strIngredient6 +"  "+ m.strIngredient7 + "  " + m.strIngredient8 + "  " + m.strIngredient9 + "  " + m.strIngredient10 + "  " + m.strIngredient11 + "  " + m.strIngredient12;
            Instructions.Text =   m.strInstructions;
            

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new WebViewPage());
        }
    }
}
