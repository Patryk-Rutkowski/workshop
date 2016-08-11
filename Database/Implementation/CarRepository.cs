using System;
using System.Collections.Generic;
using Models;

namespace Database
{
    public class CarRepository : ICarRepository
    {
        public List<Car> GetByMakeModelYearbook(string make, string model, int yearbook)
        {
            return Repository.FillCollection<Car>("workshop_get_by_make_model_yearbook", new { make = make, model = model, yearbook = yearbook });
        }

        public Car GetByVin(string vin)
        {
            return Repository.FillObject<Car>("workshop_get_by_vin", new { vin = vin });
        }
    }
}
