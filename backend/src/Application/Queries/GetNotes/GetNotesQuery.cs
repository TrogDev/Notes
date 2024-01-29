namespace Notes.Application.Queries.GetNotes;

using MediatR;
using Notes.Application.DTO;

public record GetNotesQuery : IRequest<List<NoteDTO>> { }
