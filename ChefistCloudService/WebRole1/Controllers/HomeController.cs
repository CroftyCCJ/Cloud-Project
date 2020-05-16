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


            //perform db search based on search string

           
            ViewBag.ShowResult = search;

            return View();
        }

        [HttpPost]
        public ActionResult Browse(Recipe filter)
        {
            //if no cuisine is selected
            if (filter.Cuisine == null)
            {
                // select all cuisines
                ViewBag.ShowResult = "No cuisine chosen"; //for debug purposes
            }
            else
            {
                
                EnumCuisine cuisine = (EnumCuisine)filter.Cuisine;
                //perform filter actions with cuisine choice
                ViewBag.ShowResult = cuisine; //for debug purposes

            }

            return View();
        }

    }
    
}