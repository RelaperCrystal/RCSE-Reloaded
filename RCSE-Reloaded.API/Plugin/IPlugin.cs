using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.API.Plugin
{
    /// <summary>
    /// API Plugin 实现。
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称。
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 插件的描述。
        /// </summary>
        string Description { get; }
        /// <summary>
        /// 插件使用的全部窗口。
        /// </summary>
        List<Form> Forms { get; set; }
        /// <summary>
        /// 初始化 RCSE 完成后调用。
        /// </summary>
        void Initialize();
        /// <summary>
        /// RCSE 主窗口关闭后调用。
        /// </summary>
        void Ending();
        /// <summary>
        /// 此插件需要的插件。
        /// </summary>
        List<string> References { get; }
        /// <summary>
        /// 插件版本。
        /// </summary>
        Version Version { get; }
    }
}
