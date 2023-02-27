using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebProject.Infrastructure.Persistence;

internal class MigrationsHelper : IMigrationsHelper
{
    private readonly ApplicationDbContext dbContext;

    public MigrationsHelper(ApplicationDbContext dbContext)
    {       
        this.dbContext = dbContext;     
    }

    public void ApplyMigrations()
    {
        if (dbContext.Database.GetPendingMigrations().Count() > 0)
        {
            dbContext.Database.Migrate();
        }
    }
}
