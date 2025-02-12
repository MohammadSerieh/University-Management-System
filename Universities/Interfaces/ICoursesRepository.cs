using Universities.Entities;

namespace Universities.Interfaces
{
    public interface ICoursesRepository
    {
        Task<int>AddOrUpdateCourse(UniAppCoursesReserve newCourse);
        Task<UniAppCoursesReserve?> GetCourseByID(int UniAppCourseID);
        Task<bool> DeleteCourse(int UniAppCourseID);
        Task<List<UniAppCoursesReserve>> GetAllCourses();

        
        
    }
}
