using System;
using System.Collections.Generic;
using Restaurant.Food;
using System.Linq;

namespace Restaurant.Persistence
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly IEnumerable<Food.Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Food.Restaurant>()
            {
                new Food.Restaurant { Id = 1, Name = " Scott's Pizza", Location = "Maryland", Cusine = CusineType.Indian },
                new Food.Restaurant { Id = 2, Name = " Mark's Pizza", Location = "Krakow", Cusine = CusineType.Italian },
                new Food.Restaurant { Id = 3, Name = " Andrzej's Pizza", Location = "Mielec", Cusine = CusineType.Mexican },
                new Food.Restaurant { Id = 4, Name = " Maciek's Pizza", Location = "Zakopane", Cusine = CusineType.None },
                new Food.Restaurant { Id = 5, Name = " Tomek's Pizza", Location = "Tarnow", Cusine = CusineType.Mexican }
            };
        }

        public Food.Restaurant GetRestaurant(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Food.Restaurant> GetRestaurantByName(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                return restaurants;

            var result = restaurants
                .Where(x => x.Name.Contains(name));

            return result;
        }

        public Food.Restaurant Update(Food.Restaurant updatedRestaurant)
        {
            var res = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            
            if(res != null)
            {
                res.Name = updatedRestaurant.Name;
                res.Location = updatedRestaurant.Location;
                res.Cusine = updatedRestaurant.Cusine;

                return res;
            }

           
            restaurants.Append(updatedRestaurant);

            return restaurants.Last();
        }

        public int Commit()
        {
            return 0;
        }

        public Food.Restaurant Add(Food.Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(a => a.Id) + 1;
            restaurants.Append(newRestaurant);

            return newRestaurant;
        }
    }
}
