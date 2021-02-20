using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Conctrete;
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
            return ReturnResult(result);
        }

        [HttpGet("getalldetailsforsingle")]
        public IActionResult GetAllDetailsForSingle()
        {
            var result = _customerService.GetAllDetailsForSingle();
            return ReturnResult(result);
        }

        [HttpGet("getalldetailsforlist")]
        public IActionResult GetAllDetailsForList()
        {
            var result = _customerService.GetAllDetailsForList();
            return ReturnResult(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int entityId)
        {
            var result = _customerService.Get(entityId);
            return ReturnResult(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            return ReturnResult(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return ReturnResult(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
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