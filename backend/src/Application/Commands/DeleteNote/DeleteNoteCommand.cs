namespace Notes.Application.Commands.DeleteNote;

using MediatR;

public record DeleteNoteCommand : IRequest
{
    public required long Id { get; init; }
}
