using System.ComponentModel.DataAnnotations;

namespace GameReview.ViewModels
{
    public class AddTypeViewModel
    {
        [Required]
        [Display(Name = "Game Type")]
        public string Name { get; set; }
    }
}
