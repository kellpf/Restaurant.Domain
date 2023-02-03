using Domain.Restaurants.Mappers;
using Domain.Restaurants.Models;
using Domain.Restaurants.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        public IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Task Create(CreateRestaurant restaurant)
        {
            CreateRestaurantValidator validator = new CreateRestaurantValidator();
            var validation = validator.Validate(restaurant);
            if (!validation.IsValid)
                return Task.FromResult(validation.ToString());
            
            var convertRestaurant = RestaurantMapper.ToRestaurant(restaurant);
            _restaurantRepository.Create(convertRestaurant);
            return Task.CompletedTask;
        }

        public Task Delete(int idRestaurant)
        {
                _restaurantRepository.Delete(idRestaurant);
                return Task.CompletedTask;
        }

        public async Task<List<Restaurant>> FindAll()
        {
            var restaurants = await _restaurantRepository.FindAll();
            if (!restaurants.Any())
                return new List<Restaurant>();
            return restaurants;
        }

        public async Task<Restaurant> FindById(int idRestaurant)
        {
            var restaurant = await _restaurantRepository.FindById(idRestaurant);
            return restaurant;
        }

        public Task Update(Restaurant restaurant)
        {
            RestaurantValidator validator = new RestaurantValidator();
            var validation = validator.Validate(restaurant);
            if (!validation.IsValid)
                return Task.FromResult(validation.ToString());
            _restaurantRepository.Update(restaurant);
            return Task.CompletedTask;
        }
    }
}
