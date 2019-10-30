using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Persistence;

namespace Restaurant.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Food.Restaurant Rest { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Rest = restaurantData.GetRestaurant(restaurantId);

            if (Rest == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var deletedRestaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (deletedRestaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{deletedRestaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}