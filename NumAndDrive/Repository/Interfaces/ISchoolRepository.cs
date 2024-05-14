using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetAllSchoolASync();
        Task<School?> GetSchoolByIdAsync(int id);
        Task<School> CreateNewSchoolAsync(School newSchool);
        Task UpdateSchoolAsync(School updatedSchool);
        Task DeleteSchoolAsync(int id);
    }
}
