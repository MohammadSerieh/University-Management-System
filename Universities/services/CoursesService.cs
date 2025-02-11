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
        
    }
}
