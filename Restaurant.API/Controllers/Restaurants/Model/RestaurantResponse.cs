namespace WebAPI.Controllers.Restaurants.Model
{
    public class RestaurantResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
