using Infrastructure.Model.enums;
using Infrastructure.Models;
using WebAPI.Exceptions;

namespace WebAPI.Handlers
{
    public class EmailVerifiedHandler : LoginHandler<User>
    {
       
        public override void Handle(User request)
        {
            //condition
            //do stg
            if (request.EmailVerified == "true")
            {
                //base.Handle(request);
                PhoneNumberVerifiedHandler phonehandler = (PhoneNumberVerifiedHandler)GetBefore();
                phonehandler.Status = NextPageStatus.MainPage;
            }
            else
            {
                PhoneNumberVerifiedHandler phonehandler= (PhoneNumberVerifiedHandler)GetBefore();
                phonehandler.Status = NextPageStatus.VerifyEmail;
            }
        }
    }
}
