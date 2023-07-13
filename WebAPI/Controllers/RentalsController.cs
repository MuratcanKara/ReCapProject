using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalsService;

        public RentalsController(IRentalService rentaalsService)
        {
            _rentalsService = rentaalsService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalsService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalsService.Delete(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result);
            }
        }



        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalsService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalsService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int rentalId)
        {
            var result = _rentalsService.GetById(rentalId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
