using Infrastructure.Model.DataContracts.Requests;

namespace Infrastructure.Model.Requests
{
    public class VerifyMobileCodeRequestDTO : Request
    {
        public string Username { get; set; }
        public string MobileCode { get; set; }
    }
}
