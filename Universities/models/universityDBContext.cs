using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using Universities.Entities;

namespace Universities.models
{
    public class universityDBContext: DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] { new NLogLoggerProvider() });

        private readonly string connectionString;


        public virtual DbSet<CommonZakat_MinorLookUpTable> CommonZakat_MinorLookUpTable { get; set; }

        public universityDBContext(DbContextOptions<universityDBContext> options) : base(options)
        {

             

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

             

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
      
            optionsBuilder.LogTo(m => System.Diagnostics.Debug.WriteLine(m), new[] { DbLoggerCategory.Database.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();


        }
    }
}
