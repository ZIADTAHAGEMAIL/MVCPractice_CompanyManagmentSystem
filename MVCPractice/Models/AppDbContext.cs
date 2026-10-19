

using Microsoft.EntityFrameworkCore; // استخدام EF Core
namespace MVCPractice.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Relative> Relative { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Zizo;Initial Catalog=MVC_ITI_NEW;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                   .HasIndex(ep => new { ep.EmployeeId, ep.ProjectId })
                   .IsUnique();
            modelBuilder.Entity<Department>()
    .HasMany(d => d.Employees)
    .WithOne(e => e.Department).OnDelete(DeleteBehavior.NoAction);




            /////////////////////
            modelBuilder.Entity<Project>()
    .HasMany(p => p.EmpPrj)
    .WithOne(ep => ep.Project)
    .OnDelete(DeleteBehavior.Cascade);
            ///////////////////////////
            modelBuilder.Entity<Employee>().HasMany(e=>e.Relatives)
                .WithOne(e=>e.emp).OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<Employee>()
    .HasIndex(e => new { e.Name, e.DepartmentId })
    .IsUnique();
            base.OnModelCreating(modelBuilder);
        }


    }
}
