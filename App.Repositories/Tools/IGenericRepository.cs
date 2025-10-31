using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Tools
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> expression);
        Task<T?> Get(int id);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
