using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        protected DesignPatterns20212022_TRAFFICSIMULATORContext context;
        
        public UserRepository(DesignPatterns20212022_TRAFFICSIMULATORContext context)
        {
            this.context = context;
        }

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public User Find(Expression<Func<User, bool>> predicate)
        {
            var x = context.Users.FirstOrDefault(predicate) ?? null;
            return x;
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
