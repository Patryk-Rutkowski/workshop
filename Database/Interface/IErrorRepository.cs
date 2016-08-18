using Data;
using System;

namespace Database.Interface
{
    public interface IErrorRepository
    {

        DMLResult Insert(string message, DateTime date);

    }
}
