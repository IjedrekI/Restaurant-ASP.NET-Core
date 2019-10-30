using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restaurant.Persistence;

namespace Restaurant.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Food.Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(
            IConfiguration configuration, 
            IRestaurantData restaurantData,
            ILogger<ListModel> logger)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("List Model");
            Restaurants = restaurantData.GetRestaurants();
            Message = configuration["Message"];
        }
    }
}