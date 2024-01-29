namespace Notes.Web.Api.Controllers;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Commands.CreateNote;
using Notes.Application.Commands.DeleteNote;
using Notes.Application.Commands.UpdateNote;
using Notes.Application.Common.Exceptions;
using Notes.Application.Queries.ExportNotes;
using Notes.Application.Queries.GetNote;
using Notes.Application.Queries.GetNotes;

[ApiController]
[Route("/notes")]
public class QuizController : ControllerBase
{
    private readonly ISender mediator;

    public QuizController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetList([FromQuery] GetNotesQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet]
    [Route("{id:long}")]
    [Authorize]
    public async Task<IActionResult> GetDetail([FromRoute] GetNoteQuery query)
    {
        try
        {
            return Ok(await mediator.Send(query));
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (ForbiddenException)
        {
            return Forbid();
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromForm] CreateNoteCommand query)
    {
        return StatusCode(201, await mediator.Send(query));
    }

    [HttpPut]
    [Route("{id:long}")]
    [Authorize]
    public async Task<IActionResult> Update(
        [FromRoute] long id,
        [FromForm] string title,
        [FromForm] string description
    )
    {
        try
        {
            await mediator.Send(
                new UpdateNoteCommand()
                {
                    Id = id,
                    Title = title,
                    Description = description
                }
            );
            return NoContent();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (ForbiddenException)
        {
            return Forbid();
        }
    }

    [HttpDelete]
    [Route("{id:long}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] DeleteNoteCommand query)
    {
        try
        {
            await mediator.Send(query);
            return NoContent();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (ForbiddenException)
        {
            return Forbid();
        }
    }

    [HttpGet]
    [Route("export")]
    [Authorize]
    public async Task<IActionResult> Export([FromQuery] ExportNotesQuery query)
    {
        return File(await mediator.Send(query), "application/vnd.ms-excel", "notes.xls");
    }
}
