using Infrastructure.Models;

namespace WebAPI.Handlers
{
    public class EmailVerifiedHandler : Handler<User>
    {
        private EmailVerifiedHandler emailVerifiedHandler 
            = new EmailVerifiedHandler();

        public override void Handle(User request)
        {
            //condition
            //do stg
            base.Handle(request);
        }
    }
}
