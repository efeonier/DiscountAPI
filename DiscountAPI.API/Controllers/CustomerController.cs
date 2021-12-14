using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DiscountAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IMapper mapper)
        {
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerResponse>> Get(int id)
        {
            _logger.LogInformation($"Customer Get Request: {id}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("email")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerResponse>> Get(string email)
        {
            _logger.LogInformation($"Customer GetByEmail Request: {email}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerService.GetCustomerByEmail(email);
            return Ok(response);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerResponse>> Post(CustomerRequest request)
        {
            _logger.LogInformation($"Customer Post Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerService.AddAsync(_mapper.Map<Customer>(request));
            return Ok(response);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerResponse> Put(CustomerRequest request)
        {
            _logger.LogInformation($"Customer Put Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _customerService.Update(_mapper.Map<Customer>(request));
            return Ok(response);
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerResponse> Delete(CustomerRequest request)
        {
            _logger.LogInformation($"Customer Delete Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _customerService.Delete(_mapper.Map<Customer>(request));
            return Ok();
        }
    }
}