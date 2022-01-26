using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService loginService;

        public AuthenticationController(ILoginService loginService)
        {
            
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            try
            {
                var x = loginService.Login(new LoginRequestDTO() { UserName = loginRequest.UserName, Password = loginRequest.Password });
                return Ok(x);
            }
            catch(Exception ex)
            {
                return BadRequest(new LoginResponseDTO() { Success=false, Message="An error has occured"});
            }
        }

    }
}
