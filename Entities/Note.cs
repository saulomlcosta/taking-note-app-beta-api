using MediatR;
using TakingNoteApp.Application.UseCases.Notes.Commands.UpdateNote;

namespace TakingNoteApp.Entities
{
    public class Note : BaseEntity 
    {
        public Note(string description, Guid userId)
        {
            Description = description;
            UserId = userId;
        }

        public string Description { get; private set; } = string.Empty;
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public void SetDescription(string description, IRequest request)
        {
            if (request is UpdateNoteCommand)
            {
                Description = description ?? string.Empty;
            }
            else
            {
                throw new InvalidOperationException("Description can only be updated through UpdateNoteCommand.");
            }
        }
    }
}