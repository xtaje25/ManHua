using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ManHuaAdmin.Utility
{
    public class Tools
    {
        /// <summary>
        /// 字符串转换为Unicode
        /// </summary>
        public static string GetUnicode(string str)
        {
            if (str == "") return "";

            char[] charbuffers = str.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
    }
}