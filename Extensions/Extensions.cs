using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Extensions
{
    public static class Extensions
    {
        public static Logger logger;

        public static bool HasValue<T>(this IEnumerable<T> enumerable)
        {
            return (enumerable != null && enumerable.AsEnumerable().Any());
        }

    }
}
