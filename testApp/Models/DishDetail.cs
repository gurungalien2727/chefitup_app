using System;
using System.Collections.Generic;

namespace testApp.Models
{
    public class DishDetail
    {
        public int id { get; set; }
        public string DishName { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public string preparedBy { get; set; }
        public string imageUrl { get; set; }

        public string FullImageUrl => $"http://chefapp2727.azurewebsites.net/{imageUrl}";
    }

    public class Image
    {

        public int id { get; set; }
        public string imageUrl{ get; set; }
        public int postId { get; set; }
        public object imageArray { get; set; }
        public string FullImageUrl => $"http://chefapp2727.azurewebsites.net/{imageUrl}";
    }
}
