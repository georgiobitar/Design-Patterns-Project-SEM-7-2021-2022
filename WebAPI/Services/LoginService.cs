using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Models;
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
            this.userRepository = userRepository;
        }
        public LoginResponseDTO Login(LoginRequestDTO loginRequest)
        {
            
            try
            {
                bool correct = userRepository.Find(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password) != null;
                return new LoginResponseDTO()
                {
                    Success = correct,
                    Message = correct ? "Sign in Successful" : "Wrong UserName or Password"
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
