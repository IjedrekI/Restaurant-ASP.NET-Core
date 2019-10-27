using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.Persistence
{
    public interface IRestaurantData
    {
        IEnumerable<Food.Restaurant> GetAll();
        Food.Restaurant GetRestaurant(int id);
    }
}
