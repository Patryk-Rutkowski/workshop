﻿using System.Collections.Generic;
using Data;
using Database;

namespace WorkshopServices.Implementation
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository _carRepository)
        {
            this._carRepository = _carRepository;
        }

        public Result<DMLResult> CreateNewCar(string make, string model, int yearbook, string engine, string vin)
        {
            DMLResult insert = new DMLResult();
            insert = _carRepository.CreateCar(make, model, yearbook, engine, vin);
            Result<DMLResult> result = new Result<DMLResult>(insert);
            result.InsertCheck();
            return result;
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

        public Result<List<Car>> GetByModelMarkYearbook(string make, string model, int yerbook)
        {
            List<Car> carList = _carRepository.GetByMakeModelYearbook(make, model, yerbook);
            Result<List<Car>> result = new Result<List<Car>>(carList);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<Car> GetByVin(string vin)
        {
            Car car = _carRepository.GetByVin(vin);
            Result<Car> result = new Result<Car>(car);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<DMLResult> UpdateCar(string make, string model, int yearbook, string engine, string vin)
        {
            DMLResult insert  = _carRepository.UpdateCar(make, model, yearbook, engine, vin);
            Result<DMLResult> result = new Result<DMLResult>(insert);
            result.InsertCheck();
            return result;
        }
    }
}
