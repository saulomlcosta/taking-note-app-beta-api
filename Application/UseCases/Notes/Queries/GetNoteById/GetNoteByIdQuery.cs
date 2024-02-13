using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Application.Exceptions;
using TakingNoteApp.Services.Contracts;

namespace TakingNoteApp.Application.UseCases.Notes.Queries.GetNoteById
{
    public record GetNoteByIdQuery(Guid Id) : IRequest<NoteDto>;

    public class GetNoteByIdHandler : IRequestHandler<GetNoteByIdQuery, NoteDto>
    {
        private ILoggedUser _loggedUser;
        private ITakingNoteAppContext _context;
        private readonly IMapper _mapper;

        public GetNoteByIdHandler(ILoggedUser loggedUser, ITakingNoteAppContext context, IMapper mapper)
        {
            _loggedUser = loggedUser;
            _context = context;
            _mapper = mapper;
        }

        public async Task<NoteDto> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes
              .Where(x => x.UserId == _loggedUser.Id && x.Id == request.Id)
              .FirstOrDefaultAsync(cancellationToken) 
            ?? throw new NotFoundException($"Note with NoteId {request.Id} not found.");

            return _mapper.Map<NoteDto>(entity);
        }
    }
}
