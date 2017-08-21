using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObjectClass.Objects
{
    public class Faculty 
    {
        public long FacultyId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Department> Department { get; set; }
    }
}
