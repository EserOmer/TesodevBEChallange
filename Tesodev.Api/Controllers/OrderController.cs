using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tesodev.Business.Abstract;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(Guid customerId)
        {
            var result = _orderService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("create")]
        public IActionResult Create(CreateOrderDto orderCreateDto)
        {
            var result = _orderService.Create(orderCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("changestatus")]
        public IActionResult ChangeStatus(Guid id,string status)
        {
            var result = _orderService.ChangeStatus(id, status);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(UpdateOrderDto orderUpdateDto)
        {
            var result = _orderService.Update(orderUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Guid orderId)
        {
            var result = _orderService.Delete(orderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
