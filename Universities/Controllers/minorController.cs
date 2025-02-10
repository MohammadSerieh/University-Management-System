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

        [Route("api/GetNationality")]
        [HttpGet]
        public async Task<IActionResult> GetNationality()
        {
            return Ok(await this.service.getNationality());
        }

        [Route("api/getCollege")]
        [HttpGet]
        public async Task<IActionResult> GetCollege()
        {
            var colleges = await this.service.getCollege();
            return Ok(colleges);
        }

        [Route("api/addMinor")]
        [HttpPost]
        public async Task< IActionResult> addMinor(minorDto dto) {
           return  Ok( await this.service.addOrUpdate(dto));
        }

        
        [Route("api/deleteMinor/{minorid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMinor(int minorid)
        {
            try
            {
                await this.service.deletelookup(minorid);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
