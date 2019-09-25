using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API.Interfaces
{
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称。
        /// </summary>
        string PluginName { get; }

        /// <summary>
        /// 当插件开始时调用的参数。
        /// </summary>
        void Load();
        /// <summary>
        /// 当插件结束运行时调用的参数。
        /// </summary>
        void Ending();
    }
}
