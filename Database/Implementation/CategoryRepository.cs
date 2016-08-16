using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Database
{
    public class CategoryRepository : ICategoryRepository
    {
        public DMLResult CreateNewCategory(string name)
        {
            return Repository.InsertObject("workshop_insert_category", new { name = name });
        }

        public List<Category> GetAllCategories()
        {
            return Repository.FillCollection<Category>("workshop_get_categories", new { });
        }

        public DMLResult UpdateCategory(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
