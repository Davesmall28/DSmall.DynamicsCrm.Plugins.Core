namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The input parameter extensions.</summary>
    public static class InputParameterExtensions
    {
        /// <summary>The get parameter.</summary>
        /// <param name="inputParameter">The input parameter.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <typeparam name="TParameterType">The parameter type.</typeparam>
        /// <returns>The <see cref="TParameterType"/>The input parameter.</returns>
        public static TParameterType GetParameter<TParameterType>(this DataCollection<string, object> inputParameter, string parameterName)
        {
            if (inputParameter.Contains(parameterName) && inputParameter[parameterName] is TParameterType)
            {
                return (TParameterType)inputParameter[parameterName];
            }

            return default(TParameterType);
        }
    }
}
