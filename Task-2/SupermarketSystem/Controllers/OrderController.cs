﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.OrderDtos;
using SupermarketSystem.Models;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] OrderCreateParameters parameters)
        {
            await _orderService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Cancelled")]
        public async Task<IActionResult> Cancelled(int id)
        {
            await _orderService.CancelledAsync(id);
            return Ok();
        }
        [HttpPatch]
        [Route("Checkout")]
        public async Task<IActionResult> Checkout(int id)
        {
            await _orderService.CheckoutAsync(id);
            return Ok();
        }
        [HttpPatch]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(OrderUpdateParameters parameters)
        {
            await _orderService.AddProduct(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(OrderUpdateParameters parameters)
        {
            await _orderService.RemoveProduct(parameters);
            return Ok();
        }
    }
}
