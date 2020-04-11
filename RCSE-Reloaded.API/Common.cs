using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API
{
    public static class Common
    {
        public delegate string VersionAcquire();
        public delegate string LegacyVersionAcquire();
        public delegate bool SnapshotAcquire();

        public static event VersionAcquire VersionNeeded;
        public static event VersionAcquire SnapshotNumberNeeded;
        public static event LegacyVersionAcquire LegacyFormVersionNeeded;
        public static event SnapshotAcquire IsSnapshotNeeded;

        public static string Version => VersionNeeded();
        public static string LegacyFormVersion => LegacyFormVersionNeeded();
        public static bool IsSnapshot => IsSnapshotNeeded();
        public static string SnapshotNumber => SnapshotNumberNeeded();
    }
}
