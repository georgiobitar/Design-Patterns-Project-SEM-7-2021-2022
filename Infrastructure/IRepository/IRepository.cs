using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity, List<string> columns);
        T Get(Guid id);
        List<T> GetAll();

        T Find(Expression<Func<User, bool>> predicate);
        IEnumerable<T> All();

        void SaveChanges();
    }
}
