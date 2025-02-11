using Universities.Entities;
using Universities.Interfaces;
using Universities.models;

namespace Universities.Repositry
{
    public class CoursesRepository : ICoursesRepository
    {
        private universityDBContext dBContext;
        public CoursesRepository(universityDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        
    }
}
