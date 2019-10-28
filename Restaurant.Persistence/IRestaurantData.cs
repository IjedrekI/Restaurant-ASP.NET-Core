using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Persistence
{
    public interface IRestaurantData
    {
        IEnumerable<Food.Restaurant> GetRestaurantByName(string name);
        Food.Restaurant GetRestaurant(int id);
    }
}
