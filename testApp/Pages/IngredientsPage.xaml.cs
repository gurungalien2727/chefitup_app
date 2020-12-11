using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;


namespace testApp.Pages
{
    public partial class IngredientsPage : ContentPage
    {
        public IngredientsPage()
        {
            InitializeComponent();
        }

        void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            ListView lv = (ListView)sender;
            Meal selectedMeal = (Meal)lv.SelectedItem;
            Console.WriteLine(selectedMeal);

            
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button Pressed");
            Console.WriteLine(ingredient.Text.ToLower());
            string APIBase = "http://www.themealdb.com/api/json/v1/1/search.php?s=";
            string APIlink = APIBase + ingredient.Text.ToLower();
            JsonDeserialize(APIlink);
        }

        private void DisplayAlert(string aPIlink)
        {
            throw new NotImplementedException();
        }

        public void JsonSerialize(object data, string filePath)
        {

        }

        public void JsonDeserialize(string url)
        {
            WebClient client = new WebClient();

            string myJSON = client.DownloadString(url);

            MealCollection mealCollection = JsonConvert.DeserializeObject<MealCollection>(myJSON);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Meal meal = JsonConvert.DeserializeObject<Meal>(myJSON, settings);
            Console.WriteLine(mealCollection.Meals.Count);
            myList.ItemsSource = mealCollection.Meals;



        }

        void myList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Meal details = (Meal)e.Item;
            Navigation.PushAsync(new DetailedPage(details));
        }
    }
}
