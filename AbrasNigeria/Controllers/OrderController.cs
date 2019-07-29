using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ActionResult AddOrder([FromBody]Order order)
        {
            order.OrderNo = "CAN" + DateTime.Now.ToString("yyMMddHHmmss");
            _orderRepository.Create(order);
            return Ok();
        }
    }
}
