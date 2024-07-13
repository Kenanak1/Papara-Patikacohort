using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Papara_cohort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<Customer>>> Get()
        {
            var list = _customerService.GetAll();
            return Ok(new ApiResponse<List<Customer>>(list));
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<Customer>> Get(int id)
        {
            var item = _customerService.GetById(id);
            if (item is null)
            {
                return NotFound(new ApiResponse<Customer>("Item not found in system."));
            }
            return Ok(new ApiResponse<Customer>(item));
        }

        [HttpGet("ByNameQuery")]
        public ActionResult<ApiResponse<List<Customer>>> Search([FromQuery] string name)
        {
            var results = _customerService.SearchByName(name);
            if (!results.Any())
            {
                return NotFound(new ApiResponse<List<Customer>>("No items found in system."));
            }
            return Ok(new ApiResponse<List<Customer>>(results));
        }

        [HttpGet("ListByName")]
        public ActionResult<ApiResponse<List<Customer>>> List([FromQuery] string name = "")
        {
            var filteredList = _customerService.ListByName(name);
            return Ok(new ApiResponse<List<Customer>>(filteredList));
        }

        [HttpGet("Sort")]
        public ActionResult<ApiResponse<List<Customer>>> Sort([FromQuery] string sortBy, [FromQuery] bool descending = false)
        {
            var sortedList = _customerService.Sort(sortBy, descending);
            return Ok(new ApiResponse<List<Customer>>(sortedList));
        }

        [HttpPost]
        public ActionResult<ApiResponse<List<Customer>>> Post([FromBody] Customer value)
        {
            _customerService.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<Customer>>(_customerService.GetAll()));
        }

        [HttpPost("PostQuery")]
        public ActionResult<ApiResponse<List<Customer>>> Add([FromQuery] int id, [FromBody] Customer value)
        {
            value.Id = id;
            _customerService.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<Customer>>(_customerService.GetAll()));
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Put(int id, [FromBody] Customer value)
        {
            _customerService.Update(id, value);
            return Ok(new ApiResponse<List<Customer>>(_customerService.GetAll()));
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Delete(int id)
        {
            _customerService.Delete(id);
            return Ok(new ApiResponse<List<Customer>>(_customerService.GetAll()));
        }

        [HttpPatch("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Patch(int id, [FromBody] CustomerUpdateModel updateModel)
        {
            _customerService.Patch(id, updateModel);
            return Ok(new ApiResponse<List<Customer>>(_customerService.GetAll()));
        }
    }
}
