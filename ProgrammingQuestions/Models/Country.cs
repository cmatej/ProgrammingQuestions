using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingQuestions.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string SortName { get; set; }

        [Required]
        [Display(Name="Country")]
        [StringLength(150)]
        public string Name { get; set; }

        public int Phonecode { get; set; }
    }
}