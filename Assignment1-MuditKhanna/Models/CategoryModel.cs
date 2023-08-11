using System.ComponentModel.DataAnnotations;

namespace Assignment1_MuditKhanna.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    }
}
