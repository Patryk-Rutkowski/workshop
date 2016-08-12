using System;
using Data;
using WorkshopServices.Interface;

namespace WorkshopServices.Implementation
{
    class ErrorService : IErrorService
    {
        public Result<DMLResult> Insert(string message, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
