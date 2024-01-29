namespace Notes.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

using Notes.Domain.Entities;

public interface IApplicationDbContext
{
    DbSet<Note> Notes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
