using ContosoUniversity.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso_University.Models
{
    public class Course
    {
        //Entity properties that are named ID or classnameID are recognized as PK properties.
        //تحدد السمة DatabaseGenerated مع المعلمة None في الخاصية CourseID أن قيم المفتاح الأساسي يتم توفيرها بواسطة المستخدم بدلاً من إنشاؤها بواسطة قاعدة البيانات.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")] public int CourseID { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Course Title ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, 5)]
        public int Credits { get; set; }

        // navigation property 
        //if a this class row in the database has two related Employee 
        //   rows, the Enrollments
        //   navigation property contains those two Enrollments entities
        public ICollection<Enrollment> Enrollments { get; set; }

        public int DepartmentID { get; set; }
        //Foreign key and navigation properties
        //A course can have any number of students enrolled in it, so the Enrollments navigation property is a collection:
        public Department Department { get; set; }
      
        //A course may be taught by multiple instructors, so the CourseAssignments navigation property is a collection
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
