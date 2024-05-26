
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Authorize]
    public class MeasurementsController : Controller
    {
        private readonly IMeasurementService _measurementService;
        private readonly UserManager<IdentityUser> _userManager;

        public MeasurementsController(IMeasurementService measurementService, UserManager<IdentityUser> userManager)
        {
            _measurementService = measurementService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement(float weight)
        {
            var userId = _userManager.GetUserId(User);
            await _measurementService.AddMeasurementAsync(userId, weight);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var measurements = await _measurementService.GetMeasurementsAsync(userId);
            return View(measurements);
        }
    }

}
