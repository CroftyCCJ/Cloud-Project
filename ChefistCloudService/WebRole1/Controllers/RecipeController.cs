using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class RecipeController : Controller
    {
        public List<Recipe> dummyRecipes = new List<Recipe>();

        // GET: Recipe
        [HttpGet]
        public ActionResult Index(int? id)
        {

            //QUERY: perform db search for id
            //query result should be stored in Recipe object "recipe"
            //Recipe recipe = ...

            //For debug purposes
            Recipe recipe = new Recipe(
                6546, 
                "Burrito Mexicano", 
                "dbkwolf", 
                "anchovies,minced beef, tortillas, salsa",
                "Throw everything in the tortilla", 
                EnumCuisine.Mexican);

            ViewBag.Recipe = recipe;
            
      
            return View();
        }

        public ActionResult Create()

        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}