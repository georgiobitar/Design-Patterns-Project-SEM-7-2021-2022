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
        protected DBDataContext context;
        public UserRepository() 
        {
            this.context = new DBDataContext();
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
            return context.Users.FirstOrDefault(predicate);
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            context.SubmitChanges();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
