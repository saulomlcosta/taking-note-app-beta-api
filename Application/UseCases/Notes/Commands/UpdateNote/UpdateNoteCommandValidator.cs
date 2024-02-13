using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
