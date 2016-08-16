using Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Database.Implementation
{
    public class ErrorRepository : IErrorRepository
    {
        public DMLResult Insert(string message, DateTime date)
        {
            return Repository.FillObject<DMLResult>("workshop_insert_error", new { error_time = date, error_msg = message });
        }
    }
}
