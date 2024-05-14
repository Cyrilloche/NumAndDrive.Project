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

        public async Task<School> CreateNewSchoolAsync(School newSchool)
        {
            await _context.AddAsync(newSchool);
            await _context.SaveChangesAsync();
            return newSchool;
        }

        public async Task DeleteSchoolAsync(int id)
        {
            School school = await GetSchoolByIdAsync(id);
            if(school != null)
            {
                _context.Remove(school);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<School>> GetAllSchoolASync()
        {
            return await _context.Schools.Include(s => s.SchoolAddress).ToListAsync();
        }

        public async Task<School?> GetSchoolByIdAsync(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task UpdateSchoolAsync(School updatedSchool)
        {
            _context.Update(updatedSchool);
            await _context.SaveChangesAsync();
        }
    }
}
