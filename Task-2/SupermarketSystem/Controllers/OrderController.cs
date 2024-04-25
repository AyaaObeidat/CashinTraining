using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //=================================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody]OrderCreateParameters parameters)
        {
           var order = _orderRepository.Create(parameters);
           
            return Ok(order);
        }

        //=================================================================
        [HttpPost]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var order = _orderRepository.Details();
            if (order == null) { return BadRequest(); }
            return Ok(order);
        }
        //=================================================================
        [HttpPost]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) { return BadRequest(); }
            return Ok(order);
        }
        //=================================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            int result = _orderRepository.Delete(id);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }
        //=================================================================

        [HttpPatch]
        [Route("AddProduct")]
        public IActionResult AddProduct(OrderUpdateParameters parameters)
        {
            var order = _orderRepository.AddProduct(parameters);
            return Ok(order);
        }
        ////=================================================================

        [HttpPatch]
        [Route("RemoveProduct")]
        public IActionResult RemoveProduct(OrderUpdateParameters parameters)
        {
            var order = _orderRepository.RemoveProduct(parameters);
            return Ok(order);
        }
    }
}
