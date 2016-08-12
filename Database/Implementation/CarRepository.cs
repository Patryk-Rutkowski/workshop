using System;
using System.Collections.Generic;
using Data;

namespace Database
{
    public class CarRepository : ICarRepository
    {
        public DMLResult CreateCar(string make, string model, int yearbook, string engine, string vin)
        {
            return Repository.InsertObject("workshop_insert_car", new { make = make, model = model, yearbook = yearbook, engine = engine, vin = vin});
        }

        public List<Make> GetAvailableMakes()
        {
            return Repository.FillCollection<Make>("workshop_get_makes", new { });
        }

        public List<Car> GetByMakeModelYearbook(string make, string model, int yearbook)
        {
            return Repository.FillCollection<Car>("workshop_get_by_make_model_yearbook", new { make = make, model = model, yearbook = yearbook });
        }

        public Car GetByVin(string vin)
        {
            return Repository.FillObject<Car>("workshop_get_by_vin", new { vin = vin });
        }

        public List<CarModel> GetModelByMake(string make)
        {
            return Repository.FillCollection<CarModel>("workshop_get_model_by_make", new { make = make });
        }

        public DMLResult UpdateCar(string make, string model, int yearbook, string engine, string vin)
        {
            return Repository.InsertObject("workshop_update_car", new { make = make, model = model, yearbook = yearbook, engine = engine, vin = vin });
        }
    }
}
