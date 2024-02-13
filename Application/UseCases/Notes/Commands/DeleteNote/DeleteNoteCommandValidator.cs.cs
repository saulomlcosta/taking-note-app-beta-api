using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.DeleteNote
{
    public class DeleteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty();
        }
    }
}
