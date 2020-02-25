using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            if (ModelState.IsValid && restaurantModel != null) //method is coming from web.http library API Controller 
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

        //Get all - grab table from context and return it. Don't need any parameter because we are not filtering we just need everything 

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            //have to call in the ToListAsync 
            //have to return Ok because it has to return the task... use ok then pass in "restaurants so it know 

            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //Get by ID

        //Have to pass in Id as parameter because that is what we are looking for 
        //Access _context (which houses all resturants)

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            //need to check to see if null or not, because FindAsync requires an if found and if null return  

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        //Put (Update)

        //annotations tells us where parameters are coming from 

       [HttpPut]

       //we can have methods that simply updated just one property (example... just would updated "restaurant name" 
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model)
        {
            if(ModelState.IsValid && model != null)
            {
                Restaurant restaurantDatabaseEntity = await _context.Restaurants.FindAsync(id);

                if(restaurantDatabaseEntity != null)
                {
                    //if not null apply these changes... apply it to resturant
                    restaurantDatabaseEntity.Name = model.Name;
                    restaurantDatabaseEntity.Rating = model.Rating;
                    restaurantDatabaseEntity.Style = model.Style;
                    restaurantDatabaseEntity.DollarSigns = model.DollarSigns;

                    await _context.SaveChangesAsync(); //applies to c# object

                    return Ok();    //but not applied to database until we move through and hit this line of cod 
                }
                return NotFound(); //answers the question if rest != null is false... then entity was not found 
            }

            return BadRequest(ModelState);
        }



        //Delete by ID

    }
}
