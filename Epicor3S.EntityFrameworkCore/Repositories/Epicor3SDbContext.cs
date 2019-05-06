using Microsoft.EntityFrameworkCore;
using Epicor3S.Core.Models;

namespace Epicor3S.EntityFrameworkCore.Repositories
{
    public class Epicor3SDbContext : DbContext
    {
        public Epicor3SDbContext(DbContextOptions<Epicor3SDbContext> dbContextOptions) : base(dbContextOptions)
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
            });

            modelBuilder.Entity<School>(school =>
            {
                school.HasKey(c => c.Id);
            });
        }
    }
}
