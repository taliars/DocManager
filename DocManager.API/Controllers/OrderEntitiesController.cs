using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DocManager.Domain.Core.OrderEntities;
using DocManager.Domain.Interfaces;
using System.Linq;

namespace DocManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderEntitiesController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly ILogger<OrderEntitiesController> _logger;

        public OrderEntitiesController(IOrderRepository orderRepository, ILogger<OrderEntitiesController> logger)
        {
            this.orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OrderProjection> Get()
        {
            return orderRepository.GetOrderList().Select(x => new OrderProjection
            {
                SubscriptionName = x.Subscription?.Name,
                CustomerName = x.Customer?.Name ?? "This is no customer at the moment"
            });
        }
    }

    public class OrderProjection
    {
        public string SubscriptionName { get; set; }

        public string CustomerName { get; set; }
    }
}
