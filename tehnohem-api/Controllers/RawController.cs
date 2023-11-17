using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Model;
using tehnohem_api.Services.Implementation;
using tehnohem_api.Services.Interface;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RawController : ControllerBase
    {
        private IRawService rawService { get; set; }

        public RawController(IRawService rawService) {
            this.rawService = rawService;
        }

        [HttpGet("all")]
        public ICollection<Raw> getAllRaws() 
        {

            return this.rawService.getAllRaws();
        }

        [HttpGet("{id}")]
        public Raw? getRaw(int id)
        { 
            return this.rawService.getRaw(id);
        }

        [HttpPost("add")]
        public IActionResult addRaw(Raw raw)
        {
            this.rawService.addNewRaw(raw);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult deleteRaw(int id)
        {
            this.rawService.removeRaw(id);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult updateRaw(Raw raw) 
        {
            this.rawService.updateRaw(raw);
            return Ok();
        }
    }
}
