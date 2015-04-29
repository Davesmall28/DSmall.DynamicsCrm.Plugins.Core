namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System.Collections.Generic;
    using System.Linq;
    using DSmall.DynamicsCrm.Plugins.Core.IntegrationTest.Model;

    /// <summary>The enumerable extensions.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>The no parameters.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool NoParameters(this IEnumerable<ParameterDetail> source)
        {
            return !source.Any();
        }

        /// <summary>The one.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool One(this IEnumerable<ParameterDetail> source)
        {
            return source.Count() == 1;
        }

        /// <summary>The single.</summary>
        /// <typeparam name="T">The parameter type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool OneOf<T>(this IEnumerable<ParameterDetail> source, string parameterName)
        {
            return source.Count(detail => detail.Name.Equals(parameterName) && detail.Type.Equals(typeof(T).ToString())) == 1;
        }
    }
}