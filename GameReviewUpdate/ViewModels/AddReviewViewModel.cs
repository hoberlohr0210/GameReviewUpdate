using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.ViewModels
{
    public class AddReviewViewModel
    {
        [Required]
        [Display(Name = "Name of Game")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Review")]
        public string Review { get; set; }

        [Required]
        [Display(Name = "Rating 1-5")]
        public int Rating { get; set; }
    }
}
