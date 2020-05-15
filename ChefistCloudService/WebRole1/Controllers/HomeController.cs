using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

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
            
            IEnumerable<SelectListItem> items = Enum.GetNames(typeof(Cuisine)).Select(name => new SelectListItem()
            {
                Text = name,
                Value = name
            });

            ViewBag.Cuisines = items;

            return View();
        }

        [HttpGet]
        public ActionResult Browse(string str)

        {
            
            return View();
        }


    }
    
}