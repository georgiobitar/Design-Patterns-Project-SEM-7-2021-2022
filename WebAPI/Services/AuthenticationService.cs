using Infrastructure;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> userRepository;

        public AuthenticationService(IRepository<User> userRepository) //Dependency Injection
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

        public SignUpResponseDTO SignUp(SignUpRequestDTO signUpRequest)
        {
            try
            {
                List<User> users = new List<User>();
                users = userRepository.GetAll();
                if (users.Find(u => u.UserName == signUpRequest.UserName)!=null)
                {
                    return new SignUpResponseDTO()
                    {
                        Success = false,
                        Message = "UserName Already Exists!"
                    };
                }
                if (users.Find(u => u.Email == signUpRequest.Email) != null)
                {
                    return new SignUpResponseDTO()
                    {
                        Success = false,
                        Message = "Email Already Exists!"
                    };
                }
                if (users.Find(u => u.PhoneNumber == signUpRequest.PhoneNumber) != null)
                {
                    return new SignUpResponseDTO()
                    {
                        Success = false,
                        Message = "Phone Already Exists!"
                    };
                }
                User user = new User() 
                {
                    UserName = signUpRequest.UserName,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    Email = signUpRequest.Email,
                    EmailVerified = "false",
                    PhoneNumber = signUpRequest.PhoneNumber,
                    PhoneNumberVerified = "false",
                    Country = signUpRequest.Country,
                    Password = signUpRequest.Password
                };
                userRepository.Add(user);
                return new SignUpResponseDTO()
                {
                    Success = true,
                    Message = "Sign Up Successfull! Login to continue the verification process!"
                };
            }
            catch(Exception ex)
            {
                return new SignUpResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }
        }
    }
}
