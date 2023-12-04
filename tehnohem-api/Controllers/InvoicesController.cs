using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.DTO;
using tehnohem_api.Model.Invoice;
using tehnohem_api.Services.Interface;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private IInvoicesService invoicesService;
        public InvoicesController(IInvoicesService invoicesService) {
            this.invoicesService = invoicesService;
        }

        [HttpPost("addNewIncomingInvoice")]
        public IActionResult addNewIncoimingInvoice(IncomingInvoiceDTO incomingInvoiceDTO)
        {
            this.invoicesService.AddNewIncomingInvoice(incomingInvoiceDTO);
            return Ok();
        }

        [HttpPost("addNewInternalIssueRaw")]
        public IActionResult addNewInternalIssueRaw(IncomingInvoiceDTO incomingInvoiceDTO)
        {
            this.invoicesService.AddNewInternalIssueRaw(incomingInvoiceDTO);
            return Ok();
        }

        [HttpPost("addNewInternalIssueProduct")]
        public IActionResult addNewInternalIssueProdcut(IncomingInvoiceDTO incomingInvoiceDTO)
        {
            this.invoicesService.AddNewInternalIssueProduct(incomingInvoiceDTO);
            return Ok();
        }

        [HttpPost("addNewOutgoingInvoice")]
        public IActionResult addNewOutgoingInvoic(OutgoingInvoiceDTO incomingInvoiceDTO)
        {
            this.invoicesService.AddNewOutgoingInvoice(incomingInvoiceDTO);
            return Ok();
        }


        [HttpGet("allIncomingInvoices")]
        public List<DetailInvoiceInfoDTO> getAllIncomingInvoices() { 
            List<Invoice> invoices = this.invoicesService.GetAllIncomingInvoices();
            return this.invoicesService.GetDetailInvoicesInfo(invoices);
        }

        [HttpGet("allInternalIssueRaw")]
        public List<DetailInvoiceInfoDTO> getAllInternalIssueRaw()
        {
            List<Invoice> invoices = this.invoicesService.GetAllInternalIssueRaw();
            return this.invoicesService.GetDetailInvoicesInfo(invoices);
        }

        [HttpGet("allInternalIssueProduct")]
        public List<DetailInvoiceInfoDTO> getAllInternalIssueProduct()
        {
            List<Invoice> invoices = this.invoicesService.GetAllInternalIssueProduct();
            return this.invoicesService.GetDetailInvoicesInfo(invoices);
        }

        [HttpGet("allOutgoingInvoices")]
        public List<DetailInvoiceInfoDTO> getAllOutgoingInvoices()
        {
            List<Invoice> invoices = this.invoicesService.GetAllOutgoingInvoices();
            return this.invoicesService.GetDetailInvoicesInfo(invoices);
        }
    }
}
