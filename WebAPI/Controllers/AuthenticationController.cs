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
            
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("[controller]/Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            try
            {
                var res = authenticationService.Login(loginRequest);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(new LoginResponseDTO() { Success=false, Message="An error has occured" + ex});
            }
        }
        
        [HttpPost]
        [Route("[controller]/SignUp")]
        public async Task<ActionResult<SignUpResponseDTO>> SignUp(SignUpRequestDTO signUpRequest)
        {
            try
            {

                var res= authenticationService.SignUp(signUpRequest);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(new SignUpResponseDTO() { Success = false, Message = "An erro has occured" + ex});
            }
        }

    }
}
