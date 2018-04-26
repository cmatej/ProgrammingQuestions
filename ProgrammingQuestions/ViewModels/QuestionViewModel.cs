using ProgrammingQuestions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.ViewModels
{
    public class QuestionViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You must enter between {2} and {1} characters.")]
        public string ShortDescription { get; set; }

        [Required] 
        [StringLength(4096)]
        public string Description { get; set; }

        public IEnumerable<SkillLevel> SkillLevels { get; set; }
        [Display(Name="Skill Level")]
        public int? SkillLevelId { get; set; }

        public IEnumerable<Country> Countries { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public bool? HasSolution { get; set; }

        public int? SimilarProblem { get; set; }

        // every question has zero or more technologies
        public ICollection<Technology> Technologies { get; set; }

        public QuestionViewModel()
        {
            Id = 0;
        }

        public QuestionViewModel(Question question)
        {
            Id = question.Id;
            ShortDescription = question.ShortDescription;
            Description = question.Description;
            SkillLevelId = question.SkillLevelId;
            CountryId = question.CountryId;
            Technologies = new List<Technology>();
        }
    }
}