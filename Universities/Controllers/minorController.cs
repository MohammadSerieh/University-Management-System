using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universities.Interfaces;
using Universities.models.dto;

namespace Universities.Controllers
{
    
    [ApiController]
    public class minorController : ControllerBase
    {
        private readonly IminorService service ;
        public minorController(IminorService service)
        {
            this.service = service;
        }

        [Route("api/GetUniversity")]
        [HttpGet]
        public async Task< IActionResult> GetUniversity() {
           return  Ok( await this.service.getUniversites());
        }
        [Route("api/addMinor")]
        [HttpPost]
        public async Task< IActionResult> addMinor(minorDto dto) {
           return  Ok( await this.service.addOrUpdate(dto));
        }

    }
}
