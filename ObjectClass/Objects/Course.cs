using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectClass.Objects
{
    public class Course
    {
        public long CourseId { get; set; }
        public string Name { get; set; }
        [DisplayName("Course Code")]
        [Required]
        public string CourseCode { get; set; }
        [DisplayName("Course Title")]
        [Required]
        public string CourseTitle { get; set; }
        [DisplayName("Credit Unit")]
        [Required]
        public int CourseUnit { get; set; }
        public long LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public IEnumerable<Test> Tests { get; set; }

    }
}
