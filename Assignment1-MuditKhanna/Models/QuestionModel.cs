﻿namespace Assignment1_MuditKhanna.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Category { get; set; }
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
