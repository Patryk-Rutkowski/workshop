using Data;
using System.Collections.Generic;

namespace Database.Interface
{
    public interface IMechanicsRepository
    {

        DMLResult CreateNewMechanic(string name, double salary);
        List<ComboBoxMechanic> GetIdNameMechanics();
        DMLResult UpdateMechanic(int id, string name, double salary);
    }
}
