using System;
using System.Collections.Generic;
using Restaurant.Food;

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

        public IEnumerable<Food.Restaurant> GetAll()
        {
            return restaurants;
        }

        public Food.Restaurant GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }
    }
}
