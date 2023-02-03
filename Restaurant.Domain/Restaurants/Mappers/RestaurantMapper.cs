using Domain.Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurants.Mappers
{
    public class RestaurantMapper
    {
        public static Restaurant ToRestaurant(CreateRestaurant restaurantCreate)
        {
            return new()
            {
                Name = restaurantCreate.Name,
                Description = restaurantCreate.Description
            };
        }
    }
}
