namespace CleanArchitecture.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;
using Notes.Infrastructure.Identity;

public class TodoItemConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.Property(e => e.Title).HasMaxLength(255).IsRequired();
        builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(e => e.AuthorId);
    }
}
