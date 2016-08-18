using System;
using System.Collections.Generic;
using Data;
using Database.Interface;

namespace Database.Implementation
{
    public class RepairRepository : IRepairRepository
    {
        public List<DMLResult> CreateNewRepair(string vin, double price, int mileage, DateTime repairDate, int mechanicId, double partsPrice, int[] partsId)
        {
            List<DMLResult> results = new List<DMLResult>();
            results.Add(Repository.InsertObject("workshop_insert_repair", new { vin = vin, price = price, mileage = mileage, repair_date = repairDate, mechanic_id = mechanicId, parts_price = partsPrice }));

            if (results[0].Success)
            {
                int repairdId = results[0].Count;

                foreach (int part in partsId)
                    results.Add(Repository.InsertObject("workshop_what_parts_repaired", new { repair_id = repairdId, part_id = part }));
            }
            return results;
        }

        public List<RepairTablePresentation> GetRepairHistoryByVin(string vin)
        {
            return Repository.FillCollection<RepairTablePresentation>("workshop_get_repair_historyby_vin", new { vin = vin});
        }
    }
}
