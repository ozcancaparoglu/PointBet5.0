using Common.Entities;
using Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PointBet.Data.Domains;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PointBet.Data.Context
{
    public class AppDbContext : DbContext
    {
        #region Construction

        private readonly IHttpContextAccessor _httpContextAccessor;

        //public AppDbContext()
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region TestCase

        //Alert! Just open while running Tests. Comment-out otherwise.

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Data Source=85.111.48.114,1433;Initial Catalog=suwen_ozcan;Integrated Security=False;Persist Security Info=False;User ID=ozcandb;Password=a1fX0J3");

        #endregion

        #region Domains

        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStatistic> TeamStatistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<BookMakers> BookMakers { get; set; }
        public DbSet<Bets> Bets { get; set; }

        #endregion

        #region Methods

        private void PreInsertListener()
        {
            foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added).ToList())
            {
                entity.Entity.CreatedDate = DateTime.Now;
                entity.Entity.State = (int)State.Active;
                try
                {
                    entity.Entity.ProcessedBy = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                }
                catch
                {
                    entity.Entity.ProcessedBy = 0;
                }

            }
        }

        private void UpdateListener()
        {
            foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Modified).ToList())
            {
                entity.Entity.UpdatedDate = DateTime.Now;
                try
                {
                    entity.Entity.ProcessedBy = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                }
                catch
                {
                    entity.Entity.ProcessedBy = 0;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PreInsertListener();
            UpdateListener();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            PreInsertListener();
            UpdateListener();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
