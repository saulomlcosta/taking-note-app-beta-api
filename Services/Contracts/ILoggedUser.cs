using TakingNoteApp.Entities;

namespace TakingNoteApp.Services.Contracts
{
    public interface ILoggedUser
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
    }
}
