using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.DTOs;
using Invoice.Core.Entities;
using Invoce.Api.Responses;
using Invoice.Core.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using Invoice.Core.QueryFilters;
using Invoice.Core.CustomEntities;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice.Api.Controllers
{
    [ApiController]
    public class SalesInvoiceController : ControllerBase
    {
        private readonly ISalesInvoiceUseCase _salesInvoiceUseCase;
        private readonly IMapper _mapper;

        public SalesInvoiceController(ISalesInvoiceUseCase salesInvoiceUseCase, IMapper mapper) {
            _salesInvoiceUseCase = salesInvoiceUseCase;
            _mapper = mapper;
        }

        [Route("api/SalesInvoice")]
        [HttpGet]
        public IActionResult GetSalesInvoices([FromBody]SalesInvoiceQueryFilter filters)
        {
            var salesInvoices = _salesInvoiceUseCase.GetSalesInvoices(filters);
            var salesInvoicesDto = _mapper.Map<IEnumerable<SalesInvoiceDto>>(salesInvoices);
            var response = new ApiResponse<IEnumerable<SalesInvoiceDto>>(salesInvoicesDto);
            return Ok(response);
        }

        [Route("api/SalesInvoice")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesInvoiceById(int id)
        {
            var salesInvoices = await _salesInvoiceUseCase.GetSalesInvoiceById(id);
            var salesInvoiceDto = _mapper.Map<SalesInvoiceDto>(salesInvoices);
            var response = new ApiResponse<SalesInvoiceDto>(salesInvoiceDto);
            return Ok(response);
        }

        [Route("api/SalesInvoice")]
        [HttpPost]
        public async Task<IActionResult> InsertSalesInvoice([FromBody]SalesInvoiceDto salesInvoiceDto)
        {
            var salesInvoice = _mapper.Map<SalesInvoice>(salesInvoiceDto);
            await _salesInvoiceUseCase.InsertSalesInvoice(salesInvoice);
            salesInvoiceDto = _mapper.Map<SalesInvoiceDto>(salesInvoice);
            var response = new ApiResponse<SalesInvoiceDto>(salesInvoiceDto);
            return Ok(response);
        }

        [Route("api/SalesInvoice")]
        [HttpPut]
        public async Task<IActionResult> UpdateSalesInvoice([FromBody]SalesInvoiceDto salesInvoiceDto)
        {
            var salesInvoice = _mapper.Map<SalesInvoice>(salesInvoiceDto);
            await _salesInvoiceUseCase.UpdateSalesInvoice(salesInvoice);
            var response = new ApiResponse<SalesInvoice>(salesInvoice);
            return Ok(response);
        }

        [Route("api/SalesInvoice")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesInvoice(int id)
        {
            var result = await _salesInvoiceUseCase.DeleteSalesInvoice(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [Route("api/invoices")]
        [HttpGet]
        public IActionResult GetInvoicesPaged([FromQuery] SalesInvoicePagedFilter filters)
        {
            var invoices = _salesInvoiceUseCase.GetSalesInvoicesPaged(filters);
            var invoicesDto = _mapper.Map<IEnumerable<SalesInvoiceDto>>(invoices);

            var paginator = new PaginatorData
            {
                TotalCount = invoices.TotalCount,
                PageSize = invoices.PageSize,
                CurrentPage = invoices.CurrentPage,
                TotalPages = invoices.TotalPages,
                HasNextPage = invoices.HasNextPage,
                HasPreviousPage = invoices.HasPreviousPage
            };

            var response = new SalesInvoiceResponse<IEnumerable<SalesInvoiceDto>>(invoicesDto)
            {
                paginator = paginator
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginator));
            return Ok(response);
        }
    }
}
