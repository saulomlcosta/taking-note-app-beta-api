using MediatR;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Data;
using TakingNoteApp.Entities;
using TakingNoteApp.Services.Contracts;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.CreateNote
{
    public record CreateNoteCommand(string Description) : IRequest<Guid>;

    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly ITakingNoteAppContext _context;
        private readonly ILoggedUser _loggedUser;

        public CreateNoteCommandHandler(ILoggedUser loggedUser, TakingNoteAppContext context)
        {
            _loggedUser = loggedUser;
            _context = context;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Note(request.Description, _loggedUser.Id);

            _context.Notes.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}
