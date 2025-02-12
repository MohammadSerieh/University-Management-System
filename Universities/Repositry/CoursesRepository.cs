using Microsoft.EntityFrameworkCore;
using Universities.Entities;
using Universities.Interfaces;
using Universities.models;
using Universities.models.dto;

namespace Universities.Repositry
{
    public class CoursesRepository : ICoursesRepository
    {
        private universityDBContext dBContext;
        public CoursesRepository(universityDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<int> AddOrUpdateCourse(UniAppCoursesReserve newCourse)
        {
            var existingCourse = await this.dBContext.UniAppCoursesReserve
                .FirstOrDefaultAsync(c => c.UniAppCoursesID == newCourse.UniAppCoursesID);

            if (existingCourse != null)
            {
                existingCourse.Appno = newCourse.Appno;
                existingCourse.CourseID = newCourse.CourseID;
                existingCourse.CourseCenterID = newCourse.CourseCenterID;
                existingCourse.CourseLocation = newCourse.CourseLocation;
                existingCourse.CourseDate = newCourse.CourseDate;
                existingCourse.CourseAtt = newCourse.CourseAtt;
                existingCourse.DocumentName = newCourse.DocumentName;
                existingCourse.MimeType = newCourse.MimeType;
                existingCourse.Size = newCourse.Size;
                existingCourse.UploadDate = newCourse.UploadDate;

                this.dBContext.UniAppCoursesReserve.Update(existingCourse);
            }
            else
            {
                await this.dBContext.UniAppCoursesReserve.AddAsync(newCourse);
            }

            await this.dBContext.SaveChangesAsync();
            return newCourse.UniAppCoursesID;
        }

        public async Task<UniAppCoursesReserve?> GetCourseByID(int UniAppCourseID)
        {
            UniAppCoursesReserve? obj = await this.dBContext.Set<UniAppCoursesReserve>().FindAsync(UniAppCourseID);

            return obj;
        }

        public async Task<bool> DeleteCourse(int UniAppCourseID)
        {
            var course = await GetCourseByID(UniAppCourseID);

            if (course != null)
            {
                this.dBContext.UniAppCoursesReserve.Remove(course);
                await this.dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<UniAppCoursesReserve>> GetAllCourses()
        {
            return await this.dBContext.UniAppCoursesReserve.ToListAsync();
        }
        
    }
}
