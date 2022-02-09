using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            Console.WriteLine("test");
            Console.Write(" nice");
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("[controller]/Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            try
            {
                LoginResponseDTO res = authenticationService.Login(loginRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResponseDTO() { Success = false, Message = "An error has occured" + ex });
            }
        }

        [HttpPost]
        [Route("[controller]/SignUp")]
        public async Task<ActionResult<SignUpResponseDTO>> SignUp(SignUpRequestDTO signUpRequest)
        {
            try
            {

                SignUpResponseDTO res = authenticationService.SignUp(signUpRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new SignUpResponseDTO() { Success = false, Message = "An erro has occured" + ex });
            }
        }

        [HttpPost]
        [Route("[controller]/SendMobileCode")]
        public async Task<ActionResult<SendMobileCodeResponseDTO>> SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequest)
        {
            try
            {
                SendMobileCodeResponseDTO res = authenticationService.SendMobileCode(sendMobileCodeRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new SendMobileCodeResponseDTO() { Success = false, Message = "An error has occured" + ex });
            }
        }

        [HttpPost]
        [Route("[controller]/VerifyMobileCode")]
        public async Task<ActionResult<VerifyMobileCodeResponseDTO>> VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequest)
        {
            try
            {
                VerifyMobileCodeResponseDTO res = authenticationService.VerifyMobileCode(verifyMobileCodeRequest);
               
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(new VerifyMobileCodeResponseDTO() { Success = false, Message = "An error has occured" + ex });

            }
        }

        [HttpPost]
        [Route("[controller]/SendEmailCode")]
        public async Task<ActionResult<SendEmailCodeResponseDTO>> SendEmailCode(SendEmailCodeRequestDTO sendEmaillCodeRequest)
        {
            try
            {
                SendEmailCodeResponseDTO res = authenticationService.SendEmailCode(sendEmaillCodeRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new SendEmailCodeResponseDTO() { Success = false, Message = "An error has occured" + ex });
            }
        }

        [HttpPost]
        [Route("[controller]/VerifyEmailCode")]
        public async Task<ActionResult<VerifyEmailCodeResponseDTO>> VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequest)
        {
            try
            {
                VerifyEmailCodeResponseDTO res = authenticationService.VerifyEmailCode(verifyEmailCodeRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new VerifyMobileCodeResponseDTO() { Success = false, Message = "An error has occured" + ex });

            }
        }

    }
}
