using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {

        [Key]
        public int DishId { get; set; }

        [Required]
        [Display(Name = "Dish Name:")]
        public string DishName { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "# of Calories:")]
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Tastiness:")]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ChefId { get; set; }
        public Chef Creator { get; set; }

    }
}