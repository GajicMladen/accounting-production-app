using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Services.Interface;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService PaymentService { get; set; }

        public PaymentController(IPaymentService paymentService)
        {
            PaymentService = paymentService;
        }

        [HttpPost("addNewPayment")]
        public IActionResult addNewPayment(PaymentDTO paymentDTO)
        {
            this.PaymentService.addNewPayment(paymentDTO);
            return Ok();
        }

        [HttpGet("getAllPaymentsIncomingInvoices")]
        public List<PaymentDTO> getAllPaymentsOfIncomingInvoices() { 
            List<Payment> ret = this.PaymentService.getAllPaymentsOfIncomingInvoices();
            return this.PaymentService.getPaymentDTOs(ret);
        }

        [HttpGet("getAllPaymentsIncomingOtherInvoices")]
        public List<PaymentDTO> getAllPaymentsOfIncomingOtherInvoices()
        {
            List<Payment> ret = this.PaymentService.getAllPaymentsOfThirdParty();
            return this.PaymentService.getPaymentDTOs(ret);
        }

        [HttpGet("getAllPaymentsOutgoingInvoices")]
        public List<PaymentDTO> getAllPaymentsOfOutgoingInvoices()
        {
            List<Payment> ret = this.PaymentService.getAllPaymentsOfOutgoingInvoices();
            return this.PaymentService.getPaymentDTOs(ret);
        }


        [HttpGet("getAllPaymentsOutgoingCashInvoices")]
        public List<PaymentDTO> getAllPaymentsOfOutgoingCashInvoices()
        {
            List<Payment> ret = this.PaymentService.getAllPaymentsOfOutgoingCashInvoices();
            return this.PaymentService.getPaymentDTOs(ret);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult deletePayment(string id) {
            this.PaymentService.deletePayment(id);
            return Ok();
        }
    }
}
