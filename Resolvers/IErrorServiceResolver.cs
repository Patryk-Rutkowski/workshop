using Database.Implementation;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Resolvers
{
    public static class IErrorServiceResolver
    {

        public static IErrorService Get()
        {
            var repository = new ErrorRepository();

            return new ErrorService(
                repository
                );
        }

    }
}
