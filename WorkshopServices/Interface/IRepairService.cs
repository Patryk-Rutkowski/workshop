using Data;
using Extensions;
using System;
using System.Collections.Generic;

namespace WorkshopServices.Interface
{
    public interface IRepairService
    {

        Result<DMLResult> CreateNewRepair(string vin, double price, int mileage, DateTime repairDate, int mechanicId, double partsPrice, int[] partsId);
        Result<List<RepairTablePresentation>> GetRepairHistoryByVin(string vin);

    }
}
