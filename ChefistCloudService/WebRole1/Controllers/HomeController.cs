using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

            return View();
        }

        public ActionResult Session()
        {
            return View();
        }

        public ActionResult Browse()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Browse(string str)

        {
            
            return View();
        }


    }
    
}