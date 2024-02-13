using MediatR;
using TakingNoteApp.Application.Exceptions;
using TakingNoteApp.Data;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.UpdateNote
{
    public record UpdateNoteCommand(Guid NoteId, string Description) : IRequest;

    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private TakingNoteAppContext _context;

        public UpdateNoteCommandHandler(TakingNoteAppContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes
                .FindAsync(new object[] { request.NoteId }, cancellationToken)
                ?? throw new NotFoundException($"Note with NoteId {request.NoteId} not found.");

            if (entity.Description != request.Description)
            {
                entity.SetDescription(request.Description, request);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
