using OrderManagment.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders(int customerId,string search);
        Order GetOrder(int id);
        int InsertOrder(Order customer);
        void UpdateOrder(Order customer);
        void DeleteOrder(int id);
    }
}
