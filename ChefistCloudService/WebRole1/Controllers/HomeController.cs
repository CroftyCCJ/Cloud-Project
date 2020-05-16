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
        private List<Recipe> recipeResults = new List<Recipe>();

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
        public ActionResult Browse(string search)

        {

           // ModelCuisine modelcuisine = new ModelCuisine { EnumCuisine = EnumCuisine.All };

            //perform db search based on search string

           
            ViewBag.ShowResult = "";

            return View();
        }

        [HttpPost]
        public ActionResult Browse(ModelCuisine num )
        {
            //if no cuisine is selected
            if (num.EnumCuisine == null)
            {
                // select all cuisines
                ViewBag.ShowResult = "No cuisine chosen"; //for debug purposes
            }
            else
            {
                Console.Write(num);
                EnumCuisine cuisine = (EnumCuisine)num.EnumCuisine;
                //perform filter actions with cuisine choice
                ViewBag.ShowResult = cuisine; //for debug purposes

            }

            return View();
        }

    }
    
}