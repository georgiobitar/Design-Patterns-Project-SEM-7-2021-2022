using System.ComponentModel.DataAnnotations;

namespace AdminWeb.Models
{
    public class AdminViewModel
    {
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [RegularExpression($"^[0-9]*$", ErrorMessage ="Only Numbers are allowed.")]
        public string PhoneNumber { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
