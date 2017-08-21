using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass.Objects
{
   public class Test
    {
        public long TestId { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [Required]
        public DateTime EndDate { get; set; }
        [DisplayName("Start Time")]
        [Required]
        public string StartTime { get; set; }
        [DisplayName("End Time")]
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [DisplayName("Overall Score")]
        public int OverallScore { get; set; }
        public long CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public List<Question> Questions { get; set; }
    }
}
