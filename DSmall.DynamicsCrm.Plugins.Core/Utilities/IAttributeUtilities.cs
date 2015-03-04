namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using System.Linq.Expressions;

    /// <summary>The attribute utilities interface.</summary>
    public interface IAttributeUtilities
    {
        /// <summary>The get attribute for.</summary>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="TAttribute">Type of Attribute to retrieve.</typeparam>
        /// <typeparam name="TTargetType">Type of object to target.</typeparam>
        /// <returns>The <see cref="TAttribute"/>.</returns>
        TAttribute GetAttributeFor<TAttribute, TTargetType>(Expression<Func<TTargetType, object>> expression)
            where TAttribute : Attribute;
    }
}