using Microsoft.EntityFrameworkCore;
using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Linq;

namespace SmartSchool.Persistence
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ApplicationDbContext _dbContext;

        public MeasurementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(Measurement[] measurements)
        {
            _dbContext.Measurements.AddRange(measurements);
        }

        public int GetCountOfMeasurementsForSensor(string location, string name)
        {
            return _dbContext
                .Sensors
                .Include(sensor => sensor.Measurements)
                .First(sensor =>
                    sensor.Location == location
                    && sensor.Name == name)
                .Measurements.Count;
        }
    }
}