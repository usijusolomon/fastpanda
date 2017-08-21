using System.Data.Entity;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class DepartmentDataBaseConnection : DbContext
    {
        public DepartmentDataBaseConnection(): base("TeaDb")
        {
        }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Course> Courses { get; set; } 
    }
}
