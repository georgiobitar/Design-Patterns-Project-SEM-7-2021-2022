using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using System.Diagnostics;

namespace WebAPI.Services.Decorators
{
    public class AuthenticationServiceLoggingDecorator : IAuthenticationService
    {
        private IAuthenticationService authenticationService;

        public AuthenticationServiceLoggingDecorator(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public LoginResponseDTO Login(LoginRequestDTO loginRequest)
        {
            Stopwatch sw = Stopwatch.StartNew();
            LoginResponseDTO loginResponseDTO = authenticationService.Login(loginRequest);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Logged in, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");

            return loginResponseDTO;
        }

        public SendEmailCodeResponseDTO SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SendEmailCodeResponseDTO sendEmailCodeResponseDTO = authenticationService.SendEmailCode(sendEmailCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Sent Email code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return sendEmailCodeResponseDTO;
        }

        public SendMobileCodeResponseDTO SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SendMobileCodeResponseDTO sendMobileCodeResponseDTO = authenticationService.SendMobileCode(sendMobileCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Sent Mobile Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return sendMobileCodeResponseDTO;
        }

        public SignUpResponseDTO SignUp(SignUpRequestDTO signUpRequest)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SignUpResponseDTO signUpResponseDTO = authenticationService.SignUp(signUpRequest);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Signed Up, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return signUpResponseDTO;
        }

        public VerifyEmailCodeResponseDTO VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            VerifyEmailCodeResponseDTO verifyEmailCodeResponseDTO = authenticationService.VerifyEmailCode(verifyEmailCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Verified Email Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return verifyEmailCodeResponseDTO;
        }

        public VerifyMobileCodeResponseDTO VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO)
        {
            Stopwatch sw = Stopwatch.StartNew();
            VerifyMobileCodeResponseDTO verifyMobileCodeResponseDTO = authenticationService.VerifyMobileCode(verifyMobileCodeRequestDTO);
            sw.Stop();
            long elapsedMillis = sw.ElapsedMilliseconds;
            Logger.Log($"Verified Mobile Code, Elapsed ms : {elapsedMillis}", @"H:\DesignPatternsProjectTimeLogs.txt");
            return verifyMobileCodeResponseDTO;
        }
    }
}
