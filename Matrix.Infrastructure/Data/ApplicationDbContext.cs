using Matrix.Domain.Entities;

namespace Matrix.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, int>(options)
{
    public DbSet<User> User => Set<User>();
    public DbSet<Country> Country => Set<Country>();
    public DbSet<State> State => Set<State>();
    public DbSet<City> City => Set<City>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseOpenIddict();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            // Check for CreatedOn property dynamically
            var createdOnProp = entity.GetType().GetProperty("CreatedOn");
            if (createdOnProp != null && entry.State == EntityState.Added)
            {
                createdOnProp.SetValue(entity, utcNow);
            }

            // Check for UpdatedOn property dynamically
            var updatedOnProp = entity.GetType().GetProperty("UpdatedOn");
            if (updatedOnProp != null && entry.State == EntityState.Modified)
            {
                updatedOnProp.SetValue(entity, utcNow);
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
