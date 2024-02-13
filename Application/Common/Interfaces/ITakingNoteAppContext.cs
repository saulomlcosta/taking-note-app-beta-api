using Microsoft.EntityFrameworkCore;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Application.Common.Interfaces;

public interface ITakingNoteAppContext
{
    DbSet<User> Users { get; }

    DbSet<Note> Notes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
