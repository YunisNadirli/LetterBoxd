using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Tools
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _set = context.Set<T>();
        public void Add(T entity) => _set.Add(entity);

        public void Delete(T entity) => _set.Remove(entity);

        public Task<T?> Get(int id) => _set.FirstOrDefaultAsync(x => x.Id == id);

        public List<T> GetAll() => _set.ToList();

        public void Update(T entity) => _set.Update(entity);

        public List<T> Where(Expression<Func<T, bool>> expression) => _set.Where(expression).ToList();
    }
}
