using Contoso_University.Models;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Contoso_University
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        /* The names of DbSet properties are used as table names.For entities not referenced by a DbSet property, entity class names are used as table names.*/
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }


        /*The code in the OnModelCreating method of the DbContext class uses the fluent API to configure EF behavior. The API is called "fluent" because it's often used by stringing a series of method calls together into a single statement, as in this example from the EF Core documentation:*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            //composet key
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });

            /*https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx*/

            /*حسب الاصطلاح ، يتيح Entity Framework حذفًا متتاليًا للمفاتيح الخارجية غير القابلة للإلغاء ولعلاقات أطراف بأطراف. يمكن أن يؤدي هذا إلى قواعد حذف تتالي دائرية ، مما يؤدي إلى استثناء عند محاولة إضافة ترحيل. على سبيل المثال ، إذا لم تحدد خاصية Department.InstructorID على أنها لاغية ، فسيقوم EF بتكوين قاعدة حذف متتالية لحذف القسم عند حذف المدرس ، وهذا ليس ما تريد حدوثه. إذا كانت قواعد العمل الخاصة بك تتطلب أن تكون خاصية InstructorID غير قابلة للإلغاء ، فسيتعين عليك استخدام عبارة API السهلة التالية لتعطيل الحذف المتتالي في العلاقة:*/

            modelBuilder.Entity<Department>()
  .HasOne(d => d.Administrator)
  .WithMany()
  .OnDelete(DeleteBehavior.Restrict);

        }


    }

}