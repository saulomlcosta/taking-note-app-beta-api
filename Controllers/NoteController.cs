using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakingNoteApp.Application.Common.Models;
using TakingNoteApp.Application.UseCases.Notes.Commands.CreateNote;
using TakingNoteApp.Application.UseCases.Notes.Queries;
using TakingNoteApp.Application.UseCases.Notes.Queries.GetNoteById;
using TakingNoteApp.Application.UseCases.Notes.Queries.GetNotesWithPagination;
using TakingNoteApp.Entities;

namespace TakingNoteApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedList<NoteDto>> GetNotesWithPagination([FromQuery] GetNotesWithPaginationQuery query)
        {
            return await _mediator.Send(query);
        }


        [HttpGet("{id}")]
        public async Task<NoteDto> GetNoteById([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetNoteByIdQuery(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
      
        //[HttpGet()]
        //[ProducesResponseType(typeof(Note), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public IActionResult GetAll()
        //{
        //    var result = _noteRepository.GetAll();

        //    if (result is null)
        //        return NoContent();

        //    return Ok(result);
        //}


        //[HttpGet()]
        //public async Task<IActionResult> GetAsync()
        //{
        //    var result = await _mediator.Send(query);

        //    if (result is null)
        //        return NoContent();

        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Note), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    var result = _noteRepository.GetById(id);

        //    if (result is null)
        //        return NoContent();

        //    return Ok(result);
        //}

        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public IActionResult CreateNote([FromBody] CreateNoteRequest request)
        //{
        //    var result = _noteRepository.Create(request);

        //    return CreatedAtAction(nameof(CreateNote), new { id = result.Id });
        //}

        //[HttpPut()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult UpdateNote([FromBody] UpdateNoteRequest request)
        //{
        //    var result = _noteRepository.Update(request);

        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult DeleteNote([FromRoute] int id)
        //{
        //    var result = _noteRepository.Delete(id);

        //    return Ok(result);  
        //}
    }
}
