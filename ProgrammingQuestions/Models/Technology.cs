using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.Models
{
    public class Technology
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // every technology is used in zero or more questions
        public ICollection<Question> Questions { get; set; }
    }
}