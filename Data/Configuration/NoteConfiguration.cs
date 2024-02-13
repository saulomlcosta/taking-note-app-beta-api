using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Data.Configuration
{
    public class NoteConfiguration
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                     .IsRequired();

            builder.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId);
        }
    }
}
