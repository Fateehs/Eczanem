using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _customerService.GetByUserId(userId);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getconfirmationnumber")]
        public IActionResult GetConfirmationNumber(string orderNumber)
        {
            var result = _customerService.GetConfirmationNumber(orderNumber);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        //[HttpPost("addorder")]
        //public IActionResult AddOrder(CustomerOrderDTO customerOrderDTO)
        //{
        //    var result = _customerService.AddOrder(customerOrderDTO);

        //    if (!result.Success) return BadRequest(result);
        //    return Ok(result);
        //}

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
