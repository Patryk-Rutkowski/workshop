using Database;
using WorkshopServices;
using WorkshopServices.Implementation;

namespace Resolvers
{
    public static class ICarServiceResolver
    {

        public static ICarService Get()
        {
            var repository = new CarRepository();

            return new CarService(
                repository
                );
        }

    }
}
