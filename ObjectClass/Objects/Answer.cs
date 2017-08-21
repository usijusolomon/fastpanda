using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectClass.Objects
{
    public class Answer
    {
        public long AnswerId { get; set; }
        public long QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        [DisplayName("Answer")]
        [Required]
        public string QuestionAnswer { get; set; }
        [DisplayName("Correct Answer")]
        public bool RightAnswer { get; set; }
        public char Label { get; set; }
        [DisplayName("S/n")]
        public long QuestionNumber { get; set; }
    }
}
