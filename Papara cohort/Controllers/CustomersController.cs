using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Papara_cohort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private List<Customer> list;

        public CustomersController()
        {
            list = new List<Customer>();
            list.Add(new Customer() { Id = 1, Name = "Test1", Age = 24 });
            list.Add(new Customer() { Id = 2, Name = "Test2", Age = 44 });
            list.Add(new Customer() { Id = 3, Name = "ATest3", Age = 34 });
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<Customer>>> Get()
        {
            return Ok(new ApiResponse<List<Customer>>(list));
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<Customer>> Get(int id)
        {
            var item = list?.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound(new ApiResponse<Customer>("Item not found in system."));
            }
            return Ok(new ApiResponse<Customer>(item));
        }

        [HttpGet("ByNameQuery")]
        public ActionResult<ApiResponse<List<Customer>>> Search([FromQuery] string name)
        {
            var results = list.Where(x => x.Name.Contains(name)).ToList();
            if (!results.Any())
            {
                return NotFound(new ApiResponse<List<Customer>>("No items found in system."));
            }
            return Ok(new ApiResponse<List<Customer>>(results));
        }

        [HttpGet("ListByName")]
        public ActionResult<ApiResponse<List<Customer>>> List([FromQuery] string name = "")
        {
            var filteredList = list;

            if (!string.IsNullOrEmpty(name))
            {
                filteredList = list.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(new ApiResponse<List<Customer>>(filteredList));
        }


        [HttpGet("Sort")]
        public ActionResult<ApiResponse<List<Customer>>> Sort([FromQuery] string sortBy, [FromQuery] bool descending = false)
        {
            List<Customer> sortedList;
            switch (sortBy?.ToLower())
            {
                case "name":
                    sortedList = descending ? list.OrderByDescending(x => x.Name).ToList() : list.OrderBy(x => x.Name).ToList();
                    break;
                case "age":
                    sortedList = descending ? list.OrderByDescending(x => x.Age).ToList() : list.OrderBy(x => x.Age).ToList();
                    break;
                default:
                    sortedList = list;
                    break;
            }
            return Ok(new ApiResponse<List<Customer>>(sortedList));
        }

        [HttpPost]
        public ActionResult<ApiResponse<List<Customer>>> Post([FromBody] Customer value)
        {
            list.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<Customer>>(list));
        }

        [HttpPost("PostQuery")]
        public ActionResult<ApiResponse<List<Customer>>> Add([FromQuery] int id, [FromBody] Customer value)
        {
            value.Id = id;
            list.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<Customer>>(list));
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Put(int id, [FromBody] Customer value)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound(new ApiResponse<List<Customer>>("Item not found in system."));
            }

            list.Remove(item);
            list.Add(value);
            return Ok(new ApiResponse<List<Customer>>(list));
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Delete(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound(new ApiResponse<List<Customer>>("Item not found in system."));
            }

            list.Remove(item);
            return Ok(new ApiResponse<List<Customer>>(list));
        }

        [HttpPatch("{id}")]
        public ActionResult<ApiResponse<List<Customer>>> Patch(int id, [FromBody] CustomerUpdateModel updateModel)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound(new ApiResponse<List<Customer>>("Item not found in system."));
            }

            if (updateModel.Name != null)
            {
                item.Name = updateModel.Name;
            }

            if (updateModel.Age.HasValue)
            {
                item.Age = updateModel.Age.Value;
            }

            return Ok(new ApiResponse<List<Customer>>(list));
        }

    }
}
