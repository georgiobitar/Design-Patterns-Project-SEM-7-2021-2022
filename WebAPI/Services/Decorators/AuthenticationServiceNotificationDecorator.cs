using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using System.Diagnostics;
using System.Management.Automation;

namespace WebAPI.Services.Decorators
{
    public class AuthenticationServiceNotificationDecorator : IAuthenticationService
    {
        private IAuthenticationService authenticationService;

        public AuthenticationServiceNotificationDecorator(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {

            LoginResponseDTO loginResponseDTO = await authenticationService.Login(loginRequest);
            if (loginResponseDTO.Success)
            {
                var ps1File = @"H:\BurntToast\Login.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1File}\"",
                    UseShellExecute = false
                };
                Process.Start(startInfo);
            }

            return loginResponseDTO;
        }

        public async Task<SendEmailCodeResponseDTO> SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequestDTO)
        {
            return await authenticationService.SendEmailCode(sendEmailCodeRequestDTO);
        }

        public async Task<SendMobileCodeResponseDTO> SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO)
        {
            return await authenticationService.SendMobileCode(sendMobileCodeRequestDTO);
        }

        public async Task<SignUpResponseDTO> SignUp(SignUpRequestDTO signUpRequest, bool isAdmin)
        {

            SignUpResponseDTO signUpResponseDTO = await authenticationService.SignUp(signUpRequest, isAdmin);
            if (signUpResponseDTO.Success)
            {
                var ps1File = @"H:\BurntToast\SignUp.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1File}\"",
                    UseShellExecute = false
                };
                Process.Start(startInfo);
            }

            return signUpResponseDTO;
        }

        public async Task<VerifyEmailCodeResponseDTO> VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO)
        {
            return await authenticationService.VerifyEmailCode(verifyEmailCodeRequestDTO);
        }

        public async Task<VerifyMobileCodeResponseDTO> VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO)
        {
            return await authenticationService.VerifyMobileCode(verifyMobileCodeRequestDTO);
        }
    }
}
