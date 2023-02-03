using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Votes.Model
{
    public class UpdateVotePayload
    {
        [Required(ErrorMessage = "The Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The IdUser is required")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "The IdRestaurant is required")]
        public int IdRestaurant { get; set; }

        [Required(ErrorMessage = "The Date is required")]
        public DateTime Date { get; set; }
    }
}
