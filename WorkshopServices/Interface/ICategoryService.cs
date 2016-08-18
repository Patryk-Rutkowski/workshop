using Data;
using Extensions;
using System.Collections.Generic;

namespace WorkshopServices
{
    public interface ICategoryService
    {

        Result<DMLResult> CreateNewCategory(string name);
        Result<List<Category>> GetAllCategories();
        Result<DMLResult> UpdateCategory(int id, string name);

    }
}
