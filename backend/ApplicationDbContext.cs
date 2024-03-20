using Microsoft.EntityFrameworkCore;

namespace backend {
  public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

    public DbSet<Vote> votes { get; set; }
    public DbSet<Pseudonym> pseudonyms { get; set; }
  }
}
