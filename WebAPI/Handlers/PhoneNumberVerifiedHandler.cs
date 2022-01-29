using Infrastructure.Models;

namespace WebAPI.Handlers
{
    public class PhoneNumberVerifiedHandler : Handler<User>
    {
        private PhoneNumberVerifiedHandler phoneNumberVerifiedHandler 
            = new PhoneNumberVerifiedHandler();

        public override void Handle(User request)
        {
            //condition
            //do stg
            base.Handle(request);
        }
    }
}
