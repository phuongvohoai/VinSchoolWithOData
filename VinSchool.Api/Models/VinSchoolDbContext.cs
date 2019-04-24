using Microsoft.EntityFrameworkCore;

namespace VinSchool.Api.Models
{
    public class VinSchoolDbContext : DbContext
    {
        public VinSchoolDbContext(DbContextOptions<VinSchoolDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(c => c.Id);
                student.HasOne(c => c.School).WithMany(c => c.Students).HasForeignKey(c => c.SchoolId);
                student.ToTable("students");
            });

            modelBuilder.Entity<School>(school =>
            {
                school.HasKey(c => c.Id);
                school.ToTable("schools");
            });
        }
    }
}
