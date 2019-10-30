using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace RCSE_Reloaded
{
    public static class LogManager
    {
        public static Logger Log { get; } = new Logger();

        internal static ILog GetLogger(Type type)
        {
            return log4net.LogManager.GetLogger(type);
        }
    }
}
