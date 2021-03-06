using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Models;

namespace Infrastructure.Model.Responses
{
    public class VerifyEmailCodeResponseDTO : Response
    {
        public bool Success { get; set; }
        public User User { get; set; }
    }
}
