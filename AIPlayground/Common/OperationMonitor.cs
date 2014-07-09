using System;


namespace Common
{
    public class OperationMonitor : IDisposable
    {
        private Object sender;
        private String operationName;
        private System.Diagnostics.Stopwatch stopwatch;
        private Action<string> callback;
        public OperationMonitor(Object sender, String operationName, Action<string> callback, params object[] subjects)
        {
            this.callback = callback;
            this.sender = sender;
            this.operationName = operationName;
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            // (sender, Severity.Monitor, "{0} : Start", OperationName + "[" + string.Join(",", subjects) + "]");
        }

        public void Dispose()
        {
            stopwatch.Stop();
            callback.Invoke(string.Format("{0} {1} : {2:00.000}ms" ,sender, operationName ,  stopwatch.Elapsed.TotalMilliseconds));
            //Log.Write(sender, Severity.Monitor, "{0} : End {1:00.000}ms", OperationName, Stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
