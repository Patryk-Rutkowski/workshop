using System;
using System.Collections.Generic;
using Data;
using Extensions;
using WorkshopServices.Interface;
using Database;

namespace WorkshopServices.Implementation
{
    public class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository _partRepository)
        {
            this._partRepository = _partRepository;
        }

        public Result<DMLResult> CreateNewPart(int category, string name)
        {
            DMLResult insertResult = _partRepository.CreateNewPart(category, name);
            Result<DMLResult> result = new Result<DMLResult>(insertResult);
            result.InsertCheck();
            return result;
        }

        public Result<List<ComboBoxPart>> GetPartsByCategory(int category)
        {
            List<ComboBoxPart> parts = _partRepository.GetPartsByCategory(category);
            Result<List<ComboBoxPart>> result = new Result<List<ComboBoxPart>>(parts);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<DMLResult> UpdatePart(int id, int category, string name)
        {
            throw new NotImplementedException();
        }
    }
}
