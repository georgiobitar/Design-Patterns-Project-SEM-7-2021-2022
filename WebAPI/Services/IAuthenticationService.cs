using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;

namespace WebAPI.Services
{
    public interface IAuthenticationService
    {
        LoginResponseDTO Login(LoginRequestDTO loginRequest);

        SignUpResponseDTO SignUp(SignUpRequestDTO signUpRequest);
    }
}
