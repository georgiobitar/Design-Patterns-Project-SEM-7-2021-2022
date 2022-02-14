using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;

namespace WebAPI.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);

        Task<SignUpResponseDTO> SignUp(SignUpRequestDTO signUpRequest, bool isAdmin);

        Task<VerifyMobileCodeResponseDTO> VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO);

        Task<SendMobileCodeResponseDTO> SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO);

        Task<VerifyEmailCodeResponseDTO> VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO);

        Task<SendEmailCodeResponseDTO> SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequestDTO);
    }
}
