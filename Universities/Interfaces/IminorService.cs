using Universities.models.dto;

namespace Universities.Interfaces
{
    public interface IminorService
    {
        Task<int> addOrUpdate(minorDto dto);
        Task deletelookup(int minorid);
        Task<List<dropdown>> getMajores();
        Task<List<dropdown>> getUniversites();
    }
}