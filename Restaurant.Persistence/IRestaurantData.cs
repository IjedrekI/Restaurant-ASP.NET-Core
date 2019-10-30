using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Persistence
{
    public interface IRestaurantData
    {
        IEnumerable<Food.Restaurant> GetRestaurants();
        Food.Restaurant GetRestaurantByName(string name);
        Food.Restaurant GetRestaurant(int id);
        Food.Restaurant Add(Food.Restaurant newRestaurant);
        Food.Restaurant Update(Food.Restaurant restaurant);
        Food.Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
