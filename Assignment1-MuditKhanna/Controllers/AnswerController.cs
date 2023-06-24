using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment1_MuditKhanna.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int quesId)
        {
            QuestionModel question = DataHelper.getQuestionsList().First(x => x.Id == quesId);
            ViewBag.ques = question;
            return View();
        }

        [HttpPost]
        public IActionResult Add(AnswerModel answerModel)
        {
            QuestionModel question = DataHelper.getQuestionsList().First(x => x.Id == answerModel.QuestionId);
            answerModel.Id = question.AnswersList.Count > 0 ? question.AnswersList.Max(x => x.Id) + 1 : 1;
            answerModel.Author = "Anonymous";
            question.AnswersList.Add(answerModel);
            return RedirectToAction("Details", "Question", question);
        }

        public IActionResult Delete(int id, int quesId)
        {
            QuestionModel question = DataHelper.getQuestionsList().First(x => x.Id == quesId);
            AnswerModel answer = question.AnswersList.Find(x => x.Id == id);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Delete(AnswerModel answerModel)
        {
            QuestionModel question = DataHelper.getQuestionsList().Find(x => x.Id == answerModel.QuestionId);
            AnswerModel answer = question.AnswersList.Find(x => x.Id == answerModel.Id);
            question.AnswersList.Remove(answer);

            return RedirectToAction("Details", "Question", new { id = question.Id });
        }

        public IActionResult Edit(int id, int quesId)
        {
            QuestionModel question = DataHelper.getQuestionsList().First(x => x.Id == quesId);
            AnswerModel answer = question.AnswersList.Find(x => x.Id == id);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Edit(AnswerModel answerModel)
        {
            QuestionModel question = DataHelper.getQuestionsList().Find(x => x.Id == answerModel.QuestionId);
            AnswerModel answer = question.AnswersList.Find(x => x.Id == answerModel.Id);
            answer.AnswerValue = answerModel.AnswerValue;

            return RedirectToAction("Details", "Question", new { id = question.Id });
        }
    }
}
