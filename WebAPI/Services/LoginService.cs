using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<User> userRepository;

        public LoginService(IRepository<User> userRepository) //Dependency Injection
        {
            this.userRepository = new UserRepository();
        }
        public LoginResponseDTO Login(LoginRequestDTO loginRequest)
        {
            
            try
            {
                return new LoginResponseDTO() 
                { 
                    Success = userRepository.Find(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password) != null,
                };
            }
            catch (Exception ex)
            {
                return new LoginResponseDTO()
                {
                    Success = false,
                    Message = "Error Has Occured: " + ex 
                };
            }
        }
    }
}
