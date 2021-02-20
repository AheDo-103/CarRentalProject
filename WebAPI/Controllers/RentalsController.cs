using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Conctrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            return ReturnResult(result);
        }

        [HttpGet("getalldetailsforsingle")]
        public IActionResult GetAllDetailsForSingle()
        {
            var result = _rentalService.GetAllDetailsForSingle();
            return ReturnResult(result);
        }

        [HttpGet("getalldetailsforlist")]
        public IActionResult GetAllDetailsForList()
        {
            var result = _rentalService.GetAllDetailsForList();
            return ReturnResult(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int entityId)
        {
            var result = _rentalService.Get(entityId);
            return ReturnResult(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return ReturnResult(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            return ReturnResult(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            return ReturnResult(result);
        }

        private IActionResult ReturnResult(IResult result)
        {
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}