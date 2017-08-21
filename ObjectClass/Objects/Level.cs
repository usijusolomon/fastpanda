using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObjectClass.Objects
{
    public class Level
    {
        public long LevelId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Department> Department { get; set; }
    }
}
