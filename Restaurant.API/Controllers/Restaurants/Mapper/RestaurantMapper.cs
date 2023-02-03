using Domain.Restaurants.Models;
using NPOI.SS.Formula.Functions;
using WebAPI.Controllers.Restaurants.Model;
using WebAPI.Shared.Model;

namespace WebAPI.Controllers.Restaurants.Mapper
{
    public static class RestaurantMapper
    {
        public static CreateRestaurant CreateToDomain(CreateRestaurantPayload restaurantPayload)
        {
            return new()
            {
                Name = restaurantPayload.Name,  
                Description = restaurantPayload.Description,
            };
        }

        public static Restaurant UploadToDomain(UpdateRestaurantPayload restaurantPayload)
        {
            return new()
            {
                Id = restaurantPayload.Id,
                Name = restaurantPayload.Name,
                Description = restaurantPayload.Description,
                Status = restaurantPayload.Status
            };
        }

        public static Restaurant ToDomain(RestaurantResponse restaurantModel)
        {
            return new()
            {
                Id = restaurantModel.Id,
                Name = restaurantModel.Name,
                Description = restaurantModel.Description,
                Status = restaurantModel.Status
            };
        }

        public static RestaurantResponse ToController(Restaurant restaurant)
        {
            return new()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Status = restaurant.Status
            };
        }

        public static List<RestaurantResponse> ToControllerList(List<Restaurant> restaurant)
        {
            var list = new List<RestaurantResponse>();
            if (restaurant.Count > 0)
            {
                restaurant.ForEach((item) =>
                {
                    list.Add(new RestaurantResponse()
                    {
                        Name = item.Name,
                        Status = item.Status,
                        Description = item.Description,
                        Id = item.Id
                    });
                });
            }
            return list;
        }
    }
}
