using Universities.Entities;
using Universities.models.dto;

namespace Universities.Interfaces
{
    public interface IApplicationsServices
    {
        Task<List<ApplicationsDto>> getApplications();
        
        Task<bool> deleteApplication(int appno);
        Task AddOrUpdateApplication(ApplicationsDto dto);
        
    }
}
