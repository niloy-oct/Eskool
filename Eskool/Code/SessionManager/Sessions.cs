using System;
using System.Web;

/// <summary>
/// Summary description for Sessions
/// </summary>
/// 
namespace Eskool.Code.SessionManager
{
    public static class Sessions
    {
        //public Sessions()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        public static SessionInfo Name
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["Name"] != null)
                        return HttpContext.Current.Session["Name"] as SessionInfo;
                    else
                        return null;
                }
                catch (Exception)
                {

                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Name"] = value;
            }
        }


    }
}