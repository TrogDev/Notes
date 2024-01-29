namespace Notes.Application.Commands.CreateNote;

using MediatR;

public record CreateNoteCommand : IRequest<long>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}
