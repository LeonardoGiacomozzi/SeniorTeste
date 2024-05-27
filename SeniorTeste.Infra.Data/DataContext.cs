using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using SeniorTeste.Domain.Entity;
using SeniorTeste.Infra.Data.Mappings;


namespace SeniorTeste.Infra.Data
{
    public class DataContext : DbContext
    {
        private IDbContextTransaction _transaction;
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Clima> Climas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CidadeMapping());
            modelBuilder.ApplyConfiguration(new ClimaMapping());
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            if (Database.CurrentTransaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }
    }
}
