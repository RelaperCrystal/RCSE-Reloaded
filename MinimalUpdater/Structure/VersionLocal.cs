using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalUpdater.Structure
{
    public struct VersionLocal
    {
        public string name { get; set; }
        public string stage { get; set; }
        public string release { get; set; }
    }

    public struct VersionOnline
    {
        public string name { get; set; }
        public string stage { get; set; }
        public string release { get; set; }
        public string link { get; set; }
    }
}
