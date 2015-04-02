namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DSmall.DynamicsCrm.Plugins.Core.IntegrationTest.Model;

    /// <summary>The enumerable extensions.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>The count.</summary>
        /// <param name="source">The source.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="parameterType">The parameter type.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int Count(this IEnumerable<ParameterDetail> source, string parameterName, Type parameterType)
        {
            return source.Count(detail => detail.Name.Equals(parameterName) && detail.Type.Equals(parameterType.ToString()));
        }
    }
}
