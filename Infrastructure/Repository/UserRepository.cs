using Infrastructure.DataBaseFactory;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
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
        private DesignPatterns20212022_TRAFFICSIMULATORContext context;
        public UserRepository(DesignPatterns20212022_TRAFFICSIMULATORContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User entity)
        {
            await context.Users.AddAsync(entity);
            SaveChanges();
            return entity;
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Find(Expression<Func<User, bool>> predicate)
        {
            var x = await context.Users.FirstOrDefaultAsync(predicate) ?? null;
            return x;
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }
        public void SaveChanges()
        {
            context.SaveChangesAsync();
        }

        public async Task<User> Update(User entity, List<string> columns)
        {
            foreach(string column in columns)
            {
                context.Entry(entity).Property(column).IsModified = true;
            }
            await context.SaveChangesAsync();
            return entity;

        }
    }
}
