using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Sth.Utils
{

    /// <summary>
    /// SomeWebAppHelper
    /// </summary>
    public class SomeWebAppHelper
    {

        #region cookie
        /// <summary>
        /// add Cookie
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="values">Key，value</param>
        /// <param name="expires">Expires</param>
        public static void WriteCookie(string name, IDictionary<string, string> values, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(name);
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            foreach (var item in values)
            {
                if (cookie.Values.AllKeys.Contains(item.Key))
                {
                    cookie.Values.Set(item.Key, item.Value);
                }
                else
                {
                    cookie.Values.Add(item.Key, item.Value);
                }
            }
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// write cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <param name="strValue">Value</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// write cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <param name="strValue">Value</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// write cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <param name="strValue">Value</param>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// write cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <param name="strValue">Value</param>
        /// <param name="strValue">Expire</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// delete cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="domainName"></param>
        public static void DeleteCookie(string name, string domainName = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            HttpCookie cookie = new HttpCookie(name);
            if (!string.IsNullOrEmpty(domainName))
            {
                cookie.Domain = domainName;
            }
            // delete Cookie, set a old time
            cookie.Expires = new DateTime(1900, 1, 1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// read cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <returns>cookie</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value);
            return "";
        }

        /// <summary>
        /// read cookie
        /// </summary>
        /// <param name="strName">Name</param>
        /// <returns>cookie</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key]);

            return "";
        }

        /// <summary>
        /// read cookie
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>cookie</returns>
        public static SortedDictionary<string, string> GetCookieDic(string name)
        {
            var values = new SortedDictionary<string, string>();

            var cookie = HttpContext.Current.Request.Cookies.Get(name);
            if (cookie != null)
            {
                foreach (var key in cookie.Values.AllKeys)
                {
                    if (key != null)
                    {
                        values.Add(key, cookie.Values.Get(key));
                    }
                }
            }

            return values;
        }

        #endregion

        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }

        /// <summary>
        /// GetIPAddress
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string user_IP = string.Empty;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
                else
                {
                    user_IP = HttpContext.Current.Request.UserHostAddress;
                }
            }
            return user_IP;
        }
    }
}
