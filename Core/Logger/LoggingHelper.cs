using System;
using log4net;

namespace Core.Logger
{
	public static class LoggingHelper
	{
		static LoggingHelper()
		{
			log4net.Config.XmlConfigurator.Configure();
		}

		private static readonly ILog Log = LogManager.GetLogger(typeof(LoggingHelper));

		public static void LogInformation(string message)
		{
			Log.Info(message);
		}

		public static void LogDebug(string message)
		{
			Log.Debug(message);
		}

		public static void LogError(string message, Exception exception = null)
		{
			message = "[ERROR]: " + message;

			if (exception != null) Log.Error(message, exception);
			else Log.Error(message);
		}
	}
}
