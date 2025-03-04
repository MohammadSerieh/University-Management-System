using Universities.models.dto;

namespace Universities.Interfaces
{
    public interface IminorService
    {
        Task<int> addOrUpdate(minorDto dto);
        Task deletelookup(int minorid);
        Task<List<dropdown>> getMajores();
        Task<List<dropdown>> getUniversites();
        Task<List<dropdown>> getCollege();
        Task<List<dropdown>> getNationality();
        Task<List<dropdown>> getMajor();
        Task<List<dropdown>> getCourse();
        Task<List<UniversityApplicationSummaryDto>> GetUniversityDataAsync();
        Task<List<UniversityCollegeStatsDto>> getUniCollegeStats();

    }
}