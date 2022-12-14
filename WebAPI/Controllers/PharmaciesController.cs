using Business.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        IPharmacyService _pharmacyService;

        public PharmaciesController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _pharmacyService.GetAll();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _pharmacyService.GetById(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("listorders")]
        public IActionResult ListOrders()
        {
            var result = _pharmacyService.ListOrders();

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("givepackagetocourier")]
        public IActionResult GivePackageToCourier(Order order)
        {
            var result = _pharmacyService.GivePackageToCourier(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("acceptorderfromcustomer")]
        public IActionResult AcceptOrderFromCustomer(Order order)
        {
            var result = _pharmacyService.AcceptOrderFromCustomer(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("readyfordeliver")]
        public IActionResult ReadyForDeliver(Order order)
        {
            var result = _pharmacyService.ReadyForDelivery(order);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Pharmacy pharmacy)
        {
            var result = _pharmacyService.Add(pharmacy);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Pharmacy pharmacy)
        {
            var result = _pharmacyService.Update(pharmacy);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _pharmacyService.Delete(id);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
