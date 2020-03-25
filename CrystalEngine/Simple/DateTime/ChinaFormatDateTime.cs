using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalEngine.Simple.DateTime
{
    public class ChinaFormatDateTime
    {
        /// <summary>
        /// 内置的 DateTime。
        /// </summary>
        public System.DateTime dateTime { get; private set; }
        public ChinaFormatDateTime(System.DateTime date)
        {
            dateTime = date;
        }

        public string GetChinaFormatDate(bool isShortDate)
        {
            if(isShortDate)
            {
                string result = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day;
                return result;
            }
            else
            {
                string result = dateTime.Year + "年" + dateTime.Month + "月" + dateTime.Day + "日";
                return result;
            }
        }

        public string GetChinaFormatDateTime(bool isShort)
        {
            if (isShort)
            {
                string result = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day + " " + dateTime.Hour + ":"
                    + dateTime.Minute + ":" + dateTime.Second;
                return result;
            }
            else
            {
                string result = dateTime.Year + "年" + dateTime.Month + "月" + dateTime.Day + "日" + dateTime.Hour + "时"
                    + dateTime.Minute + "分" + dateTime.Second + "秒";
                return result;
            }
        }

        public string GetChinaFormatDateTimeNoSecond(bool isShort)
        {
            if (isShort)
            {
                string result = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day + " " + dateTime.Hour + ":"
                    + dateTime.Minute;
                return result;
            }
            else
            {
                string result = dateTime.Year + "年" + dateTime.Month + "月" + dateTime.Day + "日" + dateTime.Hour + "时"
                    + dateTime.Minute + "分";
                return result;
            }
        }
    }
   }