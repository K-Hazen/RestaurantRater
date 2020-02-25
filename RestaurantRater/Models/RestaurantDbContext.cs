using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext
    {
        //This constructor is connecting to the "connection string" of code --> see "name" in web.config section should be the same as what you put in the base ( )

        public RestaurantDbContext() : base("DefaultConnection")
        {

        }

        //creating a table for our model. Takes in a "T entity" (i.e. entity framework). Typically entity is database level model
        //Then call in our Restaurant class (i.e. model) 

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}