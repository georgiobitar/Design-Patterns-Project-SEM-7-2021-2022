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

        public LoginResponseDTO Login(LoginRequestDTO loginRequest)
        {

            LoginResponseDTO loginResponseDTO = authenticationService.Login(loginRequest);
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

        public SendEmailCodeResponseDTO SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequestDTO)
        {
            return authenticationService.SendEmailCode(sendEmailCodeRequestDTO);
        }

        public SendMobileCodeResponseDTO SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO)
        {
            return authenticationService.SendMobileCode(sendMobileCodeRequestDTO);
        }

        public SignUpResponseDTO SignUp(SignUpRequestDTO signUpRequest, bool isAdmin)
        {

            SignUpResponseDTO signUpResponseDTO = authenticationService.SignUp(signUpRequest, isAdmin);
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

        public VerifyEmailCodeResponseDTO VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO)
        {
            return authenticationService.VerifyEmailCode(verifyEmailCodeRequestDTO);
        }

        public VerifyMobileCodeResponseDTO VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO)
        {
            return authenticationService.VerifyMobileCode(verifyMobileCodeRequestDTO);
        }
    }
}
