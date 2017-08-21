using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectClass.Objects
{
    public class Department
    {
        public long DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public long FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        public IEnumerable<Course> Course { get; set; }
    }
}
