using AttendanceJournalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceJournalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Додаємо кілька початкових записів
            modelBuilder.Entity<AttendanceRecord>().HasData(
                new AttendanceRecord 
                { 
                    Id = 1, 
                    Group = "CS101", 
                    Student = "John Doe", 
                    Discipline = "Mathematics", 
                    Teacher = "Dr. Smith", 
                    LessonDate = new DateTime(2024, 4, 1, 11, 0, 0).ToUniversalTime(),
                    WasPresent = true 
                },
                new AttendanceRecord 
                { 
                    Id = 2, 
                    Group = "CS102", 
                    Student = "Jane Smith", 
                    Discipline = "Physics", 
                    Teacher = "Dr. Brown", 
                    LessonDate = new DateTime(2025, 3, 1, 10, 0, 0).ToUniversalTime(),
                    WasPresent = false 
                }
            );
        }
    }
}
