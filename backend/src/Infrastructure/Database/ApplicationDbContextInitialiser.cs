namespace Notes.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext context;

    public ApplicationDbContextInitialiser(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void Initialise()
    {
        context.Database.Migrate();
    }
}
