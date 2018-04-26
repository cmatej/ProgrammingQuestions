using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingQuestions.Models;

namespace ProgrammingQuestions.ViewModels
{
    public class QuestionTechnologyViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Technology> Technologies { get; set; }
    }
}