using DocumentFormat.OpenXml.Drawing.Charts;
using Eskool.Code;
using Eskool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Eskool.Controllers
{
    public class ReportsController : Controller
    {
        private DatabaseContext context;
        public ReportsController(DatabaseContext databaseContext)
        {
            this.context = databaseContext;
        }
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

       
    }
}