namespace Assignment1_MuditKhanna.Models
{
    public class DataHelper
    {
        public static List<QuestionModel> questionsList;
        public static List<string> categories = new List<string>() { "Information Technology", "General Knowledge", "Sports" };

        public static List<QuestionModel> getQuestionsList()
        {
            if (questionsList == null)
            {
                questionsList = new List<QuestionModel>();
                questionsList.Add(new QuestionModel(1, categories.ElementAt(1), "Which is the biggest continent in the world?"));
                questionsList.Add(new QuestionModel(2, categories.ElementAt(0), "Who created first computer?"));
                questionsList.Add(new QuestionModel(3, categories.ElementAt(2), "Who has most number of centuries in international cricket?"));
                questionsList.Add(new QuestionModel(4, categories.ElementAt(0), "Is java easier than C#?"));
                questionsList.Add(new QuestionModel(5, categories.ElementAt(0), "Dell or HP?"));

                questionsList.ElementAt(0).AnswersList.Add(new AnswerModel(1, 1, "Africa", "Mudit"));
                questionsList.ElementAt(1).AnswersList.Add(new AnswerModel(1, 2, "Alan Turing", "Natalie"));
                questionsList.ElementAt(0).AnswersList.Add(new AnswerModel(2, 1, "America", "Rahul"));
                questionsList.ElementAt(2).AnswersList.Add(new AnswerModel(1, 3, "Sachin Tendulkar", "Abhay"));
                questionsList.ElementAt(3).AnswersList.Add(new AnswerModel(1, 4, "Java", "Dhruv"));
                questionsList.ElementAt(1).AnswersList.Add(new AnswerModel(2, 2, "Charles Babbage", "Abhideep"));
                questionsList.ElementAt(4).AnswersList.Add(new AnswerModel(1, 5, "Dell", "Dheeraj"));
            }
            return questionsList;
        }
    }
}
