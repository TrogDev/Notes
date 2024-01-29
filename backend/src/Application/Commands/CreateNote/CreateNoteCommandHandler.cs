namespace Notes.Application.Commands.CreateNote;

using MediatR;

using Notes.Domain.Entities;
using Notes.Application.Common.Interfaces;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, long>
{
    private readonly IApplicationDbContext context;
    private readonly ICurrentUser currentUser;

    public CreateNoteCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        this.context = context;
        this.currentUser = currentUser;
    }

    public async Task<long> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note()
        {
            Title = request.Title,
            Description = request.Description,
            AuthorId = currentUser.Id!
        };

        await context.Notes.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}
