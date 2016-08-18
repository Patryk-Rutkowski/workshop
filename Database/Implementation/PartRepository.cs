using System;
using System.Collections.Generic;
using Data;

namespace Database
{
    public class PartRepository : IPartRepository
    {
        public DMLResult CreateNewPart(int category, string name)
        {
            return Repository.InsertObject("workshop_insert_part", new { category_id=category, name = name });
        }

        public List<ComboBoxPart> GetPartsByCategory(int category)
        {
            return Repository.FillCollection<ComboBoxPart>("workshop_get_parts_by_category", new { category_id = category});
        }

        public DMLResult UpdatePart(int id, int category, string name)
        {
            throw new NotImplementedException();
        }
    }
}
