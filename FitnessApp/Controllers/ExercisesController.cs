using FitnessApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Authorize]
public class ExercisesController : Controller
{
    private readonly IExerciseRepository _repository;
    private readonly UserManager<IdentityUser> _userManager;

    public ExercisesController(IExerciseRepository repository, UserManager<IdentityUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddExercise(string name, string description, int reps, double weight)
    {
        var user = await _userManager.GetUserAsync(User);
        var exercise = new Exercise
        {
            Name = name,
            Description = description,
            Date = DateTime.Now,
            Reps = reps,
            Weight = weight,
            UserId = user.Id
        };

        await _repository.AddExerciseAsync(exercise);
        return RedirectToAction("Index", "History");
    }
}
