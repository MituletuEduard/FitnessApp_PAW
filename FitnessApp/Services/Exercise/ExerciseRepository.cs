using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationContext _context;

    public ExerciseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(string userId)
    {
        return await _context.Exercises.Where(e => e.UserId == userId).ToListAsync();
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task AddExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExerciseAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
