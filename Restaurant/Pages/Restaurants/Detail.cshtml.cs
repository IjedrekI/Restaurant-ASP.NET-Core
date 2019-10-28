using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Food;
using Restaurant.Persistence;

namespace Restaurant.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public Food.Restaurant Rest{ get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            this.Rest = restaurantData.GetRestaurant(restaurantId);

            if (Rest == null)
                return RedirectToPage("./NotFound");

            return Page();
        }
    }
}