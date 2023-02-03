using Domain.Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurants
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> FindAll();
        Task<Restaurant> FindById(int idRestaurant);
        Task Create(Restaurant restaurant);
        Task Update(Restaurant restaurant);
        Task Delete(int idRestaurant);
    }
}
