using Domain.Restaurants;
using Domain.Restaurants.Models;
using Infrastructure.Data.Repositories.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {

        public RestaurantDbContext _restaurantDbContext { get; }

        public RestaurantRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }


        public Task Create(Restaurant restaurant)
        {
            _restaurantDbContext.Restaurant.Add(restaurant);
            _restaurantDbContext.SaveChanges();

            return Task.FromResult(restaurant);
        }

        public Task Delete(int idRestaurant)
        {
            var restaurant = _restaurantDbContext.Restaurant.Find(idRestaurant);
            _restaurantDbContext.Restaurant.Remove(restaurant);
            _restaurantDbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<List<Restaurant>> FindAll()
        {
            var restaurants = _restaurantDbContext.Restaurant.ToList();
            return Task.FromResult(restaurants);

        }

        public Task<Restaurant> FindById(int idRestaurant)
        {
            var restaurant = _restaurantDbContext.Restaurant.Find(idRestaurant);

            return Task.FromResult(restaurant);
        }

        public Task Update(Restaurant restaurant)
        {
            _restaurantDbContext.Restaurant.Update(restaurant);
            _restaurantDbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
