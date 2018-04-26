using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.Models
{
    public class Question
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name="Short Description")]
        //[StringLength(100, MinimumLength = 10, ErrorMessage = "You must enter between {2} and {1} characters.")]
        public string ShortDescription { get; set; }

        //[Required] 
        [StringLength(4096)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public SkillLevel SkillLevel { get; set; }
        public int? SkillLevelId { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }

        public bool HasSolution { get; set; }

        public int? SimilarProblem { get; set; }

        public bool Approved { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        // every question has zero or more technologies
        public ICollection<Technology> Technologies { get; set; }

        public Question()
        {
            this.Technologies = new HashSet<Technology>();
        }
    }
}