using System;
using System.Linq;

namespace Courses
{
    public static class Querying_Students
    {
        internal static void SelectOrderedList()
        {
            
            using(var context = new SchoolContext())
            {
                Console.WriteLine("All students in the database:");
	            var query = from s in context.Students
			    orderby s.LastName ascending, s.FirstMidName ascending
			    select s; 
                foreach (var student in query)
                {
                    Console.WriteLine(value: student.FirstMidName + " " + student.LastName);
                }
                // Keep the console window open in debug mode
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();

            }


        }
    }
    public static class Paging_Students
    {
        internal static void SkipStudents(){
            using(var context = new SchoolContext()) {
//                var pagedStudents = context.Students.Skip(800); 
                var pagedStudents = context.Students.OrderByDescending(s => s.FirstMidName).Take(50);
                foreach(var student in pagedStudents){
                    Console.WriteLine(student.FirstMidName + " " + student.LastName);
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }

        }
    }
}