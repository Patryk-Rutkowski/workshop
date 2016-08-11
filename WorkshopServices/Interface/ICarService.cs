using Extensions;
using Models;
using System;
using System.Collections.Generic;

namespace WorkshopServices
{
    public interface ICarService
    {

        Result<Car> GetByVin(String vin);
        Result<List<Car>> GetByModelMarkYearbook(string make, string model, int yerbook);

    }
}
