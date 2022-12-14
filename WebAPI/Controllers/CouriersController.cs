using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _courierService.GetAll();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _courierService.GetById(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("listorderstobedelivered")]
        public IActionResult ListOrdersToBeDelivered()
        {
            var result = _courierService.ListOrdersToBeDelivered();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("getpackage")]
        public IActionResult GetPackage(Order order)
        {
            var result = _courierService.GetPackage(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("orderdelivered")]
        public IActionResult OrderDelivered(Order order)
        {
            var result = _courierService.OrderDelivered(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("acceptdelivery")]
        public IActionResult AcceptDelivery(Order order)
        {
            var result = _courierService.AcceptDelivery(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Courier courier)
        {
            var result = _courierService.Add(courier);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Courier courier)
        {
            var result = _courierService.Update(courier);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _courierService.Delete(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
