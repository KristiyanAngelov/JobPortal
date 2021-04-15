namespace JobPortal.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using JobPortal.Data.Common.Models;
    using JobPortal.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<JobPost> JobPosts { get; set; }

        public DbSet<SearchJobPost> SearchJobPosts { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<WorkerJobPost> WorkerJobPosts { get; set; }

        public DbSet<WorkerCompany> WorkerCompanies { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            // Configure table relations
            builder
                .Entity<WorkerJobPost>()
                .HasKey(x => new { x.CandidateId, x.JobPostId });

            builder
                .Entity<WorkerJobPost>()
                .HasOne(c => c.Candidate)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(c => c.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<WorkerJobPost>()
                .HasOne(jp => jp.JobPost)
                .WithMany(c => c.Candidates)
                .HasForeignKey(jp => jp.JobPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<WorkerCompany>()
                .HasKey(x => new { x.WorkerId, x.CompanyId });

            builder
               .Entity<WorkerCompany>()
               .HasOne(w => w.Worker)
               .WithMany(o => o.Opinions)
               .HasForeignKey(w => w.WorkerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
              .Entity<WorkerCompany>()
              .HasOne(c => c.Company)
              .WithMany(wo => wo.WorkersOpinions)
              .HasForeignKey(c => c.CompanyId)
              .OnDelete(DeleteBehavior.Restrict);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
