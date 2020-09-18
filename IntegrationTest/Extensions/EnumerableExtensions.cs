namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System.Collections.Generic;
    using System.Linq;
    using Springboard365.Xrm.Plugins.Core.Model;

    public static class EnumerableExtensions
    {
        public static bool NoParameters(this IEnumerable<ParameterDetail> source)
        {
            return !source.Any();
        }

        public static bool One(this IEnumerable<ParameterDetail> source)
        {
            return source.Count() == 1;
        }

        public static bool OneOf<T>(this IEnumerable<ParameterDetail> source, string parameterName)
        {
            return source.Count(detail => detail.Name.Equals(parameterName) && detail.Type.Equals(typeof(T).ToString())) == 1;
        }
    }
}