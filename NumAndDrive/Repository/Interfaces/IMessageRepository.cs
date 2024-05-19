using NumAndDrive.Models;

public interface IMessageRepository
{
    Task<Message?> GetMessageByIdAsync(int id);
    Task<IEnumerable<Message>> GetAllMessagesAsync();
    Task<Message> CreateMessageAsync(Message newMessage);
    Task UpdateMessageAsync(Message updatedMessage);
    Task DeleteMessageAsync(int id);
}
