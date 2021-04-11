using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DocManager.Services.Contract.Interfaces;
using DocManager.Core.OrderEntities;
using Microsoft.AspNetCore.Authorization;

namespace DocManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public async Task<DbOrder> Get()
        {
            return await orderService.GetByIdAsync(1);
        }


        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, OrderModel orderModel)
        {
            return BadRequest();
        }
    }
}
