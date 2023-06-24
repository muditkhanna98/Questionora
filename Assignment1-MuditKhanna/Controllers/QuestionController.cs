using Assignment1_MuditKhanna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment1_MuditKhanna.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Questions()
        {
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View(DataHelper.getQuestionsList());
        }

        public IActionResult Add()
        {
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View();
        }

        [HttpPost]
        public IActionResult PostQuestion(QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                questionModel.Id = DataHelper.getQuestionsList().Count + 1;
                DataHelper.getQuestionsList().Add(questionModel);
                ViewBag.CategoryNames = new SelectList(DataHelper.categories);
                return RedirectToAction("Questions", new { questions = DataHelper.getQuestionsList() });
            }

            ViewBag.CategoryNames = new SelectList(DataHelper.categories);
            return View(questionModel);
        }

        public IActionResult Details(int id)
        {
            QuestionModel questionForDetail = DataHelper.getQuestionsList().First(x => x.Id == id);
            return View(questionForDetail);
        }

        public IActionResult Delete(int id)
        {
            QuestionModel question = DataHelper.getQuestionsList().First(x => x.Id == id);
            DataHelper.getQuestionsList().Remove(question);
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View("Questions", DataHelper.getQuestionsList());
        }
    }
}
