using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class BmrController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateBmr(double weight, double height, int age, string gender)
        {
            double bmr;

            if (gender.ToLower() == "male")
            {
                bmr = 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
            }
            else
            {
                bmr = 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);
            }

            ViewBag.Bmr = bmr;
            return View("Index");
        }
    }
}
