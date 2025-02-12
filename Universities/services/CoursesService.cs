using Universities.Entities;
using Universities.Interfaces;
using Universities.models;
using Universities.models.dto;
using Universities.Repositry;

namespace Universities.services
{
    public class CoursesService : ICoursesService
    {

        private readonly ICoursesRepository icoursesrepository;
        public CoursesService(ICoursesRepository coursesRepository)
        {
            this.icoursesrepository = coursesRepository;
        }
        
        public async Task<int> AddOrUpdateCourse(CourseDto courseDto)
        {
            var newCourse = new UniAppCoursesReserve
            {
                UniAppCoursesID = courseDto.UniAppCoursesID, 
                Appno = courseDto.Appno,
                CourseID = courseDto.CourseID,
                CourseCenterID = courseDto.CourseCenterID,
                CourseLocation = courseDto.CourseLocation,
                CourseDate = courseDto.CourseDate,
                CourseAtt = courseDto.CourseAtt,
                DocumentName = courseDto.DocumentName,
                MimeType = courseDto.MimeType,
                Size = courseDto.Size,
                UploadDate = courseDto.UploadDate
            };
            return await icoursesrepository.AddOrUpdateCourse(newCourse);
        }

        public async Task<bool>DeleteCourse(int UniAppCourseID)
        {
            var course = await icoursesrepository.GetCourseByID(UniAppCourseID);

            if (course != null)
            {
                return await icoursesrepository.DeleteCourse(UniAppCourseID);
            }

            return false;
        }

        public async Task<List<CourseDto>> GetAllCourses()
        {
            var courses = await icoursesrepository.GetAllCourses();

            return courses.Select(course => new CourseDto
            {
                UniAppCoursesID = course.UniAppCoursesID,
                Appno = course.Appno,
                CourseID = course.CourseID,
                CourseCenterID = course.CourseCenterID,
                CourseLocation = course.CourseLocation,
                CourseDate = course.CourseDate,
                CourseAtt = course.CourseAtt,
                DocumentName = course.DocumentName,
                MimeType = course.MimeType,
                Size = course.Size,
                UploadDate = course.UploadDate
            }).ToList();
        }
    }
}
