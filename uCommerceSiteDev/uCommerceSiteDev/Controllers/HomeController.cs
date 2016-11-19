using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace uCommerceSiteDev.Controllers
{
    public class HomeController : RenderMvcController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("/Views/Home.cshtml");
        }
    }
}