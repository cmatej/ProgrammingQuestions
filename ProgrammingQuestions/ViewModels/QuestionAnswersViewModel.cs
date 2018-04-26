using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingQuestions.Models;

namespace ProgrammingQuestions.ViewModels
{
    public class QuestionAnswersViewModel
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}