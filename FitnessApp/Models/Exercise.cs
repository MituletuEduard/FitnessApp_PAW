using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
