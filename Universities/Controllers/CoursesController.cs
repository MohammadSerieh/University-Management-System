using Microsoft.AspNetCore.Mvc;
using Universities.Interfaces;
using Universities.models.dto;

namespace Universities.Controllers
{
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService service;
        public CoursesController(ICoursesService service)
        {
            this.service = service;
        }

        [HttpPost("addOrUpdate")]
        public async Task<IActionResult> AddOrUpdateCourse([FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest(new { message = "Invalid course Data" });
            }

            int courseId = await this.service.AddOrUpdateCourse(courseDto);

            return Ok(new { CourseID = courseId, Message = "Course Added/Updated Successfully" });

        }

        [HttpDelete("DeteleCourse")]
        public async Task<IActionResult> deleteCourse(int id)
        {
            bool isDeleted = await this.service.DeleteCourse(id);
            if (!isDeleted)
            {
                return BadRequest(new { message = "Course not found" });
            }
                return Ok(new {meessage = "Course Deleted Successfully"});
        }

        [HttpGet("GetCourses")]
        public async Task<IActionResult> getAllCourses()
        {
            var courses = await this.service.GetAllCourses();
             if (courses == null)
            {
                return BadRequest(new { message = "No Course Found" });
            }
             return Ok(courses);
        }

            


    }
}
