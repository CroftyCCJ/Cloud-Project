
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebRole1.App_Start;
using WebRole1.Models;
using System.Text.Json;
using WebRole1.Services;

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
            Recipe recipe;
            if (id.HasValue)
            {
               recipe = DBServices.GetRecipe((int)id);
               ViewBag.Recipe = recipe;

            }
            else
            {
                return RedirectToAction("Browse", "Home");
            }

            return View();
        }

             

        public ActionResult Create()
        {
            var userId = this.User?.Identity.GetUserId();
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

            
        }

        public async Task<ActionResult> ConfirmCreateAsync(string name, string imgurl, string description, string ingredients, string process, EnumCuisine cuisine)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue recipesQueue = queueClient.GetQueueReference("putrecipe");

            var userId = this.User?.Identity.GetUserId();

            Debug.WriteLine("USER ID IS =" + userId);

            string jsonRecipe = JsonSerializer.Serialize(new Recipe(0, name, userId, ingredients, process, DateTime.Today, cuisine, description, imgurl));

            new QueueService().AddMessageToQueue(recipesQueue, jsonRecipe);

            CloudQueue recipesOutQueue = queueClient.GetQueueReference("outrecipe");

            var recipeid = await new QueueService().GetMessageFromQueue(recipesOutQueue);

            return RedirectToAction("Index" , null,  new { id = recipeid });
        }

       
        [HttpPost]
        public ActionResult Edit(int recipeid)
        {
            Recipe recipe = DBServices.GetRecipe(recipeid);

            if (recipe.Owner.Equals(this.User?.Identity.GetUserId()))
            {
                ViewBag.Recipe = recipe;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

          
        }


        public async Task<ActionResult> ConfirmEditAsync(string name, string imgurl, string description, string ingredients, string process, EnumCuisine cuisine, int recipeid)
        {
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue recipesQueue = queueClient.GetQueueReference("updaterecipe");

            var userId = this.User?.Identity.GetUserId();

            Debug.WriteLine("USER ID IS =" + userId);

            string jsonRecipe = JsonSerializer.Serialize(new Recipe(recipeid, name, userId, ingredients, process, DateTime.Today, cuisine, description, imgurl));

            new QueueService().AddMessageToQueue(recipesQueue, jsonRecipe);

            CloudQueue recipesOutQueue = queueClient.GetQueueReference("outrecipe");

            await new QueueService().GetMessageFromQueue(recipesOutQueue);

            return RedirectToAction("Index", null, new { id = recipeid });
        }


        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int recipeid)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue recipesQueue = queueClient.GetQueueReference("deleterecipe");
            QueueService queueService = new QueueService();

            queueService.AddMessageToQueue(recipesQueue, recipeid.ToString());

            CloudQueue recipesOutQueue = queueClient.GetQueueReference("outrecipe");

            await queueService.GetMessageFromQueue(recipesOutQueue);

            return RedirectToAction("Profile", "User");
        }

      

    }
}