namespace Assignment1_MuditKhanna.Models
{
    public class DataHelper
    {
        public static List<QuestionModel> questionsList;
        public static List<string> categories = new List<string>() { "Personal", "Work" };

        public static List<QuestionModel> getQuestionsList()
        {
            if (questionsList == null)
            {
                questionsList = new List<QuestionModel>();
                questionsList.Add(new QuestionModel(1, categories.ElementAt(0), "First Question"));
                questionsList.Add(new QuestionModel(2, categories.ElementAt(0), "Second Question"));
                questionsList.Add(new QuestionModel(3, categories.ElementAt(1), "Third Question"));
                questionsList.Add(new QuestionModel(4, categories.ElementAt(1), "Fourth Question"));
                questionsList.Add(new QuestionModel(5, categories.ElementAt(0), "Fifth Question"));

                questionsList.ElementAt(0).AnswersList.Add(new AnswerModel(1, 1, "I am a rockstar", "Mudit"));
                questionsList.ElementAt(1).AnswersList.Add(new AnswerModel(2, 2, "I am a engineer", "Natasha"));
                questionsList.ElementAt(0).AnswersList.Add(new AnswerModel(3, 1, "I am a painter", "Rahul"));
                questionsList.ElementAt(2).AnswersList.Add(new AnswerModel(4, 3, "I am a ceo", "Abhay"));
                questionsList.ElementAt(3).AnswersList.Add(new AnswerModel(5, 4, "I am a teacher", "Dhruv"));
                questionsList.ElementAt(1).AnswersList.Add(new AnswerModel(6, 2, "I am a lover", "Abhideep"));
                questionsList.ElementAt(4).AnswersList.Add(new AnswerModel(7, 5, "I am a scientis", "Dheeraj"));
            }
            return questionsList;
        }
    }
}
