﻿namespace Assignment1_MuditKhanna.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerValue { get; set; }
        public string Author { get; set; }

        public AnswerModel() { }

        public AnswerModel(int id, int quesId, string answerValue, string author)
        {
            this.Id = id;
            QuestionId = quesId;
            AnswerValue = answerValue;
            Author = author;
        }
    }
}