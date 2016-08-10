using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopServices
{
    public interface ICarService
    {

        Car GetByVin(String vin);
        List<Car> GetByModelMarkYearbook(string model, string mark, int yerbook);

    }
}
