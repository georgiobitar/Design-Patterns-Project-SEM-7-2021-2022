using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Models;

namespace Infrastructure.Model.Requests
{
    public class SendMobileCodeRequestDTO : Request
    {
        public User User { get; set; }
    } 
}
