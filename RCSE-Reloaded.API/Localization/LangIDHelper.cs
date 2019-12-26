using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE_Reloaded.API.Localization
{
    /// <summary>
    /// 控制语言代码的识别。
    /// </summary>
    public static class LangIDHelper
    {
        public static Language GetLanguage()
        {
            string langId = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            switch(langId)
            {
                case "zh-CN":
                    return Language.SimpChinese;
                case "en-US":
                    return Language.English;
                case "Zh-TW":
                case "zh-TW":
                    return Language.TradChinese;
                case "ja-JP":
                    return Language.Japanese;
                default:
                    return Language.SimpChinese;
            }
        }

        public static Language GetLanguage(string langId)
        {
            switch (langId)
            {
                case "zh-CN":
                    return Language.SimpChinese;
                case "en-US":
                    return Language.English;
                case "Zh-TW":
                case "zh-TW":
                    return Language.TradChinese;
                case "ja-JP":
                    return Language.Japanese;
                default:
                    return Language.SimpChinese;
            }
        }
    }

    public enum Language
    {
        SimpChinese,
        TradChinese,
        English,
        Japanese
    }
}
