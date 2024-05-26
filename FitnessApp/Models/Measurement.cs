using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public float Weight { get; set; }
        public DateTime Date { get; set; }
    }

}
