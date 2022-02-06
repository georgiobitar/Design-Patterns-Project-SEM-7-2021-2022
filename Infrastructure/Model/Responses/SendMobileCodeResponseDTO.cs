using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Models;

namespace Infrastructure.Model.Responses
{
    public class SendMobileCodeResponseDTO : Response
    {
        public bool Success { get; set; }
        public User User { get; set; }
    }
}
