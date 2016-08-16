using Database.Implementation;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Resolvers
{
    public static class IMechanicsServiceResolver
    {

        public static IMechanicsService Get()
        {
            var repository = new MechanicsRepository();

            return new MechanicsService(
                repository
                );
        }

    }
}
