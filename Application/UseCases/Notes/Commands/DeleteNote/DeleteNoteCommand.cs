using MediatR;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Application.Exceptions;
using TakingNoteApp.Data;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.DeleteNote
{
    public record DeleteNoteCommand(Guid NoteId) : IRequest;

    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly ITakingNoteAppContext _context;

        public DeleteNoteCommandHandler(TakingNoteAppContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes
                .FindAsync(new object[] { request.NoteId }, cancellationToken)
            ?? throw new NotFoundException($"Note with NoteId {request.NoteId} not found.");
            
            _context.Notes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
