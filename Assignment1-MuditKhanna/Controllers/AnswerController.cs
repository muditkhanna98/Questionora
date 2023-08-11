using Assignment1_MuditKhanna.Data;
using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_MuditKhanna.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswerController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int quesId)
        {
            QuestionModel question = _context.Questions.Find(quesId);
            ViewBag.ques = question;
            return View();
        }

        [HttpPost]
        public IActionResult Add(AnswerModel answerModel)
        {
            answerModel.Author = "Anonymous";
            _context.Answers.Add(answerModel);
            _context.SaveChanges();
            QuestionModel question = _context.Questions.Find(answerModel.QuestionModelId);
            return RedirectToAction("Details", "Question", new { id = question.Id });
        }

        public IActionResult Delete(int id, int quesId)
        {
            AnswerModel answer = _context.Answers.FirstOrDefault(x => x.Id == id && x.QuestionModelId == quesId);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Delete(AnswerModel answerModel)
        {
            _context.Answers.Remove(answerModel);
            _context.SaveChanges();
            QuestionModel question = _context.Questions.Find(answerModel.QuestionModelId);
            return RedirectToAction("Details", "Question", new { id = question.Id });
        }

        public IActionResult Edit(int id, int quesId)
        {
            AnswerModel answer = _context.Answers.FirstOrDefault(x => x.Id == id && x.QuestionModelId == quesId);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Edit(AnswerModel answerModel)
        {
            AnswerModel answer = _context.Answers.Find(answerModel.Id);
            answer.AnswerValue = answerModel.AnswerValue;
            _context.SaveChanges();

            QuestionModel question = _context.Questions.Find(answerModel.QuestionModelId);
            return RedirectToAction("Details", "Question", new { id = question.Id });
        }
    }
}
