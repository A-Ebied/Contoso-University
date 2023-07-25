using Contoso_University.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        // the Column attribute is being used to change SQL data type mapping so that the column will be defined using the SQL Server money type in the database:
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        //A department may or may not have an administrator, and an administrator is always an instructor. Therefore the InstructorID property is included as the foreign key to the Instructor entity, and a question mark is added after the int type designation to mark the property as nullable. The navigation property is named Administrator but holds an Instructor entity:
        public int? InstructorID { get; set; }

        public Instructor Administrator { get; set; }
        //A department may have many courses, so there's a Courses navigation property:


        public ICollection<Course> Courses { get; set; }
    }
}