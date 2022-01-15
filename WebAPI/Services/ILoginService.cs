using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;

namespace WebAPI.Services
{
    public interface ILoginService
    {
        LoginResponseDTO Login(LoginRequestDTO loginRequest);
    }
}
