using SmartSchool.Core.Entities;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);
        int GetCountOfMeasurementsForSensor(string location, string name);
    }
}
