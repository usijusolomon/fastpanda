using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass.Objects;

namespace DataBase.DataContext
{
    public class CandidateTestDataBaseConnection : DbContext
    {
        public CandidateTestDataBaseConnection(): base("TeaDb")
        {
        }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<CandidateTest> CandidateTests { get; set; }


    }
}
