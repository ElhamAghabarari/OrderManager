using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Interface
{
    public interface IUnitOfWork
    {
        void Save();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
