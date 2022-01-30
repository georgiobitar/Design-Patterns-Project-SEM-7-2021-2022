using Infrastructure.Model.enums;
using Infrastructure.Models;
using WebAPI.Exceptions;

namespace WebAPI.Handlers
{
    public class PhoneNumberVerifiedHandler : LoginHandler<User>
    {

        public override void Handle(User request)
        {
            //condition
            //do stg
            if (request.PhoneNumberVerified =="true")
            {
                base.Handle(request);
            }
            else
            {
                base.Status = NextPageStatus.VerifyMobileNumber;
                //throw new PhoneNotVerifiedException("Phone Number not verified");
            }
        }
    }
}
