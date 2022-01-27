using Infrastructure.Model.DataContracts.Requests;

namespace Infrastructure.Model.Requests
{
    public class SignUpRequestDTO : Request
    {
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
