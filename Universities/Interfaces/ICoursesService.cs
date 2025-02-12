using Universities.models.dto;

namespace Universities.Interfaces
{
    public interface ICoursesService
    {
        Task<int> AddOrUpdateCourse(CourseDto newCourse);
        Task<bool> DeleteCourse(int UniAppCourseID);
        Task<List<CourseDto>> GetAllCourses();
       
    }
}
