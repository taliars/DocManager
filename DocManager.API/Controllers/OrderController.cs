using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DocManager.Domain.Core.OrderEntities;
using System.Threading.Tasks;
using DocManager.Services.Interfaces;

namespace DocManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<DbOrder> Get()
        {
            return await orderService.GetByIdAsync(1);
        }


        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, OrderModel orderModel)
        {
            return BadRequest();
        }
    }
}
