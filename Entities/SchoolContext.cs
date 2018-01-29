using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    private static SchoolContext _context;
    internal object orderedStudents;

    public static SchoolContext Instance
    {
        get
        {
            if (_context == null)
            {
                _context = new SchoolContext();
            }
            return _context;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql("server=localhost;userid=root;pwd=rootpw;port=3306;database=School;sslmode=none;");
        }
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity => {
            entity.ToTable("Course");
            entity.Property(e => e.CourseID).HasMaxLength(6);
            entity.Property(e => e.Credits).HasColumnType("int(3)");
            entity.Property(e => e.Title).HasMaxLength(45).IsRequired();
        });
        modelBuilder.Entity<Enrollment>(entity => { 
        entity.ToTable("Enrollment");
        entity.Property(e => e.EnrollmentID)
                .IsRequired()
                .HasColumnType("int(11");
        entity.Property(e=>e.CourseID)
                .IsRequired()
                .HasMaxLength(6);
        entity.Property(e=>e.Grade).IsRequired();
        entity.Property(e=>e.StudentID).IsRequired();
        });
        modelBuilder.Entity<Student>(entity => {
            entity.ToTable("Student");
            entity.Property(e => e.ID).IsRequired().HasColumnType("int(9)");
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.FirstMidName).IsRequired();
        });
    }
   
}