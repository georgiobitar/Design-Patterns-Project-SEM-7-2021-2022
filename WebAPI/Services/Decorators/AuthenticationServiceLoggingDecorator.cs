using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using System.Diagnostics;
using System.Management.Automation;

namespace WebAPI.Services.Decorators
{
    public class AuthenticationServiceLoggingDecorator : IAuthenticationService
    {
        private IAuthenticationService authenticationService;

        public AuthenticationServiceLoggingDecorator(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            Stopwatch sw = Stopwatch.StartNew();
            LoginResponseDTO loginResponseDTO = await authenticationService.Login(loginRequest);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Logged in, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return loginResponseDTO;
        }

        public async Task<SendEmailCodeResponseDTO> SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SendEmailCodeResponseDTO sendEmailCodeResponseDTO = await authenticationService.SendEmailCode(sendEmailCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Sent Email code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return sendEmailCodeResponseDTO;
        }

        public async Task<SendMobileCodeResponseDTO> SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SendMobileCodeResponseDTO sendMobileCodeResponseDTO = await authenticationService.SendMobileCode(sendMobileCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Sent Mobile Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return sendMobileCodeResponseDTO;
        }

        public async Task<SignUpResponseDTO> SignUp(SignUpRequestDTO signUpRequest, bool isAdmin)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SignUpResponseDTO signUpResponseDTO = await authenticationService.SignUp(signUpRequest, isAdmin);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Signed Up, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return signUpResponseDTO;
        }

        public async Task<VerifyEmailCodeResponseDTO> VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            VerifyEmailCodeResponseDTO verifyEmailCodeResponseDTO = await authenticationService.VerifyEmailCode(verifyEmailCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Verified Email Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return verifyEmailCodeResponseDTO;
        }

        public async Task<VerifyMobileCodeResponseDTO> VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            VerifyMobileCodeResponseDTO verifyMobileCodeResponseDTO = await authenticationService.VerifyMobileCode(verifyMobileCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log(DateTime.Now + $" Verified Mobile Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return verifyMobileCodeResponseDTO;
        }
    }
}
