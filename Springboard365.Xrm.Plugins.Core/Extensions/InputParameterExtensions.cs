namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public static class InputParameterExtensions
    {
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