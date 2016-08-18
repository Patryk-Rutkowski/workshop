using System;
using System.Collections.Generic;
using Data;
using Extensions;
using WorkshopServices.Interface;
using Database.Interface;

namespace WorkshopServices.Implementation
{
    public class MechanicsService : IMechanicsService
    {

        private readonly IMechanicsRepository _mechanicsRepository;

        public MechanicsService(IMechanicsRepository _mechanicsRepository)
        {
            this._mechanicsRepository = _mechanicsRepository;
        }

        public Result<DMLResult> CreateNewMechanic(string name, double salary)
        {
            DMLResult insertResult = _mechanicsRepository.CreateNewMechanic(name, salary);
            Result<DMLResult> result = new Result<DMLResult>(insertResult);
            result.InsertCheck();
            return result;
        }

        public Result<List<ComboBoxMechanic>> GetIdNameMechanics()
        {
            List<ComboBoxMechanic> mechanics = _mechanicsRepository.GetIdNameMechanics();
            Result<List<ComboBoxMechanic>> result = new Result<List<ComboBoxMechanic>>(mechanics);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<DMLResult> UpdateMechanic(int id, string name, double salary)
        {
            DMLResult insertResult = _mechanicsRepository.UpdateMechanic(id, name, salary);
            Result<DMLResult> result = new Result<DMLResult>(insertResult);
            result.InsertCheck();
            return result;
        }
    }
}
