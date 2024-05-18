using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IClassroomRepository
    {
        Task<Classroom?> GetClassroomByIdAsync(int id);
        Task<IEnumerable<Classroom>> GetAllClassroomsAsync();
        Task<Classroom> CreateClassroomAsync(Classroom newClassroom);
        Task UpdateClassroomAsync(Classroom updatedClassroom);
        Task DeleteClassroomAsync(int id);
    }
}
