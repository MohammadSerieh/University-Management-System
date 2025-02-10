using Universities.Entities;

namespace Universities.Interfaces
{
    public interface IApplicationsRepository
    {
        Task<List<UniversityApplicationReserve>> getApplications(); 
        Task AddOrUpdateApplication(UniversityApplicationReserve entity);
        Task<UniversityApplicationReserve?> getByAppno(int appno); 
        Task<bool> deleteApplication(int appno); 

    }
}
