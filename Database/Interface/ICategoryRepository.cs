using Data;
using System.Collections.Generic;
namespace Database
{
    public interface ICategoryRepository
    {

        DMLResult CreateNewCategory(string name);
        List<Category> GetAllCategories();
        DMLResult UpdateCategory(int id, string name);

    }
}
