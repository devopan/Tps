using Tps.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Tps.Server.Data.Entities.Task;

namespace Tps.Server.Data
{
    public class TpmDbContext : DbContext
    {
        public TpmDbContext(
            DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Translator> Translators { get; set; }
    }
}
