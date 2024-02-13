using System.Security.Claims;
using TakingNoteApp.Services.Contracts;

namespace TakingNoteApp.Services
{
    public class LoggedUser : ILoggedUser
    {
        public LoggedUser(IHttpContextAccessor _contextAccessor)
        {
            _contextAccessor = _contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));

            var user = _contextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated is true)
            {
                Id = Guid.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId) ? userId : throw new InvalidOperationException("User Id claim is missing or invalid");
                Name = user.FindFirst(ClaimTypes.Name)?.Value ?? throw new InvalidOperationException("User Name claim is missing");
                Email = user.FindFirst(ClaimTypes.Email)?.Value ?? throw new InvalidOperationException("User Email claim is missing");
            }
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
