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

        [HttpPost]
        public IActionResult PostQuestion(QuestionModel questionModel)
        {
            questionModel.Id = DataHelper.getQuestionsList().Count + 1;
            DataHelper.getQuestionsList().Add(questionModel);
            ViewBag.categoryNames = new SelectList(DataHelper.categories);
            return View("Questions", DataHelper.getQuestionsList());
        }

        public IActionResult Details(int id)
        {
            QuestionModel questionForDetail = DataHelper.getQuestionsList().First(x => x.Id == id);
            return View(questionForDetail);
        }
    }
}
