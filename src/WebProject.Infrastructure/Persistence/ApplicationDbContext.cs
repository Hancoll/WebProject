using Microsoft.EntityFrameworkCore;
using WebProject.Domain.UserAggregate;

namespace WebProject.Infrastructure.Persistence;

internal class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) : base(options) { }
}
