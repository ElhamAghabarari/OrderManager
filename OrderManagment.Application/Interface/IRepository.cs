﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll(Func<T, bool> filter);
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
