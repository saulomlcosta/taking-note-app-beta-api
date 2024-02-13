using FluentValidation;

namespace TakingNoteApp.Application.UseCases.Notes.Queries.GetNotesWithPagination
{
    public class GetNoteWithPaginationQueryValidator : AbstractValidator<GetNotesWithPaginationQuery>
    {
        public GetNoteWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
