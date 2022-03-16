using Microsoft.AspNetCore.Mvc;
using System;
using Tesodev.Business.Abstract;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(Guid customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("create")]
        public IActionResult Create(CreateCustomerDto createCustomerDto)
        {
            var result = _customerService.Create(createCustomerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateCustomerDto updateCustomerDto)
        {
            var result = _customerService.Update(updateCustomerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Guid customerId)
        {
            var result = _customerService.Delete(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("validate")]
        public IActionResult Validate(Guid customerId)
        {
            var result = _customerService.Validate(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
