using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Login.Commands
{

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
