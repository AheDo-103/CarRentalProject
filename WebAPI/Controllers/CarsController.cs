using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Conctrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return ReturnResult(result);
        }
        
        [HttpGet("getalldetailsforsingle")]
        public IActionResult GetAllDetailsForSingle()
        {
            var result = _carService.GetAllDetailsForSingle();
            return ReturnResult(result);
        }

        [HttpGet("getalldetailsforlist")]
        public IActionResult GetAllDetailsForList()
        {
            var result = _carService.GetAllDetailsForList();
            return ReturnResult(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int entityId)
        {
            var result = _carService.Get(entityId);
            return ReturnResult(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            return ReturnResult(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            return ReturnResult(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
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