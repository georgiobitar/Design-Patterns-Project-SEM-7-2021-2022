using Infrastructure;
using Infrastructure.Models;

namespace WebAPI.Structural
{
    public sealed class Singleton
    {
        //lazy initialization which has a thread safe pattern to handle null instance initialization
        public static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        private static User _user;
        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance Called", @"H:\DesignPatternsProjectLogsSingleton.txt");
                return _instance.Value;
            }
        }

        private Singleton()
        {
            Logger.Log("Constructor invoked.", @"H:\DesignPatternsProjectLogsSingleton.txt");
        }

        public static void SetUser(User user)
        {
            _user = user;
            Logger.Log("User Set.", @"H:\DesignPatternsProjectLogsSingleton.txt");
        }


        public static User GetUser()
        {
            Logger.Log("User Returned.", @"H:\DesignPatternsProjectLogsSingleton.txt");
            return _user;
        }
    }
}
