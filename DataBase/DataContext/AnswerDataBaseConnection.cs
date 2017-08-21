using System.Data.Entity;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class AnswerDataBaseConnection : DbContext
    {
        public AnswerDataBaseConnection(): base("TeaDb")
            {
            }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
    }
}
