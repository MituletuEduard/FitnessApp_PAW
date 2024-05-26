using FitnessApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Authorize]
public class HistoryController : Controller
{
    private readonly IExerciseRepository _repository;
    private readonly UserManager<IdentityUser> _userManager;

    public HistoryController(IExerciseRepository repository, UserManager<IdentityUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var exercises = await _repository.GetAllExercisesAsync(user.Id);
        return View(exercises);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var exercise = await _repository.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return View(exercise);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Exercise exercise)
    {
        if (ModelState.IsValid)
        {
            await _repository.UpdateExerciseAsync(exercise);
            return RedirectToAction(nameof(Index));
        }
        return View(exercise);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var exercise = await _repository.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return View(exercise);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repository.DeleteExerciseAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
