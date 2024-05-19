using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class MessageRepository : IMessageRepository
{
    private readonly NumAndDriveContext _context;

    public MessageRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Message?> GetMessageByIdAsync(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    public async Task<IEnumerable<Message>> GetAllMessagesAsync()
    {
        return await _context.Messages.ToListAsync();
    }

    public async Task<Message> CreateMessageAsync(Message newMessage)
    {
        await _context.Messages.AddAsync(newMessage);
        await _context.SaveChangesAsync();
        return newMessage;
    }

    public async Task UpdateMessageAsync(Message updatedMessage)
    {
        _context.Messages.Update(updatedMessage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMessageAsync(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}
