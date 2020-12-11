using System;
using testApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace testApp.Services
{
    public static class ApiService
    {

        public static async Task<bool>  RegisterUser(string name, string email, string password)
        {
            var RegisterModel = new RegisterModel()
            {
                Name = name,
                Email=email,
                Password=password

            };

            var httpClient = new HttpClient();
            var json=JsonConvert.SerializeObject(RegisterModel);
            var content= new StringContent(json, Encoding.UTF8, "application/json");

            var response= await httpClient.PostAsync("https://chefapp2727.azurewebsites.net/api/accounts/register", content);

            if (!response.IsSuccessStatusCode) return false;
            return true;

        }

        

        public static async Task<bool>  Login(string email,string password)
        {
            var loginModel = new LoginModel()
            {
                Email = email,
                Password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://chefapp2727.azurewebsites.net/api/accounts/login", content);

            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result= JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userId", result.user_Id);
           
            return true;


        }


        public static async Task<bool> EditUserProfile(byte [] imageArray)
        {
            

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(imageArray);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));

            var response = await httpClient.PostAsync("https://chefapp2727.azurewebsites.net/api/accounts/EditUserProfile", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;

        }


        public static async Task<UserImageModel> GetUserProfileImage()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync("https://chefapp2727.azurewebsites.net/api/accounts/UserProfileImage");
            return JsonConvert.DeserializeObject<UserImageModel>(response);
        }


       

        public static async Task<bool> AddImage(int dishId, byte[] imageArray)
        {


            var dishImage = new DishImage()
            {
                Dishimage=dishId,
                ImageArray=imageArray

            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(dishImage);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));

            var response = await httpClient.PostAsync("https://chefapp2727.azurewebsites.net/api/Images", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;

        }


        public static async Task<DishDetail> GetDishDetail(int id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"https://chefapp2727.azurewebsites.net/api/Vehicles/VehicleDetails?id={id}");
            return JsonConvert.DeserializeObject<DishDetail>(response);
        }

        public static async Task<List<DishType>> GetDishByType(int dishTypeId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"https://chefapp2727.azurewebsites.net/api/Vehicles?categoryId={dishTypeId}");
            return JsonConvert.DeserializeObject<List<DishType>>(response);
        }



        public static async Task<Post> AddPost(Post post)
        {
           

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(post);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));

            var response = await httpClient.PostAsync("https://chefapp2727.azurewebsites.net/api/Vehicles", content);

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(jsonResult);
            
            

        }



        public static async Task<List<MyPost>> GetMyPost()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"https://chefapp2727.azurewebsites.net/api/Vehicles/MyAds");
            return JsonConvert.DeserializeObject<List<MyPost>>(response);
        }



    }
}
