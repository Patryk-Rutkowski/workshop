using Extensions;
using Data;
using System;
using System.Collections.Generic;

namespace WorkshopServices
{
    public interface ICarService
    {

        Result<Car> GetByVin(String vin);
        Result<List<Car>> GetByModelMarkYearbook(string make, string model, int yerbook);
        Result<List<Make>> GetAvailableMakes();
        Result<List<CarModel>> GetModelByMake(string make);
        Result<DMLResult> CreateNewCar(string make, string model, int yearbook, string engine, string vin);
        Result<DMLResult> UpdateCar(string make, string model, int yearbook, string engine, string vin);
    }
}
