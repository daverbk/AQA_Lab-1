using DBHomework.Configuration;
using DBHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace DBHomework.Databases
{
    public class DataBaseConnector : DbContext
    {
        public DbSet<Milestone> Milestones { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        public DataBaseConnector()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Host={Configurator.DbSettings.Server};" +
                $"Port={Configurator.DbSettings.Port};" +
                $"Database={Configurator.DbSettings.Schema};" +
                $"User Id={Configurator.DbSettings.Username};" +
                $"Password={Configurator.DbSettings.Password};";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
