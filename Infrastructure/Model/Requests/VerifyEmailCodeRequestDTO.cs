using Infrastructure.Model.DataContracts.Requests;

namespace Infrastructure.Model.Requests
{
    public class VerifyEmailCodeRequestDTO : Request
    {
        public string Username { get; set; }
        public string EmailCode { get; set; }
    }
}
