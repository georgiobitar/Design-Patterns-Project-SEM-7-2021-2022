using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService loginService;
        public ILogger<AuthenticationController> Logger { get; }


        public AuthenticationController(ILoginService loginService, ILogger<AuthenticationController> logger)
        {
            this.loginService = loginService;
            Logger = logger;
        }

        [HttpGet(Name = "Login")]
        public LoginResponseDTO Login(User user)
        {
            LoginRequestDTO loginRequest = new LoginRequestDTO() { UserName = user.UserName, Password = user.Password };
            return loginService.Login(loginRequest);

        }
    }
}
