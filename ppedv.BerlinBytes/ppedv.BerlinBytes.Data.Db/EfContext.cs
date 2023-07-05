using Microsoft.EntityFrameworkCore;
using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Data.Db
{
    public class EfContext : DbContext
    {
        public DbSet<App> Apps { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Model.DomainModel.Version> Versions { get; set; }

        private readonly string _conString;
        public EfContext(string conString)
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conString).UseLazyLoadingProxies();
        }
    }
}