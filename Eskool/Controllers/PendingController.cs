using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eskool.Code;
using Eskool.Models;
using Eskool.ViewModels;
using static Eskool.Controllers.AccountController;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;
using Newtonsoft.Json;
using System.Web.Services.Description;

namespace Eskool.Controllers
{
    public class PendingController : Controller
    {

        private DatabaseContext db;
        public PendingController(DatabaseContext databaseContext)
        {
            this.db = databaseContext;
        }

        // GET: Pending

        public ActionResult Index()
        {
            
            return View();
        }

      
    }
}