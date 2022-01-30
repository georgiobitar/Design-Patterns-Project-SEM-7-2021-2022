using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Models;

namespace Infrastructure.Model.Requests
{
    public class SendEmailCodeRequestDTO : Request
    {
        public User User { get; set; }
    }
}
