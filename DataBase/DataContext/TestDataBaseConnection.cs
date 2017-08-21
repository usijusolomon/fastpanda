using System.Data.Entity;
using ObjectClass;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class TestDataBaseConnection : DbContext
    {
        public TestDataBaseConnection(): base("TeaDb")
        {
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        public System.Data.Entity.DbSet<ObjectClass.Objects.Test> Tests { get; set; }
    }
}
