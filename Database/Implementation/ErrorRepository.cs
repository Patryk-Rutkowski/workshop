using Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Database.Implementation
{
    class ErrorRepository : IErrorRepository
    {
        public DMLResult Insert(string message, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
