using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;
using WebRole1.Services;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {

        Recipe recipe1 = new Recipe(54, "Fruit Salad 1", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", DateTime.Today, EnumCuisine.MiddleEastern, "some short description", "url");
        Recipe recipe2 = new Recipe(55, "Fruit Salad 2", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", DateTime.Today, EnumCuisine.MiddleEastern, "some short description", "url" );
        Recipe recipe3 = new Recipe(56, "Fruit Salad 3", "someuser", "banana, mandarine, apple", "chop everything and throw it together in a bowl", DateTime.Today, EnumCuisine.MiddleEastern, "some short description", "url");

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


        public ActionResult Browse()
        {

            List<Recipe> recipes = DBServices.GetAllRecipes();
            ViewBag.Recipes = recipes;
            return View();
        }

        [HttpGet]
        public ActionResult Browse(string search)

        {

            List<Recipe> recipes;
            if (String.IsNullOrEmpty(search))
            {
                recipes = DBServices.GetAllRecipes();
               
            }
            else
            {
               recipes = DBServices.SearchRecipes(search);
               
            }
          
            ViewBag.Recipes = recipes;

            return View();
        }

        [HttpPost]
        public ActionResult Browse(Recipe filter)
        {

            List<Recipe> recipes;

            //if no cuisine is selected
            if (filter.Cuisine == null)
            {

                recipes = DBServices.GetAllRecipes();

            }
            else
            {
                
                EnumCuisine cuisine = (EnumCuisine)filter.Cuisine;
                recipes = DBServices.FilterRecipes(cuisine.ToString());

            }

            ViewBag.Recipes = recipes;


            return View();
        }

    }
    
}