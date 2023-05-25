using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eskool.Helper
{

   
    public class MsgAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

            string errorMsg = MessageDisplay.GetMassage("ErrorMsg");
            string successMsg = MessageDisplay.GetMassage("SuccessMsg");
            if (!string.IsNullOrEmpty(errorMsg)) filterContext.Controller.ViewBag.ErrorMessage = errorMsg;
            if (!string.IsNullOrEmpty(successMsg)) filterContext.Controller.ViewBag.SuccessMessage = successMsg;
        }
    }
}