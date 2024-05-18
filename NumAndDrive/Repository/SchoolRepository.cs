using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly NumAndDriveContext _context;

        public SchoolRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<School?> GetSchoolByIdAsync(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<IEnumerable<School>> GetAllSchoolsAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> CreateSchoolAsync(School newSchool)
        {
            await _context.Schools.AddAsync(newSchool);
            await _context.SaveChangesAsync();
            return newSchool;
        }

        public async Task UpdateSchoolAsync(School updatedSchool)
        {
            _context.Schools.Update(updatedSchool);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchoolAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school != null)
            {
                _context.Schools.Remove(school);
                await _context.SaveChangesAsync();
            }
        }
    }
}
