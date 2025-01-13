using OrderManagment.Application.Interface;
using OrderManagment.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Service
{
    internal class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Order> _repository;
        public OrderService(IUnitOfWork work)
        {
            _unitOfWork = work;
            _repository = _unitOfWork.GetRepository<Order>();
        }
        public void DeleteOrder(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
        }

        public List<Order> GetAllOrders(int customerId, string search)
        {
            return _repository.GetAll((order) => order.CustomerId==customerId && order.Name.ToLower().Contains(search));
        }

        public Order GetOrder(int id)
        {
            return _repository.GetById(id);
        }

        public int InsertOrder(Order order)
        {
            _repository.Add(order);
            _unitOfWork.Save();
            return order.Id;
        }

        public void UpdateOrder(Order order)
        {
            _repository.Update(order);
            _unitOfWork.Save();
        }
    }
}
