using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectClass.Objects
{
    public class Question
    {
        public long QuestionId { get; set; }
        public long TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        [DisplayName("Question")]
        [Required]
        public string AskedQuestion { get; set; }
        [DisplayName("S/n")]
        public int QuestionNumber { get; set; }
        public string Image { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
