namespace Notes.Application.Commands.DeleteNote;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Notes.Domain.Entities;
using Notes.Application.Common.Interfaces;
using Notes.Application.Common.Exceptions;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly IApplicationDbContext context;
    private readonly ICurrentUser currentUser;

    public DeleteNoteCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        this.context = context;
        this.currentUser = currentUser;
    }

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        Note note = await getNote(request.Id, cancellationToken);

        if (note.AuthorId != currentUser.Id)
        {
            throw new ForbiddenException();
        }

        context.Notes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    private async Task<Note> getNote(long id, CancellationToken cancellationToken)
    {
        Note? note = await context.Notes.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (note is null)
        {
            throw new EntityNotFoundException();
        }

        return note;
    }
}
