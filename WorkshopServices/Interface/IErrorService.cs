using Data;
using System;

namespace WorkshopServices.Interface
{
    public interface IErrorService
    {

        Result<DMLResult> Insert(string message, DateTime date);

    }
}
