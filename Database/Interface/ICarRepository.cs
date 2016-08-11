using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface ICarRepository
    {

        Car GetByVin(string vin);
        List<Car> GetByMakeModelYearbook(string make, string model, int yearbook);
        List<Make> GetAvailableMakes();
        List<CarModel> GetModelByMake(string make);

    }
}
