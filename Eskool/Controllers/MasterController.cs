using Eskool.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eskool.Code.SessionManager;

namespace Eskool.Controllers
{
    public class MasterController : Controller
    {


        private DatabaseContext context;

        public MasterController(DatabaseContext databaseContext)
        {
            this.context = databaseContext;
        }


        // GET: Master
        public ActionResult Index()
        {
            return View();
        }


        public  ActionResult Menue()
        {
            
            ViewBag.MenueList = context.Query($"SP_MARC_GetMenueList '{Sessions.Name.UserId}'").ToDynamicList(); ;
            ViewBag.SubMenueList = context.Query($"SP_MARC_GetSubMenueList '{Sessions.Name.UserId}'").ToDynamicList();

            return PartialView();
        }

        protected void LoadMenue()
        {
          
        }

        


    }
}