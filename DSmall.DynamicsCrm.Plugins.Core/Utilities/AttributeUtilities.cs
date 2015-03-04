namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>The attribute utilities.</summary>
    public class AttributeUtilities : IAttributeUtilities
    {
        /// <summary>The get attribute for.</summary>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="TAttribute">Type of Attribute to retrieve.</typeparam>
        /// <typeparam name="TTargetType">Type of object to target.</typeparam>
        /// <returns>The <see cref="TAttribute"/>.</returns>
        public TAttribute GetAttributeFor<TAttribute, TTargetType>(Expression<Func<TTargetType, object>> expression)
            where TAttribute : Attribute
        {
            var memberExpression = GetPropertyOrMethodExpression(expression);

            if (memberExpression == null)
            {
                throw new ArgumentException("Unsupported expression type. Expression must be resolvable against a member or property.");
            }

            return GetAttributeAgainstMemberExpression<TAttribute, TTargetType>(memberExpression.Member.Name);
        }

        private static TAttribute GetAttributeAgainstMemberExpression<TAttribute, TTargetType>(string memberOrPropertyName)
            where TAttribute : Attribute
        {
            var memberInfo = typeof(TTargetType).GetMember(memberOrPropertyName).FirstOrDefault();

            if (memberInfo == null)
            {
                return null;
            }

            return memberInfo.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault() as TAttribute;
        }

        private static MemberExpression GetPropertyOrMethodExpression<TTargetType>(Expression<Func<TTargetType, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body != null)
            {
                return body;
            }

            var ubody = (UnaryExpression)expression.Body;
            return ubody.Operand as MemberExpression;
        }
    }
}