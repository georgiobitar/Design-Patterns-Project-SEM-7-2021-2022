using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EmailVerified { get; set; } = null!;
        public string? EmailCode { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string PhoneNumberVerified { get; set; } = null!;
        public string? PhoneCode { get; set; }
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
