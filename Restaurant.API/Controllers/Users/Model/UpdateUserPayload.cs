using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Users.Model
{
    public class UpdateUserPayload
    {
        [Required(ErrorMessage = "The id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The name must contain between 3 and 30 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The password is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "The password must contain between 6 and 8 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "The email is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "The email must contain between 3 and 30 characters")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
