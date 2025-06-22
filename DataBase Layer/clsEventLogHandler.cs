using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsEventLogHandler
    {
        public static void ExeptionsEventLog(string Message, EventLogEntryType Type, string Source = "Ammar Dahab")
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            EventLog.WriteEntry(Source, Message, Type);
        }
    }
}
