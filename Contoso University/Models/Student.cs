using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso_University.Models
{
    public class Student
    {
        //Entity properties that are named ID or classnameID are recognized as PK properties.

        public int ID { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [StringLength(50)]
        [DisplayName("First Name ")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(50, ErrorMessage = "Must not exceed 50 characters.")]
        [StringLength(50)]
        [DisplayName("Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
