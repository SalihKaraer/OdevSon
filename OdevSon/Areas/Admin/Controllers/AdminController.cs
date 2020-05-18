using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdevSon.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: 
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}