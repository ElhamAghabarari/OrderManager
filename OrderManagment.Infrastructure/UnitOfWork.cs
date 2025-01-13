using OrderManagment.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> _repositories;
        private readonly OrderDbContext _context;
        public UnitOfWork(OrderDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }
        public IRepository<T> GetRepository<T>() where T : class 
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }
            var newRep = new Repository<T>(_context);
            _repositories.Add(typeof(T), newRep);
            return newRep;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
