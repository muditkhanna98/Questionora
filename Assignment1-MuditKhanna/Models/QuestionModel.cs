using System.ComponentModel.DataAnnotations;

namespace Assignment1_MuditKhanna.Models
{
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string QuestionValue { get; set; }
        public List<AnswerModel> AnswersList { get; set; } = new List<AnswerModel>();

        public QuestionModel() { }

        public QuestionModel(int id, string category, string questionValue)
        {
            Id = id;
            Category = category;
            QuestionValue = questionValue;
        }
    }
}
