using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
