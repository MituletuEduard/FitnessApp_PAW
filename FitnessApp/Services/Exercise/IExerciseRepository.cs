using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllExercisesAsync(string userId);
    Task<Exercise> GetExerciseByIdAsync(int id);
    Task AddExerciseAsync(Exercise exercise);
    Task UpdateExerciseAsync(Exercise exercise);
    Task DeleteExerciseAsync(int id);
}
