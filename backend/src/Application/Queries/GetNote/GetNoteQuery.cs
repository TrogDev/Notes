namespace Notes.Application.Queries.GetNote;

using MediatR;

using Notes.Application.DTO;

public record GetNoteQuery : IRequest<NoteDTO>
{
    public required long Id { get; init; }
}
