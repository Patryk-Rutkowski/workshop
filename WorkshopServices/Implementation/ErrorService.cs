using System;
using Data;
using WorkshopServices.Interface;
using Database.Interface;
using NLog;

namespace WorkshopServices.Implementation
{
    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;

        public ErrorService(IErrorRepository _errorRepository)
        {
            this._errorRepository = _errorRepository;
        }

        public Result<DMLResult> Insert(string message, DateTime date)
        {
            DMLResult insert = _errorRepository.Insert(message, date);
            Result<DMLResult> result = new Result<DMLResult>(insert);
            result.InsertCheck();
            return result;
        }
    }
}
