using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Application.Common.Mappings;
using TakingNoteApp.Application.Common.Models;
using TakingNoteApp.Services.Contracts;

namespace TakingNoteApp.Application.UseCases.Notes.Queries.GetNotesWithPagination
{
    public record GetNotesWithPaginationQuery(int PageNumber = 1,
                                             int PageSize = 10) : IRequest<PaginatedList<NoteDto>>;

    public class GetNotesWithPaginationQueryHandler : IRequestHandler<GetNotesWithPaginationQuery, PaginatedList<NoteDto>>
    {
        private readonly ITakingNoteAppContext _context;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public GetNotesWithPaginationQueryHandler(ITakingNoteAppContext context, IMapper mapper, ILoggedUser loggedUser)
        {
            _context = context;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<PaginatedList<NoteDto>> Handle(GetNotesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Notes
                .Where(x => x.UserId == _loggedUser.Id)
                .OrderBy(x => x.Description)
                .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }


}
