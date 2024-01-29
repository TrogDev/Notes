namespace Notes.Application.Queries.GetNote;

using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Common.Interfaces;
using Notes.Application.DTO;
using Notes.Domain.Entities;

public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteDTO>
{
    private readonly IApplicationDbContext context;
    private readonly ICurrentUser currentUser;

    public GetNoteQueryHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        this.context = context;
        this.currentUser = currentUser;
    }

    public async Task<NoteDTO> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        Note note = await getNote(request.Id, cancellationToken);

        if (note.AuthorId != currentUser.Id)
        {
            throw new ForbiddenException();
        }

        return new NoteDTO()
        {
            Id = note.Id,
            Title = note.Title,
            Description = note.Description,
            CreatedAt = note.CreatedAt
        };
    }

    private async Task<Note> getNote(long id, CancellationToken cancellationToken)
    {
        Note? note = await context.Notes.FindAsync(id);

        if (note is null)
        {
            throw new EntityNotFoundException();
        }

        return note;
    }
}
