using Database;
using WorkshopServices;

namespace Resolvers
{
    public static class ICategoryServiceResolver
    {

        public static ICategoryService Get()
        {
            var repository = new CategoryRepository();

            return new CategoryService(
                repository
                );
        }

    }
}
