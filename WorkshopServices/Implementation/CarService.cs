using System.Collections.Generic;
using Data;
using Database;
using Extensions;
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

        public Result<List<Make>> GetAvailableMakes()
        {
            List<Make> makes = _carRepository.GetAvailableMakes();
            Result<List<Make>> result = new Result<List<Make>>(makes);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<List<CarModel>> GetModelByMake(string make)
        {
            List<CarModel> models = _carRepository.GetModelByMake(make);
            Result<List<CarModel>> result = new Result<List<CarModel>>(models);
            result.ErrorIfDataNull();
            return result;
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
