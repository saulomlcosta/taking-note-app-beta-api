using AutoMapper;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Application.UseCases.Notes.Queries
{
    public class NoteDto
    {
        public Guid Id { get; init; }
        public string Description { get; init; } = string.Empty;
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Note, NoteDto>();
            }
        }
    }
}
