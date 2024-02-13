using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQueryValidator : AbstractValidator<GetNoteByIdQuery>
    {
        public GetNoteByIdQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
