using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Model.DataContracts
{
    public partial class User
    {
        private string _UserId;
        private string _UserName;
        private string _FirstName;
        private string _LastName;
        private string _PhoneNumber;
        private bool _PhoneNumberVerified;
        private string _Email;
        private bool _EmailVerified;
        private string _Country;
        private string _Password;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        public bool PhoneNumberVerified
        {
            get { return _PhoneNumberVerified; }
            set { _PhoneNumberVerified = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public bool EmailVerified
        {
            get { return _EmailVerified; }
            set { _EmailVerified = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
    }
}
