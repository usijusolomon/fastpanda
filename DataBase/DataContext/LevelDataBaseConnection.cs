using System.Data.Entity;
using ObjectClass;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class LevelDataBaseConnection : DbContext
    {
        public LevelDataBaseConnection(): base("TeaDb")
        {

        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
    }
}
