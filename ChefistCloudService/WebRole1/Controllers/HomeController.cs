using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
       
        Recipe recipe1 = new Recipe(54, "Fruit Salad 1", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", EnumCuisine.MiddleEastern);
        Recipe recipe2 = new Recipe(55, "Fruit Salad 2", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", EnumCuisine.MiddleEastern);
        Recipe recipe3 = new Recipe(56, "Fruit Salad 3", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", EnumCuisine.MiddleEastern);

        List<Recipe> recipeResults = new List<Recipe>();

        protected void InitializeTest()
        {
            recipeResults.Add(recipe1);
            recipeResults.Add(recipe2);
            recipeResults.Add(recipe3);

        } 

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
           
            ViewBag.ShowResult = search;
            InitializeTest();
            //QUERY: perform db search based on search string
            //The result should be a list of Recipe objects (List<Recipe>) 
            //recipeResults = ...
            ViewBag.Recipes = recipeResults;

            return View();
        }

        [HttpPost]
        public ActionResult Browse(Recipe filter)
        {
            //if no cuisine is selected
            if (filter.Cuisine == null)
            {
                //QUERY: select all cuisines. 
                //The result should be a list of Recipe objects (List<Recipe>) 
                //recipeResults = ...
                ViewBag.ShowResult = "No cuisine chosen"; //for debug purposes
            }
            else
            {
                
                EnumCuisine cuisine = (EnumCuisine)filter.Cuisine;
                //QUERY:perform filter actions with cuisine choice
                //The result should be a list of Recipe objects (List<Recipe>) 
                //recipeResults = ...
                ViewBag.ShowResult = cuisine; //for debug purposes

            }

            InitializeTest(); //for debug purposes
            ViewBag.Recipes = recipeResults;
            return View();
        }

    }
    
}