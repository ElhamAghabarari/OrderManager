using OrderManagment.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Infrastructure
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderDbContext _context;
        public Repository(OrderDbContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T? item = _context.Set<T>().Find(id);
            if (item != null)
                _context.Set<T>().Remove(item);
        }

        public List<T> GetAll(Func<T,bool> filter)
        {
            var res = _context.Set<T>().AsQueryable();
            return res.Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
