using System.Net.Mime;
using System.Threading.Tasks;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DiscountAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpPost, Route("CalculateDiscount")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TotalDiscountResponse>> CalculateDiscount(InvoiceRequest request)
        {
            _logger.LogInformation($"Customer Get Request: {request}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _invoiceService.CalculateDiscount(request);
            return Ok(response);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InvoiceResponse>> Post(InvoiceRequest request)
        {
            _logger.LogInformation($"Customer Get Request: {request}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _invoiceService.CreateInvoice(request);
            return Ok(response);
        }
    }
}