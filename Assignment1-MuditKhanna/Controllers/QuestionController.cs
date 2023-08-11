using Assignment1_MuditKhanna.Data;
using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_MuditKhanna.Controllers
{
    public class QuestionController : Controller
    {
        public readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Questions()
        {
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View(_context.Questions.Include(q => q.AnswersList).ToList());
        }

        [Authorize]
        public IActionResult Add()
        {
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult PostQuestion(QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Questions.Add(questionModel);
                _context.SaveChanges();
                ViewBag.CategoryNames = new SelectList(DataHelper.categories);
                return RedirectToAction("Questions", new { questions = _context.Questions.ToList() });
            }

            ViewBag.CategoryNames = new SelectList(DataHelper.categories);
            return View(questionModel);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            QuestionModel questionForDetail = _context.Questions
                .Include(q => q.AnswersList)
                .FirstOrDefault(q => q.Id == id);
            return View(questionForDetail);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            QuestionModel questionForDelete = _context.Questions.Find(id);
            _context.Questions.Remove(questionForDelete);
            _context.SaveChanges();
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View("Questions", _context.Questions.ToList());
        }
    }
}
