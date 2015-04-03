namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>The retry.</summary>
    public static class Retry
    {
        /// <summary>The do.</summary>
        /// <param name="action">The action to retry.</param>
        /// <param name="retryInterval">The retry interval in seconds.</param>
        /// <param name="retryCount">The number of retries to execute.</param>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public static T Do<T>(Func<T> action, int retryInterval = 10, int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int retry = 0; retry < retryCount; retry++)
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
