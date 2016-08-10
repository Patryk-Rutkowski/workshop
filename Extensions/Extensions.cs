using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class Extensions
    {
        public static bool HasValue<T>(this IEnumerable<T> enumerable)
        {
            return (enumerable != null && enumerable.AsEnumerable().Any());
        }
    }
}
