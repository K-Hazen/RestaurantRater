using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        //we are going to build our methods to return status codes
        //we are going to be using an interface as a return (IHttpActionResult) 

        //POST - first so that we can see them

        //we are going to need an instance of the same variable mulitple times so we create a field 

        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        //this is our doorman, our endpoint... if you want to post something you need to go through here so we need to pass in Restaurant to connect it to our Restaurant model 

        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurantModel)
        {
            //wrapping in if statement to check and make sure everything is in the model is valid
            //ModelState = checking the annotations in the model 
            
            if(ModelState.IsValid && restaurantModel != null) //method is coming from web.http library API Controller 
            {
                //Restaurants is the name of the data table  -- and so we are adding a model into the database (i.e. restaurant)
                _context.Restaurants.Add(restaurantModel);

                //need to save changes to database 

                await _context.SaveChangesAsync();

                //returns the ok that the connection was made (200 message)

                return Ok();
            }

            //another method within the web.http library API Controller  -- passing in ModelState because it then brings in the error
            return BadRequest(ModelState); 
        }

    }
}
