using Data;
using Extensions;
using System.Collections.Generic;

namespace WorkshopServices.Interface
{
    public interface IMechanicsService
    {

        Result<DMLResult> CreateNewMechanic(string name, double salary);
        Result<List<ComboBoxMechanic>> GetIdNameMechanics();
        Result<DMLResult> UpdateMechanic(int id, string name, double salary);
    }
}
