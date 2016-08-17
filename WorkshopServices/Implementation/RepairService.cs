using System;
using System.Collections.Generic;
using Data;
using Extensions;
using WorkshopServices.Interface;
using Database.Interface;

namespace WorkshopServices.Implementation
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;

        public RepairService(IRepairRepository _repairRepository)
        {
            this._repairRepository = _repairRepository;
        }

        public Result<List<DMLResult>> CreateNewRepair(string vin, double price, int mileage, DateTime repairDate, int mechanicId, double partsPrice, int[] partsId)
        {
            List<DMLResult> insertResult = _repairRepository.CreateNewRepair(vin, price, mileage, repairDate, mechanicId, partsPrice, partsId);
            Result<List<DMLResult>> result = new Result<List<DMLResult>>(insertResult);
            //result.InsertCheck();
            return result;
        }

        public Result<List<RepairTablePresentation>> GetRepairHistoryByVin(string vin)
        {
            List<RepairTablePresentation> repairs = _repairRepository.GetRepairHistoryByVin(vin);
            Result<List<RepairTablePresentation>> result = new Result<List<RepairTablePresentation>>(repairs);
            result.ErrorIfDataNull();
            return result;
        }
    }
}
