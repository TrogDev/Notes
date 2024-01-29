namespace Notes.Application.Queries.ExportNotes;

using MediatR;

using Notes.Application.Common.Interfaces;
using Notes.Application.DTO;
using Notes.Application.Queries.GetNotes;

public class ExportNotesQueryHandler : IRequestHandler<ExportNotesQuery, byte[]>
{
    private readonly IExporter exporter;
    private readonly ISender mediator;

    public ExportNotesQueryHandler(IExporter exporter, ISender mediator)
    {
        this.exporter = exporter;
        this.mediator = mediator;
    }

    public async Task<byte[]> Handle(ExportNotesQuery request, CancellationToken cancellationToken)
    {
        List<NoteDTO> notes = await mediator.Send(new GetNotesQuery(), cancellationToken);
        return exporter.Export(notes);
    }
}
