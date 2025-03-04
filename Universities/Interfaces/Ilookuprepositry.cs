using Universities.Entities;
using Universities.models.dto;

namespace Universities.Interfaces
{
    public interface Ilookuprepositry
    {
        Task<CommonZakat_MinorLookUpTable> addNewLookup(int majorID, string descs);
        Task deleteLookup(int minorid);
        Task<CommonZakat_MinorLookUpTable?> getbyid(int minorid);
        Task<List<CommonZakat_MinorLookUpTable>> retriveLookupByMajor(int majorID);
        Task<CommonZakat_MinorLookUpTable> updateLookup(int minorid, string descs);
        Task<CommonZakat_MinorLookUpTable> updateLookup(CommonZakat_MinorLookUpTable obj);
        Task<List<UniversityApplicationSummaryDto>> GetUniversityDataAsync();
        Task<List<UniversityCollegeStatsDto>> GetUniCollegeStats();
    }

}