using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ISchoolRepository
    {
        Task<School?> GetSchoolByIdAsync(int id);
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<School> CreateSchoolAsync(School newSchool);
        Task UpdateSchoolAsync(School updatedSchool);
        Task DeleteSchoolAsync(int id);
    }
}
