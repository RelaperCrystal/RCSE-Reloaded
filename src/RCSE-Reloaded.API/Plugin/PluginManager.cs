using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RCSE_Reloaded.API.Plugin
{
    internal static class PluginManager
    {
        public static List<IPlugin> Plugins;

        private static bool IsPluginImplementedInterface(Type t)
        {
            bool result = false;
            Type[] interfaces = t.GetInterfaces();
            foreach (Type theInterface in interfaces)
            {
                if (theInterface.FullName == "RCSE_Reloaded.API.Plugin.IPlugin")
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取并执行所有插件。
        /// </summary>
        public static void LoadAllPlugins()
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\plugin\\");
            foreach (string file in files)
            {
                string ext = file.Substring(file.LastIndexOf(".", StringComparison.Ordinal));
                if (ext != ".dll") continue;
                try
                {
                    Assembly tmp = Assembly.LoadFile(file);
                    Type[] types = tmp.GetTypes();
                    foreach (Type t in types)
                        if (IsPluginImplementedInterface(t))
                        {
                            IPlugin plugin = (IPlugin)tmp.CreateInstance(t.FullName);
                            Plugins.Add(plugin);
                        }
                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
