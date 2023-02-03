using Domain.Restaurants.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurants
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> FindAll();
        Task<Restaurant> FindById(int idRestaurant);
        Task Create(CreateRestaurant restaurant);
        Task Update(Restaurant restaurant);
        Task Delete(int idRestaurant);
    }
}
