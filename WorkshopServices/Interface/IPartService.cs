using Data;
using Extensions;
using System.Collections.Generic;

namespace WorkshopServices.Interface
{
    public interface IPartService
    {

        Result<DMLResult> CreateNewPart(int category, string name);
        Result<List<ComboBoxPart>> GetPartsByCategory(int category);
        Result<DMLResult> UpdatePart(int id, int category, string name);

    }
}
