using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        //This would be our restaurant model
        //this builds the primary key, which gets us into the data table and allows us to index through it (in it?). Currently the primary key because it is first in the list. Must always have a primary key when dealing with entity framework 
        
        [Key] //Making this a key automatically makes it a required field 
        public int Id { get; set; } 

        [Required] //annotation goes to the first thing it can apply to and then stops 
        public string Style { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double Rating { get; set; }

        [Required]
        [Range(1, 5)]
        public int DollarSigns { get; set; }

    }
}