using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Food;

namespace Restaurant.Persistence
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext dbContext;

        public SqlRestaurantData(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Food.Restaurant Add(Food.Restaurant newRestaurant)
        {
            dbContext.Add(newRestaurant);
            return newRestaurant;

        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Food.Restaurant Delete(int id)
        {
            var restaurant = GetRestaurant(id);
            
            if(restaurant != null)
            {
                dbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return dbContext.Restaurants.Count();
        }

        public Food.Restaurant GetRestaurant(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public Food.Restaurant GetRestaurantByName(string name)
        {
            return dbContext.Restaurants
                .Where(x => x.Name.StartsWith(name))
                .OrderBy(x => x.Name)
                .FirstOrDefault();
        }

        public IEnumerable<Food.Restaurant> GetRestaurants()
        {
            return dbContext.Restaurants;
        }

        public Food.Restaurant Update(Food.Restaurant restaurant)
        {
            var entity = dbContext.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity.Entity;
        }
    }
}
