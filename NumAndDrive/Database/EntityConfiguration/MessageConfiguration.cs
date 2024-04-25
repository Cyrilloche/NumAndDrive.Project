using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");

            builder
                .Property(m => m.MessageContent)
                .HasColumnType("text");
            builder
                .Property(m => m.SendingDate)
                .HasColumnType("datetime");
            builder
                .Property(m => m.ReceiptDate)
            .HasColumnType("datetime");

            builder
                .HasOne<User>(m => m.SenderUser)
                .WithMany(u => u.PostMessage)
                .HasForeignKey(m => m.SenderUserId);

            builder
                .HasOne<User>(m => m.ReceiverUser)
                .WithMany(u => u.IncomingMessage)
                .HasForeignKey(m => m.ReceiverUserId);
        }
    }
}
