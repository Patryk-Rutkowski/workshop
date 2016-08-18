using Database.Implementation;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Resolvers
{
    public static class IRepairServiceResolver
    {

        public static IRepairService Get()
        {
            var repository = new RepairRepository();

            return new RepairService(
                    repository
                );
        }

    }
}
