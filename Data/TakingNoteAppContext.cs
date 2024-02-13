using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Data
{
    public class TakingNoteAppContext : DbContext, ITakingNoteAppContext
    {
        public TakingNoteAppContext() { }

        public TakingNoteAppContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Note> Notes => Set<Note>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
