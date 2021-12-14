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
    public class CustomerTypeController : ControllerBase
    {
        private readonly ILogger<CustomerTypeController> _logger;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IMapper _mapper;

        public CustomerTypeController(ILogger<CustomerTypeController> logger, ICustomerTypeService customerTypeService,
            IMapper mapper)
        {
            _logger = logger;
            _customerTypeService = customerTypeService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerTypeResponse>> Get(int id)
        {
            _logger.LogInformation($"Customer Get Request: {id}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerTypeService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerResponse>> Get()
        {
            _logger.LogInformation($"Customertype GetAll Request");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerTypeService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerTypeResponse>> Post(CustomerTypeRequest request)
        {
            _logger.LogInformation($"Customertype Post Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _customerTypeService.AddAsync(_mapper.Map<CustomerType>(request));
            return Ok(response);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerTypeResponse> Put(CustomerTypeRequest request)
        {
            _logger.LogInformation($"Customertype Put Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _customerTypeService.Update(_mapper.Map<CustomerType>(request));
            return Ok(response);
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerTypeResponse> Delete(CustomerTypeRequest request)
        {
            _logger.LogInformation($"Customertype Delete Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _customerTypeService.Delete(_mapper.Map<CustomerType>(request));
            return Ok();
        }
    }
}