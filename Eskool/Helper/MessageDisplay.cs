using System;
using System.Linq;
using System.Web;

namespace Eskool.Helper
{
    public class MessageDisplay
    {

        public static void SetMassage(string Type, string message)
        {

            HttpCookie Cookie = new HttpCookie(Type);
            Cookie.Value = message;
            Cookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(Cookie);

        }

        public static void RemoveAllCookies()
        {
            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                if (key != "ASP.NET_SessionId")
                {
                    HttpCookie c = HttpContext.Current.Request.Cookies[key];
                    c.Expires = DateTime.Now.AddMonths(-1);
                    HttpContext.Current.Response.AppendCookie(c);
                }
            }

        }

        public static string GetMassage(string Type)
        {

            HttpCookie cookie = null;

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(Type))
            {
                cookie = HttpContext.Current.Request.Cookies[Type];
                HttpContext.Current.Response.Cookies[Type].Expires = DateTime.Now.AddDays(-1);
                return cookie.Value.ToString();

            }

            return "";


        }
    }
}