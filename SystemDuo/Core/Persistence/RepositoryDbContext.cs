using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Persistence.Configurations;

namespace SystemDuo.Core.Persistence
{
    public class RepositoryDbContext: IdentityDbContext<
        User,
        Role,
        string,
        IdentityUserClaim<string>,
        UserRole,
        IdentityUserLogin<string>,    
        IdentityRoleClaim<string>,    
        IdentityUserToken<string>>
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            modelBuilder.Entity<UserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<Role>().ToTable("AspNetRoles");


            modelBuilder.Entity<UserRole>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.Roles)
                        .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Roles)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SkillsConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());



        }
        
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Skills>? Skills { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Documents>? Documents { get; set; }
        public DbSet<ApplicantSkills>? CandidateSkills { get; set; }
        public DbSet<JobSkills>? JobsSkills { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<EmployeeJob>? EmployeeJobs { get; set; }
        public DbSet<EmployeeRecension>? EmployeeRecensions { get; set; }
        public DbSet<ApplicationComments>? ApplicationComments { get; set; }    
        public DbSet<UserCalendar>? UserCalendars { get; set; }    
     }
}
