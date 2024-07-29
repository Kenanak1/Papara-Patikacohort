using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using Papara_cohort.Models;

namespace Papara_cohort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerUpdateDto> _updateValidator;
        private readonly IValidator<int> _idValidator;

        public CustomersController(ICustomerService customerService, IMapper mapper,
                                   IValidator<CustomerUpdateDto> updateValidator,
                                   IValidator<int> idValidator)
        {
            _customerService = customerService;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _idValidator = idValidator;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<CustomerDto>>> Get()
        {
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return Ok(new ApiResponse<List<CustomerDto>>(listDto));
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<CustomerDto>> Get(int id)
        {
            ValidationResult validationResult = _idValidator.Validate(id);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<CustomerDto>(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            var item = _customerService.GetById(id);
            if (item is null)
            {
                return NotFound(new ApiResponse<CustomerDto>(new List<string> { "Item not found in system." }));
            }
            var itemDto = _mapper.Map<CustomerDto>(item);
            return Ok(new ApiResponse<CustomerDto>(itemDto));
        }

        [HttpGet("ByNameQuery")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Search([FromQuery] string name)
        {
            var results = _customerService.SearchByName(name);
            if (!results.Any())
            {
                return NotFound(new ApiResponse<List<CustomerDto>>(new List<string> { "No items found in system." }));
            }
            var resultsDto = _mapper.Map<List<CustomerDto>>(results);
            return Ok(new ApiResponse<List<CustomerDto>>(resultsDto));
        }

        [HttpGet("ListByName")]
        public ActionResult<ApiResponse<List<CustomerDto>>> List([FromQuery] string name = "")
        {
            var filteredList = _customerService.ListByName(name);
            var filteredListDto = _mapper.Map<List<CustomerDto>>(filteredList);
            return Ok(new ApiResponse<List<CustomerDto>>(filteredListDto));
        }

        [HttpGet("Sort")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Sort([FromQuery] string sortBy, [FromQuery] bool descending = false)
        {
            var sortedList = _customerService.Sort(sortBy, descending);
            var sortedListDto = _mapper.Map<List<CustomerDto>>(sortedList);
            return Ok(new ApiResponse<List<CustomerDto>>(sortedListDto));
        }

        [HttpPost]
        public ActionResult<ApiResponse<List<CustomerDto>>> Post([FromBody] CustomerDto value)
        {
            var customer = _mapper.Map<Customer>(value);
            _customerService.Add(customer);
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<CustomerDto>>(listDto));
        }

        [HttpPost("PostQuery")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Add([FromQuery] int id, [FromBody] CustomerDto value)
        {
            value.Id = id;
            var customer = _mapper.Map<Customer>(value);
            _customerService.Add(customer);
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, new ApiResponse<List<CustomerDto>>(listDto));
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Put(int id, [FromBody] CustomerUpdateDto value)
        {
            ValidationResult idValidationResult = _idValidator.Validate(id);
            if (!idValidationResult.IsValid)
            {
                return BadRequest(new ApiResponse<List<CustomerDto>>(idValidationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            ValidationResult updateValidationResult = _updateValidator.Validate(value);
            if (!updateValidationResult.IsValid)
            {
                return BadRequest(new ApiResponse<List<CustomerDto>>(updateValidationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            var customerUpdateModel = _mapper.Map<CustomerUpdateModel>(value);
            _customerService.Update(id, _mapper.Map<Customer>(customerUpdateModel));
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return Ok(new ApiResponse<List<CustomerDto>>(listDto));
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Delete(int id)
        {
            ValidationResult validationResult = _idValidator.Validate(id);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<List<CustomerDto>>(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            _customerService.Delete(id);
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return Ok(new ApiResponse<List<CustomerDto>>(listDto));
        }


        [HttpPatch("{id}")]
        public ActionResult<ApiResponse<List<CustomerDto>>> Patch(int id, [FromBody] CustomerUpdateDto updateModel)
        {
            ValidationResult idValidationResult = _idValidator.Validate(id);
            if (!idValidationResult.IsValid)
            {
                return BadRequest(new ApiResponse<List<CustomerDto>>(idValidationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            ValidationResult updateValidationResult = _updateValidator.Validate(updateModel);
            if (!updateValidationResult.IsValid)
            {
                return BadRequest(new ApiResponse<List<CustomerDto>>(updateValidationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            var customerUpdateModel = _mapper.Map<CustomerUpdateModel>(updateModel);
            _customerService.Patch(id, customerUpdateModel);
            var list = _customerService.GetAll();
            var listDto = _mapper.Map<List<CustomerDto>>(list);
            return Ok(new ApiResponse<List<CustomerDto>>(listDto));
        }
    }
}
