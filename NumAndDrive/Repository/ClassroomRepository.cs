using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

public class ClassroomRepository : IClassroomRepository
{
    private readonly NumAndDriveContext _context;

    public ClassroomRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Classroom?> GetClassroomByIdAsync(int id)
    {
        return await _context.Classrooms.FindAsync(id);
    }

    public async Task<IEnumerable<Classroom>> GetAllClassroomsAsync()
    {
        return await _context.Classrooms.ToListAsync();
    }

    public async Task<Classroom> CreateClassroomAsync(Classroom newClassroom)
    {
        await _context.Classrooms.AddAsync(newClassroom);
        await _context.SaveChangesAsync();
        return newClassroom;
    }

    public async Task UpdateClassroomAsync(Classroom updatedClassroom)
    {
        _context.Classrooms.Update(updatedClassroom);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassroomAsync(int id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom != null)
        {
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
        }
    }
}
