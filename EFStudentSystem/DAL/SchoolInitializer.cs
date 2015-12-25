using EFStudentSystem.Models;
using EFStudentSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFStudentSystem.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();


            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", 
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",    
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",       
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",      
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",      
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID, 
                    Location = "Smith 17" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID, 
                    Location = "Gowan 27" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID, 
                    Location = "Thompson 304" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.Add(s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Chemistry", "Harui");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");

            AddOrUpdateInstructor(context, "Calculus", "Fakhouri");
            AddOrUpdateInstructor(context, "Trigonometry", "Harui");
            AddOrUpdateInstructor(context, "Composition", "Abercrombie");
            AddOrUpdateInstructor(context, "Literature", "Abercrombie");

            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID, 
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B         
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();

            var announcements = new List<Announcement>
            {
                new Announcement { Title= "Petri-dishing the Dirt for Science and Education",
                    ShortDescription="WPI joins Howard Hughes Medical Institute program for undergraduate research on soil-dwelling viruses.",
                    Content="As vacation homework assignments go, it wasn't bad—dig up some soil near home and bring it to class after the break. But the undergraduates at Worcester Polytechnic Institute (WPI) who gathered those soil samples are now using them to conduct research as part of a national program led by the Howard Hughes Medical Institute (HHMI) that seeks to enhance undergraduate life sciences education while also crowd-sourcing the discovery and characterization of viruses that attack bacteria.",
                    PostedOn = DateTime.Parse("2015-12-21"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },

                new Announcement { Title= "WPI Marks 15th Anniversary as host of Massachusetts FIRST LEGO League State Championship",
                    ShortDescription="Teams from across Massachusetts--and Jamaica--will participate in annual event",
                    Content="Eighty-two elementary and middle school robotics teams from Massachusetts—and two from Jamaica—will compete in the 15th annual FIRST LEGO League (FLL) RoboNautica competition, to be held at Worcester Polytechnic Institute (WPI). This year's theme is 'Trash Trek' which will challenge teams to choose and solve a real-world trash problem. Teams will build, test, and program an autonomous robot, using LEGO MINDSTORMS® technology, to either help people generate less trash or improve the way they handle trash. Throughout the day teams will present their research and innovative solutions to judges.",
                    PostedOn = DateTime.Parse("2015-12-15"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },


                new Announcement { Title= "Twelve Days of A Christmas Carol: A Dozen Curious Facts About the Most Famous Christmas Book of All Time",
                    ShortDescription="WPI Dickens Scholar Joel Brattin Offers His List of the Fascinating Stories Behind the Creation and the Legacy of Charles Dickens's Immortal Holiday Tale",
                    Content="On Dec. 19, 1843, Charles Dickens released a short work of fiction with a powerful and enduring message about redemption and charity. A Christmas Carol was an immediate success, selling out edition after edition and delighting critics and other literary luminaries. The book's power to engage and illuminate readers has remained undiminished for more than 170 years.",
                    PostedOn = DateTime.Parse("2015-12-14"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },

                new Announcement { Title= "Andrew Palumbo Named Dean of Admissions and Financial Aid",
                    ShortDescription="An energetic and innovative leader, Palumbo has a track record for enhancing outreach and increasing enrollment",
                    Content="Following a rigorous nationwide search, Worcester Polytechnic Institute (WPI) has appointed Andrew B. Palumbo dean of admissions and financial aid. Palumbo will join the university Dec. 7 from Plymouth State University in New Hampshire, where he was assistant vice president of enrollment management and director of admissions.At Plymouth State, Palumbo led a successful strategic enrollment initiative, working with several academic departments to craft a multilayered recruitment program that led the university out of a three-year trend of sharp enrollment decline and broadened the school’s geographic reach. The efforts surpassed regional and national enrollment norms in a highly competitive market. Prior to Plymouth State, Palumbo was the director of undergraduate admissions at The Sage Colleges of Albany, N.Y., where he streamlined admissions processes for both schools (Russell Sage College and its sister school, Sage College of Albany). He began his admissions career as assistant dean at Union College in Schenectady, N.Y.",
                    PostedOn = DateTime.Parse("2015-12-03"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID },
            };
            announcements.ForEach(s => context.Announcements.Add(s));
            context.SaveChanges();
           
        }

        private void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
    }
}