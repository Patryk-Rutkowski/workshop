using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interface
{
    public interface IRepairRepository
    {

        List<DMLResult> CreateNewRepair(string vin, double price, int mileage, DateTime repairDate, int mechanicId, double partsPrice, int[] partsId);
        List<RepairTablePresentation> GetRepairHistoryByVin(string vin);

    }
}
