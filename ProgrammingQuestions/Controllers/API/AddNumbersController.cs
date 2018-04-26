using ProgrammingQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Controllers
{
    public class AddNumbersController : ApiController
    {
        private ApplicationDbContext _context;

        public AddNumbersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPatch]
        public void AddNumber(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);

            int brojac = 0;
            brojac++;

            if (question.SimilarProblem == null || question.SimilarProblem == 0)
                question.SimilarProblem = brojac;
            else
                question.SimilarProblem = question.SimilarProblem + 1;


            try
            {
                _context.SaveChanges();
            }
            catch
            {
            }

            string taskID = id.ToString();

            HttpCookie cookie = new HttpCookie("brojac" + id.ToString(), taskID);
            cookie.Expires = DateTime.Now.AddDays(30);

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

    }
}
