using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        /*لاحظ أن العديد من الخصائص هي نفسها في الكيانين Student و Instructor. في البرنامج التعليمي "تنفيذ الوراثة" لاحقًا في هذه السلسلة ، ستقوم بإعادة تشكيل هذا الرمز للتخلص من التكرار.
يمكنك وضع سمات متعددة في سطر واحد ، بحيث يمكنك أيضًا كتابة سمات HireDate على النحو التالي:*/
        [DataType(DataType.Date), Display(Name = "Hire Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
      

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        //خصائص CourseAssignments و OfficeAssignment هي خصائص تنقل.

       // يمكن للمدرس تدريس أي عدد من الدورات التدريبية ، لذلك يتم تعريف CourseAssignments على أنها مجموعة.
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        /*If a navigation property can hold multiple entities, its type must be a list in which entries can be added, deleted, and updated. You can specify ICollection<T> or a type such as List<T> or HashSet<T>. If you specify ICollection<T>, EF creates a HashSet<T> collection by default.

The reason why these are CourseAssignment entities is explained below in the section about many-to-many relationships.

Contoso University business rules state that an instructor can only have at most one office, so the OfficeAssignment property holds a single OfficeAssignment entity (which may be null if no office is assigned).*/
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}