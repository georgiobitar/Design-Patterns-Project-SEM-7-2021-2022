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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using WebAPI.Structural;
using System.Windows;

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
                User user = userRepository.Find(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);
                bool correct = user != null;

                return new LoginResponseDTO()
                {
                    Success = correct,
                    Message = correct ? "Sign in Successful" : "Wrong UserName or Password",
                    User = user
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
                if (users.Find(u => u.UserName == signUpRequest.UserName) != null)
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
            catch (Exception ex)
            {
                return new SignUpResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }
        }
        public SendMobileCodeResponseDTO SendMobileCode(SendMobileCodeRequestDTO sendMobileCodeRequestDTO)
        {
            try
            {
                Random r = new Random();
                int randNum = r.Next(1000000);
                string sixDigitNumber = randNum.ToString("D6");

                User user = sendMobileCodeRequestDTO.User;
                user.PhoneCode = sixDigitNumber;
                userRepository.Update(user, new List<string>() { "PhoneCode" });

                Logger.Log("The mobile code for " + user.UserName + " is " + user.PhoneCode);
                return new SendMobileCodeResponseDTO()
                {
                    Success = true,
                    Message = "Code Sent Successfully to your Mobile Number!",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new SendMobileCodeResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }
        }

        public VerifyMobileCodeResponseDTO VerifyMobileCode(VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO)
        {
            try
            {
                User user = userRepository.Find(u => u.UserName == verifyMobileCodeRequestDTO.Username);
                if (user == null || user.PhoneCode == null)
                {
                    return new VerifyMobileCodeResponseDTO()
                    {
                        Success = false,
                        Message = "Error has occured"
                    };
                }


                if (user.PhoneCode == verifyMobileCodeRequestDTO.MobileCode)
                {
                    user.PhoneNumberVerified = "true";
                    userRepository.Update(user, new List<string>() { "PhoneNumberVerified" });

                    return new VerifyMobileCodeResponseDTO()
                    {
                        Success = true,
                        Message = "Mobile Verified Successfully!",
                        User = user
                    };
                }
                return new VerifyMobileCodeResponseDTO()
                {
                    Success = false,
                    Message = "Wrong Code!"
                };


            }
            catch (Exception ex)
            {
                return new VerifyMobileCodeResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }

        }

        public SendEmailCodeResponseDTO SendEmailCode(SendEmailCodeRequestDTO sendEmailCodeRequest)
        {
            try
            {
                Random r = new Random();
                int randNum = r.Next(1000000);
                string sixDigitNumber = randNum.ToString("D6");

                User user = sendEmailCodeRequest.User;
                user.EmailCode = sixDigitNumber;
                userRepository.Update(user, new List<string>() { "EmailCode" });

                Logger.Log("The email code for " + user.UserName + " is " + user.EmailCode);
                return new SendEmailCodeResponseDTO()
                {
                    Success = true,
                    Message = "Code Sent Successfully to your Email!",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new SendEmailCodeResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }
        }

        public VerifyEmailCodeResponseDTO VerifyEmailCode(VerifyEmailCodeRequestDTO verifyEmailCodeRequestDTO)
        {
            try
            {
                User user = userRepository.Find(u => u.UserName == verifyEmailCodeRequestDTO.Username);
                if (user == null || user.EmailCode == null)
                {
                    return new VerifyEmailCodeResponseDTO()
                    {
                        Success = false,
                        Message = "Error has occured"
                    };
                }


                if (user.EmailCode == verifyEmailCodeRequestDTO.EmailCode)
                {
                    user.EmailVerified = "true";
                    userRepository.Update(user, new List<string>() { "EmailVerified" });

                    return new VerifyEmailCodeResponseDTO()
                    {
                        Success = true,
                        Message = "Email Verified Successfully!",
                        User = user
                    };
                }
                return new VerifyEmailCodeResponseDTO()
                {
                    Success = false,
                    Message = "Wrong Code!"
                };


            }
            catch (Exception ex)
            {
                return new VerifyEmailCodeResponseDTO()
                {
                    Success = false,
                    Message = "Error has occured" + ex
                };
            }

        }
    }
}
