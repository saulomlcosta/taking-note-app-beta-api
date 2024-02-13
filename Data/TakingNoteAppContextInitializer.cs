using Microsoft.EntityFrameworkCore;
using System.Threading;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Data
{
    public static class TakingNoteAppContextInitializer
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<TakingNoteAppContextInitialiser>();

            await initialiser.SeedAsync();
        }
    }

    public class TakingNoteAppContextInitialiser
    {
        private readonly ILogger<TakingNoteAppContextInitialiser> _logger;
        private readonly TakingNoteAppContext _context;

        public TakingNoteAppContextInitialiser(ILogger<TakingNoteAppContextInitialiser> logger, TakingNoteAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            var user = new User("Saulo","saulomarcosdlc@gmail.com");

            bool userExists = await _context.Users.AsNoTracking().AnyAsync(c => c.Email == user.Email);

            if (!userExists)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
