using System.Collections.Generic;
using Models;
using Database;
using System;

namespace WorkshopServices.Implementation
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository _carRepository)
        {
            this._carRepository = _carRepository;
        }

        public List<Car> GetByModelMarkYearbook(string make, string model, int yerbook)
        {
            return _carRepository.GetByMakeModelYearbook(make, model, yerbook);
        }

        public Car GetByVin(string vin)
        {
            var result = _carRepository.GetByVin(vin);
            return _carRepository.GetByVin(vin);
        }
    }
}
