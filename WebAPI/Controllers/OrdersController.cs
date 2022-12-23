using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getdetailsbynumber")]
        public IActionResult GetDetailsByNumber(string number)
        {
            var result = _orderService.GetDetailsByNumber(number);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
