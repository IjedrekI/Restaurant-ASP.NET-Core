using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Persistence;

namespace Restaurant.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Food.Restaurant Rest { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<Food.CusineType>();

            if (restaurantId.HasValue)
            {
                Rest = restaurantData.GetRestaurant(restaurantId.Value);
            }

            else
            {
                Rest = new Food.Restaurant();
            }

            if (Rest == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<Food.CusineType>();
                return Page();
            }

            if (Rest.Id > 0)
            {
                restaurantData.Update(Rest);
            }

            else
            {
                restaurantData.Add(Rest);
            }

            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved";
            return RedirectToPage("./Detail", new { restaurantId = Rest.Id });
        }
    }
}