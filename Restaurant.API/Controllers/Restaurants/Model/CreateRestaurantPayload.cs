using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Restaurants.Model
{
    public class CreateRestaurantPayload
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must contain between 3 and 30 characters")]
        public string Name { get; set; } = string.Empty;


        [StringLength(250, MinimumLength = 50, ErrorMessage = "The description must contain betwenn 50 and 250 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
