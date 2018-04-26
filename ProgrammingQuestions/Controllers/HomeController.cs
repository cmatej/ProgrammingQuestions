using ProgrammingQuestions.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProgrammingQuestions.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using Glimpse.AspNet.Tab;

namespace ProgrammingQuestions.Controllers
{
    [SessionCheck] // stavlja vrijednost GUID-a na cijeli kontroler, ne moram na svaku akciju posebno
    public class HomeController : Controller
    {
        //private readonly string _SessionGuid = Trace.CorrelationManager.ActivityId.ToString();

        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var model = _context.Questions
                .Include(a => a.SkillLevel)
                .Include(a => a.Country)
                .Include(a => a.Technologies)
                .ToList();

            var auth = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (auth)
                return View(model);
            else
            {
                model = model.Where(m => m.Approved == true).ToList();
            }

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var question = _context.Questions
                .Include(a => a.SkillLevel)
                .Include(a => a.Country)
                .Include(a => a.Technologies)
                .SingleOrDefault(a => a.Id == id);

            if (question == null)
                return HttpNotFound();

            var answers = _context.Answers
                .Where(a => a.QuestionId.Equals(id))
                .ToList();

            var viewModel = new QuestionAnswersViewModel
            {
                Question = question,
                Answers = answers
            };


            return View(viewModel);
        }

        public ActionResult New()
        {
            var country = _context.Countries.ToList();
            var technologies = _context.Technologies.ToList();
            var skillLevels = _context.SkillLevels.ToList();

            var viewModel = new QuestionViewModel
            {
                Countries = country,
                Technologies = technologies,
                SkillLevels = skillLevels
            };


            return View("ProblemForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Question question, string[] techIds)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new QuestionViewModel
                {
                    Countries = _context.Countries.ToList(),
                    SkillLevels = _context.SkillLevels.ToList()
                };
                return View("ProblemForm", viewModel);
            }


            if (question.Id == 0)
            {
                UpdatePostCategories(question, techIds);

                question.Approved = false;
                _context.Questions.Add(question);

            }
            else
            {
                var questionInDb = _context.Questions.Single(q => q.Id == question.Id);

                questionInDb.ShortDescription = question.ShortDescription;
                questionInDb.Description = question.Description;
                questionInDb.SkillLevelId = question.SkillLevelId;
                questionInDb.CountryId = question.CountryId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private void UpdatePostCategories(Question question, string[] techIds)
        {
            var selectedCategoriesHS = new HashSet<string>(techIds);
            var postCategories = new HashSet<int>(question.Technologies.Select(t => t.Id));

            foreach (var item in _context.Technologies)
            {
                if (selectedCategoriesHS.Contains(item.Id.ToString()))
                {
                    if (!postCategories.Contains(item.Id))
                    {
                        question.Technologies.Add(item);
                    }
                }
                else
                {
                    if (postCategories.Contains(item.Id))
                    {
                        question.Technologies.Remove(item);
                    }
                }
            }
        }

        public ActionResult About()
        {
            // testing purpose only

            //Session["test"] = _SessionGuid;
            int.Parse("test");

            //    int i = 30;
            //    int j = 0;
            //    int x = i / j;


            ViewBag.Message = "Your application description page.";

            return View();
            
        }

        [HttpPatch]
        public void AddNumber(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            //int brojac = 0;
            //brojac++;

            if (question.SimilarProblem == null || question.SimilarProblem == 0)
                question.SimilarProblem = 1;
            else
                question.SimilarProblem++;


            try
            {
                _context.SaveChanges();
            }
            catch
            {
            }

            string taskID = id.ToString();

            HttpCookie cookie = new HttpCookie("brojac" + id.ToString(), taskID);
            cookie.Expires = DateTime.Now.AddDays(90);

            Response.Cookies.Add(cookie);

        }

        [HttpPatch]
        public void Approve(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            question.Approved = true;
            
            _context.SaveChanges();

        }
    }
}