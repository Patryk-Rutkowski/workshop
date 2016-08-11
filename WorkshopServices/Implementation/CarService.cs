using System.Collections.Generic;
using Models;
using Database;
using Extensions;

namespace WorkshopServices.Implementation
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository _carRepository)
        {
            this._carRepository = _carRepository;
        }

        Result<List<Car>> ICarService.GetByModelMarkYearbook(string make, string model, int yerbook)
        {
            List<Car> carList = _carRepository.GetByMakeModelYearbook(make, model, yerbook);
            Result<List<Car>> result = new Result<List<Car>>(carList);
            result.ErrorIfDataNull();
            return result;
        }

        Result<Car> ICarService.GetByVin(string vin)
        {
            Car car = _carRepository.GetByVin(vin);
            Result<Car> result = new Result<Car>(car);
            result.ErrorIfDataNull();
            return result;
        }
    }
}
