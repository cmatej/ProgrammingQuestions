using ProgrammingQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProgrammingQuestions.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _context;
        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Questions
        public ActionResult Index()
        {
            var model = _context.Questions.Include(a => a.SkillLevel).Include(a => a.Country).ToList();

            return View(model);
        }
    }
}