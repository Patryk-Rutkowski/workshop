using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class DMLResult
    {

        public int Count { get; set; }

        public bool Success { get { return Count > 0; } }

    }
}
