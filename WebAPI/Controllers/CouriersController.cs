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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _courierService.GetAll();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _courierService.GetById(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Courier courier)
        {
            var result = _courierService.Add(courier);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Update(Courier courier)
        {
            var result = _courierService.Update(courier);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _courierService.Delete(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
