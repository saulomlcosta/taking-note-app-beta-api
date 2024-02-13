using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Data.Configuration
{
    public class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
