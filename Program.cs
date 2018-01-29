using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            var context = new SchoolContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();
            // var count = context.Courses.Count();
            // Console.WriteLine($"Hello World! The number of Courses is {count}");
            // Course ENG110 = new Course {CourseID = 111, Title = "Dynamics", Credits = 3};
            // context.Courses.Add(ENG110);
            // context.SaveChanges();
            //var ncount = context.Courses.Count();
            //Console.WriteLine($"Hello World! The number of Courses is {ncount}");
            //Console.WriteLine("All students in the database:");
            // Get all Students from the database ordered by Name
            Paging_Students.SkipStudents();
            
    }
    }
}
