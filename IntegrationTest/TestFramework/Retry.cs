namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public static class Retry
    {
        public static T Do<T>(Func<T> action, int retryInterval = 10, int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (var retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Thread.Sleep(retryInterval * 1000);
                }
            }

            throw new AggregateException(exceptions);
        }
    }
}