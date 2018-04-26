using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public bool IsComplete { get; set; }

        public bool Verified { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}