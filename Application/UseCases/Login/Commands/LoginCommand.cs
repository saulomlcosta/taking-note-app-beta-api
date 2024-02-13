using MediatR;
using Microsoft.EntityFrameworkCore;
using TakingNoteApp.Application.Common.Interfaces;
using TakingNoteApp.Application.Exceptions;
using TakingNoteApp.Data;
using TakingNoteApp.Services;

namespace TakingNoteApp.Application.UseCases.Login.Commands
{
    public record LoginCommand(string Email) : IRequest<string>;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly ITakingNoteAppContext _context;

        public LoginCommandHandler(TakingNoteAppContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(c => c.Email == request.Email, cancellationToken) 
                ?? throw new NotFoundException($"User with Email {request.Email} not found.");

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
