﻿using Microsoft.Extensions.Logging;

namespace MetricsSample
{
   internal class LoggingEvents
   {
      public static EventId Injection { get; } = new(2000, nameof(Injection));

      public static EventId Networking { get; } = new(2002, nameof(Networking));
   }
}