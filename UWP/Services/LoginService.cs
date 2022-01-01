using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UWP.Services
{
    public class LoginService
    {
        private DataContext context;
        //private DBDataContext context;
        public LoginService()
        {  
            //context = new DBDataContext();
        }

        public void testc()
        {
            //User u = context.Users.FirstOrDefault(u => u.UserName == 'jounix');
        }
    }
}
