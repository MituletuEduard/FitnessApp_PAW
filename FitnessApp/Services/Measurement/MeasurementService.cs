using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;


    public interface IMeasurementService
    {
        Task AddMeasurementAsync(string userId, float weight);
        Task<List<Measurement>> GetMeasurementsAsync(string userId);
    }

    public class MeasurementService : IMeasurementService
    {
        private readonly ApplicationContext _context;

        public MeasurementService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddMeasurementAsync(string userId, float weight)
        {
            var measurement = new Measurement
            {
                UserId = userId,
                Weight = weight,
                Date = DateTime.Now
            };
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Measurement>> GetMeasurementsAsync(string userId)
        {
            return await _context.Measurements
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.Date)
                .ToListAsync();
        }
    }


