using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass.Objects
{
    public class CandidateTest
    {
        public long CandidateTestId { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long? TestId { get; set; }
        [ForeignKey("TestId")]
        public Test Test { get; set; }
        public long Score { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime Duration { get; set; }

    }
}
