using Assignment1_MuditKhanna.Data;
using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_MuditKhanna.Controllers
{
    [Authorize]
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> userManager;

        public AnswerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this._context = context;
            this.userManager = userManager;
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
            IdentityUser user = userManager.GetUserAsync(User).Result;
            answerModel.Author = user.Email;
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
