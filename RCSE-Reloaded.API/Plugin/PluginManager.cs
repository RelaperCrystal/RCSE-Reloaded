﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCSE_Reloaded.API.Plugin
{
    internal static class PluginManager
    {
        public static List<IPlugin> plugins;

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
            int i = 0;
            foreach (string file in files)
            {
                string ext = file.Substring(file.LastIndexOf("."));
                if (ext != ".dll") continue;
                try
                {
                    Assembly tmp = Assembly.LoadFile(file);
                    Type[] types = tmp.GetTypes();
                    bool ok = false;
                    foreach (Type t in types)
                        if (IsPluginImplementedInterface(t))
                        {
                            IPlugin plugin = (IPlugin)tmp.CreateInstance(t.FullName);
                            plugins.Add(plugin);
                        }
                }
                catch (Exception err)
                {
                    
                }
            }
        }

    }
}
