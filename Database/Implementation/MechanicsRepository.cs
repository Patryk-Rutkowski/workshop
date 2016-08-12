using System;
using System.Collections.Generic;
using Data;
using Database.Interface;

namespace Database.Implementation
{
    public class MechanicsRepository : IMechanicsRepository
    {
        public DMLResult CreateNewMechanic(string name, double salary)
        {
            return Repository.InsertObject("workshop_insert_mechanics", new { name = name, salary = salary });
        }

        public List<ComboBoxMechanic> GetIdNameMechanics()
        {
            return Repository.FillCollection<ComboBoxMechanic>("workshop_get_mechanics", new { });
        }

        public DMLResult UpdateMechanic(int id, string name, double salary)
        {
            return Repository.InsertObject("workshop_update_mechanic", new {id = id, name = name, salary = salary });
        }
    }
}
