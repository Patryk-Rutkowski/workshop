using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IPartRepository
    {

        DMLResult CreateNewPart(int category, string name);
        List<ComboBoxPart> GetPartsByCategory(int category);
        DMLResult UpdatePart(int id, int category, string name);

    }
}
