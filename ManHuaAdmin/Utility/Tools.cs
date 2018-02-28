using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ManHuaAdmin.Utility
{
    public class Tools
    {
        #region unicode
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
        #endregion

        #region DateTime时间戳互转
        public static string DateTimeToTimeStamp(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (dt - dtStart).TotalMilliseconds.ToString();
        }

        public static DateTime TimeStampToDateTime(String TimeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(TimeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        #endregion

        #region MD5
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        public static string MD5Encrypt32(string password)
        {
            string cl = password + "manhua";
            string pwd = "";
            MD5 md5 = MD5.Create(); // 实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("x2");
            }
            return pwd;
        }

        /// <summary>
        /// 64位MD5加密
        /// </summary>
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            //string pwd = "";
            MD5 md5 = MD5.Create(); // 实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        #endregion

        #region 请求
        public static string GetWebRequest(string url, Encoding encoding, out string msg)
        {
            string result = "";
            msg = "";
            Stream receiveStream = null;
            WebResponse hwrs = null;
            StreamWriter streamWriter = null;
            try
            {
                HttpWebRequest hwrq = WebRequest.Create(url) as HttpWebRequest;
                hwrq.Method = "GET";

                hwrs = hwrq.GetResponse();
                receiveStream = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(receiveStream, encoding);
                result = sr.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (receiveStream != null)
                    receiveStream.Close();

                if (hwrs != null)
                    hwrs.Close();

                if (streamWriter != null)
                    streamWriter.Close();
            }
            return "";
        }

        public static string PostWebRequest(string url, string data, Encoding encoding, out string msg)
        {
            string result = "";
            msg = "";
            Stream receiveStream = null;
            WebResponse hwrs = null;
            StreamWriter streamWriter = null;
            HttpWebRequest hwrq = null;
            try
            {
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((a, b, c, d) => true);
                    hwrq = WebRequest.Create(url) as HttpWebRequest;
                    hwrq.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    hwrq = WebRequest.Create(url) as HttpWebRequest;
                }

                hwrq.ContentType = "application/x-www-form-urlencoded";
                hwrq.Method = "POST";

                byte[] bytes = encoding.GetBytes(data);
                Stream stream = hwrq.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                hwrs = hwrq.GetResponse();
                receiveStream = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(receiveStream, encoding);
                result = sr.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (receiveStream != null)
                    receiveStream.Close();

                if (hwrs != null)
                    hwrs.Close();

                if (streamWriter != null)
                    streamWriter.Close();
            }
            return "";
        }

        public static string PostWebRequest(string url, string data, string contentType, Encoding encoding, out string msg)
        {
            string result = "";
            msg = "";
            Stream receiveStream = null;
            WebResponse hwrs = null;
            StreamWriter streamWriter = null;
            HttpWebRequest hwrq = null;
            try
            {
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((a, b, c, d) => true);
                    hwrq = WebRequest.Create(url) as HttpWebRequest;
                    hwrq.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    hwrq = WebRequest.Create(url) as HttpWebRequest;
                }

                if (contentType != "")
                {
                    hwrq.ContentType = contentType;
                }
                hwrq.Method = "POST";

                byte[] bytes = encoding.GetBytes(data);
                Stream stream = hwrq.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                hwrs = hwrq.GetResponse();
                receiveStream = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(receiveStream, encoding);
                result = sr.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (receiveStream != null)
                    receiveStream.Close();

                if (hwrs != null)
                    hwrs.Close();

                if (streamWriter != null)
                    streamWriter.Close();
            }
            return "";
        }
        #endregion

    }
}