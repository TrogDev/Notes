namespace Notes.Application.Queries.ExportNotes;

using MediatR;

public record ExportNotesQuery : IRequest<byte[]> { }
