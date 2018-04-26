using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.Models
{
    public class SkillLevel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Skill Level")]
        [StringLength(50, ErrorMessage="Maximum number of characters is {1}.")]
        public string Name { get; set; }
    }
}