namespace Notes.Application.Commands.UpdateNote;

using MediatR;

public record UpdateNoteCommand : IRequest
{
    public required long Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}
