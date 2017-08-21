using System.Data.Entity;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class CourseDataBaseConnection : DbContext
    {
        public CourseDataBaseConnection(): base("TeaDb")
        {
        }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

    }
}
