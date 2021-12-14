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
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(ILogger<DiscountController> logger, IDiscountService discountService, IMapper mapper)
        {
            _logger = logger;
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountResponse>> Get(int id)
        {
            _logger.LogInformation($"Customer Get Request: {id}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _discountService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("typeId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountResponse>> GetByTypeId(int typeId)
        {
            _logger.LogInformation($"Customer Get Request: {typeId}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _discountService.GetDiscountByType(typeId);
            return Ok(response);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountResponse>> Get()
        {
            _logger.LogInformation($"Customertype GetAll Request");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _discountService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountResponse>> Post(DiscountRequest request)
        {
            _logger.LogInformation($"Customertype Post Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _discountService.AddAsync(_mapper.Map<Discount>(request));
            return Ok(response);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DiscountResponse> Put(DiscountRequest request)
        {
            _logger.LogInformation($"Customertype Put Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _discountService.Update(_mapper.Map<Discount>(request));
            return Ok(response);
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DiscountResponse> Delete(DiscountRequest request)
        {
            _logger.LogInformation($"Customertype Delete Request: {JsonConvert.SerializeObject(request)}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _discountService.Delete(_mapper.Map<Discount>(request));
            return Ok();
        }
    }
}