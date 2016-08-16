using Database;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Resolvers
{
    public static class IPartServiceResolver
    {

        public static IPartService Get()
        {
            var repository = new PartRepository();

            return new PartService(
                repository
                );
        }

    }
}
