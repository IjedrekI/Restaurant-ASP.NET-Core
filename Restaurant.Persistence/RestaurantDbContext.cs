using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Persistence
{
    public class RestaurantDbContext: DbContext
    {
        public DbSet<Food.Restaurant> Restaurants { get; set; }

    }
}
