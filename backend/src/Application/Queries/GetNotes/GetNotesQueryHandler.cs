namespace Notes.Application.Queries.GetNotes;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Interfaces;
using Notes.Application.DTO;
using Notes.Domain.Entities;

public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<NoteDTO>>
{
    private readonly IApplicationDbContext context;
    private readonly ICurrentUser currentUser;

    public GetNotesQueryHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        this.context = context;
        this.currentUser = currentUser;
    }

    public async Task<List<NoteDTO>> Handle(
        GetNotesQuery request,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Notes.Where(e => e.AuthorId == currentUser.Id)
            .Select(
                e =>
                    new NoteDTO()
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Description = e.Description,
                        CreatedAt = e.CreatedAt
                    }
            )
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }
}
