using Microsoft.AspNetCore.Mvc;
using Universities.Interfaces;
using Universities.models.dto;

namespace Universities.Controllers
{
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsServices service;
        public ApplicationsController(IApplicationsServices service)
        {
            this.service = service;
        }


        [HttpGet("getApplications")]
        public async Task<IActionResult> GetApplications()
        {
            var applications = await this.service.getApplications();

            if (applications == null || applications.Count == 0)
            {
                return NotFound(new { message = "No applications found" });
            }

            return Ok(applications);
        }

        [Route("api/AddOrUpdateApplication")]
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateApplication([FromBody] ApplicationsDto dto)
        {
            await this.service.AddOrUpdateApplication(dto);
            return Ok(new { message = "Application added or updated successfully" });
        }

        [HttpDelete("deleteApplication")]
        public async Task<IActionResult> DeleteApplication(int appno)
        {
            bool isDeleted = await this.service.deleteApplication(appno);

            if (isDeleted)
            {
                return Ok(new { message = "Application deleted successfully" }); 
            }
            else
            {
                return NotFound(new { message = "Application not found" }); 
            }
        }
    }
}
