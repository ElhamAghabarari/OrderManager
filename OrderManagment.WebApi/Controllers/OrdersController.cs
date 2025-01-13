using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.Application.Interface;
using OrderManagment.Application.Model;

namespace OrderManagment.WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Order Get(int id)
        {
            return _orderService.GetOrder(id);
        }

        [HttpGet]
        [Route("customerOrders/{customerId}")]
        public List<Order> GetAll(int customerId, [FromQuery]string search="")
        {
            return _orderService.GetAllOrders(customerId,search);
        }

        [HttpPut]
        public ActionResult Add(Order order)
        {
            return Ok(_orderService.InsertOrder(order));
        }

        [HttpPost]
        public ActionResult Update(Order order)
        {
            _orderService.UpdateOrder(order);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
